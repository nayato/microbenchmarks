namespace ConsoleApplication16
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Text;

    public struct SubString
    {
        readonly string source;
        readonly int offset;
        readonly int length;

        public SubString(string source, int offset, int length)
            : this()
        {
            this.offset = offset;
            this.length = length;
            this.source = source;
        }

        public static readonly SubString Empty = new SubString(string.Empty, 0, 0);

        public int Length
        {
            get { return this.length; }
        }

        public bool Equals(SubString other)
        {
            return this.Equals(other, StringComparison.Ordinal);
        }

        public bool Equals(SubString other, StringComparison stringComparison)
        {
            if (this.length != other.length)
            {
                return false;
            }
            return string.Compare(this.source, this.offset, other.source, other.offset, this.length, stringComparison) == 0;
        }

        public int Compare(SubString other, StringComparison stringComparison)
        {
            int compareResult = string.Compare(this.source, this.offset, other.source, other.offset, this.length, stringComparison);
            if (compareResult == 0)
            {
                return this.length - other.length;
            }
            return compareResult;
        }

        public int Compare(string other, StringComparison stringComparison)
        {
            throw new NotImplementedException();
        }

        public int Compare(int index, string other, int indexOther, int length, StringComparison stringComparison)
        {
            Contract.Requires(index >= 0 && index < this.length);
            Contract.Requires(length + index <= this.length);
            Contract.Requires(length > 0);

            return string.Compare(this.source, this.offset + index, other, indexOther, length, stringComparison);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                unsafe
                {
                    fixed (char* src = this.source)
                    {
                        Contract.Assert(src[this.source.Length] == '\0', "src[this.Length] == '\\0'");
                        Contract.Assert(((int)src) % 4 == 0, "Managed string should start at 4 bytes boundary");

                        int hash1 = 5381;
                        int hash2 = hash1;

                        int c;
                        char* s = src + this.offset;
                        int toRead = this.length;
                        while (toRead > 1)
                        {
                            c = s[0];
                            if (c == 0)
                            {
                                break;
                            }
                            hash1 = ((hash1 << 5) + hash1) ^ c;
                            c = s[1];
                            if (c == 0)
                            {
                                break;
                            }
                            hash2 = ((hash2 << 5) + hash2) ^ c;
                            toRead -= 2;
                            s += 2;
                        }

                        if (toRead == 1)
                        {
                            c = s[0];
                            hash1 = ((hash1 << 5) + hash1) ^ c;
                        }
                        return hash1 + (hash2 * 1566083941);
                    }
                }
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
            Contract.Requires(startIndex < length || (length == 0 && startIndex == 0));

            return new SubString(this.source, this.offset + startIndex, this.length - startIndex);
        }

        public SubString Substring(int startIndex, int count)
        {
            if (count == 0)
            {
                return Empty;
            }
            return new SubString(this.source, this.offset + startIndex, count);
        }

        public int IndexOf(char value, int startIndex, int count)
        {
            Contract.Requires(startIndex >= 0);
            Contract.Requires(count >= 0);
            Contract.Requires(count <= this.length - startIndex);

            return this.source.IndexOf(value, startIndex + this.offset, count);
        }

        void AppendToStringBuilder(StringBuilder stringBuilder)
        {
            stringBuilder.Append(this.source, this.offset, this.length);
        }

        public override string ToString()
        {
            return this.source.Substring(this.offset, this.length);
        }
    }
}