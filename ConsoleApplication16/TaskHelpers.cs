namespace ConsoleApplication16
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Nito.AsyncEx;

    static class TaskHelpers
    {
        public static Task FromException(Exception ex) => FromException<int>(ex);

        static readonly HashedWheelTimer<TimeoutScope> Wheel = new HashedWheelTimer<TimeoutScope>();

        struct TimeoutScope : IRunnable
        {
            readonly object promise;
            readonly Action<object> cancel;

            public TimeoutScope(object promise, Action<object> cancel)
            {
                this.promise = promise;
                this.cancel = cancel;
            }

            public void Run() => this.cancel(this.promise);
        }

        public static Task<T> FromException<T>(Exception ex)
        {
            var promise = new TaskCompletionSource<T>();
            promise.TrySetException(ex);
            return promise.Task;
        }

        public static Task<Option<T>> TryWithTimeoutWheel<T>(this Task<T> task, long timeoutInMs)
        {
            //timeout = NormalizeTimeout(timeout);

            if (timeoutInMs == -1)
            {
                return task.ContinueWith(t => Option.Some(t.Result));
            }

            switch (task.Status)
            {
                case TaskStatus.RanToCompletion:
                    return Task.FromResult(Option.Some(task.Result));
                case TaskStatus.Canceled:
                    return TaskConstants<Option<T>>.Canceled;
                case TaskStatus.Faulted:
                    return FromException<Option<T>>(task.Exception);
                default:
                    var promise = new TaskCompletionSource<Option<T>>();
                    var scope = new TimeoutScope(promise, p => ((TaskCompletionSource<Option<T>>)p).TrySetResult(Option.None<T>()));
                    Wheel.NewTimeout(scope, timeoutInMs);
                    task.ContinueWith(
                        (t, p) =>
                        {
                            var ps = (TaskCompletionSource<Option<T>>)p;
                            switch (t.Status)
                            {
                                case TaskStatus.RanToCompletion:
                                    ps.TrySetResult(Option.Some(t.Result));
                                    break;
                                case TaskStatus.Canceled:
                                    ps.TrySetCanceled();
                                    break;
                                case TaskStatus.Faulted:
                                    ps.TrySetException(t.Exception);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        },
                        promise);
                    return promise.Task;
            }
        }

        public static Task<Option<T>> TryWithTimeout<T>(this Task<T> task, TimeSpan timeout)
        {
            //timeout = NormalizeTimeout(timeout);

            if (timeout == Timeout.InfiniteTimeSpan)
            {
                return task.ContinueWith(t => Option.Some(t.Result));
            }

            switch (task.Status)
            {
                case TaskStatus.RanToCompletion:
                    return Task.FromResult(Option.Some(task.Result));
                case TaskStatus.Canceled:
                    return TaskConstants<Option<T>>.Canceled;
                case TaskStatus.Faulted:
                    return FromException<Option<T>>(task.Exception);
                default:
                    return WithTimeoutInternal(task, timeout);
            }
        }

        static async Task<Option<T>> WithTimeoutInternal<T>(Task<T> task, TimeSpan timeout)
        {
            using (var cts = new CancellationTokenSource())
            {
                if (task == await Task.WhenAny(task, Task.Delay(timeout, cts.Token)))
                {
                    cts.Cancel();
                    await task;
                    return Option.Some(task.Result);
                }
            }

            return Option.None<T>();
        }

        static TimeSpan NormalizeTimeout(TimeSpan timeout)
        {
            if (timeout == TimeSpan.MaxValue)
            {
                return Timeout.InfiniteTimeSpan;
            }

            if (timeout.TotalMilliseconds > int.MaxValue)
            {
                return TimeSpan.FromMilliseconds(int.MaxValue);
            }

            if (timeout < TimeSpan.Zero)
            {
                return TimeSpan.Zero;
            }

            return timeout;
        }
    }
}