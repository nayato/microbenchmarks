using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication16
{
    class LazyHost
    {
        private Lazy<string> s = new Lazy<string>(() => string.Empty, false);
        private Lazy<DateTime> d = new Lazy<DateTime>(() => DateTime.Now, false);
        private Lazy<DateTime> d2 = new Lazy<DateTime>(() => DateTime.Now, false);

        public string S
        {
            get { return s.Value; }
        }

        public DateTime D
        {
            get { return d.Value; }
        }

        public DateTime D2
        {
            get { return d2.Value; }
        }
    }

    class MaybeLazyHost
    {
        private MaybeLazy<string> s = new MaybeLazy<string>(() => string.Empty);
        private MaybeLazy<DateTime> d = new MaybeLazy<DateTime>(() => DateTime.Now);
        private MaybeLazy<DateTime> d2 = new MaybeLazy<DateTime>(() => DateTime.Now);

        public string S
        {
            get { return s.Value; }
        }

        public DateTime D
        {
            get { return d.Value; }
        }

        public DateTime D2
        {
            get { return d2.Value; }
        }
    }

    class MaybeHost
    {
        private Maybe<string> s = Maybe.None<string>();
        private Maybe<DateTime> d = Maybe.None<DateTime>();
        private Maybe<DateTime> d2 = Maybe.None<DateTime>();

        public string S
        {
            get
            {
                if (!s.HasValue)
                    s = Maybe.Some(string.Empty);
                return s.Value;
            }
        }

        public DateTime D
        {
            get
            {
                if (!d.HasValue)
                    d = Maybe.Some(DateTime.Now);
                return d.Value;
            }
        }

        public DateTime D2
        {
            get
            {
                if (!d2.HasValue)
                    d2 = Maybe.Some(DateTime.Now);
                return d2.Value;
            }
        }
    }

    class MaybeStructHost
    {
        private MaybeStruct<string> s;
        private MaybeStruct<DateTime> d;
        private MaybeStruct<DateTime> d2;

        public string S
        {
            get
            {
                if (!s.HasValue)
                    s = MaybeStruct.Some(string.Empty);
                return s.Value;
            }
        }

        public DateTime D
        {
            get
            {
                if (!d.HasValue)
                    d = MaybeStruct.Some(DateTime.Now);
                return d.Value;
            }
        }

        public DateTime D2
        {
            get
            {
                if (!d2.HasValue)
                    d2 = MaybeStruct.Some(DateTime.Now);
                return d2.Value;
            }
        }
    }
}
