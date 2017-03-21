namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Wintellect;

    class MeasureUriTemplateTableVsRegex
    {
        public static long Run()
        {
            long ran = 0;
            const int Iterations = 1000000; // 100 * 1000 * 1000;

            var baseUri = new Uri("http://x");
            var table = new UriTemplateTable(
                baseUri,
                new[] { "devices/{deviceId}/messages/events/{*subTopic}", "devices/{deviceId}/messages/log/{level=info}/{subject=n%2Fa}" }.Select(x => new KeyValuePair<UriTemplate, object>(new UriTemplate(x, false), x)));
            table.MakeReadOnly(true);
            Regex[] regexes = new[] { "^devices/(?<deviceId>[^/]*)/messages/events/(?<subTopic>.*)$", "^devices/(?<deviceId>[^/]*)/messages/log(/(?<level>[^/]*)(/(?<level>[^/]*))?)?$" }.Select(x => new Regex(x, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.CultureInvariant)).ToArray();

            var values = new[] { "devices/WAUCB28D7XA451194/messages/events/some/other/segments", "devices/WAUCB28D7XA451194/messages/log/warning/oilPressureAlert" };

            CodeTimer.Time(true, "table", Iterations, () =>
            {
                foreach (string value in values)
                {
                    Collection<UriTemplateMatch> matches = table.Match(new Uri(baseUri, value));
                    if (matches.Count == 0)
                    {
                        continue;
                    }
                    if (matches.Count > 1)
                    {
                        //
                    }
                    UriTemplateMatch match = matches[0];
                    string deviceId = match.BoundVariables["deviceId"];
                    if (deviceId[0] == 'W')
                    {
                        unchecked
                        {
                            ran++;
                        }
                    }
                }
            });

            CodeTimer.Time(true, "regex", Iterations, () =>
            {
                foreach (string value in values)
                {
                    foreach (Regex regex in regexes)
                    {
                        Match match = regex.Match(value);
                        if (!match.Success)
                        {
                            continue;
                        }
                        string deviceId = match.Groups["deviceId"].Value;
                        if (deviceId[0] == 'W')
                        {
                            unchecked
                            {
                                ran++;
                            }
                        }
                        break;
                    }
                }
            });

            return ran;
        }
    }
}