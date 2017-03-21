namespace ConsoleApplication16
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Runtime.ExceptionServices;

    public struct Try<T>
    {
        readonly T value;

        public Try(T value)
        {
            this.value = value;
            this.Exception = null;
        }

        public Try(Exception exception)
        {
            Contract.Assert(exception != null);

            this.value = default(T);
            this.Exception = exception;
        }

        public T Value
        {
            get
            {
                if (this.Exception != null)
                {
                    ExceptionDispatchInfo.Capture(this.Exception).Throw();
                }
                return this.value;
            }
        }

        public Exception Exception { get; }

        public bool Success => this.Exception == null;

        public static Try<T> Failure(Exception exception) => new Try<T>(exception);

        public static implicit operator Try<T>(T value) => new Try<T>(value);
    }

    public static class Try
    {
        public static Try<T> Success<T>(T value)
        {
            return new Try<T>(value);
        }
    }
}