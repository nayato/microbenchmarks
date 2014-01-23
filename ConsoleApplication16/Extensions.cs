using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication16
{
    static class Extensions
    {
        public static string ToString(this StringBuilder stringBuilder, int startIndex)
        {
            return stringBuilder.ToString(startIndex, stringBuilder.Length - startIndex);
        }

        public static void trimToSize(this StringBuilder stringBuilder)
        {
            stringBuilder.Capacity = stringBuilder.Length;
        }
    }
}
