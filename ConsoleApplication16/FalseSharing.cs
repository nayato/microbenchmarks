namespace ConsoleApplication16
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    public sealed class FalseSharing
    {
        public static readonly int ThreadCount = Environment.ProcessorCount; // change
        public static readonly long Iterations = 500L * 1000L * 1000L;
        readonly int arrayIndex;

        static readonly VolatileInt[] Ints = new VolatileInt[ThreadCount];

        static FalseSharing()
        {
            for (int i = 0; i < Ints.Length; i++)
            {
                Ints[i] = new VolatileInt();
            }
        }

        public FalseSharing(int arrayIndex)
        {
            this.arrayIndex = arrayIndex;
        }

        public static void Run()
        {
            Stopwatch sw = Stopwatch.StartNew();
            runTest();
            Console.WriteLine("duration = " + (sw.Elapsed));
        }

        static void runTest()
        {
            var threads = new Thread[ThreadCount];

            for (int i = 0; i < threads.Length; i++)
            {
                var falseSharing = new FalseSharing(i);
                threads[i] = new Thread(s => falseSharing.run());
            }

            foreach (Thread t in threads)
            {
                t.Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }

        public void run()
        {
            int i = (int)Iterations + 1;
            while (0 != --i)
            {
                Ints[this.arrayIndex].value = i;
            }
        }

        public class VolatileInt
        {
            public volatile int value;
            //public long p1, p2, p3, p4, p5, p6, p7; // comment out
        }
    }
}