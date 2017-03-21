namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using Wintellect;

    class MeasureStringBuilderVsString
    {
        public static long Run()
        {
            long ran = 0;
            const int Iterations = 1 * 1000 * 1000;

            var url = new Url("https", "test.azure-api.net", 443, "/echo/resource-cached/", '?' + "subscription-key=01E9C4F0E87EDA4997BC5347FF48DA69&criteria=blablabla");

            //CodeTimer.Time(true, "string", Iterations, () =>
            //{
            //    if (url.Uri.OriginalString.Length > 10)
            //    {
            //        ran++;
            //    }
            //});

            //CodeTimer.Time(true, "string builder", Iterations, () =>
            //{
            //    if (url.UriTB.OriginalString.Length > 10)
            //    {
            //        ran++;
            //    }
            //});

            CodeTimer.Time(true, "uri", Iterations, () =>
            {
                if (url.ToString().Length < 10)
                {
                    ran++;
                }
            });

            CodeTimer.Time(true, "concat", Iterations, () =>
            {
                if (url.ToStringC().Length < 10)
                {
                    ran++;
                }
            });

            return ran;
        }

        static string FormatTitle(string title, int matchLength, int matchCount)
        {
            return title + '\t' + matchLength + '\t' + matchCount;
        }

        [DebuggerDisplay("{Scheme}://{Host}:{Port}{Path}, QueryString = {queryString}")]
        public class Url : ICloneable
        {
            Uri uri;
            Dictionary<string, string[]> query;
            string queryString;

            public Url(Uri uri)
            {
                this.Scheme = uri.Scheme;
                this.Host = uri.Host;
                this.Port = uri.Port;
                this.Path = uri.AbsolutePath;
                this.QueryString = uri.Query;
                this.uri = uri;
            }

            public Url(string scheme, string host, int? port, string path, string query)
            {
                this.Scheme = scheme;
                this.Host = host;
                if (port.HasValue)
                {
                    this.Port = port.Value;
                }
                else if (scheme == Uri.UriSchemeHttps)
                {
                    this.Port = 443;
                }
                else if (scheme == Uri.UriSchemeHttp)
                {
                    this.Port = 80;
                }
                this.Path = path;
                this.QueryString = query;
            }

            public string Scheme { get; set; }

            public string Host { get; set; }

            public int Port { get; set; }

            public string Path { get; set; }

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public Dictionary<string, string[]> Query
            {
                get
                {
                    if (this.query == null)
                    {
                        Dictionary<string, string[]> result = this.ParseQueryString();

                        this.query = result;
                        // todo parse
                    }
                    this.queryString = null; // reset query string at this point as we don't have feedback loop yet to identify changes through dictionary - todo
                    this.uri = null;
                    return this.query;
                }
            }

            Dictionary<string, string[]> ParseQueryString()
            {
                var result = new Dictionary<string, string[]>();

                if (string.IsNullOrEmpty(this.queryString))
                {
                    return result;
                }

                int index = 0;
                int length = this.queryString.Length;
                string sourceQuery = this.queryString;
                int sourceQueryLength = length;
                if (this.queryString[0] == UriExtensions.QueryStartCharacter)
                {
                    index++;
                }

                while (index < length)
                {
                    // find param name end
                    int paramNameStopIndex = sourceQuery.IndexOfAny(UriExtensions.QueryParamNameEndCharacters, index);
                    if (paramNameStopIndex == -1)
                    {
                        paramNameStopIndex = sourceQueryLength;
                    }

                    string paramName = sourceQuery.Substring(index, paramNameStopIndex - index);
                    index = paramNameStopIndex + 1;

                    if (paramNameStopIndex < sourceQueryLength && sourceQuery[paramNameStopIndex] == UriExtensions.QueryNameValueSeparator)
                    {
                        // param name is followed by '=' => extract param value
                        string paramValue;
                        if (index < sourceQueryLength)
                        {
                            int valueEndIndex = sourceQuery.IndexOf(UriExtensions.QueryParameterSeparator, index);
                            if (valueEndIndex == -1)
                            {
                                valueEndIndex = sourceQueryLength;
                            }
                            paramValue = sourceQuery.Substring(index, valueEndIndex - index);
                            index = valueEndIndex + 1;
                        }
                        else
                        {
                            // '=' is the last character in query string
                            paramValue = string.Empty;
                        }

                        result.Append(paramName, paramValue);
                    }
                    else if (paramName.Length > 0)
                    {
                        // param pair ended with '&' or at last character in query string => param pair has only name
                        result.Append(paramName, string.Empty);
                    }
                }
                return result;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public string QueryString
            {
                get
                {
                    if (this.queryString == null)
                    {
                        if (this.query.Count == 0)
                        {
                            this.queryString = string.Empty;
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder().Append(UriExtensions.QueryStartCharacter);
                            foreach (KeyValuePair<string, string[]> paramDefinition in this.query)
                            {
                                foreach (string value in paramDefinition.Value)
                                {
                                    if (sb.Length > 1)
                                    {
                                        sb.Append(UriExtensions.QueryParameterSeparator);
                                    }
                                    sb.Append(paramDefinition.Key);
                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        sb.Append(UriExtensions.QueryNameValueSeparator).Append(value);
                                    }
                                }
                            }
                            this.queryString = sb.ToString();
                        }
                    }
                    return this.queryString;
                }
                set
                {
                    this.queryString = value;
                    this.query = null;
                }
            }

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public Uri Uri
            {
                get
                {
                    if (this.uri == null)
                    {
                        return new Uri(this.Scheme + Uri.SchemeDelimiter + this.Host + ":" + this.Port + this.Path + this.QueryString, UriKind.Absolute);
                    }
                    return this.uri;
                }
            }

            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public Uri UriTB
            {
                get
                {
                    if (this.uri == null)
                    {
                        string scheme = this.Scheme;

                        string host = this.Host;
                        string path = this.Path;
                        string query = this.QueryString;
                        var sb = new StringBuilder(scheme, scheme.Length + host.Length + 6 + path.Length + query.Length);
                        sb.Append(Uri.SchemeDelimiter).Append(host).Append(':').Append(this.Port).Append(path).Append(query);
                        return new Uri(sb.ToString(), UriKind.Absolute);
                    }
                    return this.uri;
                }
            }

            public override string ToString()
            {
                return this.Uri.ToString();
            }

            public virtual string ToStringC()
            {
                return this.Scheme + Uri.SchemeDelimiter + this.Host + ":" + this.Port + this.Path + this.QueryString;
            }

            public object Clone()
            {
                return new Url(this.Scheme, this.Host, this.Port, this.Path, this.QueryString);
            }
        }
    }
}