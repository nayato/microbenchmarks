namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization;
    using LZ4;
    using Newtonsoft.Json;
    using ProtoBuf;
    using Wintellect;

    class MeasureJsonNetVsProtobuf
    {
        public static long Run()
        {
            long ran = 0;
            const int Iterations = 1;

            CompleteEntry[] entries = Enumerable.Repeat(1, 40000).Select(x => new CompleteEntry
                {
                    BackendMethod = "GET",
                    BackendUrl = "https://testbackendapiuswest.cloudapp.net:8080/backendapi/scaleobjects/operation1?subscription-key=850f18ed12ef4083b7d1a16f4d5b8148" + x,
                    ActivityId = Guid.Parse("eb316213-c15f-41c2-863b-a2f9ef50803b"),
                    TenantId = 1,
                    ApiId = 4,
                    OperationId = 11,
                    ProductId = 3,
                    SubjectId = 59,
                    Method = "GET",
                    Url = "https://mysite1.hamidswest.antares-test.windows-int.net/mockbe/scaleobjects/operation1?subscription-key=850f18ed12ef4083b7d1a16f4d5b8148" + x,
                    IpAddress = "191.236.98.85" + x,
                    BackendResponseCode = HttpStatusCode.OK,
                    ResponseCode = HttpStatusCode.OK,
                    ResponseSize = 2171,
                    Timestamp = DateTime.Parse("2014-09-24T19:47:13.2297565Z"),
                    Cache = CacheInvolvement.Hit,
                    OverallTime = TimeSpan.Parse("00:00:00.0076907"),
                    ServiceTime = TimeSpan.Parse("00:00:00.0060038"),
                    ProxyTime = TimeSpan.Parse("00:00:00.0001382"),
                    SkipReporting = false
                })
                .ToArray();

            JsonSerializer jsonNetSerializer = JsonSerializer.CreateDefault();

            //CodeTimer.Time(true, "json.net", Iterations, () =>
            //{
            //    //using (var stream = new MemoryStream())
            //    using (var uncompressedStream = new MemoryStream())
            //    using (var stream = new GZipStream(uncompressedStream, CompressionLevel.Fastest))
            //    using (var writer = new StreamWriter(stream))
            //    using (var jsonWriter = new JsonTextWriter(writer))
            //    {
            //        jsonNetSerializer.Serialize(jsonWriter, entries);
            //        if (stream.CanRead)
            //        {
            //            ran++;
            //        }
            //    }
            //});

            // CURRENT
            //CodeTimer.Time(true, "json.net", Iterations, () =>
            //{
            //    //using (var stream = new MemoryStream())
            //    using (var compressedStream = new MemoryStream())
            //    using (var stream = new GZipStream(compressedStream, CompressionLevel.Optimal))
            //    using (var writer = new StreamWriter(stream))
            //    using (var jsonWriter = new JsonTextWriter(writer))
            //    {
            //        jsonNetSerializer.Serialize(jsonWriter, entries);
            //        stream.Flush();

            //        if (stream.CanRead)
            //        {
            //            ran++;
            //        }
            //    }
            //});

            Serializer.PrepareSerializer<CompleteEntry>();

            //CodeTimer.Time(true, "protobuf", Iterations, () =>
            //{
            //    //using (var stream = new MemoryStream())
            //    using (var uncompressedStream = new MemoryStream())
            //    using (var stream = new GZipStream(uncompressedStream, CompressionLevel.Fastest))
            //    {
            //        Serializer.Serialize(stream, entries);
            //        if (stream.CanRead)
            //        {
            //            ran++;
            //        }
            //    }
            //});

            CodeTimer.Time(true, "protobuf stream", Iterations, () =>
            {
                //using (var stream = new MemoryStream())
                using (var compressedStream = new MemoryStream())
                using (var stream = new GZipStream(compressedStream, CompressionLevel.Fastest))
                {
                    Serializer.SerializeWithLengthPrefix(stream, 2, PrefixStyle.Fixed32);
                    foreach (CompleteEntry entry1 in entries)
                    {
                        Serializer.SerializeWithLengthPrefix(stream, entry1, PrefixStyle.Fixed32);
                    }
                    stream.Flush();

                    if (stream.CanRead)
                    {
                        ran++;
                    }
                    //stream.Position = 0;
                    //int version = Serializer.DeserializeWithLengthPrefix<int>(stream, PrefixStyle.Fixed32);
                    //bool eof = false;
                    //TelemetryEntry entry;
                    //do
                    //{
                    //    entry = Serializer.DeserializeWithLengthPrefix<TelemetryEntry>(stream, PrefixStyle.Fixed32);
                    //    ran++;
                    //}
                    //while (entry != null);

                    //var dhentries = Serializer.Deserialize<IEnumerable<CompleteEntry>>(stream);
                    //ran += dhentries.Count();
                }
            });

            //CodeTimer.Time(true, "protobuf stream + snappy", Iterations, () =>
            //{
            //    //using (var stream = new MemoryStream())
            //    using (var compressedStream = new MemoryStream())
            //    using (var stream = new SnappyStream(compressedStream, CompressionMode.Compress))
            //    {
            //        Serializer.SerializeWithLengthPrefix(stream, 2, PrefixStyle.Fixed32);
            //        foreach (var entry1 in entries)
            //        {
            //            Serializer.SerializeWithLengthPrefix(stream, entry1, PrefixStyle.Fixed32);
            //        }

            //        stream.Flush();

            //        if (stream.CanRead)
            //        {
            //            ran++;
            //        }
            //    }
            //});

            CodeTimer.Time(true, "protobuf stream + lz4", Iterations, () =>
            {
                //using (var stream = new MemoryStream())
                using (var compressedStream = new MemoryStream())
                using (var stream = new LZ4Stream(compressedStream, CompressionMode.Compress, false, 80 * 1024))
                {
                    Serializer.SerializeWithLengthPrefix(stream, 2, PrefixStyle.Fixed32);
                    foreach (CompleteEntry entry1 in entries)
                    {
                        Serializer.SerializeWithLengthPrefix(stream, entry1, PrefixStyle.Fixed32);
                    }

                    stream.Flush();

                    if (stream.CanRead)
                    {
                        ran++;
                    }
                }
            });

            return ran;
        }

        [DataContract]
        [ProtoContract]
        [ProtoInclude(100, typeof(CompleteEntry))]
        public class TelemetryEntry
        {
            public const long CurrentVersion = 1;
            public static readonly IEnumerable<long> SupportedVersions = new[] { CurrentVersion };

            [DataMember(Name = "tenantId")]
            [ProtoMember(1)]
            public int TenantId { get; set; }

            [DataMember(Name = "apiId")]
            [ProtoMember(2)]
            public int ApiId { get; set; }

            [DataMember(Name = "operationId")]
            [ProtoMember(3)]
            public int OperationId { get; set; }

            [DataMember(Name = "productId")]
            [ProtoMember(4)]
            public int ProductId { get; set; }

            [DataMember(Name = "subjectId")]
            [ProtoMember(5)]
            public int SubjectId { get; set; }

            [DataMember(Name = "method")]
            [ProtoMember(6)]
            public string Method { get; set; }

            [DataMember(Name = "url")]
            [ProtoMember(7)]
            public string Url { get; set; }

            [DataMember(Name = "ip")]
            [ProtoMember(8)]
            public string IpAddress { get; set; }

            [DataMember(Name = "backendResponseCode")]
            [ProtoMember(9)]
            public HttpStatusCode? BackendResponseCode { get; set; }

            [DataMember(Name = "responseCode")]
            [ProtoMember(10)]
            public HttpStatusCode ResponseCode { get; set; }

            [DataMember(Name = "responseSize")]
            [ProtoMember(11)]
            public long ResponseSize { get; set; }

            [DataMember(Name = "timestamp")]
            [ProtoMember(12)]
            public DateTime Timestamp { get; set; }

            [DataMember(Name = "cache")]
            [ProtoMember(13)]
            public CacheInvolvement Cache { get; set; }

            /// <summary>
            ///     Complete processing time from first byte received from proxy client to last byte sent to it back.
            /// </summary>
            [DataMember(Name = "overallTime")]
            [ProtoMember(14)]
            public TimeSpan OverallTime { get; set; }

            /// <summary>
            ///     Processing time from first byte sent to customer service to last byte received from it back.
            /// </summary>
            [DataMember(Name = "serviceTime")]
            [ProtoMember(15)]
            public TimeSpan? ServiceTime { get; set; }

            /// <summary>
            ///     Time spent in proxy
            /// </summary>
            [DataMember(Name = "proxyTime")]
            [ProtoMember(16)]
            public TimeSpan ProxyTime { get; set; }

            [DataMember(Name = "skipReporting")]
            [ProtoMember(17)]
            public bool SkipReporting { get; set; }
        }

        public enum CacheInvolvement
        {
            [EnumMember(Value = "none")]
            None = 0,

            [EnumMember(Value = "hit")]
            Hit = 1,

            [EnumMember(Value = "miss")]
            Miss = 2
        }

        [DataContract]
        [ProtoContract]
        public class CompleteEntry : TelemetryEntry
        {
            [DataMember(Name = "responseHeaders", EmitDefaultValue = false)]
            [ProtoMember(1)]
            public Dictionary<string, string[]> ResponseHeaders { get; set; }

            [DataMember(Name = "responseBody", EmitDefaultValue = false)]
            [ProtoMember(2)]
            public byte[] ResponseContent { get; set; }

            [DataMember(Name = "backendMethod", EmitDefaultValue = false)]
            [ProtoMember(3)]
            public string BackendMethod { get; set; }

            [DataMember(Name = "backendUrl", EmitDefaultValue = false)]
            [ProtoMember(4)]
            public string BackendUrl { get; set; }

            [DataMember(Name = "activityId", EmitDefaultValue = false)]
            [ProtoMember(5)]
            public Guid ActivityId { get; set; }
        }
    }
}