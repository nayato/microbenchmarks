namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using Wintellect;

    class MeasureSubstringHashVsCompare
    {
        public static unsafe long Run()
        {
            long ran = 0;
            const int iterations = 100000000;

            string value = "?subscription-key=345&key=gfql3i4ufgdf3subscription-key=345&key=gfql3i4ufgdf3";
            string value2 = "?subscription-key=345&key=gfql3i4ufgdf3subscription-key=345&key=gfql3i4ufgdf31";

            var comparer = new OrdinalIgnoreCaseSubStringComparer();
            var map = new Dictionary<SubString, int>(comparer);
            var match = new SubString(value, 1, 30);
            var match2 = new SubString(value, 2, 30);
            map.Add(match2, 1);
            map.Add(match, 1);
            var candidate = new SubString(value2, 1, 30);
            
            CodeTimer.Time(true, "lookup", iterations, () =>
            {
                int v;
                map.TryGetValue(candidate, out v);
            });

            CodeTimer.Time(true, "lookup", iterations, () =>
            {
                comparer.Equals(candidate, match);
                comparer.Equals(candidate, match2);
            });

            return ran;
        }
    }
}