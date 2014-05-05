// --------------------------------------------------------------------------
//  <copyright file="MeasureExpressionCreationTime - Copy.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------

namespace ConsoleApplication16
{
    using System;
    using System.IO;
    using System.Text;
    using Murmur;
    using Wintellect;

    class MeasureHashPerformance
    {
        public static unsafe long Run()
        {
            long ran = 0;
            const int iterations = 10000000;

            string value = "?subscription-key=345&key=gfql3i4ufgdf3";
            string value2 = "?key=gfql3i4ufgdf3&subscription-key=345";
            var subValue = new SubString(value, 0, value.Length);
            //byte[] valueBytes = Encoding.Unicode.GetBytes(value);
            //Console.WriteLine(value.GetHashCode());
            //Console.WriteLine(subValue.GetHashCode());

            //CodeTimer.Time(true, "string.GetHashCode()", iterations, () => { value.GetHashCode(); });

            //CodeTimer.Time(true, "SubString.GetHashCode()", iterations, () => { subValue.GetHashCode(); });

            SubString subString = new SubString(value, 1, 16);
            Console.WriteLine(subString.ToString() + ":" + subString.GetHashCode());
            subString = new SubString(value, 22, 3);
            Console.WriteLine(subString.ToString() + ":" + subString.GetHashCode());

            subString = new SubString(value2, 19, 16);
            Console.WriteLine(subString.ToString() + ":" + subString.GetHashCode());
            subString = new SubString(value2, 1, 3);
            Console.WriteLine(subString.ToString() + ":" + subString.GetHashCode());

            CodeTimer.Time(true, "new SubString().GetHashCode()", iterations, () =>
            {
                new SubString(value, 1, 16).GetHashCode();
                new SubString(value, 23, 3).GetHashCode();
            });

            CodeTimer.Time(true, "string.Substring().GetHashCode()", iterations, () =>
            {
                string substring = value.Substring(1, 16);
                substring.GetHashCode();
                substring = value.Substring(23, 3);
                substring.GetHashCode();
            });

            return ran;
        }
    }
}