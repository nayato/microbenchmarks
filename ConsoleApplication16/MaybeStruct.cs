namespace ConsoleApplication16
{
    /// <summary>
    ///     Optional object type.
    /// </summary>
    /// <typeparam name="T">Type of the object.</typeparam>
    public struct MaybeStruct<T>
    {
        public MaybeStruct(T value)
        {
            this.HasValue = false;
            this.Value = value;
        }

        /// <summary>
        ///     Gets whether an object is present.
        /// </summary>
        public readonly bool HasValue;

        /// <summary>
        ///     Gets the object.
        /// </summary>
        public readonly T Value;

        public static readonly MaybeStruct<T> None = new MaybeStruct<T>();
    }

    public static class MaybeStruct
    {
        public static MaybeStruct<T> Some<T>(T value)
        {
            return new MaybeStruct<T>(value);
        }

        public static MaybeStruct<T> None<T>()
        {
            return MaybeStruct<T>.None;
        }
    }
}