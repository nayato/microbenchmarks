namespace ConsoleApplication16
{
    using System;
    using Wintellect;

    class MeasureSubstringHashPerformance
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

            var subString = new SubString(value, 1, 16);
            Console.WriteLine(subString.ToString() + ":" + subString.GetHashCode());
            subString = new SubString(value, 22, 3);
            Console.WriteLine(subString.ToString() + ":" + subString.GetHashCode());

            subString = new SubString(value2, 19, 16);
            Console.WriteLine(subString.ToString() + ":" + subString.GetHashCode());
            Console.WriteLine(subString.ToString() + ":" + subString.GetHashCode2());
            subString = new SubString(value2, 1, 3);
            Console.WriteLine(subString.ToString() + ":" + subString.GetHashCode());
            Console.WriteLine(subString.ToString() + ":" + subString.GetHashCode2());

            CodeTimer.Time(true, "new SubString().GetHashCode2()", iterations, () =>
            {
                new SubString(value, 1, 16).GetHashCode2();
                new SubString(value, 23, 3).GetHashCode2();
                new SubString(value, 1, 16).GetHashCode2();
            });

            CodeTimer.Time(true, "new SubString().GetHashCode()", iterations, () =>
            {
                new SubString(value, 1, 16).GetHashCode();
                new SubString(value, 23, 3).GetHashCode();
                new SubString(value, 1, 16).GetHashCode();
            });

            var ssComparer = new OrdinalIgnoreCaseSubStringComparer();
            CodeTimer.Time(true, "new SubString().GetCaseInsensitiveHashCode()", iterations, () =>
            {
                ssComparer.GetHashCode(new SubString(value, 1, 16));
                ssComparer.GetHashCode(new SubString(value, 23, 3));
                ssComparer.GetHashCode(new SubString(value, 1, 16));
            });

            CodeTimer.Time(true, "string.Substring().GetHashCode()", iterations, () =>
            {
                string substring = value.Substring(1, 16);
                substring.GetHashCode();
                substring = value.Substring(23, 3);
                substring.GetHashCode();
                substring = value.Substring(1, 16);
                substring.GetHashCode();
            });

            var comparer = StringComparer.OrdinalIgnoreCase;
            CodeTimer.Time(true, "string.Substring().GetHashCode() insensitive", iterations, () =>
            {
                string substring = value.Substring(1, 16);
                comparer.GetHashCode(substring);
                substring = value.Substring(23, 3);
                comparer.GetHashCode(substring);
                substring = value.Substring(1, 16);
                comparer.GetHashCode(substring);
            });

            return ran;
        }
    }
}