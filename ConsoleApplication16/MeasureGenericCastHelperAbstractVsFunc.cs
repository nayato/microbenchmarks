namespace ConsoleApplication16
{
    using System;
    using Wintellect;

    class MeasureGenericCastHelperAbstractVsFunc
    {
        public static long Run()
        {
            long ran = 0;
            const int Iterations = 2000000000; // 100 * 1000 * 1000;

            CodeTimer.Time(true, "common", Iterations, () =>
            {
                if (GenCommon<bool>(true))
                {
                    ran += GenCommon<int>(false);
                }
            });

            CodeTimer.Time(true, "class", Iterations, () =>
            {
                if (GenClass<bool>(true))
                {
                    ran += GenClass<int>(false);
                }
            });

            //CodeTimer.Time(true, "func", Iterations, () =>
            //{
            //    if (GenFunc<bool>(true))
            //    {
            //        ran += GenFunc<int>(false);
            //    }
            //});

            return ran;
        }

        static T GenClass<T>(bool isBool)
        {
            if (isBool)
            {
                return GenericCastHelper.Cast<bool, T>(true);
            }
            else
            {
                return GenericCastHelper.Cast<int, T>(1);
            }
        }

        static T GenFunc<T>(bool isBool)
        {
            if (isBool)
            {
                return GenericCastHelperFunc.Cast<bool, T>(true);
            }
            else
            {
                return GenericCastHelperFunc.Cast<int, T>(1);
            }
        }

        static T GenCommon<T>(bool isBool)
        {
            if (isBool)
            {
                return (T)(object)true;
            }
            else
            {
                return (T)(object)1;
            }
        }

        public static class GenericCastHelper
        {
            public static TOut Cast<TIn, TOut>(TIn value)
            {
                return GenericCastHelperInternal<TIn, TOut>.Instance.Cast(value);
            }

            abstract class GenericCastHelperInternal<TIn, TOut>
            {
                public static readonly GenericCastHelperInternal<TIn, TOut> Instance = CreateHelper();

                static GenericCastHelperInternal<TIn, TOut> CreateHelper()
                {
                    if (typeof(TIn) == typeof(TOut))
                    {
                        return new SameTypeCastHelper<TIn>() as GenericCastHelperInternal<TIn, TOut>;
                    }
                    else
                    {
                        throw new NotSupportedException("Input and Output types must match.");
                    }
                }

                public abstract TOut Cast(TIn value);
            }

            sealed class SameTypeCastHelper<T> : GenericCastHelperInternal<T, T>
            {
                public override T Cast(T value)
                {
                    return value;
                }
            }
        }

        public static class GenericCastHelperFunc
        {
            public static TOut Cast<TIn, TOut>(TIn value)
            {
                return GenericCastHelperInternal<TIn, TOut>.CastFunc(value);
            }

            static class GenericCastHelperInternal<TIn, TOut>
            {
                public static readonly Func<TIn, TOut> CastFunc = CreateHelper();

                static Func<TIn, TOut> CreateHelper()
                {
                    if (typeof(TIn) == typeof(TOut))
                    {
                        Func<TIn, TIn> func = @in => @in;
                        return func as Func<TIn, TOut>;
                    }
                    else
                    {
                        throw new NotSupportedException("Input and Output types must match.");
                    }
                }
            }
        }
    }
}