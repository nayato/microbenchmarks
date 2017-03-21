namespace ConsoleApplication16
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Wintellect;

    class MeasureConditionalWeakTablePattern
    {
        public long Run()
        {
            var map = new ConditionalWeakTable<Task, Task>();
            long ran = 0;
            const int Iterations = 1 * 1000 * 1000;
            var t = new Task(() => { });

            CodeTimer.Time(true, "concat", Iterations, () =>
            {
                map.GetValue(t, task => task.ContinueWith(t1 =>
                {
                    Exception ignored = t1.Exception;
                }));
            });

            return ran;
        }
    }
}