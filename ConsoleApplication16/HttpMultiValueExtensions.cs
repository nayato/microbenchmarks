namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    public static class HttpMultiValueExtensions
    {
        public static void Append(this IDictionary<string, string[]> headerDictionary, string headerName, string value)
        {
            string[] currentValues;
            if (headerDictionary.TryGetValue(headerName, out currentValues))
            {
                var values = new string[currentValues.Length + 1];
                Array.Copy(currentValues, 0, values, 0, currentValues.Length);
                values[currentValues.Length] = value;
                headerDictionary[headerName] = values;
            }
            else
            {
                headerDictionary[headerName] = new[] { value };
            }
        }

        public static void Append(this IDictionary<string, string[]> headerDictionary, string headerName, params string[] value)
        {
            string[] currentValues;
            int valueLength = value.Length;
            if (headerDictionary.TryGetValue(headerName, out currentValues))
            {
                var values = new string[currentValues.Length + valueLength];
                Array.Copy(currentValues, 0, values, 0, currentValues.Length);
                Array.Copy(value, 0, values, currentValues.Length, valueLength);
                headerDictionary[headerName] = values;
            }
            else
            {
                var values = new string[valueLength];
                Array.Copy(value, 0, values, 0, valueLength);
                headerDictionary[headerName] = value;
            }
        }

        public static void Add(this IDictionary<string, string[]> headerDictionary, string headerName, params string[] value)
        {
            headerDictionary.Add(headerName, value);
        }

        public static void Set(this IDictionary<string, string[]> headerDictionary, string headerName, params string[] values)
        {
            headerDictionary[headerName] = values;
        }

        public static string GetFirst(this IDictionary<string, string[]> headerDictionary, string headerName)
        {
            string[] values;
            if (!headerDictionary.TryGetValue(headerName, out values))
            {
                return null;
            }
            return values[0];
        }

        public static string[] Get(this IDictionary<string, string[]> headerDictionary, string headerName)
        {
            string[] values;
            if (!headerDictionary.TryGetValue(headerName, out values))
            {
                return null;
            }
            if (values.Length == 1)
            {
                values = values[0].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            return values;
        }

        public static string GetCombined(this IDictionary<string, string[]> headerDictionary, string headerName, string separator = ",")
        {
            string[] values;
            if (!headerDictionary.TryGetValue(headerName, out values))
            {
                return null;
            }
            return Combine(values, separator);
        }

        public static string Combine(this string[] values, string separator = ",")
        {
            if (values.Length == 1)
            {
                return values[0];
            }
            return string.Join(separator, values, 0, values.Length);
        }

        public static string[] ParseMultiValue(string value)
        {
            string[] result = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i].Trim();
            }
            return result;
        }

        public static Dictionary<string, string[]> ToDictionary(this IEnumerable<KeyValuePair<string, string[]>> enumerable)
        {
            Contract.Requires(enumerable != null);

            var result = new Dictionary<string, string[]>();
            foreach (KeyValuePair<string, string[]> paramPair in enumerable)
            {
                result.Append(paramPair.Key, paramPair.Value);
            }
            return result;
        }
    }
}