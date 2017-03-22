namespace ConsoleApplication16
{
    static class HashCode
    {
        public static int CombineHashCodes(int h1, int h2) => ((h1 << 5) + h1) ^ h2;

        public static int CombineHashCodes(int h1, int h2, int h3) => CombineHashCodes(CombineHashCodes(h1, h2), h3);

        public static int CombineHashCodes(int h1, int h2, int h3, int h4) => CombineHashCodes(CombineHashCodes(h1, h2), CombineHashCodes(h3, h4));

        public static int SafeGet<T>(T value)
            where T : class
        {
            if (value != null)
            {
                return value.GetHashCode();
            }

            return 0;
        }

        ////public static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5)
        ////{
        ////    return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), h5);
        ////}

        ////public static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6)
        ////{
        ////    return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6));
        ////}

        public static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7) => CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7));

        ////public static int CombineHashCodes(int h1, int h2, int h3, int h4, int h5, int h6, int h7, int h8)
        ////{
        ////    return CombineHashCodes(CombineHashCodes(h1, h2, h3, h4), CombineHashCodes(h5, h6, h7, h8));
        ////}
    }
}