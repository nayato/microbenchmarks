namespace ConsoleApplication16
{
    using System.Threading.Tasks;
    using Wintellect;

    class MeasureVolatileVsPlain
    {
        volatile Reference abc;
        volatile TaskCompletionSource<int> promise;
        volatile int value;

        public long Run()
        {
            long ran = 0;
            const int Iterations = 100 * 1000 * 1000;
            this.abc = new Reference();
            this.value = 0;

            CodeTimer.Time(true, "2 volatile", Iterations, () => { ran += this.promise == null ? this.value : 1; });

            CodeTimer.Time(true, "1 volatile reference", Iterations, () => { ran += this.abc.GetValue(); });

            return ran;
        }

        sealed class Reference
        {
            TaskCompletionSource<int> promise;
            readonly int value = 0;

            public int GetValue() => this.promise == null ? this.value : 1;
        }
    }
}