namespace ConsoleApplication16
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using Nito.AsyncEx;
    using Wintellect;
    using Wintellect.PowerCollections;

    class Program
    {
        static readonly Encoding Utf8 = Encoding.UTF8;

        static void Main()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            CodeTimer.Time(string.Empty, 1, () => Thread.Sleep(0));

            //MeasureExpressionCachingBenefits();

            //MeasureBufferPoolBenefits.Run();

            //MeasureXmlReaders();

            //MeasureTupleVsKeyValuePairInDictionaryLookup();

            //MeasureHeaderCollectionTypes();

            //MeasureLowerInvariantVsIgnoreCaseComparison();

            //MeasureDifferentAllocationSizeTime();

            //MeasureAsyncVsContinueWith();

            //MeasureFastReflectionPaths();

            //MeasureMaybeClassVsStruct();

            //MeasureDateTimeFormatDiffCultures();

            //MeasureConcurrentDictionaryVsDictionary();

            //MeasureSearchMethods();

            //MeasurePassingTupleVsClosingOverVariables();

            //MeasureStringBuilderVsStringFormat();

            //MeasureHMHVsPipeline();

            //MeasureGzippedStringSetSize.Run();

            //MeasureExpressionCreationTime.Run();

            //MeasureSubstringHashPerformance.Run();

            //MeasureSubstringHashVsCompare.Run();

            //MeasureJsonNetVsProtobuf.Run();

            //MeasureStringBuilderVsString.Run();

            //MeasureFixedVsManaged.Run();

            //MeasureRngLongVsGuidLong.Run();

            //MeasureGenericCastHelperAbstractVsFunc.Run();

            //MeasureUriTemplateTableVsRegex.Run();

            //MeasureContinueWithVsAsyncVoid.Run();

            //MeasureContinueWithVsAsyncVoidComplex.Run();

            //new MeasureJsonVerify().Run();

            //new MeasureVolatileVsPlain().Run();

            //new MeasureConditionalWeakTablePattern().Run();

            //MeasureThreadVsXThread.Run();

            //FalseSharing.Run();

            //MeasureAsyncNestedThrowVsTry.Run();

            MeasureTimersVsWheel.Run();

            //Console.ReadLine();
        }

        static long MeasureHMHVsPipeline()
        {
            const int iterations = 1000;
            long ran = 0;

            Adelegate lastFunc = c => Task.FromResult(c.Value + 1);

            Adelegate a1 = async (context) =>
            {
                int result = await lastFunc(context);
                return result + 1;
            };

            Adelegate a2 = async context =>
            {
                int result = await a1(context);
                return result - 1;
            };

            Bdelegate lastFuncB = c =>
            {
                c.Value = c.Value + 1;
                return TaskConstants.Completed;
            };

            Bdelegate b1 = context =>
            {
                context.Value = context.Value + 1;
                return null;
            };

            Bdelegate b2 = context =>
            {
                context.Value = context.Value - 1;
                return null;
            };

            CodeTimer.TimeAsync(
                true,
                "Chained async",
                iterations,
                async () =>
                {
                    int result = await a2(new MeasureHPContext());
                    unchecked
                    {
                        ran += result;
                    }
                });

            Bdelegate[] pipeline = { lastFuncB, b1, b2 };

            CodeTimer.TimeAsync(
                true,
                "Iterated async",
                iterations,
                async () =>
                {
                    var ctx = new MeasureHPContext();
                    foreach (Bdelegate d in pipeline)
                    {
                        Task t = d(ctx);
                        if (t != null)
                            await t;
                    }
                    unchecked
                    {
                        ran += ctx.Value;
                    }
                });
            return ran;
        }

        static long MeasureStringBuilderVsStringFormat()
        {
            const int iterations = 1000000;

            long ran = 0;

            int a = 1, b = -1;

            var x = new StructTuple<int, int, int>(100, 102, 300);

            CodeTimer.Time(
                true,
                "string.Format()",
                iterations,
                () => { ran += string.Format("daily/{0}/apis/{1}/operations/{2}/test", x.First, x.Second, x.Third).Length; });

            CodeTimer.Time(
                true,
                "string.Format with explicit .ToString()",
                iterations,
                () =>
                {
                    ran +=
                        string.Format("daily/{0}/apis/{1}/operations/{2}/test", x.First.ToString(CultureInfo.InvariantCulture), x.Second.ToString(CultureInfo.InvariantCulture), x.Third.ToString(CultureInfo.InvariantCulture))
                            .Length;
                });

            CodeTimer.Time(
                true,
                "StringBuilder",
                iterations,
                () =>
                {
                    StringBuilder sb = new StringBuilder()
                        .Append("daily/")
                        .Append(x.First)
                        .Append("/apis/")
                        .Append(x.Second)
                        .Append("/operations/")
                        .Append(x.Third)
                        .Append("/test");

                    ran += sb.ToString().Length;
                });

            Console.WriteLine(ran);

            return ran;
        }

        static long MeasurePassingTupleVsClosingOverVariables()
        {
            const int iterations = 1000000;

            long ran = 0;

            int a = 1, b = -1;

            CodeTimer.Time(
                true,
                "stateful function",
                iterations,
                () =>
                {
                    a = a + 1;
                    b = b - 2;
                    ran += FuncHost(o =>
                    {
                        var tuple = (Tuple<int, int>)o;
                        return tuple.Item1 + tuple.Item2 - 1;
                    }, Tuple.Create(a, b));
                });

            Console.WriteLine(ran);

            ran = 0;

            CodeTimer.Time(
                true,
                "function closing over variable",
                iterations,
                () =>
                {
                    a = -a;
                    //b = -b;
                    ran += FuncHost(() => a + b - 1);
                });

            Console.WriteLine(ran);

            return ran;
        }

        static long FuncHost(Func<long> f)
        {
            return f();
        }

        static long FuncHost(Func<object, long> f, object state)
        {
            return f(state);
        }

        static long MeasureSearchMethods()
        {
            const int iterations = 1000000;

            long ran = 0;

            var source = new[]
            {
                "Connection",
                "KeepAlive",
                "TransferEncoding",
                "WwwAuthenticate",
                "Server"
            };

            Array.Sort(source, StringComparer.OrdinalIgnoreCase);

            var sortedSet = new SortedSet<string>(source, StringComparer.OrdinalIgnoreCase);

            var hashSet = new HashSet<string>(source);

            CodeTimer.Time(
                true,
                "binary search",
                iterations,
                () =>
                {
                    if (Array.BinarySearch(source, "Server1", StringComparer.OrdinalIgnoreCase) != 0)
                        ran += 1;
                });

            CodeTimer.Time(
                true,
                "sorted set search",
                iterations,
                () =>
                {
                    if (sortedSet.Contains("Server1", StringComparer.OrdinalIgnoreCase))
                        ran += 1;
                });

            CodeTimer.Time(
                true,
                "hash set search",
                iterations,
                () =>
                {
                    if (hashSet.Contains("Server1", StringComparer.OrdinalIgnoreCase))
                        ran += 1;
                });

            return ran;
        }

        static long MeasureConcurrentDictionaryVsDictionary()
        {
            const int iterations = 10000;

            long ran = 0;

            var map = new Dictionary<int, string>();
            var concurrentMap = new ConcurrentDictionary<int, string>();

            for (int i = 0; i < 100; i++)
            {
                map[i] = i + "1";
                concurrentMap[i] = i + "1";
            }

            CodeTimer.Time(true, "Dictionary",
                iterations,
                () =>
                {
                    foreach (string value in map.Values)
                    {
                        ran += 1;
                    }
                });

            CodeTimer.Time(true, "Concurrent Dictionary",
                iterations,
                () =>
                {
                    foreach (string value in concurrentMap.Values)
                    {
                        ran += 1;
                    }
                });

            return ran;
        }

        static long MeasureDateTimeFormatDiffCultures()
        {
            const int iterations = 100000;

            long ran = 0;

            DateTime time = DateTime.UtcNow;

            CodeTimer.Time(true, "Current Culture",
                iterations,
                () => { ran += time.ToString("R").Length; });

            CodeTimer.Time(true, "Invariant Culture",
                iterations,
                () => { ran += time.ToString("R", CultureInfo.InvariantCulture).Length; });

            return ran;
        }

        static long MeasureMaybeClassVsStruct()
        {
            const int iterations = 10000000;

            long ran = 0;

            CodeTimer.Time(true, "Maybe",
                iterations,
                () =>
                {
                    var mh = new MaybeHost();
                    ran += mh.S.Length;
                    ran += mh.D.Month;
                    ran += mh.D2.Month;
                });

            CodeTimer.Time(true, "MaybeStruct",
                iterations,
                () =>
                {
                    var mh = new MaybeStructHost();
                    ran += mh.S.Length;
                    ran += mh.D.Month;
                    ran += mh.D2.Month;
                });

            CodeTimer.Time(true, "Maybe Lazy",
                iterations,
                () =>
                {
                    var lh = new MaybeLazyHost();
                    ran += lh.S.Length;
                    ran += lh.D.Month;
                    ran += lh.D2.Month;
                });

            CodeTimer.Time(true, "Lazy",
                iterations,
                () =>
                {
                    var lh = new LazyHost();
                    ran += lh.S.Length;
                    ran += lh.D.Month;
                    ran += lh.D2.Month;
                });

            return ran;
        }

        static long MeasureAsyncVsContinueWith()
        {
            const int iterations = 1000000;

            long ran = 0;

            Task cachedTask = Task.FromResult(0);

            CodeTimer.TimeAsync(true, "Empty Async",
                iterations,
                () => cachedTask);

            CodeTimer.TimeAsync(true, "Await",
                iterations,
                async () =>
                {
                    ran += 1;
                    ran += await MeasureAsyncVsContinueWith_TaskSource();
                });

            CodeTimer.TimeAsync(true, "ContinueWith",
                iterations,
                () =>
                {
                    ran += 1;
                    return MeasureAsyncVsContinueWith_TaskSource()
                        .ContinueWith(t => { ran += t.Result; },
                            TaskContinuationOptions.OnlyOnRanToCompletion);
                });

            CodeTimer.TimeAsync(true, "ContinueWith on Awaiter",
                iterations,
                () =>
                {
                    ran += 1;
                    Task<int> task = MeasureAsyncVsContinueWith_TaskSource();
                    task.GetAwaiter().OnCompleted(() => ran += task.Result);
                    return task;
                });
            return ran;
        }

        static async Task<int> MeasureAsyncVsContinueWith_TaskSource()
        {
            await Task.Yield();
            return 1;
        }

        static long MeasureFastReflectionPaths()
        {
            const int iterations = 1000000;

            long ran = 0;

            MethodInfo sourceMethod = typeof(WebHeaderCollection).GetMethod("AddInternal", BindingFlags.NonPublic | BindingFlags.Instance);

            var @delegate = (AddHeaderDelegate)Delegate.CreateDelegate(typeof(AddHeaderDelegate), sourceMethod);

            ParameterExpression instanceExpression = Expression.Parameter(typeof(WebHeaderCollection));
            ParameterExpression nameParamExpression = Expression.Parameter(typeof(string));
            ParameterExpression valueParamExpression = Expression.Parameter(typeof(string));

            MethodCallExpression methodCallExpression = Expression.Call(instanceExpression, sourceMethod, nameParamExpression, valueParamExpression);
            Expression<AddHeaderDelegate> lambda = Expression.Lambda<AddHeaderDelegate>(methodCallExpression, new[]
            {
                instanceExpression, nameParamExpression, valueParamExpression
            });
            AddHeaderDelegate expression = lambda.Compile();

            var method = new DynamicMethod(
                "",
                null,
                new[] { typeof(WebHeaderCollection), typeof(string), typeof(string) },
                typeof(Program),
                true);
            ILGenerator ilGenerator = method.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Ldarg_2);
            ilGenerator.Emit(OpCodes.Callvirt, sourceMethod);
            ilGenerator.Emit(OpCodes.Ret);

            var dynamicDelegate = (AddHeaderDelegate)method.CreateDelegate(typeof(AddHeaderDelegate));

            var whc = new WebHeaderCollection();
            CodeTimer.Time(true, "delegate",
                iterations,
                () =>
                {
                    @delegate(whc, "test", "abc");
                    @delegate(whc, "test2", "abc1");
                    @delegate(whc, "test3", "abc2");
                    @delegate(whc, "test4", "abc3");
                    @delegate(whc, "test5", "abc4");
                    @delegate(whc, "test6", "abc5");
                    whc.Clear();
                });

            CodeTimer.Time(true, "expression",
                iterations,
                () =>
                {
                    expression(whc, "test", "abc");
                    expression(whc, "test2", "abc1");
                    expression(whc, "test3", "abc2");
                    expression(whc, "test4", "abc3");
                    expression(whc, "test5", "abc4");
                    expression(whc, "test6", "abc5");
                    whc.Clear();
                });

            CodeTimer.Time(true, "delegate",
                iterations,
                () =>
                {
                    dynamicDelegate(whc, "test", "abc");
                    dynamicDelegate(whc, "test2", "abc1");
                    dynamicDelegate(whc, "test3", "abc2");
                    dynamicDelegate(whc, "test4", "abc3");
                    dynamicDelegate(whc, "test5", "abc4");
                    dynamicDelegate(whc, "test6", "abc5");
                    whc.Clear();
                });

            return ran;
        }

        static long MeasureDifferentAllocationSizeTime()
        {
            const int iterations = 100000000;

            long ran = 0;

            CodeTimer.Time(true, "List 16",
                iterations,
                () =>
                {
                    var l = new List<int>(16);
                    ran += l.Count;
                });

            CodeTimer.Time(true, "List 12",
                iterations,
                () =>
                {
                    var l = new List<int>(12);
                    ran += l.Count;
                });

            return ran;
        }

        static long MeasureLowerInvariantVsIgnoreCaseComparison()
        {
            const int iterations = 10000;

            long ran = 0;

            string value = "p1/orders/";

            CodeTimer.Time(true, "LowerInvariant",
                iterations,
                () =>
                {
                    string requestPath = value.ToLowerInvariant();
                    string proxyAddress = "p1/orders/".ToLowerInvariant();
                    string proxyAddressSegmented = proxyAddress.EndsWith("/") ? proxyAddress : proxyAddress + "/";
                    if (requestPath.StartsWith(proxyAddressSegmented) || requestPath == proxyAddress)
                        ran += 1;
                });

            CodeTimer.Time(true, "StringComparer",
                iterations,
                () =>
                {
                    string requestPath = value;
                    string proxyAddress = "p1/orders";
                    int proxyAddressLength = proxyAddress.Length;
                    bool proxyAddressIsClosed = proxyAddress[proxyAddressLength - 1] == '/';
                    bool proxyAddressMatchedInPrefix = requestPath.StartsWith(proxyAddress, StringComparison.OrdinalIgnoreCase)
                        && (proxyAddressIsClosed
                            || requestPath.Length == proxyAddressLength
                            || (requestPath.Length > proxyAddressLength && requestPath[proxyAddressLength] == '/'));
                    if (proxyAddressMatchedInPrefix)
                        ran += 1;
                });

            return ran;
        }

        static long MeasureHeaderCollectionTypes()
        {
            const int iterations = 1000000;

            long ran = 0;

            var headers = new[]
            {
                "Connection", "Content-Type", "Host", "Accept-Encoding", "Accept", "Accept-Charset", "Vary", "Cache-Control", "Expires", "Date",
                "X-Apiphany-Developer-Key"
            };
            var nameValueCollection = new NameValueCollection(headers.Length, StringComparer.OrdinalIgnoreCase);
            var tupleList = new List<Tuple<string, object>>(headers.Length);
            var headerDictionary = new Dictionary<string, List<string>>(headers.Length, StringComparer.OrdinalIgnoreCase);
            var pairList = new List<Pair<string, object>>(headers.Length);

            for (int i = 0; i < headers.Length; i++)
            {
                nameValueCollection.Add(headers[i], headers[i] + "123");
                tupleList.Add(new Tuple<string, object>(headers[i], headers[i] + "123"));
                pairList.Add(new Pair<string, object>(headers[i], headers[i] + "123"));
                headerDictionary.Add(headers[i], new List<string>(new[] { headers[i] + "123" }));
            }

            CodeTimer.Time(true, "NameValueCollection lookup",
                iterations,
                () =>
                {
                    string key = nameValueCollection["X-Apiphany-Developer-Key"];
                    if (key != null)
                        ran += key.Length;
                    string date = nameValueCollection["Date"];
                    if (date != null)
                        ran += date.Length;
                    for (int i = 0; i < nameValueCollection.Count; i++)
                    {
                        ran += nameValueCollection.GetKey(i).Length;
                        string[] values = nameValueCollection.GetValues(i);
                        if (values != null)
                        {
                            for (int j = 0; j < values.Length; j++)
                            {
                                ran += 1;
                            }
                        }
                    }
                });

            CodeTimer.Time(true, "Tuple list lookup",
                iterations,
                () =>
                {
                    string key = FindKey(tupleList, "X-Apiphany-Developer-Key");
                    if (key != null)
                        ran += key.Length;
                    string date = FindKey(tupleList, "Date");
                    if (date != null)
                        ran += date.Length;
                    for (int i = 0; i < tupleList.Count; i++)
                    {
                        Tuple<string, object> tuple = tupleList[i];
                        ran += tuple.Item1.Length;
                        string value = tuple.Item2 as string;
                        if (value != null)
                            ran += 1;
                        var values = tuple.Item2 as string[];
                        if (values != null)
                        {
                            for (int j = 0; j < values.Length; j++)
                            {
                                ran += 1;
                            }
                        }
                    }
                });

            CodeTimer.Time(true, "Dictionary lookup",
                iterations,
                () =>
                {
                    List<string> keys = headerDictionary["X-Apiphany-Developer-Key"];
                    if (keys != null && keys.Count > 0)
                        ran += keys[0].Length;
                    List<string> dates = headerDictionary["Date"];
                    if (dates != null && dates.Count > 0)
                        ran += dates[0].Length;
                    foreach (KeyValuePair<string, List<string>> pair in headerDictionary)
                    {
                        ran += pair.Key.Length;
                        List<string> values = pair.Value;
                        if (values != null)
                        {
                            for (int j = 0; j < values.Count; j++)
                            {
                                ran += 1;
                            }
                        }
                    }
                });

            CodeTimer.Time(true, "Pair list lookup",
                iterations,
                () =>
                {
                    string key = FindKey(pairList, "X-Apiphany-Developer-Key");
                    if (key != null)
                        ran += key.Length;
                    string date = FindKey(pairList, "Date");
                    if (date != null)
                        ran += date.Length;
                    for (int i = 0; i < pairList.Count; i++)
                    {
                        Pair<string, object> tuple = pairList[i];
                        ran += tuple.First.Length;
                        string value = tuple.Second as string;
                        if (value != null)
                            ran += 1;
                        var values = tuple.Second as string[];
                        if (values != null)
                        {
                            for (int j = 0; j < values.Length; j++)
                            {
                                ran += 1;
                            }
                        }
                    }
                });

            return ran;
        }

        static string FindKey(List<Tuple<string, object>> list, string headerName)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            string key = null;

            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                Tuple<string, object> tuple = list[i];
                if (comparer.Equals(headerName, tuple.Item1))
                {
                    key = (string)tuple.Item2;
                    break;
                }
            }
            return key;
        }

        static string FindKey(List<Pair<string, object>> list, string headerName)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            string key = null;

            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                Pair<string, object> tuple = list[i];
                if (comparer.Equals(headerName, tuple.First))
                {
                    key = (string)tuple.Second;
                    break;
                }
            }
            return key;
        }

        static int MeasureTupleVsKeyValuePairInDictionaryLookup()
        {
            const int iterations = 1000000;

            int ran = 0;

            var tupleMap = new DictionaryEx<Tuple<int, int, int, DateTime>, int>(200);
            var structMap = new DictionaryEx<StructTuple<int, int, int, DateTime>, int>(200);
            for (int i = 200 - 1; i >= 0; i--)
            {
                tupleMap.Add(new Tuple<int, int, int, DateTime>(400 - i, i + 1, i - 1, new DateTime(1990 + i % 10, 5, 2)), 0);
                structMap.Add(new StructTuple<int, int, int, DateTime>(400 - i, i + 1, i - 1, new DateTime(1990 + i % 10, 5, 2)), 0);
            }

            //CodeTimer.Time(true, "Tuple lookup",
            //    iterations,
            //    () =>
            //    {
            //        int value;
            //        if (tupleMap.TryGetValue(new Tuple<int, int, int, DateTime>(390, 11, 9, new DateTime(1990, 5, 2)), out value))
            //            ran += 1;
            //    });

            CodeTimer.Time(true, "Struct lookup outer add or update",
                iterations,
                () =>
                {
                    var key = new StructTuple<int, int, int, DateTime>(390, 11, 9, new DateTime(1990, 5, 2));
                    int a = 1;
                    int value;
                    if (structMap.TryGetValue(key, out value))
                        structMap[key] = value + a;
                    else
                        structMap.Add(key, a);
                    ran += 1;
                });

            CodeTimer.Time(true, "Struct lookup AddOrUpdate",
                iterations,
                () =>
                {
                    int a = 1;
                    structMap.AddOrUpdate(
                        new StructTuple<int, int, int, DateTime>(390, 11, 9, new DateTime(1990, 5, 2)),
                        a,
                        (k, cv, nv) => cv + nv);
                    ran += 1;
                });

            return ran;
        }

        static void MeasureXmlReaders()
        {
            const int iterations = 1000;

            int ran = 0;

            Stream ms = new MemoryStream(Encoding.UTF8.GetBytes(Constants.SampleXml));

            ran += ParseWithXmlReader(ms, ran);
            ms.Seek(0, SeekOrigin.Begin);

            CodeTimer.Time(true, "sync xml reader",
                iterations,
                () =>
                {
                    int i = 0;
                    i = ParseWithXmlReader(ms, i);
                    ran = i;
                    ms.Seek(0, SeekOrigin.Begin);
                });

            XmlReader reader1 = XmlReader.Create(ms, new XmlReaderSettings
            {
                Async = true
            });
            ran += ReadXmlAsync(reader1).Result;
            ms.Seek(0, SeekOrigin.Begin);

            CodeTimer.Time(true, "async xml reader",
                iterations,
                () =>
                {
                    int i = 0;
                    using (XmlReader reader = XmlReader.Create(ms, new XmlReaderSettings
                    {
                        Async = true
                    }))
                    {
                        ran = ReadXmlAsync(reader).Result;
                    }
                    ran = i;
                    ms.Seek(0, SeekOrigin.Begin);
                });

            //ran += AaltoRun(ms, ran);
            //ms.Seek(0, SeekOrigin.Begin);

            //CodeTimer.Time(true, "aalto xml reader",
            //    iterations,
            //    () =>
            //    {
            //        int i = 0;

            //        i = AaltoRun(ms, i);

            //        ran = i;
            //        ms.Seek(0, SeekOrigin.Begin);
            //    });

            //ran += AaltoRunAsync(ms, ran).Result;
            //ms.Seek(0, SeekOrigin.Begin);

            //CodeTimer.Time(true, "async aalto xml reader",
            //    iterations,
            //    () =>
            //    {
            //        int i = 0;

            //        i = AaltoRunAsync(ms, i).Result;

            //        ran = i;
            //        ms.Seek(0, SeekOrigin.Begin);
            //    });

            //ran += ParseWithSmallParser(ms, ran);
            //ms.Seek(0, SeekOrigin.Begin);

            //CodeTimer.Time(true, "small xml parser",
            //    iterations,
            //    () =>
            //    {
            //        int i = 0;

            //        i = ParseWithSmallParser(ms, i);

            //        ran = i;
            //        ms.Seek(0, SeekOrigin.Begin);
            //    });

            Console.WriteLine(ran);
        }

        static int ParseWithXmlReader(Stream ms, int i)
        {
            using (XmlReader reader = XmlReader.Create(ms))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            i += reader.LocalName.Length;
                            break;
                        case XmlNodeType.Attribute:
                            i += reader.Value.Length;
                            break;
                    }
                }
            }
            return i;
        }

        static int ParseWithSmallParser(Stream ms, int i)
        {
            var parser = new SmallXmlParser();
            var reader = new StreamReader(ms, Utf8);
            var handler = new SmallContentHandler();
            parser.Parse(reader, handler);
            return i + handler.Counted;
        }

        //static int AaltoRun(Stream ms, int i)
        //{
        //    var factory = new InputFactoryImpl();
        //    var reader = factory.createAsyncXMLStreamReader();
        //    var buffer = new byte[64 * 1024];
        //    int token;
        //    do
        //    {
        //        token = reader.next();
        //        while (token == AsyncXMLStreamReader.__Fields.EVENT_INCOMPLETE)
        //        {
        //            token = NextToken(reader, ms, buffer);
        //        }
        //        switch (token)
        //        {
        //            case XMLStreamConstants.__Fields.START_ELEMENT:
        //                i += reader.getLocalName().Length;
        //                int attrCount = reader.getAttributeCount();
        //                for (int ai = 0; ai < attrCount; ai++)
        //                {
        //                    string attributeValue = reader.getAttributeValue(ai);
        //                    i += attributeValue.Length;
        //                }
        //                break;
        //            case XMLStreamConstants.__Fields.CHARACTERS:
        //                var sb = new StringBuilder();
        //                while (reader.getEventType() == XMLStreamConstants.__Fields.CHARACTERS)
        //                {
        //                    string currentText = reader.getText();
        //                    sb.Append(currentText);
        //                    NextToken(reader, ms, buffer);
        //                }
        //                i += sb.ToString().Length;
        //                break;
        //        }
        //    } while (token != XMLStreamConstants.__Fields.END_DOCUMENT);
        //    return i;
        //}

        //public static int NextToken(AsyncXMLStreamReader reader, Stream sourceStream, byte[] buffer)
        //{
        //    int token;

        //    while ((token = reader.next()) == AsyncXMLStreamReader.__Fields.EVENT_INCOMPLETE)
        //    {
        //        AsyncInputFeeder feeder = reader.getInputFeeder();
        //        if (!feeder.needMoreInput())
        //            throw new Exception("Got EVENT_INCOMPLETE, could not feed more input");
        //        int read = sourceStream.Read(buffer, 0, buffer.Length);
        //        if (read == 0)
        //            feeder.endOfInput();
        //        else
        //            feeder.feedInput(buffer, 0, read);
        //    }
        //    return token;
        //}

        //static async Task<int> AaltoRunAsync(Stream ms, int i)
        //{
        //    var factory = new InputFactoryImpl();
        //    var reader = factory.createAsyncXMLStreamReader();
        //    var buffer = new byte[64 * 1024];
        //    int token;
        //    do
        //    {
        //        token = reader.next();
        //        while (token == AsyncXMLStreamReader.__Fields.EVENT_INCOMPLETE)
        //        {
        //            token = await NextTokenAsync(reader, ms, buffer).ConfigureAwait(false);
        //        }
        //        switch (token)
        //        {
        //            case XMLStreamConstants.__Fields.START_ELEMENT:
        //                i += reader.getLocalName().Length;
        //                int attrCount = reader.getAttributeCount();
        //                for (int ai = 0; ai < attrCount; ai++)
        //                {
        //                    string attributeValue = reader.getAttributeValue(ai);
        //                    i += attributeValue.Length;
        //                }
        //                break;
        //            case XMLStreamConstants.__Fields.CHARACTERS:
        //                var sb = new StringBuilder();
        //                while (reader.getEventType() == XMLStreamConstants.__Fields.CHARACTERS)
        //                {
        //                    string currentText = reader.getText();
        //                    sb.Append(currentText);
        //                    await NextTokenAsync(reader, ms, buffer).ConfigureAwait(false);
        //                }
        //                i += sb.ToString().Length;
        //                break;
        //        }
        //    } while (token != XMLStreamConstants.__Fields.END_DOCUMENT);
        //    return i;
        //}

        //public static async Task<int> NextTokenAsync(AsyncXMLStreamReader reader, Stream sourceStream, byte[] buffer)
        //{
        //    int token;

        //    while ((token = reader.next()) == AsyncXMLStreamReader.__Fields.EVENT_INCOMPLETE)
        //    {
        //        AsyncInputFeeder feeder = reader.getInputFeeder();
        //        if (!feeder.needMoreInput())
        //            throw new Exception("Got EVENT_INCOMPLETE, could not feed more input");
        //        int read = sourceStream.Read(buffer, 0, buffer.Length);
        //        if (read == 0)
        //            feeder.endOfInput();
        //        else
        //            feeder.feedInput(buffer, 0, read);
        //    }
        //    return token;
        //}

        static async Task<int> ReadXmlAsync(XmlReader reader)
        {
            int i = 0;
            //Task<bool> t = reader.ReadAsync();
            //while ((t.IsCompleted && t.Result) || (await t.ConfigureAwait(false)))
            while ((await reader.ReadAsync().ConfigureAwait(false)))
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        i += reader.LocalName.Length;
                        break;
                    case XmlNodeType.Attribute:
                        i += (await reader.GetValueAsync().ConfigureAwait(false)).Length;
                        //Task<string> tva = reader.GetValueAsync();
                        //i += tva.IsCompleted ? tva.Result.Length : (await tva.ConfigureAwait(false)).Length;
                        break;
                }
                //t = reader.ReadAsync();
            }
            return i;
        }

        static void MeasureExpressionCachingBenefits()
        {
            const int iterations = 10000;

            IQueryable<TestClass> seq = Enumerable.Range(1, 100).Select(x => new TestClass
            {
                A = x % 2 == 0,
                B = x * 2,
                C = x.ToString()
            }).AsQueryable();

            IQueryable<string> found = null;
            CodeTimer.Time("create expressions each time",
                iterations,
                () => { found = seq.Where(x => x.B > 20 && x.A).Select(x => x.C); });

            Expression<Func<TestClass, bool>> whereClause = x => x.B > 20 && x.A;
            Expression<Func<TestClass, string>> selectClause = x => x.C;

            CodeTimer.Time("cache expressions",
                iterations,
                () => { found = seq.Where(whereClause).Select(selectClause); });

            Console.WriteLine(found);
        }

        delegate void AddHeaderDelegate(WebHeaderCollection collection, string headerName, string headerValue);

        delegate Task<int> Adelegate(MeasureHPContext context);

        delegate Task Bdelegate(MeasureHPContext context);

        class MeasureHPContext
        {
            public int Value { get; set; }
        }

        class SmallContentHandler : SmallXmlParser.IContentHandler
        {
            int _counted;

            public SmallContentHandler()
            {
            }

            public int Counted
            {
                get { return this._counted; }
            }

            public void OnStartParsing(SmallXmlParser parser)
            {
            }

            public void OnEndParsing(SmallXmlParser parser)
            {
            }

            public void OnStartElement(string name, SmallXmlParser.IAttrList attrs)
            {
                this._counted += name.Length;
                for (int i = 0; i < attrs.Length; i++)
                {
                    this._counted += attrs.GetValue(i).Length;
                }
            }

            public void OnEndElement(string name)
            {
            }

            public void OnProcessingInstruction(string name, string text)
            {
            }

            public void OnChars(string text)
            {
                this._counted += text.Length;
            }

            public void OnIgnorableWhitespace(string text)
            {
            }
        }

        public class TestClass
        {
            public bool A { get; set; }

            public int B { get; set; }

            public string C { get; set; }
        }
    }
}