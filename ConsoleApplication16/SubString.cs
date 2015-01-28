namespace ConsoleApplication16
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Text;

    public struct SubString : IEquatable<SubString>
    {
        internal readonly string Source;
        internal readonly int Offset;
        public readonly int Length;

        public SubString(string source)
            : this(source, 0, source.Length)
        {
        }

        public SubString(string source, int offset, int length)
            : this()
        {
            this.Offset = offset;
            this.Length = length;
            this.Source = source;
        }

        public static readonly SubString Empty = new SubString(string.Empty, 0, 0);

        public char this[int index]
        {
            get { return this.Source[this.Offset + index]; }
        }

        public bool Equals(SubString other)
        {
            return this.Equals(other, StringComparison.Ordinal);
        }

        public bool Equals(SubString other, StringComparison stringComparison)
        {
            if (this.Length != other.Length)
            {
                return false;
            }
            return string.Compare(this.Source, this.Offset, other.Source, other.Offset, this.Length, stringComparison) == 0;
        }

        public int Compare(SubString other, StringComparison stringComparison)
        {
            int compareResult = string.Compare(this.Source, this.Offset, other.Source, other.Offset, this.Length, stringComparison);
            if (compareResult == 0)
            {
                return this.Length - other.Length;
            }
            return compareResult;
        }

        public int Compare(string other, StringComparison stringComparison)
        {
            throw new NotImplementedException();
        }

        public int Compare(int index, string other, int indexOther, int length, StringComparison stringComparison)
        {
            Contract.Requires(index >= 0 && index < this.Length);
            Contract.Requires(length + index <= this.Length);
            Contract.Requires(length > 0);

            return string.Compare(this.Source, this.Offset + index, other, indexOther, length, stringComparison);
        }

        public override unsafe int GetHashCode()
        {
            fixed (char* c = this.Source)
            {
                char* cc = c + this.Offset;
                char* end = cc + this.Length - 1;
                int h = 0;
                for (; cc < end; cc += 2)
                {
                    h = (h << 5) - h + *cc;
                    h = (h << 5) - h + cc[1];
                }
                ++end;
                if (cc < end)
                {
                    h = (h << 5) - h + *cc;
                }
                return h;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is SubString && this.Equals((SubString)obj);
        }

        public SubString Substring(int startIndex)
        {
            Contract.Requires(startIndex < this.Length || (this.Length == 0 && startIndex == 0));

            return new SubString(this.Source, this.Offset + startIndex, this.Length - startIndex);
        }

        public SubString Substring(int startIndex, int count)
        {
            if (count == 0)
            {
                return Empty;
            }
            return new SubString(this.Source, this.Offset + startIndex, count);
        }

        public int IndexOf(char value, int startIndex, int count)
        {
            Contract.Requires(startIndex >= 0);
            Contract.Requires(count >= 0);
            Contract.Requires(count <= this.Length - startIndex);

            return this.Source.IndexOf(value, startIndex + this.Offset, count);
        }

        void AppendToStringBuilder(StringBuilder stringBuilder)
        {
            stringBuilder.Append(this.Source, this.Offset, this.Length);
        }

        public override string ToString()
        {
            return this.Source.Substring(this.Offset, this.Length);
        }
    }
}