namespace ConsoleApplication16
{
    using System;
    using System.Threading.Tasks;
    using Wintellect;

    class MeasureContinueWithVsAsyncVoidComplex
    {
        const int Iterations = 1000 * 1000; // 100 * 1000 * 1000;

        public static long Run()
        {
            long ran = 0;

            FailAsync();

            FailCW();

            FailHack();

            FailHack2();

            SuccessAsync();

            SuccessCW();

            SuccessHack();

            SuccessHack2();

            SyncAsync();

            SyncCW();

            SyncHack();

            SyncHack2();

            TcsAsync();

            TcsCW();

            TcsHack();

            TcsHack2();

            return ran;
        }

        static void FailAsync()
        {
            CodeTimer.Time(true, "async void", Iterations, () =>
            {
                Task t = TestMethodFailureAsync();
                OnFaultOrSuccessAsync(t, SuccessAction, "PUBLISH");
            });
        }

        static void FailCW()
        {
            CodeTimer.Time(true, "ContinueWith", Iterations,
                () => { TestMethodFailureAsync().OnFaultOrSuccess(FaultOrSuccessContinuationAction); });
        }

        static void FailHack()
        {
            CodeTimer.Time(true, "async void hack", Iterations, () =>
            {
                Task t = TestMethodFailureAsync();
                OnFaultOrSuccessAsyncHack(t, SuccessAction, "PUBLISH");
            });
        }

        static void FailHack2()
        {
            CodeTimer.Time(true, "async void hack2", Iterations, () =>
            {
                Task t = TestMethodFailureAsync();
                OnFaultOrSuccessAsyncHack2(t, FaultOrSuccessContinuationAction);
            });
        }

        static void SuccessAsync()
        {
            CodeTimer.TimeAsync(true, "success: async void", Iterations, () =>
            {
                Task t = TestMethodSuccessAsync();
                OnFaultOrSuccessAsync(t, SuccessAction, "PUBLISH");
                return t;
            });
        }

        static void SuccessCW()
        {
            CodeTimer.TimeAsync(true, "success: ContinueWith", Iterations, () =>
            {
                Task t = TestMethodSuccessAsync();
                t.OnFaultOrSuccess(FaultOrSuccessContinuationAction);
                return t;
            });
        }

        static void SuccessHack()
        {
            CodeTimer.TimeAsync(true, "success: async void hack", Iterations, () =>
            {
                Task t = TestMethodSuccessAsync();
                OnFaultOrSuccessAsyncHack(t, SuccessAction, "PUBLISH");
                return t;
            });
        }

        static void SuccessHack2()
        {
            CodeTimer.TimeAsync(true, "success: async void hack2", Iterations, () =>
            {
                Task t = TestMethodSuccessAsync();
                OnFaultOrSuccessAsyncHack2(t, FaultOrSuccessContinuationAction);
                return t;
            });
        }

        static void SyncAsync()
        {
            CodeTimer.TimeAsync(true, "sync succcess: async void", Iterations, () =>
            {
                Task t = TestMethodSyncSuccessAsync();
                OnFaultOrSuccessAsync(t, SuccessAction, "PUBLISH");
                return t;
            });
        }

        static void SyncCW()
        {
            CodeTimer.TimeAsync(true, "ContinueWith", Iterations, () =>
            {
                Task t = TestMethodSyncSuccessAsync();
                t.OnFaultOrSuccess(FaultOrSuccessContinuationAction);
                return t;
            });
        }

        static void SyncHack()
        {
            CodeTimer.TimeAsync(true, "sync succcess: async void hack", Iterations, () =>
            {
                Task t = TestMethodSyncSuccessAsync();
                OnFaultOrSuccessAsyncHack(t, SuccessAction, "PUBLISH");
                return t;
            });
        }

        static void SyncHack2()
        {
            CodeTimer.TimeAsync(true, "sync success: async void hack2", Iterations, () =>
            {
                Task t = TestMethodSyncSuccessAsync();
                OnFaultOrSuccessAsyncHack2(t, FaultOrSuccessContinuationAction);
                return t;
            });
        }

        static void TcsAsync()
        {
            CodeTimer.TimeAsync(true, "sync succcess: async void", Iterations, () =>
            {
                var tcs = new TaskCompletionSource<int>();
                tcs.TrySetResult(0);
                OnFaultOrSuccessAsync(tcs.Task, SuccessAction, "PUBLISH");
                return tcs.Task;
            });
        }

        static void TcsCW()
        {
            CodeTimer.TimeAsync(true, "ContinueWith", Iterations, () =>
            {
                var tcs = new TaskCompletionSource<int>();
                tcs.TrySetResult(0);
                tcs.Task.OnFaultOrSuccess(FaultOrSuccessContinuationAction);
                return tcs.Task;
            });
        }

        static void TcsHack()
        {
            CodeTimer.TimeAsync(true, "sync succcess: async void hack", Iterations, () =>
            {
                var tcs = new TaskCompletionSource<int>();
                tcs.TrySetResult(0);
                OnFaultOrSuccessAsyncHack(tcs.Task, SuccessAction, "PUBLISH");
                return tcs.Task;
            });
        }

        static void TcsHack2()
        {
            CodeTimer.TimeAsync(true, "sync success: async void hack2", Iterations, () =>
            {
                var tcs = new TaskCompletionSource<int>();
                tcs.TrySetResult(0);
                OnFaultOrSuccessAsyncHack2(tcs.Task, FaultOrSuccessContinuationAction);
                return tcs.Task;
            });
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

        static readonly Action SuccessAction = OnSuccess;
        static readonly Action<Task> SuccessTaskAction = t => OnSuccess();

        static void OnSuccess()
        {
        }

        static async void OnFaultOrSuccessAsync(Task t, Action successAction, string source)
        {
            try
            {
                await t;
                successAction();
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

        static void OnFaultOrSuccessAsyncHack2(Task t, Action<Task> action)
        {
            if (t.IsCompleted)
            {
                action(t);
                return;
            }

            GoHack2Async(t, action);
        }

        static void GoHack2Async(Task t, Action<Task> action)
        {
            t.GetAwaiter().UnsafeOnCompleted(() => action(t));
        }

        static void OnFaultOrSuccessAsyncHack(Task t, Action successAction, string source)
        {
            TaskStatus status = t.Status;
            if (status == TaskStatus.Faulted)
            {
                var ex = t.Exception.InnerException as InvalidOperationException;
                if (ex != null)
                {
                    ex.Source = source;
                }
                return;
            }
            else if (status == TaskStatus.RanToCompletion)
            {
                successAction();
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
                else
                {
                    successAction();
                }
            });
        }

        static readonly Action<Task> FaultOrSuccessContinuationAction = CreateSuccessOrFaultContinuationAction(SuccessAction, "PUBLISH");

        static readonly Action<Task> FaultContinuationAction = CreateFaultContinuationAction("PUBLISH");

        static Action<Task> CreateSuccessOrFaultContinuationAction(Action successAction, string source)
        {
            return t =>
            {
                if (t.IsFaulted)
                {
                    var ex = t.Exception.InnerException as InvalidOperationException;
                    if (ex != null)
                    {
                        ex.Source = source;
                    }
                }
                else
                {
                    successAction();
                }
            };
        }

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