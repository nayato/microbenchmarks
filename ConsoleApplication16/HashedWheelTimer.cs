namespace ConsoleApplication16
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    ///     A reusable low precision timer with approximate scheduling
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Timeout actions are executed on a ThreadPool thread supplied by the system. If you need to execute blocking
    ///         operations,
    ///         it is recommended that you start a new Task using a TaskScheduler.
    ///     </para>
    ///     Based on George Varghese and Tony Lauck's paper,
    ///     <a href="http://cseweb.ucsd.edu/users/varghese/PAPERS/twheel.ps.Z">
    ///         Hashed and Hierarchical Timing Wheels: data structures to efficiently implement a timer facility
    ///     </a>
    /// </remarks>
    sealed class HashedWheelTimer<T> : IDisposable
        where T : IRunnable
    {
        const int InitState = 0;
        const int ExpiredState = 1;
        const int CancelledState = 2;
        readonly Bucket[] wheel;
        readonly Timer timer;
        int isDisposed;
        readonly int tickDuration;

        readonly ConcurrentQueue<ValueTuple<TimeoutItem, long>> pendingToAdd = new ConcurrentQueue<ValueTuple<TimeoutItem, long>>();

        readonly ConcurrentQueue<TimeoutItem> cancelledTimeouts = new ConcurrentQueue<TimeoutItem>();

        /// <summary>
        ///     Represents the index of the next tick
        /// </summary>
        internal int Index { get; set; }

        public HashedWheelTimer(int tickDuration = 100, int ticksPerWheel = 512)
        {
            if (ticksPerWheel < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(ticksPerWheel));
            }
            if (tickDuration < 20)
            {
                throw new ArgumentOutOfRangeException(nameof(tickDuration),
                    "Timer resolution is system dependant, you should not use this class for tick durations lower than 20 ms");
            }
            //Create the wheel
            this.wheel = new Bucket[ticksPerWheel];
            for (int i = 0; i < ticksPerWheel; i++)
            {
                this.wheel[i] = new Bucket();
            }
            //Create the timer
            this.tickDuration = tickDuration;
            this.timer = new Timer(this.TimerTick, null, this.tickDuration, Timeout.Infinite);
        }

        void TimerTick(object state)
        {
            this.AddPending();
            this.RemoveCancelled();
            //go through the timeouts in the current bucket and subtract the round
            //or expire
            Bucket bucket = this.wheel[this.Index];

            for (int index = bucket.Count - 1; index >= 0; index--)
            {
                TimeoutItem timeout = bucket[index];
                if (!timeout.IsAssigned)
                {
                    continue;
                }

                if (timeout.Rounds == 0)
                {
                    timeout.Expire();
                    bucket.RemoveAt(index, timeout);
                }
                else if (timeout.IsCancelled)
                {
                    bucket.RemoveAt(index, timeout);
                }
                else
                {
                    timeout.Rounds--;
                }
            }
            bucket.Compact();
            //while (timeout != null)
            //{
            //    if (timeout.Rounds == 0)
            //    {
            //        timeout.Expire();
            //        bucket.Remove(timeout);
            //    }
            //    else if (timeout.IsCancelled)
            //    {
            //        bucket.Remove(timeout);
            //    }
            //    else
            //    {
            //        timeout.Rounds--;
            //    }
            //    timeout = timeout.Next;
            //}
            //Setup the next tick
            this.Index = (this.Index + 1) % this.wheel.Length;
            try
            {
                this.timer.Change(this.tickDuration, Timeout.Infinite);
            }
            catch (ObjectDisposedException)
            {
                //the _timer might already have been disposed of
            }
        }

        /// <summary>
        ///     Releases the underlying timer instance.
        /// </summary>
        public void Dispose()
        {
            //Allow multiple calls to dispose
            if (Interlocked.Increment(ref this.isDisposed) != 1)
            {
                return;
            }
            this.timer.Dispose();
        }

        /// <summary>
        ///     Adds a new action to be executed with a delay
        /// </summary>
        /// <param name="action">
        ///     Action to be executed. Consider that the action is going to be invoked in an IO thread.
        /// </param>
        /// <param name="delay">Delay in milliseconds</param>
        public TimeoutItem NewTimeout(T action, long delay)
        {
            if (delay < this.tickDuration)
            {
                delay = this.tickDuration;
            }
            var item = new TimeoutItem(this, action);
            this.pendingToAdd.Enqueue(ValueTuple.Create(item, delay));
            return item;
        }

        /// <summary>
        ///     Adds the timeouts to each bucket
        /// </summary>
        void AddPending()
        {
            ValueTuple<TimeoutItem, long> pending;
            while (this.pendingToAdd.TryDequeue(out pending))
            {
                this.AddTimeout(pending.Item1, pending.Item2);
            }
        }

        void AddTimeout(TimeoutItem item, long delay)
        {
            if (item.IsCancelled)
            {
                //It has been cancelled since then
                return;
            }
            //delay expressed in tickets
            long ticksDelay = delay / this.tickDuration +
                //As index is for the current tick and it was added since the last tick
                this.Index - 1;
            int bucketIndex = Convert.ToInt32(ticksDelay % this.wheel.Length);
            long rounds = ticksDelay / this.wheel.Length;
            if (rounds > 0 && bucketIndex < this.Index)
            {
                rounds--;
            }
            item.Rounds = rounds;
            this.wheel[bucketIndex].Add(item);
        }

        /// <summary>
        ///     Removes all cancelled timeouts from the buckets
        /// </summary>
        void RemoveCancelled()
        {
            TimeoutItem timeout;
            while (this.cancelledTimeouts.TryDequeue(out timeout))
            {
                timeout.Bucket.Remove(timeout);
            }
        }

        /// <summary>
        ///     Linked list of Timeouts to allow easy removal of HashedWheelTimeouts in the middle.
        ///     Methods are not thread safe.
        /// </summary>
        internal sealed class Bucket : List<TimeoutItem>
        {
            public Bucket()
                : base(4096)
            {
            }

            internal new void Add(TimeoutItem item)
            {
                item.Bucket = this;
                base.Add(item);
            }

            internal void RemoveAt(int index, TimeoutItem item)
            {
                this[index] = default(TimeoutItem); // soft delete
                //item.Dispose();
            }

            public void Compact()
            {
                // todo: chunk copy strategy
                int shift = 0;
                for (int i = 0; i < this.Count; i++)
                {
                    TimeoutItem item = this[i];
                    if (item.Bucket == null)
                    {
                        shift++;
                    }
                    else
                    {
                        if (shift > 0)
                        {
                            this[i - shift] = item;
                        }
                    }
                }
                if (shift > 0)
                {
                    this.RemoveRange(this.Count - shift, shift);
                }
            }
        }

        internal struct TimeoutItem
        {
            //Use fields instead of properties as micro optimization
            //More 100 thousand timeout items could be created and GC collected each second
            readonly T action;
            int state;
            readonly HashedWheelTimer<T> timer;

            internal long Rounds;

            internal Bucket Bucket;

            public bool IsCancelled => this.state == CancelledState;

            public bool IsAssigned => this.Bucket != null;

            internal TimeoutItem(HashedWheelTimer<T> timer, T action)
            {
                this.action = action;
                this.timer = timer;
                this.state = InitState;
                this.Rounds = 0;
                this.Bucket = null;
            }

            public bool Cancel()
            {
                if (Interlocked.CompareExchange(ref this.state, CancelledState, InitState) == InitState)
                {
                    if (this.IsAssigned)
                    {
                        //Mark this to be removed from the bucket on the next tick
                        this.timer.cancelledTimeouts.Enqueue(this);
                    }
                    return true;
                }
                return false;
            }

            /// <summary>
            ///     Execute the timeout action
            /// </summary>
            public void Expire()
            {
                if (Interlocked.CompareExchange(ref this.state, ExpiredState, InitState) != InitState)
                {
                    //Its already cancelled
                    return;
                }
                this.action.Run();
            }
        }
    }

    interface IRunnable
    {
        void Run();
    }
}