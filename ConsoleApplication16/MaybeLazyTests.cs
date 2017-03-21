namespace ConsoleApplication16
{
    using System;

    class LazyHost
    {
        readonly Lazy<string> s = new Lazy<string>(() => string.Empty, false);
        readonly Lazy<DateTime> d = new Lazy<DateTime>(() => DateTime.Now, false);
        readonly Lazy<DateTime> d2 = new Lazy<DateTime>(() => DateTime.Now, false);

        public string S
        {
            get { return this.s.Value; }
        }

        public DateTime D
        {
            get { return this.d.Value; }
        }

        public DateTime D2
        {
            get { return this.d2.Value; }
        }
    }

    class MaybeLazyHost
    {
        readonly MaybeLazy<string> s = new MaybeLazy<string>(() => string.Empty);
        readonly MaybeLazy<DateTime> d = new MaybeLazy<DateTime>(() => DateTime.Now);
        readonly MaybeLazy<DateTime> d2 = new MaybeLazy<DateTime>(() => DateTime.Now);

        public string S
        {
            get { return this.s.Value; }
        }

        public DateTime D
        {
            get { return this.d.Value; }
        }

        public DateTime D2
        {
            get { return this.d2.Value; }
        }
    }

    class MaybeHost
    {
        Maybe<string> s = Maybe.None<string>();
        Maybe<DateTime> d = Maybe.None<DateTime>();
        Maybe<DateTime> d2 = Maybe.None<DateTime>();

        public string S
        {
            get
            {
                if (!this.s.HasValue)
                    this.s = Maybe.Some(string.Empty);
                return this.s.Value;
            }
        }

        public DateTime D
        {
            get
            {
                if (!this.d.HasValue)
                    this.d = Maybe.Some(DateTime.Now);
                return this.d.Value;
            }
        }

        public DateTime D2
        {
            get
            {
                if (!this.d2.HasValue)
                    this.d2 = Maybe.Some(DateTime.Now);
                return this.d2.Value;
            }
        }
    }

    class MaybeStructHost
    {
        MaybeStruct<string> s;
        MaybeStruct<DateTime> d;
        MaybeStruct<DateTime> d2;

        public string S
        {
            get
            {
                if (!this.s.HasValue)
                    this.s = MaybeStruct.Some(string.Empty);
                return this.s.Value;
            }
        }

        public DateTime D
        {
            get
            {
                if (!this.d.HasValue)
                    this.d = MaybeStruct.Some(DateTime.Now);
                return this.d.Value;
            }
        }

        public DateTime D2
        {
            get
            {
                if (!this.d2.HasValue)
                    this.d2 = MaybeStruct.Some(DateTime.Now);
                return this.d2.Value;
            }
        }
    }
}