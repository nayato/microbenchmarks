namespace ConsoleApplication16
{
    using System;
    using System.Threading.Tasks;
    using Wintellect;

    class MeasureAsyncNestedThrowVsTry
    {
        public static long Run()
        {
            long ran = 0;
            const int depth = 5;
            const int Iterations = 100 * 1000; // 100 * 1000 * 1000;

            CodeTimer.TimeAsync(true, "try", Iterations, async () =>
            {
                try
                {
                    Try<bool> result = await NestedTryFailureAsync(depth);
                    if (!result.Success)
                    {
                        ran++;
                    }
                }
                catch (Exception)
                {
                    ran++;
                }
            });

            CodeTimer.TimeAsync(true, "exception no stack", Iterations, async () =>
            {
                try
                {
                    await NestedExceptionNoTraceFailureAsync(depth);
                }
                catch (Exception)
                {
                    ran++;
                }
            });

            CodeTimer.TimeAsync(true, "exception", Iterations, async () =>
            {
                try
                {
                    await NestedExceptionFailureAsync(depth);
                }
                catch (Exception)
                {
                    ran++;
                }
            });

            return ran;
        }

        static async Task<bool> FailAsync()
        {
            //await Task.Yield();
            throw new Exception("ouch");
        }

        static async Task<Try<bool>> NestedTryFailureAsync(int countdown)
        {
            try
            {
                if (countdown == 0)
                {
                    return await FailAsync();
                }
                return await NestedTryFailureAsync(--countdown);
            }
            catch (Exception ex)
            {
                return Try<bool>.Failure(ex);
            }
        }

        static async Task<bool> NestedExceptionFailureAsync(int countdown)
        {
            if (countdown == 0)
            {
                return await FailAsync();
            }
            return await NestedExceptionFailureAsync(--countdown);
        }

        static Task<bool> NestedExceptionNoTraceFailureAsync(int countdown)
        {
            try
            {
                if (countdown == 0)
                {
                    return FailAsync();
                }
                return NestedExceptionNoTraceFailureAsync(--countdown).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        return Task.FromException<bool>(t.Exception);
                    }
                    return Task.FromResult(t.Result);
                }).Unwrap();
            }
            catch (Exception ex)
            {
                return Task.FromException<bool>(ex);
            }
        }
    }
}