namespace ConsoleApplication16
{
    using System;
    using System.Threading.Tasks;
    using Wintellect;

    class MeasureContinueWithVsAsyncVoid
    {
        public static long Run()
        {
            long ran = 0;
            const int Iterations = 1000 * 1000; // 100 * 1000 * 1000;

            CodeTimer.Time(true, "async void", Iterations, () =>
            {
                Task t = TestMethodFailureAsync();
                OnFaultAsync(t, "PUBLISH");
            });

            CodeTimer.Time(true, "ContinueWith", Iterations, () => { TestMethodFailureAsync().OnFault(FaultContinuationAction); });

            CodeTimer.Time(true, "async void hack", Iterations, () =>
            {
                Task t = TestMethodFailureAsync();
                OnFaultAsyncHack(t, "PUBLISH");
            });

            CodeTimer.TimeAsync(true, "success: async void", Iterations, () =>
            {
                Task t = TestMethodSuccessAsync();
                OnFaultAsync(t, "PUBLISH");
                return t;
            });

            CodeTimer.TimeAsync(true, "success: ContinueWith", Iterations, () =>
            {
                Task t = TestMethodSuccessAsync();
                t.OnFault(FaultContinuationAction);
                return t;
            });

            CodeTimer.TimeAsync(true, "success: async void hack", Iterations, () =>
            {
                Task t = TestMethodSuccessAsync();
                OnFaultAsyncHack(t, "PUBLISH");
                return t;
            });

            CodeTimer.TimeAsync(true, "sync succcess: async void", Iterations, () =>
            {
                Task t = TestMethodSyncSuccessAsync();
                OnFaultAsync(t, "PUBLISH");
                return t;
            });

            CodeTimer.TimeAsync(true, "sync succcess: ContinueWith", Iterations, () =>
            {
                Task t = TestMethodSyncSuccessAsync();
                t.OnFault(FaultContinuationAction);
                return t;
            });

            CodeTimer.TimeAsync(true, "sync succcess: async void hack", Iterations, () =>
            {
                Task t = TestMethodSyncSuccessAsync();
                OnFaultAsyncHack(t, "PUBLISH");
                return t;
            });

            return ran;
        }

        static async Task TestMethodFailureAsync()
        {
            await Task.Yield();
            throw new InvalidOperationException();
        }

        static async Task TestMethodSuccessAsync()
        {
            await Task.Yield();
        }

        static async Task TestMethodSyncSuccessAsync()
        {
        }

        static async void OnFaultAsync(Task t, string source)
        {
            try
            {
                await t;
            }
            catch (Exception ex)
            {
                var asInvalid = ex as InvalidOperationException;
                if (asInvalid != null)
                {
                    asInvalid.Source = source;
                }
            }
        }

        //private static readonly Action<Task> OnCompletedAction = new Action<Task>();

        static void OnFaultAsyncHack(Task t, string source)
        {
            if (t.IsCompleted)
            {
                if (t.IsFaulted)
                {
                    var ex = t.Exception.InnerException as InvalidOperationException;
                    if (ex != null)
                    {
                        ex.Source = source;
                    }
                }
                return;
            }

            t.GetAwaiter().UnsafeOnCompleted(() =>
            {
                if (t.IsFaulted)
                {
                    var ex = t.Exception.InnerException as InvalidOperationException;
                    if (ex != null)
                    {
                        ex.Source = source;
                    }
                }
            });
        }

        static readonly Action<Task> FaultContinuationAction = CreateFaultContinuationAction("PUBLISH");

        static Action<Task> CreateFaultContinuationAction(string source)
        {
            return t =>
            {
                var ex = t.Exception.InnerException as InvalidOperationException;
                if (ex != null)
                {
                    ex.Source = source;
                }
            };
        }
    }
}