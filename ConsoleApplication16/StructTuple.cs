﻿namespace ConsoleApplication16
{
    using System;
    using System.Text;

    public static class StructTuple
    {
        public static StructTuple<T1, T2> Create<T1, T2>(T1 first, T2 second)
            where T1 : IEquatable<T1>
            where T2 : IEquatable<T2>
        {
            return new StructTuple<T1, T2>(first, second);
        }

        public static StructTuple<T1, T2, T3> Create<T1, T2, T3>(T1 first, T2 second, T3 third)
            where T1 : IEquatable<T1>
            where T2 : IEquatable<T2>
            where T3 : IEquatable<T3>
        {
            return new StructTuple<T1, T2, T3>(first, second, third);
        }

        public static StructTuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 first, T2 second, T3 third, T4 fourth)
            where T1 : IEquatable<T1>
            where T2 : IEquatable<T2>
            where T3 : IEquatable<T3>
            where T4 : IEquatable<T4>
        {
            return new StructTuple<T1, T2, T3, T4>(first, second, third, fourth);
        }
    }

    [Serializable]
    public struct StructTuple<T1, T2> : IEquatable<StructTuple<T1, T2>>
        where T1 : IEquatable<T1>
        where T2 : IEquatable<T2>
    {
        public readonly T1 First;

        public readonly T2 Second;

        public StructTuple(T1 first, T2 second)
        {
            this.First = first;
            this.Second = second;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;
            if (!(other is StructTuple<T1, T2>))
                return false;
            return this.Equals((StructTuple<T1, T2>)other);
        }

        public override int GetHashCode()
        {
            return CombineHashCodes(this.First.GetHashCode(), this.Second.GetHashCode());
        }

        static int CombineHashCodes(int h1, int h2)
        {
            return ((h1 << 5) + h1) ^ h2;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder('(')
                .Append(this.First)
                .Append(", ")
                .Append(this.Second)
                .Append(')');
            return sb.ToString();
        }

        public bool Equals(StructTuple<T1, T2> other)
        {
            // todo: danger: first or second might be null
            return other.First.Equals(this.First) && other.Second.Equals(this.Second);
        }
    }

    [Serializable]
    public struct StructTuple<T1, T2, T3> : IEquatable<StructTuple<T1, T2, T3>>
        where T1 : IEquatable<T1>
        where T2 : IEquatable<T2>
        where T3 : IEquatable<T3>
    {
        public readonly T1 First;

        public readonly T2 Second;

        public readonly T3 Third;

        public StructTuple(T1 first, T2 second, T3 third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;
            if (!(other is StructTuple<T1, T2, T3>))
                return false;
            return this.Equals((StructTuple<T1, T2, T3>)other);
        }

        public override int GetHashCode()
        {
            return CombineHashCodes(
                CombineHashCodes(this.First.GetHashCode(), this.Second.GetHashCode()), this.Third.GetHashCode());
        }

        static int CombineHashCodes(int h1, int h2)
        {
            return ((h1 << 5) + h1) ^ h2;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder('(')
                .Append(this.First)
                .Append(", ")
                .Append(this.Second)
                .Append(", ")
                .Append(this.Third)
                .Append(')');
            return sb.ToString();
        }

        public bool Equals(StructTuple<T1, T2, T3> other)
        {
            // todo: danger: first or second might be null
            return other.First.Equals(this.First) && other.Second.Equals(this.Second) && other.Third.Equals(this.Third);
        }
    }

    [Serializable]
    public struct StructTuple<T1, T2, T3, T4> : IEquatable<StructTuple<T1, T2, T3, T4>>
        where T1 : IEquatable<T1>
        where T2 : IEquatable<T2>
        where T3 : IEquatable<T3>
        where T4 : IEquatable<T4>
    {
        public readonly T1 First;

        public readonly T2 Second;

        public readonly T3 Third;

        public readonly T4 Fourth;

        public StructTuple(T1 first, T2 second, T3 third, T4 fourth)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;
            if (!(other is StructTuple<T1, T2, T3, T4>))
                return false;
            return this.Equals((StructTuple<T1, T2, T3, T4>)other);
        }

        public override int GetHashCode()
        {
            return CombineHashCodes(CombineHashCodes(this.First.GetHashCode(), this.Second.GetHashCode()),
                CombineHashCodes(this.Third.GetHashCode(), this.Fourth.GetHashCode()));
        }

        static int CombineHashCodes(int h1, int h2)
        {
            return ((h1 << 5) + h1) ^ h2;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder('(')
                .Append(this.First)
                .Append(", ")
                .Append(this.Second)
                .Append(", ")
                .Append(this.Third)
                .Append(", ")
                .Append(this.Fourth)
                .Append(')');
            return sb.ToString();
        }

        public bool Equals(StructTuple<T1, T2, T3, T4> other)
        {
            // todo: danger: first or second might be null
            return other.First.Equals(this.First) && other.Second.Equals(this.Second) && other.Third.Equals(this.Third) && other.Fourth.Equals(this.Fourth);
        }
    }
}