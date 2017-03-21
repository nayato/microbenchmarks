namespace ConsoleApplication16
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
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
        readonly Bucket[] _wheel;
        readonly Timer _timer;
        int _isDisposed;
        readonly int _tickDuration;

        readonly ConcurrentQueue<ValueTuple<TimeoutItem, long>> _pendingToAdd =
            new ConcurrentQueue<ValueTuple<TimeoutItem, long>>();

        readonly ConcurrentQueue<TimeoutItem> _cancelledTimeouts = new ConcurrentQueue<TimeoutItem>();

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
            this._wheel = new Bucket[ticksPerWheel];
            for (int i = 0; i < ticksPerWheel; i++)
            {
                this._wheel[i] = new Bucket();
            }
            //Create the timer
            this._tickDuration = tickDuration;
            this._timer = new Timer(this.TimerTick, null, this._tickDuration, Timeout.Infinite);
        }

        void TimerTick(object state)
        {
            this.AddPending();
            this.RemoveCancelled();
            //go through the timeouts in the current bucket and subtract the round
            //or expire
            Bucket bucket = this._wheel[this.Index];

            for (int index = bucket.Count - 1; index >= 0; index--)
            {
                TimeoutItem timeout = bucket[index];
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
            this.Index = (this.Index + 1) % this._wheel.Length;
            try
            {
                this._timer.Change(this._tickDuration, Timeout.Infinite);
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
            if (Interlocked.Increment(ref this._isDisposed) != 1)
            {
                return;
            }
            this._timer.Dispose();
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
            if (delay < this._tickDuration)
            {
                delay = this._tickDuration;
            }
            var item = new TimeoutItem(this, action);
            this._pendingToAdd.Enqueue(ValueTuple.Create(item, delay));
            return item;
        }

        /// <summary>
        ///     Adds the timeouts to each bucket
        /// </summary>
        void AddPending()
        {
            ValueTuple<TimeoutItem, long> pending;
            while (this._pendingToAdd.TryDequeue(out pending))
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
            long ticksDelay = delay / this._tickDuration +
                //As index is for the current tick and it was added since the last tick
                this.Index - 1;
            int bucketIndex = Convert.ToInt32(ticksDelay % this._wheel.Length);
            long rounds = ticksDelay / this._wheel.Length;
            if (rounds > 0 && bucketIndex < this.Index)
            {
                rounds--;
            }
            item.Rounds = rounds;
            this._wheel[bucketIndex].Add(item);
        }

        /// <summary>
        ///     Removes all cancelled timeouts from the buckets
        /// </summary>
        void RemoveCancelled()
        {
            TimeoutItem timeout;
            while (this._cancelledTimeouts.TryDequeue(out timeout))
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
                : base(128)
            {
                
            }

            internal new void Add(TimeoutItem item)
            {
                item.Bucket = this;
                base.Add(item);
            }

            internal void RemoveAt(int index, TimeoutItem item)
            {
                this[index] = null; // soft delete
                item.Dispose();
            }

            public void Compact()
            {
                int shift = 0;
                for (int i = 0; i < this.Count; i++)
                {
                    TimeoutItem item = this[i];
                    if (item == null)
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

        internal sealed class TimeoutItem
        {
            //Use fields instead of properties as micro optimization
            //More 100 thousand timeout items could be created and GC collected each second
            T _action;
            int _state = InitState;
            HashedWheelTimer<T> _timer;

            internal long Rounds;

            internal Bucket Bucket;

            public bool IsCancelled => this._state == CancelledState;

            internal TimeoutItem(HashedWheelTimer<T> timer, T action)
            {
                this._action = action;
                this._timer = timer;
            }

            public bool Cancel()
            {
                if (Interlocked.CompareExchange(ref this._state, CancelledState, InitState) == InitState)
                {
                    if (this.Bucket != null)
                    {
                        //Mark this to be removed from the bucket on the next tick
                        this._timer._cancelledTimeouts.Enqueue(this);
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
                if (Interlocked.CompareExchange(ref this._state, ExpiredState, InitState) != InitState)
                {
                    //Its already cancelled
                    return;
                }
                this._action.Run();
            }

            public void Dispose()
            {
                this.DoDispose();
                GC.SuppressFinalize(this);
            }

            void DoDispose()
            {
                //Break references
                this.Bucket = null;
                this._action = default(T);
                this._timer = null;
            }

            ~TimeoutItem()
            {
                this.DoDispose();
            }
        }
    }

    interface IRunnable
    {
        void Run();
    }

    public static class ValueTuple
    {
        public static ValueTuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2) => new ValueTuple<T1, T2>(item1, item2);

        public static ValueTuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
            => new ValueTuple<T1, T2, T3>(item1, item2, item3);

        public static ValueTuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
            => new ValueTuple<T1, T2, T3, T4>(item1, item2, item3, item4);
    }

    public struct ValueTuple<T1, T2> : IEquatable<ValueTuple<T1, T2>>
    {
        static readonly EqualityComparer<T1> Comparer1 = EqualityComparer<T1>.Default;
        static readonly EqualityComparer<T2> Comparer2 = EqualityComparer<T2>.Default;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T1 Item1;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T2 Item2;

        public ValueTuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public bool Equals(ValueTuple<T1, T2> other)
        {
            return Comparer1.Equals(this.Item1, other.Item1)
                && Comparer2.Equals(this.Item2, other.Item2);
        }

        public override bool Equals(object obj)
        {
            if (obj is ValueTuple<T1, T2>)
            {
                var other = (ValueTuple<T1, T2>)obj;
                return this.Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
            => HashCode.CombineHashCodes(Comparer1.GetHashCode(this.Item1), Comparer2.GetHashCode(this.Item2));

        public static bool operator ==(ValueTuple<T1, T2> left, ValueTuple<T1, T2> right) => left.Equals(right);

        public static bool operator !=(ValueTuple<T1, T2> left, ValueTuple<T1, T2> right) => !left.Equals(right);
    }

    [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
        Justification = "It is a helper struct")]
    public struct ValueTuple<T1, T2, T3> : IEquatable<ValueTuple<T1, T2, T3>>
    {
        static readonly EqualityComparer<T1> Comparer1 = EqualityComparer<T1>.Default;
        static readonly EqualityComparer<T2> Comparer2 = EqualityComparer<T2>.Default;
        static readonly EqualityComparer<T3> Comparer3 = EqualityComparer<T3>.Default;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T1 Item1;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T2 Item2;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T3 Item3;

        public ValueTuple(T1 item1, T2 item2, T3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public bool Equals(ValueTuple<T1, T2, T3> other)
        {
            return Comparer1.Equals(this.Item1, other.Item1)
                && Comparer2.Equals(this.Item2, other.Item2)
                && Comparer3.Equals(this.Item3, other.Item3);
        }

        public override bool Equals(object obj)
        {
            if (obj is ValueTuple<T1, T2, T3>)
            {
                var other = (ValueTuple<T1, T2, T3>)obj;
                return this.Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.CombineHashCodes(
                HashCode.CombineHashCodes(
                    Comparer1.GetHashCode(this.Item1),
                    Comparer2.GetHashCode(this.Item2)),
                Comparer3.GetHashCode(this.Item3));
        }

        public static bool operator ==(ValueTuple<T1, T2, T3> left, ValueTuple<T1, T2, T3> right) => left.Equals(right);

        public static bool operator !=(ValueTuple<T1, T2, T3> left, ValueTuple<T1, T2, T3> right) => !left.Equals(right);
    }

    [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
        Justification = "It is a helper struct")]
    public struct ValueTuple<T1, T2, T3, T4> : IEquatable<ValueTuple<T1, T2, T3, T4>>
    {
        static readonly EqualityComparer<T1> Comparer1 = EqualityComparer<T1>.Default;
        static readonly EqualityComparer<T2> Comparer2 = EqualityComparer<T2>.Default;
        static readonly EqualityComparer<T3> Comparer3 = EqualityComparer<T3>.Default;
        static readonly EqualityComparer<T4> Comparer4 = EqualityComparer<T4>.Default;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T1 Item1;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T2 Item2;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T3 Item3;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T4 Item4;

        public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
            this.Item4 = item4;
        }

        public bool Equals(ValueTuple<T1, T2, T3, T4> other)
        {
            return Comparer1.Equals(this.Item1, other.Item1)
                && Comparer2.Equals(this.Item2, other.Item2)
                && Comparer3.Equals(this.Item3, other.Item3)
                && Comparer4.Equals(this.Item4, other.Item4);
        }

        public override bool Equals(object obj)
        {
            if (obj is ValueTuple<T1, T2, T3, T4>)
            {
                var other = (ValueTuple<T1, T2, T3, T4>)obj;
                return this.Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.CombineHashCodes(
                HashCode.CombineHashCodes(
                    Comparer1.GetHashCode(this.Item1),
                    Comparer2.GetHashCode(this.Item2)),
                HashCode.CombineHashCodes(
                    Comparer3.GetHashCode(this.Item3),
                    Comparer4.GetHashCode(this.Item4)));
        }

        public static bool operator ==(ValueTuple<T1, T2, T3, T4> left, ValueTuple<T1, T2, T3, T4> right)
            => left.Equals(right);

        public static bool operator !=(ValueTuple<T1, T2, T3, T4> left, ValueTuple<T1, T2, T3, T4> right)
            => !left.Equals(right);
    }

    static class HashCode
    {
        public static int CombineHashCodes(int h1, int h2)
        {
            return ((h1 << 5) + h1) ^ h2;
        }

        public static int CombineHashCodes(int h1, int h2, int h3)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2), h3);
        }

        public static int CombineHashCodes(int h1, int h2, int h3, int h4)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2), CombineHashCodes(h3, h4));
        }

        public static int SafeGet<T>(T value)
            where T : class
        {
            if (value != null)
            {
                return value.GetHashCode();
            }

            return 0;
        }

        ////public static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5)
        ////{
        ////    return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), h5);
        ////}

        ////public static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6)
        ////{
        ////    return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6));
        ////}

        public static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7));
        }

        ////public static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8)
        ////{
        ////    return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7, h8));
        ////}
    }
}