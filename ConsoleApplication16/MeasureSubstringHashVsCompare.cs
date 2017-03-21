namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Wintellect;

    class MeasureSubstringHashVsCompare
    {
        public static long Run()
        {
            long ran = 0;
            const int Iterations = 15 * 1000 * 1000;

            const string Value = "suubscriptionkey345keygfql3i4ufgdf3187632541236451287364182345192e6rgiquf4ro8q2trp9q83yrr34r4gw45g34fw3sfdsfr34rq34r34r3fq34fq3fraq34rq34rq3rfqeeeq2344234rq34fq3rfq2fq35yw45yw4frdaewdawrt35tq34aededksetroifuaewpgftiuaetfiawtefoiuwayefyagwieuftwae";

            var comparer = new OrdinalIgnoreCaseSubStringComparer();

            for (int matchLength = 2; matchLength <= 20; matchLength += 2)
                //for (int matchCount = 1; matchCount <= 10; matchCount++)
            for (int matchCount = 10; matchCount <= 10; matchCount++)
            {
                Tuple<SubString, int>[] matches = Enumerable.Range(1, matchCount).Select(i => new SubString(Value, i, matchLength)).Select(x => Tuple.Create(x, 1)).ToArray();
                var lookupArray = new Tuple<SubString, int>[matchLength][];
                lookupArray[matchLength - 1] = matches;

                var map = new Dictionary<SubString, int>(comparer);
                var mapGuard = new Dictionary<Tuple<char, char>, int>();

                foreach (Tuple<SubString, int> match in matches)
                {
                    mapGuard.Add(Tuple.Create(char.ToLowerInvariant(match.Item1[0]), char.ToLowerInvariant(match.Item1[match.Item1.Length - 1])), 1);
                    map.Add(match.Item1, match.Item2);
                }
                var mapSorted = new SortedList<SubString, int>(map, comparer);

                //var tree = new SubStringTree(map);

                //CodeTimer.Time(true, FormatTitle("sub tre", matchLength, matchCount), Iterations, () =>
                //{
                //    var candidateA = new SubString(Value, matchCount, matchLength);
                //    int v;
                //    tree.TryGetValue(candidateA, out v);
                //});

                var mapS = new Dictionary<string, int>(map.ToDictionary(s => s.Key.ToString(), s => s.Value), StringComparer.OrdinalIgnoreCase);
                CodeTimer.Time(true, FormatTitle("str lkp", matchLength, matchCount), Iterations, () =>
                {
                    string candidateS = Value.Substring(matchCount, matchLength);
                    int v;
                    mapS.TryGetValue(candidateS, out v);
                });

                //var matchesS = matches.Select(x => Tuple.Create(x.Item1.ToString(), x.Item2)).ToArray();
                //CodeTimer.Time(true, FormatTitle("str cmp", matchLength, matchCount), Iterations, () =>
                //{
                //    var candidateS = Value.Substring(matchCount, matchLength);
                //    var lookupList = matchesS;
                //    foreach (var matchL in lookupList)
                //    {
                //        var matchString = matchL.Item1;
                //        //int length = matchString.Length;
                //        //if (length > 2)
                //        //{
                //        //    if (OrdinalIgnoreCaseSubStringComparer.ToLower(matchString[0]) != OrdinalIgnoreCaseSubStringComparer.ToLower(candidateS[0])
                //        //        || OrdinalIgnoreCaseSubStringComparer.ToLower(matchString[length - 1]) != OrdinalIgnoreCaseSubStringComparer.ToLower(candidateS[length - 1]))
                //        //    {
                //        //        continue;
                //        //    }
                //        //}
                //        if (StringComparer.OrdinalIgnoreCase.Equals(candidateS, matchString))
                //        //if (StringComparer.OrdinalIgnoreCase.Equals(candidateS.Substring(1, length - 2), matchString.Substring(1, length - 2)))
                //        {
                //            break;
                //        }
                //    }
                //});

                //CodeTimer.Time(true, FormatTitle("sub cmp", matchLength, matchCount), Iterations, () =>
                //{
                //    var candidate = new SubString(Value, matchCount, matchLength);
                //    Tuple<SubString, int>[] lookupList = lookupArray[candidate.Length - 1];
                //    if (lookupList != null)
                //    {
                //        foreach (var matchL in lookupList)
                //        {
                //            SubString matchString = matchL.Item1;
                //            //int length = matchString.Length;
                //            //if (length > 2)
                //            //{
                //            //    if (OrdinalIgnoreCaseSubStringComparer.ToLower(matchString[0]) != OrdinalIgnoreCaseSubStringComparer.ToLower(candidate[0])
                //            //        || OrdinalIgnoreCaseSubStringComparer.ToLower(matchString[length - 1]) != OrdinalIgnoreCaseSubStringComparer.ToLower(candidate[length - 1]))
                //            //    {
                //            //        continue;
                //            //    }
                //            //}
                //            if (comparer.Equals(candidate, matchString))
                //            //if (comparer.Equals(candidate.Substring(1, length - 2), matchL.Substring(1, length - 2)))
                //            {
                //                break;
                //            }
                //        }
                //    }
                //});

                CodeTimer.Time(true, FormatTitle("sub lkp", matchLength, matchCount), Iterations, () =>
                {
                    var candidateA = new SubString(Value, matchCount, matchLength);
                    int v;
                    map.TryGetValue(candidateA, out v);
                });

                //CodeTimer.Time(true, FormatTitle("sub srt", matchLength, matchCount), Iterations, () =>
                //{
                //    var candidateA = new SubString(Value, matchCount, matchLength);
                //    int v;
                //    mapSorted.TryGetValue(candidateA, out v);
                //});
            }
            return ran;
        }

        static string FormatTitle(string title, int matchLength, int matchCount)
        {
            return title + '\t' + matchLength + '\t' + matchCount;
        }
    }

    public class SubStringTree
    {
        readonly Node root;
        readonly FixedLengthComparer comparer = new FixedLengthComparer(new OrdinalIgnoreCaseSubStringComparer());

        public SubStringTree(IEnumerable<KeyValuePair<SubString, int>> strings)
        {
            this.root = new Node(this.comparer);
            this.MapTree(this.root, strings);
            foreach (KeyValuePair<SubString, Node> child in this.root.Children.ToArray())
            {
                this.Optimize(child.Key, child.Value, this.root);
            }
            this.comparer.Enabled = true;
        }

        void Optimize(SubString key, Node current, Node parent)
        {
            if (!current.Value.HasValue && current.Children.Count == 1)
            {
                KeyValuePair<SubString, Node> pair = current.Children.First();
                Node node = pair.Value;
                parent.Children.Remove(key);
                var newKey = new SubString(key.ToString() + pair.Key.ToString());
                node.PrefixLength = newKey.Length;
                parent.Children.Add(newKey, node);
                this.Optimize(newKey, node, parent);
            }
            else
            {
                foreach (KeyValuePair<SubString, Node> child in current.Children.ToArray())
                {
                    this.Optimize(child.Key, child.Value, current);
                }
            }
        }

        void MapTree(Node current, IEnumerable<KeyValuePair<SubString, int>> strings)
        {
            //current.CanSelfMatch = strings.Any(s => s.Length == 0);
            Dictionary<SubString, Node> charGroups = (
                    from s in strings
                    where s.Key.Length > 0
                    let c = char.ToLowerInvariant(s.Key[0])
                    let r = new KeyValuePair<SubString, int>(s.Key.Substring(1), s.Value)
                    group r by c)
                .ToDictionary(
                    g => new SubString(g.Key.ToString(CultureInfo.InvariantCulture)),
                    g =>
                    {
                        var node = new Node(this.comparer);
                        node.PrefixLength = 1;
                        KeyValuePair<SubString, int>[] remainder = g.ToArray();
                        int ownValue = remainder.Where(x => x.Key.Length == 0).Select(x => x.Value).DefaultIfEmpty(-1).First();
                        if (ownValue > -1)
                        {
                            node.Value = ownValue;
                        }
                        this.MapTree(node, g.ToArray());
                        return node;
                    });
            current.Children = new SortedList<SubString, Node>(charGroups, this.comparer);
        }

        public bool TryGetValue(SubString key, out int value)
        {
            Node current = this.root;
            do
            {
                Node newCurrent;
                if (current.Children.TryGetValue(key, out newCurrent))
                {
                    current = newCurrent;
                    int matchRemainder = key.Length - current.PrefixLength;
                    if (matchRemainder == 0)
                    {
                        if (current.Value.HasValue)
                        {
                            value = current.Value.Value;
                            return true;
                        }
                        else
                        {
                            value = default(int);
                            return false;
                        }
                    }
                    key = key.Substring(current.PrefixLength, matchRemainder);
                }
                else
                {
                    value = default(int);
                    return false;
                }
            }
            while (current.Children.Count > 0);

            value = default(int);
            return false;
        }

        class Node
        {
            public Node(IComparer<SubString> comparer)
            {
                this.Children = new SortedList<SubString, Node>(comparer);
            }

            public int? Value;

            public int PrefixLength;

            public SortedList<SubString, Node> Children;
        }

        class FixedLengthComparer : IComparer<SubString>
        {
            readonly IComparer<SubString> innerComparer;
            public bool Enabled;

            public FixedLengthComparer(IComparer<SubString> innerComparer)
            {
                this.innerComparer = innerComparer;
            }

            public int Compare(SubString x, SubString y)
            {
                if (this.Enabled)
                {
                    return this.innerComparer.Compare(x, y.Substring(0, Math.Min(y.Length, x.Length)));
                }
                return this.innerComparer.Compare(x, y);
            }
        }
    }
}