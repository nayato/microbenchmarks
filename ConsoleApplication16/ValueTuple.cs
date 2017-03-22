namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public static class ValueTuple
    {
        public static ValueTuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2) => new ValueTuple<T1, T2>(item1, item2);

        public static ValueTuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
            => new ValueTuple<T1, T2, T3>(item1, item2, item3);

        public static ValueTuple<T1, T2, T3, T4> Create<T1, T2, T3, T4>(T1 item1, T2 item2, T3 item3, T4 item4)
            => new ValueTuple<T1, T2, T3, T4>(item1, item2, item3, item4);
    }

    public struct ValueTuple<T1, T2> : IEquatable<ValueTuple<T1, T2>>
    {
        static readonly EqualityComparer<T1> Comparer1 = EqualityComparer<T1>.Default;
        static readonly EqualityComparer<T2> Comparer2 = EqualityComparer<T2>.Default;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T1 Item1;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T2 Item2;

        public ValueTuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public bool Equals(ValueTuple<T1, T2> other)
        {
            return Comparer1.Equals(this.Item1, other.Item1)
                && Comparer2.Equals(this.Item2, other.Item2);
        }

        public override bool Equals(object obj)
        {
            if (obj is ValueTuple<T1, T2>)
            {
                var other = (ValueTuple<T1, T2>)obj;
                return this.Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
            => HashCode.CombineHashCodes(Comparer1.GetHashCode(this.Item1), Comparer2.GetHashCode(this.Item2));

        public static bool operator ==(ValueTuple<T1, T2> left, ValueTuple<T1, T2> right) => left.Equals(right);

        public static bool operator !=(ValueTuple<T1, T2> left, ValueTuple<T1, T2> right) => !left.Equals(right);
    }

    [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
        Justification = "It is a helper struct")]
    public struct ValueTuple<T1, T2, T3> : IEquatable<ValueTuple<T1, T2, T3>>
    {
        static readonly EqualityComparer<T1> Comparer1 = EqualityComparer<T1>.Default;
        static readonly EqualityComparer<T2> Comparer2 = EqualityComparer<T2>.Default;
        static readonly EqualityComparer<T3> Comparer3 = EqualityComparer<T3>.Default;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T1 Item1;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T2 Item2;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T3 Item3;

        public ValueTuple(T1 item1, T2 item2, T3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public bool Equals(ValueTuple<T1, T2, T3> other)
        {
            return Comparer1.Equals(this.Item1, other.Item1)
                && Comparer2.Equals(this.Item2, other.Item2)
                && Comparer3.Equals(this.Item3, other.Item3);
        }

        public override bool Equals(object obj)
        {
            if (obj is ValueTuple<T1, T2, T3>)
            {
                var other = (ValueTuple<T1, T2, T3>)obj;
                return this.Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.CombineHashCodes(
                HashCode.CombineHashCodes(
                    Comparer1.GetHashCode(this.Item1),
                    Comparer2.GetHashCode(this.Item2)),
                Comparer3.GetHashCode(this.Item3));
        }

        public static bool operator ==(ValueTuple<T1, T2, T3> left, ValueTuple<T1, T2, T3> right) => left.Equals(right);

        public static bool operator !=(ValueTuple<T1, T2, T3> left, ValueTuple<T1, T2, T3> right) => !left.Equals(right);
    }

    [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
        Justification = "It is a helper struct")]
    public struct ValueTuple<T1, T2, T3, T4> : IEquatable<ValueTuple<T1, T2, T3, T4>>
    {
        static readonly EqualityComparer<T1> Comparer1 = EqualityComparer<T1>.Default;
        static readonly EqualityComparer<T2> Comparer2 = EqualityComparer<T2>.Default;
        static readonly EqualityComparer<T3> Comparer3 = EqualityComparer<T3>.Default;
        static readonly EqualityComparer<T4> Comparer4 = EqualityComparer<T4>.Default;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T1 Item1;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T2 Item2;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T3 Item3;

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Field in an immutable helper struct")]
        public readonly T4 Item4;

        public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
            this.Item4 = item4;
        }

        public bool Equals(ValueTuple<T1, T2, T3, T4> other)
        {
            return Comparer1.Equals(this.Item1, other.Item1)
                && Comparer2.Equals(this.Item2, other.Item2)
                && Comparer3.Equals(this.Item3, other.Item3)
                && Comparer4.Equals(this.Item4, other.Item4);
        }

        public override bool Equals(object obj)
        {
            if (obj is ValueTuple<T1, T2, T3, T4>)
            {
                var other = (ValueTuple<T1, T2, T3, T4>)obj;
                return this.Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.CombineHashCodes(
                HashCode.CombineHashCodes(
                    Comparer1.GetHashCode(this.Item1),
                    Comparer2.GetHashCode(this.Item2)),
                HashCode.CombineHashCodes(
                    Comparer3.GetHashCode(this.Item3),
                    Comparer4.GetHashCode(this.Item4)));
        }

        public static bool operator ==(ValueTuple<T1, T2, T3, T4> left, ValueTuple<T1, T2, T3, T4> right)
            => left.Equals(right);

        public static bool operator !=(ValueTuple<T1, T2, T3, T4> left, ValueTuple<T1, T2, T3, T4> right)
            => !left.Equals(right);
    }
}