namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MaybeLazy<T>
    {
        private MaybeStruct<T> _maybe;
        private Func<T> _func;

        public MaybeLazy(Func<T> func)
        {
            _func = func;
        }

        public T Value
        {
            get
            {
                if (!_maybe.HasValue)
                    _maybe = MaybeStruct.Some(_func());
                return _maybe.Value;
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
            private None()
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
            private readonly T _value;

            /// <summary>
            ///     Creates a new Some object.
            /// </summary>
            /// <param name="value">Object stored in Some.</param>
            public Some(T value)
            {
                _value = value;
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
                get { return _value; }
            }

            /// <summary>
            ///     Provides a friendly string representation.
            /// </summary>
            /// <returns>None&lt;T&gt;(Value)</returns>
            public override string ToString()
            {
                return "Some<" + typeof(T).Name + ">(" + (_value == null ? "null" : _value.ToString()) + ")";
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
