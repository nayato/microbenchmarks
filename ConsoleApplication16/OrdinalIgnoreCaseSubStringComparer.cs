namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;

    public class OrdinalIgnoreCaseSubStringComparer : IEqualityComparer<SubString>, IComparer<SubString>
    {
        public bool Equals(SubString x, SubString y)
        {
            return x.Equals(y, StringComparison.OrdinalIgnoreCase);
        }

        public unsafe int GetHashCode(SubString obj)
        {
            unchecked
            {
                fixed (char* c = obj.Source)
                {
                    char* cc = c + obj.Offset;
                    char* end = cc + obj.Length - 1;
                    int h = 0;
                    for (; cc < end; cc += 2)
                    {
                        h = (h << 5) - h + ToLower(*cc);
                        h = (h << 5) - h + ToLower(cc[1]);
                    }
                    ++end;
                    if (cc < end)
                    {
                        h = (h << 5) - h + ToLower(*cc);
                    }
                    return h;
                }
            }
        }

        public static char ToLower(char c)
        {
            if (c < 0x80)
            {
                if (c <= 'Z' && 'A' <= c)
                {
                    c = (char)(c + 0x20);
                }
            }
            else
            {
                c = char.ToLowerInvariant(c);
            }
            return c;
        }

        public int Compare(SubString x, SubString y)
        {
            return x.Compare(y, StringComparison.OrdinalIgnoreCase);
        }
    }
}