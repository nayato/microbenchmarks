namespace ConsoleApplication16
{
    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using Wintellect;

    class MeasureBufferPoolBenefits
    {
        public static long Run()
        {
            const int iterations = 10000;
            const int bufferSize = 16 * 1024;

            var from = new MemoryStream(new byte[100 * 1024]);

            var to = new MemoryStream(new byte[100 * 1024]);

            CodeTimer.Time("buffer every time",
                iterations,
                () => { @from.CopyTo(to, bufferSize); });

            CodeTimer.Time("buffer every time, self",
                iterations,
                () =>
                {
                    var buffer = new byte[bufferSize];
                    int count;
                    while ((count = @from.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        to.Write(buffer, 0, count);
                    }
                });

            ConcurrentQueue<byte[]> bufferPool = null;

            CodeTimer.Time("buffer pool creation",
                1,
                () =>
                {
                    var pool = new byte[2000][];
                    for (int i = 0; i < pool.Length; i++)
                    {
                        pool[i] = new byte[bufferSize];
                    }
                    bufferPool = new ConcurrentQueue<byte[]>(pool);
                });

            Func<byte[]> bufferProvider = () =>
            {
                byte[] buffer;
                if (bufferPool.TryDequeue(out buffer))
                    return buffer;
                throw new InvalidOperationException("Buffer Pool is depleted.");
            };

            Action<byte[]> returnBuffer = buffer => { bufferPool.Enqueue(buffer); };

            CodeTimer.Time("buffer pool",
                iterations,
                () =>
                {
                    byte[] buffer = bufferProvider();
                    int count;
                    while ((count = @from.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        to.Write(buffer, 0, count);
                    }
                    returnBuffer(buffer);
                });
        }
    }
}