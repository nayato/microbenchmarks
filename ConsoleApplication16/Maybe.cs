namespace ConsoleApplication16
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class MaybeLazy<T>
    {
        MaybeStruct<T> maybe;
        readonly Func<T> func;

        public MaybeLazy(Func<T> func)
        {
            this.func = func;
        }

        public T Value
        {
            get
            {
                if (!this.maybe.HasValue)
                {
                    this.maybe = MaybeStruct.Some(this.func());
                }
                return this.maybe.Value;
            }
        }
    }

    /// <summary>
    ///     Optional object type.
    /// </summary>
    /// <typeparam name="T">Type of the object.</typeparam>
    public abstract class Maybe<T>
    {
        /// <summary>
        ///     Gets whether an object is present.
        /// </summary>
        public abstract bool HasValue { get; }

        /// <summary>
        ///     Gets the object.
        /// </summary>
        public abstract T Value { get; }

        /// <summary>
        ///     None optional type.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class None : Maybe<T>
        {
            None()
            {
            }

            /// <summary>
            ///     Gets whether an object is present. Always returns false for None.
            /// </summary>
            public override bool HasValue
            {
                get { return false; }
            }

            /// <summary>
            ///     Gets the object. Always throws InvalidOperationException for None.
            /// </summary>
            public override T Value
            {
                get { throw new InvalidOperationException(); }
            }

            /// <summary>
            ///     Provides a friendly string representation.
            /// </summary>
            /// <returns>None&lt;T&gt;</returns>
            public override string ToString()
            {
                return "None<" + typeof(T).Name + ">()";
            }

            // ReSharper disable StaticFieldInGenericType
            public static readonly None Instance = new None();
            // ReSharper restore StaticFieldInGenericType
        }

        /// <summary>
        ///     Some optional type.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public sealed class Some : Maybe<T>
        {
            /// <summary>
            ///     Object stored in Some.
            /// </summary>
            readonly T _value;

            /// <summary>
            ///     Creates a new Some object.
            /// </summary>
            /// <param name="value">Object stored in Some.</param>
            public Some(T value)
            {
                this._value = value;
            }

            /// <summary>
            ///     Gets whether an object is present. Always returns true for Some.
            /// </summary>
            public override bool HasValue
            {
                get { return true; }
            }

            /// <summary>
            ///     Gets the object.
            /// </summary>
            public override T Value
            {
                get { return this._value; }
            }

            /// <summary>
            ///     Provides a friendly string representation.
            /// </summary>
            /// <returns>None&lt;T&gt;(Value)</returns>
            public override string ToString()
            {
                return "Some<" + typeof(T).Name + ">(" + (this._value == null ? "null" : this._value.ToString()) + ")";
            }
        }
    }

    public static class Maybe
    {
        public static Maybe<T> Some<T>(T value)
        {
            return new Maybe<T>.Some(value);
        }

        public static Maybe<T> None<T>()
        {
            return Maybe<T>.None.Instance;
        }
    }
}