namespace ConsoleApplication16
{
    using System;
    using Wintellect;

    class MeasureFixedVsManaged
    {
        public static long Run()
        {
            long ran = 0;
            const int Iterations = 1; // 100 * 1000 * 1000;

            var toFill = new byte[12];
            int[] values = { 100000, 9544, int.MaxValue - 1000 };

            CodeTimer.Time(true, "fixed", Iterations, () =>
            {
                for (int i = 0; i < values.Length; i++)
                {
                    WriteFixed((uint)values[i], toFill, i * 4);
                }
            });

            CodeTimer.Time(true, "managed", Iterations, () =>
            {
                for (int i = 0; i < values.Length; i++)
                {
                    WriteDirect((uint)values[i], toFill, i * 4);
                }
            });

            return ran;
        }

        public static unsafe void WriteFixed(uint value, byte[] array, int offset)
        {
            if (BitConverter.IsLittleEndian)
            {
                fixed (byte* b = &array[offset])
                {
                    *(b) = (byte)(value >> 24);
                    *(b + 1) = (byte)(value >> 16);
                    *(b + 2) = (byte)(value >> 8);
                    *(b + 3) = (byte)value;
                }
            }
            else
            {
                fixed (byte* b = &array[offset])
                {
                    *((uint*)b) = value;
                }
            }
        }

        public static unsafe void WriteDirect(uint value, byte[] array, int offset)
        {
            if (BitConverter.IsLittleEndian)
            {
                array[offset] = (byte)(value >> 24);
                array[offset + 1] = (byte)(value >> 16);
                array[offset + 2] = (byte)(value >> 8);
                array[offset + 3] = (byte)value;
            }
            else
            {
                fixed (byte* b = &array[offset])
                {
                    *((uint*)b) = value;
                }
            }
        }
    }
}