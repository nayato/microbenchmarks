namespace ConsoleApplication16
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using Wintellect;

    class MeasureRngLongVsGuidLong
    {
        public static unsafe long Run()
        {
            long ran = 0;
            const int Iterations = 10000000; // 100 * 1000 * 1000;

            var crypto = new RNGCryptoServiceProvider();

            CodeTimer.Time(true, "Guid cut", Iterations, () =>
            {
                var conversion = new InplaceGuidConversion(false);
                long result = conversion.firstLong;
                //var bytes = guid.ToByteArray();
                //long result;
                //fixed(long * pbyte = bytes)
                //{
                //    result = *pbyte;
                //}
                if (result > 0)
                {
                    ran++;
                }
            });

            var toFill = new byte[8];
            CodeTimer.Time(true, "crypto gen", Iterations, () =>
            {
                crypto.GetBytes(toFill);
                long result;
                fixed (byte* pbyte = toFill)
                {
                    result = *((long*)pbyte);
                }
                if (result > 0)
                {
                    ran++;
                }
            });

            return ran;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct InplaceGuidConversion
        {
            [FieldOffset(0)]
            public readonly Guid guid;

            [FieldOffset(0)]
            public readonly long firstLong;

            public InplaceGuidConversion(bool nomatter)
            {
                this.firstLong = 0;
                this.guid = Guid.NewGuid();
            }
        }
    }
}