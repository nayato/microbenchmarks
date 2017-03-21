namespace ConsoleApplication16
{
    using System;
    using System.Diagnostics.Contracts;

    public static class UriExtensions
    {
        public const char PathSeparator = '/';
        public const char QueryNameValueSeparator = '=';
        public const char QueryParameterSeparator = '&';
        public const char QueryStartCharacter = '?';
        public const char FragmentStartCharacter = '#';
        public const char WildcardCharacter = '*';

        public static readonly char[] QueryParamNameEndCharacters = { QueryNameValueSeparator, QueryParameterSeparator };
        public static readonly char[] QueryTerminationCharacters = { QueryParameterSeparator, FragmentStartCharacter };
        public static readonly char[] PathSegmentTerminationCharacters = { PathSeparator, QueryStartCharacter };

        public static string RemoveLeadingSlash(this string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            return url[0] == '/' ? url.Substring(1) : url;
        }

        public static string RemoveAllLeadingSlashes(this string url)
        {
            return url.TrimStart(new[] { '/' });
        }

        public static string RemoveTrailingSlash(this string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            return url[url.Length - 1] == '/' ? url.Substring(0, url.Length - 1) : url;
        }

        public static string EnsureTrailingSlash(this string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            return url[url.Length - 1] == '/' ? url : url + '/';
        }

        public static string EnsureLeadingSlash(this string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            return url[0] == '/' ? url : '/' + url;
        }

        public static Uri AppendSegment(this Uri uri, string segment)
        {
            string result = uri.AbsoluteUri;

            if (result[result.Length - 1] != '/')
            {
                result += '/';
            }

            result += segment;

            return new Uri(result);
        }

        public static string UriCombine(this string val, string append)
        {
            if (string.IsNullOrEmpty(val))
            {
                return append;
            }

            if (string.IsNullOrEmpty(append))
            {
                return val;
            }

            if (append[0] == '?' || append[0] == '&')
            {
                return val + append;
            }

            return val.TrimEnd('/') + '/' + append.TrimStart('/');
        }

        public static string AddParam(this string val, string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException();
            }

            char separator = val.IndexOf('?') >= 0 ? '&' : '?';
            string paramString = string.IsNullOrEmpty(value) ? name : name + '=' + value;
            return val.UriCombine(separator + paramString);
        }

        public static bool IsQueryParamPresent(string uri, string paramName, int queryStartIndex)
        {
            Contract.Requires(uri != null);
            Contract.Requires(paramName != null);
            Contract.Requires(queryStartIndex >= 0 && queryStartIndex < uri.Length);

            if (paramName.Length == 0)
            {
                return IndexOfQueryParamWithoutName(uri, queryStartIndex) >= 0;
            }
            else
            {
                return IndexOfQueryParamName(uri, paramName, queryStartIndex, false) >= 0;
            }
        }

        public static string GetQueryParamValue(string query, string paramName, bool ignoreCase)
        {
            Contract.Requires(!string.IsNullOrEmpty(paramName));

            int index = IndexOfQueryParamName(query, paramName, 0, ignoreCase);

            if (index >= 0)
            {
                index = index + paramName.Length + 1; // + 1 stands for '=' that we approved as well
                int valueEndIndex;
                int queryLength = query.Length;
                if (index >= queryLength || (valueEndIndex = query.IndexOfAny(QueryTerminationCharacters, index)) == -1)
                {
                    valueEndIndex = queryLength - 1;
                }
                else
                {
                    valueEndIndex--;
                }
                string result;
                if (index >= valueEndIndex) // empty value after equals sign
                {
                    result = string.Empty;
                }
                else
                {
                    result = query.Substring(index, valueEndIndex - index + 1);
                }
                return result;
            }

            return null;
        }

        static int IndexOfQueryParamName(string uri, string paramName, int queryStartIndex, bool ignoreCase)
        {
            Contract.Requires(uri != null);
            Contract.Requires(!string.IsNullOrEmpty(paramName));
            Contract.Requires(queryStartIndex >= 0 && queryStartIndex < uri.Length);

            int index = queryStartIndex;

            int paramNameLength = paramName.Length;
            int queryLength = uri.Length;
            do
            {
                index = uri.IndexOf(paramName, index, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                if (index == -1)
                {
                    break;
                }

                if (index == 0 || uri[index - 1] == QueryParameterSeparator || (index - queryStartIndex == 1 && uri[index - 1] == QueryStartCharacter)) // verify it's the beginning of query param name
                {
                    if (queryLength < index + paramNameLength + 1)
                    {
                        return index;
                    }
                    else
                    {
                        char afterNameChar = uri[index + paramNameLength];
                        if (afterNameChar == QueryNameValueSeparator || afterNameChar == QueryParameterSeparator || afterNameChar == FragmentStartCharacter) // verify it's the whole name
                        {
                            return index;
                        }
                    }
                }

                index += paramNameLength + 1;
            }
            while (index <= queryLength - paramNameLength);

            return -1;
        }

        /// <remarks>startIndex is expected to match first symbol of query string in URI and must be '?'</remarks>
        static int IndexOfQueryParamWithoutName(string uri, int startIndex)
        {
            Contract.Requires(uri != null);
            Contract.Requires(startIndex >= 0 && startIndex < uri.Length);
            Contract.Requires(uri[startIndex] == QueryStartCharacter);

            int queryLength = uri.Length;

            int index = startIndex;

            do
            {
                // at this point index is at char
                index++;
                if (index >= queryLength || uri[index] == QueryNameValueSeparator || uri[index] == QueryParameterSeparator)
                {
                    return index;
                }

                index = uri.IndexOf(QueryParameterSeparator, index);
                if (index == -1)
                {
                    return -1;
                }
            }
            while (index < queryLength);

            return -1;
        }
    }
}