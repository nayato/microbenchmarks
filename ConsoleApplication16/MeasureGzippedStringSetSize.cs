namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Runtime;
    using System.Text;
    using java.io;
    using Wintellect;
    using Console = System.Console;

    class MeasureGzippedStringSetSize
    {
        public static long Run()
        {
            long ran = 0;
            const int iterations = 86400;
            var strings = new List<Tuple<Guid, byte>>(iterations);
            DateTime time = DateTime.UtcNow.AddDays(-20);
            for (int i = 0; i < iterations; i++)
            {
                time = StepTime(time);
                var blobName = GenerateBlobName(time);
                strings.Add(blobName);
            }

            var memStream = new MemoryStream();
            using (var writer = new BinaryWriter(memStream, Encoding.UTF8, true))
            {
                writer.Write(strings.Count);
                foreach (var s in strings)
                {
                    writer.Write(s.Item1.ToByteArray());
                    writer.Write(s.Item2);
                }
            }

            memStream.Seek(0, SeekOrigin.Begin);
            Console.WriteLine(memStream.Length);

            var gzippedStream = new MemoryStream();
            using (var gs = new GZipStream(gzippedStream, CompressionLevel.Optimal, true))
            {
                memStream.CopyTo(gs);
            }
            var compressedBytes = memStream.ToArray();

            Console.WriteLine(gzippedStream.Length);

            time = StepTime(time);
            var newValue = GenerateBlobName(time);
            
            CodeTimer.Time(true, "read/write compression", 300, () =>
            {
                int newInstance = newValue.Item2;
                byte[] newBytes = null;
                var sourceStream = new MemoryStream(compressedBytes);
                var readStream = new MemoryStream();
                sourceStream.CopyTo(readStream);
                readStream.Seek(0, SeekOrigin.Begin);
                byte[] newRegisterBytes = null;
                using (var reader = new BinaryReader(readStream, Encoding.UTF8, true))
                using (var writer = new BinaryWriter(readStream, Encoding.UTF8, true))
                {
                    bool isRegisteredAlready = false;
                        int count = reader.ReadInt32();
                        for (int i = 0; i < count; i++)
                        {
                            var guidBytes = reader.ReadBytes(16);
                            int instance = reader.ReadByte();
                            if (instance == newInstance)
                            {
                                if (new Guid(guidBytes) == newValue.Item1)
                                {
                                    isRegisteredAlready = true;
                                    break;
                                }
                            }
                        }

                        if (!isRegisteredAlready)
                        {
                            if (newBytes == null)
                            {
                                newBytes = newValue.Item1.ToByteArray();
                            }
                            readStream.Seek(0, SeekOrigin.Begin);
                            writer.Write(count + 1);

                            readStream.Seek(0, SeekOrigin.End);
                            writer.Write(newBytes);
                            writer.Write(newValue.Item2);
                        }

                    if (!isRegisteredAlready)
                    {
                        newRegisterBytes = readStream.ToArray();
                        ran = newRegisterBytes.Length;
                    }
                }
            });

            return ran;
        }

        static DateTime StepTime(DateTime time)
        {
            return time.AddMinutes(5);
        }

        static Tuple<Guid, byte> GenerateBlobName(DateTime time)
        {
            return Tuple.Create(Guid.NewGuid(), (byte)1);
            //string blobName = string.Format("{0}-{1}",
            //    time.ToString(FileTimestampFormat, CultureInfo.InvariantCulture.DateTimeFormat),
            //    Environment.MachineName);
            //return blobName;
        }
    }
}   