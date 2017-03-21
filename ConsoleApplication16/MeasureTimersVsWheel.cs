namespace ConsoleApplication16
{
    using System;
    using System.Threading.Tasks;
    using Wintellect;

    class MeasureTimersVsWheel
    {
        public static long Run()
        {
            long ran = 0;
            const int Iterations = 350 * 1000; // 100 * 1000 * 1000;

            CodeTimer.TimeAsync(true, "direct", 4, async () =>
            {
                int threads = Environment.ProcessorCount;
                int len = Iterations / threads;
                var ttasks = new Task[threads];
                for (int ti = 0; ti < threads; ti++)
                {
                    ttasks[ti] = Task.Factory.StartNew(
                        async () =>
                        {
                            var tasks = new Task[len];
                            for (int i = 0; i < len; i++)
                            {
                                tasks[i] = TestAsync().TryWithTimeout(TimeSpan.FromMilliseconds(100));
                            }
                            await Task.WhenAll(tasks);
                        },
                        TaskCreationOptions.LongRunning);
                }
                await Task.WhenAll(ttasks);
            });

            CodeTimer.TimeAsync(true, "timer wheel", 4, async () =>
            {
                int threads = Environment.ProcessorCount;
                int len = Iterations / threads;
                var ttasks = new Task[threads];
                for (int ti = 0; ti < threads; ti++)
                {
                    ttasks[ti] = Task.Factory.StartNew(
                        async () =>
                        {
                            var tasks = new Task[len];
                            for (int i = 0; i < len; i++)
                            {
                                tasks[i] = TestAsync().TryWithTimeoutWheel(100);
                            }
                            await Task.WhenAll(tasks);
                        },
                        TaskCreationOptions.LongRunning);
                }
                await Task.WhenAll(ttasks);
            });

            return ran;
        }

        static async Task<int> TestAsync()
        {
            await Task.Yield();
            return 1;
        }
    }
}