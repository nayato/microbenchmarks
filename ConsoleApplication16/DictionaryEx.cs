namespace ConsoleApplication16
{
    // Type: System.Collections.Generic.DictionaryEx`2
    // Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    // MVID: BC586C7A-E51D-48AE-A4CF-B09CF3223BAA
    // Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime;
    using System.Runtime.InteropServices;
    using System.Threading;

    /// <summary>
    ///     Represents a collection of keys and values.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <filterpriority>1</filterpriority>
    [DebuggerDisplay("Count = {Count}")]
    [ComVisible(false)]
    [Serializable]
    public class DictionaryEx<TKey, TValue> : IDictionary<TKey, TValue>, ICollection, IReadOnlyDictionary<TKey, TValue>
    {
        int[] buckets;
        Entry[] entries;
        int count;
        int version;
        int freeList;
        int freeCount;
        readonly IEqualityComparer<TKey> comparer;
        KeyCollection keys;
        ValueCollection values;
        object _syncRoot;
        const string VersionName = "Version";
        const string HashSizeName = "HashSize";
        const string KeyValuePairsName = "KeyValuePairs";
        const string ComparerName = "Comparer";

        /// <summary>
        ///     Gets the <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> that is used to determine equality of keys
        ///     for the dictionary.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> generic interface implementation that is used
        ///     to determine equality of keys for the current <see cref="T:System.Collections.Generic.DictionaryEx`2" /> and to
        ///     provide hash values for the keys.
        /// </returns>
        public IEqualityComparer<TKey> Comparer
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get { return this.comparer; }
        }

        /// <summary>
        ///     Gets the number of key/value pairs contained in the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </summary>
        /// <returns>
        ///     The number of key/value pairs contained in the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </returns>
        public int Count
        {
            get { return this.count - this.freeCount; }
        }

        /// <summary>
        ///     Gets a collection containing the keys in the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" /> containing the keys in the
        ///     <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </returns>
        public KeyCollection Keys
        {
            get
            {
                if (this.keys == null)
                    this.keys = new KeyCollection(this);
                return this.keys;
            }
        }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get
            {
                if (this.keys == null)
                    this.keys = new KeyCollection(this);
                return (ICollection<TKey>)this.keys;
            }
        }

        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys
        {
            get
            {
                if (this.keys == null)
                    this.keys = new KeyCollection(this);
                return this.keys;
            }
        }

        /// <summary>
        ///     Gets a collection containing the values in the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" /> containing the values in the
        ///     <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </returns>
        public ValueCollection Values
        {
            get
            {
                if (this.values == null)
                    this.values = new ValueCollection(this);
                return this.values;
            }
        }

        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get
            {
                if (this.values == null)
                    this.values = new ValueCollection(this);
                return this.values;
            }
        }

        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values
        {
            get
            {
                if (this.values == null)
                    this.values = new ValueCollection(this);
                return this.values;
            }
        }

        /// <summary>
        ///     Gets or sets the value associated with the specified key.
        /// </summary>
        /// <returns>
        ///     The value associated with the specified key. If the specified key is not found, a get operation throws a
        ///     <see cref="T:System.Collections.Generic.KeyNotFoundException" />, and a set operation creates a new element with
        ///     the specified key.
        /// </returns>
        /// <param name="key">The key of the value to get or set.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key" /> is null.</exception>
        /// <exception cref="T:System.Collections.Generic.KeyNotFoundException">
        ///     The property is retrieved and
        ///     <paramref name="key" /> does not exist in the collection.
        /// </exception>
        public TValue this[TKey key]
        {
            get
            {
                int entry = this.FindEntry(key);
                if (entry >= 0)
                    return this.entries[entry].value;
                throw new KeyNotFoundException();
            }

            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] set { this.Insert(key, value, false); }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get { return false; }
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        object ICollection.SyncRoot
        {
            get
            {
                if (this._syncRoot == null)
                    Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), (object)null);
                return this._syncRoot;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> class that is empty,
        ///     has
        ///     the default initial capacity, and uses the default equality comparer for the key type.
        /// </summary>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public DictionaryEx()
            : this(0, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> class that is empty,
        ///     has
        ///     the specified initial capacity, and uses the default equality comparer for the key type.
        /// </summary>
        /// <param name="capacity">
        ///     The initial number of elements that the <see cref="T:System.Collections.Generic.DictionaryEx`2" />
        ///     can contain.
        /// </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="capacity" /> is less than 0.</exception>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public DictionaryEx(int capacity)
            : this(capacity, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> class that is empty,
        ///     has
        ///     the default initial capacity, and uses the specified
        ///     <see cref="T:System.Collections.Generic.IEqualityComparer`1" />.
        /// </summary>
        /// <param name="comparer">
        ///     The <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> implementation to use when
        ///     comparing keys, or null to use the default <see cref="T:System.Collections.Generic.EqualityComparer`1" /> for the
        ///     type of the key.
        /// </param>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public DictionaryEx(IEqualityComparer<TKey> comparer)
            : this(0, comparer)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> class that is empty,
        ///     has
        ///     the specified initial capacity, and uses the specified
        ///     <see cref="T:System.Collections.Generic.IEqualityComparer`1" />.
        /// </summary>
        /// <param name="capacity">
        ///     The initial number of elements that the <see cref="T:System.Collections.Generic.DictionaryEx`2" />
        ///     can contain.
        /// </param>
        /// <param name="comparer">
        ///     The <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> implementation to use when
        ///     comparing keys, or null to use the default <see cref="T:System.Collections.Generic.EqualityComparer`1" /> for the
        ///     type of the key.
        /// </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="capacity" /> is less than 0.</exception>
        public DictionaryEx(int capacity, IEqualityComparer<TKey> comparer)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("capacity");
            if (capacity > 0)
                this.Initialize(capacity);
            this.comparer = comparer ?? EqualityComparer<TKey>.Default;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> class that contains
        ///     elements copied from the specified <see cref="T:System.Collections.Generic.IDictionary`2" /> and uses the default
        ///     equality comparer for the key type.
        /// </summary>
        /// <param name="dictionary">
        ///     The <see cref="T:System.Collections.Generic.IDictionary`2" /> whose elements are copied to the
        ///     new <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="dictionary" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="dictionary" /> contains one or more duplicate keys.</exception>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public DictionaryEx(IDictionary<TKey, TValue> dictionary)
            : this(dictionary, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> class that contains
        ///     elements copied from the specified <see cref="T:System.Collections.Generic.IDictionary`2" /> and uses the specified
        ///     <see cref="T:System.Collections.Generic.IEqualityComparer`1" />.
        /// </summary>
        /// <param name="dictionary">
        ///     The <see cref="T:System.Collections.Generic.IDictionary`2" /> whose elements are copied to the
        ///     new <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </param>
        /// <param name="comparer">
        ///     The <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> implementation to use when
        ///     comparing keys, or null to use the default <see cref="T:System.Collections.Generic.EqualityComparer`1" /> for the
        ///     type of the key.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="dictionary" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="dictionary" /> contains one or more duplicate keys.</exception>
        public DictionaryEx(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : this(dictionary != null ? dictionary.Count : 0, comparer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");
            foreach (KeyValuePair<TKey, TValue> keyValuePair in dictionary)
            {
                this.Add(keyValuePair.Key, keyValuePair.Value);
            }
        }

        /// <summary>
        ///     Adds the specified key and value to the dictionary.
        /// </summary>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="value">The value of the element to add. The value can be null for reference types.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException">
        ///     An element with the same key already exists in the
        ///     <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </exception>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void Add(TKey key, TValue value)
        {
            this.Insert(key, value, true);
        }

        public void AddOrUpdate(TKey key, TValue value, Func<TKey, TValue, TValue, TValue> updateFunc)
        {
            this.Insert(key, value, false, updateFunc);
        }

        //public void AddOrUpdate<TValue, TTransientValue>(TKey key,
        //    Func<TValue> addValueFactory,
        //    Func<TKey, TValue, TTransientValue, TValue> updateFactory)
        //{
        //    Insert(key, value, false, updateFunc);
        //}

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
        {
            this.Add(keyValuePair.Key, keyValuePair.Value);
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
        {
            int entry = this.FindEntry(keyValuePair.Key);
            return entry >= 0 && EqualityComparer<TValue>.Default.Equals(this.entries[entry].value, keyValuePair.Value);
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
        {
            int entry = this.FindEntry(keyValuePair.Key);
            if (entry < 0 || !EqualityComparer<TValue>.Default.Equals(this.entries[entry].value, keyValuePair.Value))
                return false;
            this.Remove(keyValuePair.Key);
            return true;
        }

        /// <summary>
        ///     Removes all keys and values from the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </summary>
        public void Clear()
        {
            if (this.count <= 0)
                return;
            for (int index = 0; index < this.buckets.Length; ++index)
            {
                this.buckets[index] = -1;
            }
            Array.Clear((Array)this.entries, 0, this.count);
            this.freeList = -1;
            this.count = 0;
            this.freeCount = 0;
            ++this.version;
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> contains the specified key.
        /// </summary>
        /// <returns>
        ///     true if the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> contains an element with the specified key;
        ///     otherwise, false.
        /// </returns>
        /// <param name="key">The key to locate in the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key" /> is null.</exception>
        public bool ContainsKey(TKey key)
        {
            return this.FindEntry(key) >= 0;
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> contains a specific value.
        /// </summary>
        /// <returns>
        ///     true if the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> contains an element with the specified
        ///     value;
        ///     otherwise, false.
        /// </returns>
        /// <param name="value">
        ///     The value to locate in the <see cref="T:System.Collections.Generic.DictionaryEx`2" />. The value can
        ///     be null for reference types.
        /// </param>
        public bool ContainsValue(TValue value)
        {
            if ((object)value == null)
            {
                for (int index = 0; index < this.count; ++index)
                {
                    if (this.entries[index].hashCode >= 0 && (object)this.entries[index].value == null)
                        return true;
                }
            }
            else
            {
                EqualityComparer<TValue> @default = EqualityComparer<TValue>.Default;
                for (int index = 0; index < this.count; ++index)
                {
                    if (this.entries[index].hashCode >= 0 && @default.Equals(this.entries[index].value, value))
                        return true;
                }
            }
            return false;
        }

        void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum")
                    ;
            if (array.Length - index < this.Count)
                throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
            int num = this.count;
            Entry[] entryArray = this.entries;
            for (int index1 = 0; index1 < num; ++index1)
            {
                if (entryArray[index1].hashCode >= 0)
                    array[index++] = new KeyValuePair<TKey, TValue>(entryArray[index1].key, entryArray[index1].value);
            }
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.Collections.Generic.DictionaryEx`2.Enumerator" /> structure for the
        ///     <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </returns>
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this, 2);
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return new Enumerator(this, 2);
        }

        int FindEntry(TKey key)
        {
            if ((object)key == null)
                throw new ArgumentNullException("key");
            if (this.buckets != null)
            {
                int num = this.comparer.GetHashCode(key) & int.MaxValue;
                for (int index = this.buckets[num % this.buckets.Length]; index >= 0; index = this.entries[index].next)
                {
                    if (this.entries[index].hashCode == num && this.comparer.Equals(this.entries[index].key, key))
                        return index;
                }
            }
            return -1;
        }

        void Initialize(int capacity)
        {
            int prime = GetPrime(capacity);
            this.buckets = new int[prime];
            for (int index = 0; index < this.buckets.Length; ++index)
            {
                this.buckets[index] = -1;
            }
            this.entries = new Entry[prime];
            this.freeList = -1;
        }

        void Insert(TKey key, TValue value, bool add, Func<TKey, TValue, TValue, TValue> updateFunc = null)
        {
            if ((object)key == null)
                throw new ArgumentNullException("key");
            if (this.buckets == null)
                this.Initialize(0);
            int num1 = this.comparer.GetHashCode(key) & int.MaxValue;
            int index1 = num1 % this.buckets.Length;
            int num2 = 0;
            for (int index2 = this.buckets[index1]; index2 >= 0; index2 = this.entries[index2].next)
            {
                if (this.entries[index2].hashCode == num1 && this.comparer.Equals(this.entries[index2].key, key))
                {
                    if (add)
                        throw new ArgumentException("Argument_AddingDuplicate");
                    this.entries[index2].value = updateFunc == null ? value : updateFunc(key, this.entries[index2].value, value);
                    ++this.version;
                    return;
                }
                else
                    ++num2;
            }
            int index3;
            if (this.freeCount > 0)
            {
                index3 = this.freeList;
                this.freeList = this.entries[index3].next;
                --this.freeCount;
            }
            else
            {
                if (this.count == this.entries.Length)
                {
                    this.Resize();
                    index1 = num1 % this.buckets.Length;
                }
                index3 = this.count;
                ++this.count;
            }
            this.entries[index3].hashCode = num1;
            this.entries[index3].next = this.buckets[index1];
            this.entries[index3].key = key;
            this.entries[index3].value = value;
            this.buckets[index1] = index3;
            ++this.version;
            if (num2 <= 100 || (this.comparer != null && this.comparer != EqualityComparer<string>.Default))
                return;

            throw new NotSupportedException("There is high rate of collisions and such scenario is not supported.");
            //comparer = (IEqualityComparer<TKey>) HashHelpers.GetRandomizedEqualityComparer((object) comparer);
            //Resize(entries.Length, true);
        }

        //private void Insert(TKey key, TValue value, bool add, Func<TKey, TValue, TValue, TValue> updateFunc = null)
        //{
        //    //Insert<TValue>(key, value, add, updateFunc);
        //}

        //private void Insert<TTransientValue>(TKey key, TTransientValue transientValue,
        //    Func<TTransientValue, TValue> addTransformationFunc, bool add, Func<TKey, TValue, TValue, TValue> updateFunc = null)
        //{
        //    if ((object) key == null)
        //        throw new ArgumentNullException("key"); 
        //    if (buckets == null)
        //        Initialize(0);
        //    int num1 = comparer.GetHashCode(key) & int.MaxValue;
        //    int index1 = num1 % buckets.Length;
        //    int num2 = 0;
        //    for (int index2 = buckets[index1]; index2 >= 0; index2 = entries[index2].next)
        //    {
        //        if (entries[index2].hashCode == num1 && comparer.Equals(entries[index2].key, key))
        //        {
        //            if (add)
        //                throw new ArgumentException("Argument_AddingDuplicate");
        //            if (updateFunc == null)
        //                entries[index2].value = default(TValue);
        //            else
        //                entries[index2].value = updateFunc(key, entries[index2].value, default(TValue));
        //            ++version;
        //            return;
        //        }
        //        else
        //            ++num2;
        //    }
        //    int index3;
        //    if (freeCount > 0)
        //    {
        //        index3 = freeList;
        //        freeList = entries[index3].next;
        //        --freeCount;
        //    }
        //    else
        //    {
        //        if (count == entries.Length)
        //        {
        //            Resize();
        //            index1 = num1 % buckets.Length;
        //        }
        //        index3 = count;
        //        ++count;
        //    }
        //    entries[index3].hashCode = num1;
        //    entries[index3].next = buckets[index1];
        //    entries[index3].key = key;
        //    //entries[index3].value = value;
        //    buckets[index1] = index3;
        //    ++version;
        //    if (num2 <= 100 || (comparer != null && comparer != EqualityComparer<string>.Default))
        //        return;

        //    throw new NotSupportedException("There is high rate of collisions and such scenario is not supported.");
        //    //comparer = (IEqualityComparer<TKey>) HashHelpers.GetRandomizedEqualityComparer((object) comparer);
        //    //Resize(entries.Length, true);
        //}

        void Resize()
        {
            this.Resize(ExpandPrime(this.count), false);
        }

        #region Prime routines

        static readonly int[] primes = new int[72]
        {
            3,
            7,
            11,
            17,
            23,
            29,
            37,
            47,
            59,
            71,
            89,
            107,
            131,
            163,
            197,
            239,
            293,
            353,
            431,
            521,
            631,
            761,
            919,
            1103,
            1327,
            1597,
            1931,
            2333,
            2801,
            3371,
            4049,
            4861,
            5839,
            7013,
            8419,
            10103,
            12143,
            14591,
            17519,
            21023,
            25229,
            30293,
            36353,
            43627,
            52361,
            62851,
            75431,
            90523,
            108631,
            130363,
            156437,
            187751,
            225307,
            270371,
            324449,
            389357,
            467237,
            560689,
            672827,
            807403,
            968897,
            1162687,
            1395263,
            1674319,
            2009191,
            2411033,
            2893249,
            3471899,
            4166287,
            4999559,
            5999471,
            7199369
        };

        internal static int GetPrime(int min)
        {
            if (min < 0)
                throw new ArgumentException("Arg_HTCapacityOverflow");
            for (int index = 0; index < primes.Length; ++index)
            {
                int num = primes[index];
                if (num >= min)
                    return num;
            }
            int candidate = min | 1;
            while (candidate < int.MaxValue)
            {
                if (IsPrime(candidate) && (candidate - 1) % 101 != 0)
                    return candidate;
                candidate += 2;
            }
            return min;
        }

        internal static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
                return candidate == 2;
            int num1 = (int)Math.Sqrt((double)candidate);
            int num2 = 3;
            while (num2 <= num1)
            {
                if (candidate % num2 == 0)
                    return false;
                num2 += 2;
            }
            return true;
        }

        internal static int ExpandPrime(int oldSize)
        {
            int min = 2 * oldSize;
            if ((uint)min > 2146435069U && 2146435069 > oldSize)
                return 2146435069;
            else
                return GetPrime(min);
        }

        #endregion

        void Resize(int newSize, bool forceNewHashCodes)
        {
            var numArray = new int[newSize];
            for (int index = 0; index < numArray.Length; ++index)
            {
                numArray[index] = -1;
            }
            var entryArray = new Entry[newSize];
            Array.Copy((Array)this.entries, 0, (Array)entryArray, 0, this.count);
            if (forceNewHashCodes)
            {
                for (int index = 0; index < this.count; ++index)
                {
                    if (entryArray[index].hashCode != -1)
                        entryArray[index].hashCode = this.comparer.GetHashCode(entryArray[index].key) & int.MaxValue;
                }
            }
            for (int index1 = 0; index1 < this.count; ++index1)
            {
                int index2 = entryArray[index1].hashCode % newSize;
                entryArray[index1].next = numArray[index2];
                numArray[index2] = index1;
            }
            this.buckets = numArray;
            this.entries = entryArray;
        }

        /// <summary>
        ///     Removes the value with the specified key from the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </summary>
        /// <returns>
        ///     true if the element is successfully found and removed; otherwise, false.  This method returns false if
        ///     <paramref name="key" /> is not found in the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </returns>
        /// <param name="key">The key of the element to remove.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key" /> is null.</exception>
        public bool Remove(TKey key)
        {
            if ((object)key == null)
                throw new ArgumentNullException("key");
            if (this.buckets != null)
            {
                int num = this.comparer.GetHashCode(key) & int.MaxValue;
                int index1 = num % this.buckets.Length;
                int index2 = -1;
                for (int index3 = this.buckets[index1]; index3 >= 0; index3 = this.entries[index3].next)
                {
                    if (this.entries[index3].hashCode == num && this.comparer.Equals(this.entries[index3].key, key))
                    {
                        if (index2 < 0)
                            this.buckets[index1] = this.entries[index3].next;
                        else
                            this.entries[index2].next = this.entries[index3].next;
                        this.entries[index3].hashCode = -1;
                        this.entries[index3].next = this.freeList;
                        this.entries[index3].key = default(TKey);
                        this.entries[index3].value = default(TValue);
                        this.freeList = index3;
                        ++this.freeCount;
                        ++this.version;
                        return true;
                    }
                    else
                        index2 = index3;
                }
            }
            return false;
        }

        /// <summary>
        ///     Gets the value associated with the specified key.
        /// </summary>
        /// <returns>
        ///     true if the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> contains an element with the specified key;
        ///     otherwise, false.
        /// </returns>
        /// <param name="key">The key of the value to get.</param>
        /// <param name="value">
        ///     When this method returns, contains the value associated with the specified key, if the key is
        ///     found; otherwise, the default value for the type of the <paramref name="value" /> parameter. This parameter is
        ///     passed uninitialized.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key" /> is null.</exception>
        public bool TryGetValue(TKey key, out TValue value)
        {
            int entry = this.FindEntry(key);
            if (entry >= 0)
            {
                value = this.entries[entry].value;
                return true;
            }
            else
            {
                value = default(TValue);
                return false;
            }
        }

        internal TValue GetValueOrDefault(TKey key)
        {
            int entry = this.FindEntry(key);
            if (entry >= 0)
                return this.entries[entry].value;
            else
                return default(TValue);
        }

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            this.CopyTo(array, index);
        }

        void ICollection.CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (array.Rank != 1)
                throw new ArgumentException("Arg_RankMultiDimNotSupported");
            if (array.GetLowerBound(0) != 0)
                throw new ArgumentException("Arg_NonZeroLowerBound");
            if (index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
            if (array.Length - index < this.Count)
                throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
            var array1 = array as KeyValuePair<TKey, TValue>[];
            if (array1 != null)
                this.CopyTo(array1, index);
            else if (array is DictionaryEntry[])
            {
                var dictionaryEntryArray = array as DictionaryEntry[];
                Entry[] entryArray = this.entries;
                for (int index1 = 0; index1 < this.count; ++index1)
                {
                    if (entryArray[index1].hashCode >= 0)
                    {
                        dictionaryEntryArray[index++] = new DictionaryEntry((object)entryArray[index1].key,
                            (object)entryArray[index1].value);
                    }
                }
            }
            else
            {
                var objArray = array as object[];
                if (objArray == null)
                    throw new ArgumentException("Argument_InvalidArrayType");
                try
                {
                    int num = this.count;
                    Entry[] entryArray = this.entries;
                    for (int index1 = 0; index1 < num; ++index1)
                    {
                        if (entryArray[index1].hashCode >= 0)
                            objArray[index++] = (object)new KeyValuePair<TKey, TValue>(entryArray[index1].key, entryArray[index1].value);
                    }
                }
                catch (ArrayTypeMismatchException ex)
                {
                    throw new ArgumentException("Argument_InvalidArrayType");
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this, 2);
        }

        struct Entry
        {
            public int hashCode;
            public int next;
            public TKey key;
            public TValue value;
        }

        /// <summary>
        ///     Enumerates the elements of a <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </summary>
        [Serializable]
        public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            internal const int DictEntry = 1;
            internal const int KeyValuePair = 2;
            readonly DictionaryEx<TKey, TValue> dictionary;
            readonly int version;
            int index;
            KeyValuePair<TKey, TValue> current;
            readonly int getEnumeratorRetType;

            /// <summary>
            ///     Gets the element at the current position of the enumerator.
            /// </summary>
            /// <returns>
            ///     The element in the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> at the current position of the
            ///     enumerator.
            /// </returns>
            public KeyValuePair<TKey, TValue> Current
            {
                [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get { return this.current; }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (this.index == 0 || this.index == this.dictionary.count + 1)
                        throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                    if (this.getEnumeratorRetType == 1)
                        return (object)new DictionaryEntry((object)this.current.Key, (object)this.current.Value);
                    else
                        return (object)new KeyValuePair<TKey, TValue>(this.current.Key, this.current.Value);
                }
            }

            internal Enumerator(DictionaryEx<TKey, TValue> dictionary, int getEnumeratorRetType)
            {
                this.dictionary = dictionary;
                this.version = dictionary.version;
                this.index = 0;
                this.getEnumeratorRetType = getEnumeratorRetType;
                this.current = new KeyValuePair<TKey, TValue>();
            }

            /// <summary>
            ///     Advances the enumerator to the next element of the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
            /// </summary>
            /// <returns>
            ///     true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of
            ///     the collection.
            /// </returns>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            public bool MoveNext()
            {
                if (this.version != this.dictionary.version)
                    throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                for (; (uint)this.index < (uint)this.dictionary.count; ++this.index)
                {
                    if (this.dictionary.entries[this.index].hashCode >= 0)
                    {
                        this.current = new KeyValuePair<TKey, TValue>(this.dictionary.entries[this.index].key, this.dictionary.entries[this.index].value);
                        ++this.index;
                        return true;
                    }
                }
                this.index = this.dictionary.count + 1;
                this.current = new KeyValuePair<TKey, TValue>();
                return false;
            }

            /// <summary>
            ///     Releases all resources used by the <see cref="T:System.Collections.Generic.DictionaryEx`2.Enumerator" />.
            /// </summary>
            public void Dispose()
            {
            }

            void IEnumerator.Reset()
            {
                if (this.version != this.dictionary.version)
                    throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                this.index = 0;
                this.current = new KeyValuePair<TKey, TValue>();
            }
        }

        /// <summary>
        ///     Represents the collection of keys in a <see cref="T:System.Collections.Generic.DictionaryEx`2" />. This class
        ///     cannot
        ///     be inherited.
        /// </summary>
        [DebuggerDisplay("Count = {Count}")]
        [Serializable]
        public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, ICollection, IEnumerable
        {
            readonly DictionaryEx<TKey, TValue> dictionary;

            /// <summary>
            ///     Gets the number of elements contained in the
            ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" />
            ///     .
            /// </summary>
            /// <returns>
            ///     The number of elements contained in the <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" />
            ///     .Retrieving the value of this property is an O(1) operation.
            /// </returns>
            public int Count
            {
                get { return this.dictionary.Count; }
            }

            bool ICollection<TKey>.IsReadOnly
            {
                get { return true; }
            }

            bool ICollection.IsSynchronized
            {
                get { return false; }
            }

            object ICollection.SyncRoot
            {
                get { return ((ICollection)this.dictionary).SyncRoot; }
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" /> class
            ///     that
            ///     reflects the keys in the specified <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
            /// </summary>
            /// <param name="dictionary">
            ///     The <see cref="T:System.Collections.Generic.DictionaryEx`2" /> whose keys are reflected in the
            ///     new <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" />.
            /// </param>
            /// <exception cref="T:System.ArgumentNullException"><paramref name="dictionary" /> is null.</exception>
            public KeyCollection(DictionaryEx<TKey, TValue> dictionary)
            {
                if (dictionary == null)
                    throw new ArgumentNullException("dictionary");
                this.dictionary = dictionary;
            }

            /// <summary>
            ///     Returns an enumerator that iterates through the
            ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" />.
            /// </summary>
            /// <returns>
            ///     A <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection.Enumerator" /> for the
            ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" />.
            /// </returns>
            public Enumerator GetEnumerator()
            {
                return new Enumerator(this.dictionary);
            }

            /// <summary>
            ///     Copies the <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" /> elements to an existing
            ///     one-dimensional <see cref="T:System.Array" />, starting at the specified array index.
            /// </summary>
            /// <param name="array">
            ///     The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied
            ///     from <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" />. The <see cref="T:System.Array" />
            ///     must
            ///     have zero-based indexing.
            /// </param>
            /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
            /// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> is null. </exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index" /> is less than zero.</exception>
            /// <exception cref="T:System.ArgumentException">
            ///     The number of elements in the source
            ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" /> is greater than the available space from
            ///     <paramref name="index" /> to the end of the destination <paramref name="array" />.
            /// </exception>
            public void CopyTo(TKey[] array, int index)
            {
                if (array == null)
                    throw new ArgumentNullException("array");
                if (index < 0 || index > array.Length)
                    throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
                if (array.Length - index < this.dictionary.Count)
                    throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
                int num = this.dictionary.count;
                Entry[] entryArray = this.dictionary.entries;
                for (int index1 = 0; index1 < num; ++index1)
                {
                    if (entryArray[index1].hashCode >= 0)
                        array[index++] = entryArray[index1].key;
                }
            }

            void ICollection<TKey>.Add(TKey item)
            {
                throw new NotSupportedException("NotSupported_KeyCollectionSet");
            }

            void ICollection<TKey>.Clear()
            {
                throw new NotSupportedException("NotSupported_KeyCollectionSet");
            }

            bool ICollection<TKey>.Contains(TKey item)
            {
                return this.dictionary.ContainsKey(item);
            }

            bool ICollection<TKey>.Remove(TKey item)
            {
                throw new NotSupportedException("NotSupported_KeyCollectionSet");
                return false;
            }

            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
            {
                return (IEnumerator<TKey>)new Enumerator(this.dictionary);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)new Enumerator(this.dictionary);
            }

            void ICollection.CopyTo(Array array, int index)
            {
                if (array == null)
                    throw new ArgumentNullException("array");
                if (array.Rank != 1)
                    throw new ArgumentException("Arg_RankMultiDimNotSupported");
                if (array.GetLowerBound(0) != 0)
                    throw new ArgumentException("Arg_NonZeroLowerBound");
                if (index < 0 || index > array.Length)
                    throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
                if (array.Length - index < this.dictionary.Count)
                    throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
                var array1 = array as TKey[];
                if (array1 != null)
                    this.CopyTo(array1, index);
                else
                {
                    var objArray = array as object[];
                    if (objArray == null)
                        throw new ArgumentException("Argument_InvalidArrayType");
                    int num = this.dictionary.count;
                    Entry[] entryArray = this.dictionary.entries;
                    try
                    {
                        for (int index1 = 0; index1 < num; ++index1)
                        {
                            if (entryArray[index1].hashCode >= 0)
                                objArray[index++] = (object)entryArray[index1].key;
                        }
                    }
                    catch (ArrayTypeMismatchException ex)
                    {
                        throw new ArgumentException("Argument_InvalidArrayType");
                    }
                }
            }

            /// <summary>
            ///     Enumerates the elements of a <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" />.
            /// </summary>
            [Serializable]
            public struct Enumerator : IEnumerator<TKey>, IDisposable, IEnumerator
            {
                readonly DictionaryEx<TKey, TValue> dictionary;
                int index;
                readonly int version;
                TKey currentKey;

                /// <summary>
                ///     Gets the element at the current position of the enumerator.
                /// </summary>
                /// <returns>
                ///     The element in the <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" /> at the current position
                ///     of the enumerator.
                /// </returns>
                public TKey Current
                {
                    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get { return this.currentKey; }
                }

                object IEnumerator.Current
                {
                    get
                    {
                        if (this.index == 0 || this.index == this.dictionary.count + 1)
                            throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                        return (object)this.currentKey;
                    }
                }

                internal Enumerator(DictionaryEx<TKey, TValue> dictionary)
                {
                    this.dictionary = dictionary;
                    this.version = dictionary.version;
                    this.index = 0;
                    this.currentKey = default(TKey);
                }

                /// <summary>
                ///     Releases all resources used by the
                ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection.Enumerator" />.
                /// </summary>
                public void Dispose()
                {
                }

                /// <summary>
                ///     Advances the enumerator to the next element of the
                ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" />.
                /// </summary>
                /// <returns>
                ///     true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of
                ///     the collection.
                /// </returns>
                /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
                public bool MoveNext()
                {
                    if (this.version != this.dictionary.version)
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    for (; (uint)this.index < (uint)this.dictionary.count; ++this.index)
                    {
                        if (this.dictionary.entries[this.index].hashCode >= 0)
                        {
                            this.currentKey = this.dictionary.entries[this.index].key;
                            ++this.index;
                            return true;
                        }
                    }
                    this.index = this.dictionary.count + 1;
                    this.currentKey = default(TKey);
                    return false;
                }

                void IEnumerator.Reset()
                {
                    if (this.version != this.dictionary.version)
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    this.index = 0;
                    this.currentKey = default(TKey);
                }
            }
        }

        /// <summary>
        ///     Represents the collection of values in a <see cref="T:System.Collections.Generic.DictionaryEx`2" />. This class
        ///     cannot be inherited.
        /// </summary>
        [DebuggerDisplay("Count = {Count}")]
        [Serializable]
        public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, ICollection, IEnumerable
        {
            readonly DictionaryEx<TKey, TValue> dictionary;

            /// <summary>
            ///     Gets the number of elements contained in the
            ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" />.
            /// </summary>
            /// <returns>
            ///     The number of elements contained in the <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" />.
            /// </returns>
            public int Count
            {
                get { return this.dictionary.Count; }
            }

            bool ICollection<TValue>.IsReadOnly
            {
                get { return true; }
            }

            bool ICollection.IsSynchronized
            {
                get { return false; }
            }

            object ICollection.SyncRoot
            {
                get { return ((ICollection)this.dictionary).SyncRoot; }
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" /> class
            ///     that reflects the values in the specified <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
            /// </summary>
            /// <param name="dictionary">
            ///     The <see cref="T:System.Collections.Generic.DictionaryEx`2" /> whose values are reflected in the
            ///     new <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" />.
            /// </param>
            /// <exception cref="T:System.ArgumentNullException"><paramref name="dictionary" /> is null.</exception>
            public ValueCollection(DictionaryEx<TKey, TValue> dictionary)
            {
                if (dictionary == null)
                    throw new ArgumentNullException("dictionary");
                this.dictionary = dictionary;
            }

            /// <summary>
            ///     Returns an enumerator that iterates through the
            ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" />.
            /// </summary>
            /// <returns>
            ///     A <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection.Enumerator" /> for the
            ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" />.
            /// </returns>
            public Enumerator GetEnumerator()
            {
                return new Enumerator(this.dictionary);
            }

            /// <summary>
            ///     Copies the <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" /> elements to an existing
            ///     one-dimensional <see cref="T:System.Array" />, starting at the specified array index.
            /// </summary>
            /// <param name="array">
            ///     The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied
            ///     from <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" />. The <see cref="T:System.Array" />
            ///     must have zero-based indexing.
            /// </param>
            /// <param name="index">The zero-based index in <paramref name="array" /> at which copying begins.</param>
            /// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> is null.</exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index" /> is less than zero.</exception>
            /// <exception cref="T:System.ArgumentException">
            ///     The number of elements in the source
            ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" /> is greater than the available space from
            ///     <paramref name="index" /> to the end of the destination <paramref name="array" />.
            /// </exception>
            public void CopyTo(TValue[] array, int index)
            {
                if (array == null)
                    throw new ArgumentNullException("array");
                if (index < 0 || index > array.Length)
                    throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
                if (array.Length - index < this.dictionary.Count)
                    throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
                int num = this.dictionary.count;
                Entry[] entryArray = this.dictionary.entries;
                for (int index1 = 0; index1 < num; ++index1)
                {
                    if (entryArray[index1].hashCode >= 0)
                        array[index++] = entryArray[index1].value;
                }
            }

            void ICollection<TValue>.Add(TValue item)
            {
                throw new NotSupportedException("NotSupported_ValueCollectionSet");
            }

            bool ICollection<TValue>.Remove(TValue item)
            {
                throw new NotSupportedException("NotSupported_ValueCollectionSet");
                return false;
            }

            void ICollection<TValue>.Clear()
            {
                throw new NotSupportedException("NotSupported_ValueCollectionSet");
            }

            bool ICollection<TValue>.Contains(TValue item)
            {
                return this.dictionary.ContainsValue(item);
            }

            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
            {
                return (IEnumerator<TValue>)new Enumerator(this.dictionary);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)new Enumerator(this.dictionary);
            }

            void ICollection.CopyTo(Array array, int index)
            {
                if (array == null)
                    throw new ArgumentNullException("array");
                if (array.Rank != 1)
                    throw new ArgumentException("Arg_RankMultiDimNotSupported");
                if (array.GetLowerBound(0) != 0)
                    throw new ArgumentException("Arg_NonZeroLowerBound");
                if (index < 0 || index > array.Length)
                    throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum");
                if (array.Length - index < this.dictionary.Count)
                    throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
                var array1 = array as TValue[];
                if (array1 != null)
                    this.CopyTo(array1, index);
                else
                {
                    var objArray = array as object[];
                    if (objArray == null)
                        throw new ArgumentException("Argument_InvalidArrayType");
                    int num = this.dictionary.count;
                    Entry[] entryArray = this.dictionary.entries;
                    try
                    {
                        for (int index1 = 0; index1 < num; ++index1)
                        {
                            if (entryArray[index1].hashCode >= 0)
                                objArray[index++] = (object)entryArray[index1].value;
                        }
                    }
                    catch (ArrayTypeMismatchException ex)
                    {
                        throw new ArgumentException("Argument_InvalidArrayType");
                    }
                }
            }

            /// <summary>
            ///     Enumerates the elements of a <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" />.
            /// </summary>
            [Serializable]
            public struct Enumerator : IEnumerator<TValue>, IDisposable, IEnumerator
            {
                readonly DictionaryEx<TKey, TValue> dictionary;
                int index;
                readonly int version;
                TValue currentValue;

                /// <summary>
                ///     Gets the element at the current position of the enumerator.
                /// </summary>
                /// <returns>
                ///     The element in the <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" /> at the current
                ///     position
                ///     of the enumerator.
                /// </returns>
                public TValue Current
                {
                    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get { return this.currentValue; }
                }

                object IEnumerator.Current
                {
                    get
                    {
                        if (this.index == 0 || this.index == this.dictionary.count + 1)
                            throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                        return (object)this.currentValue;
                    }
                }

                internal Enumerator(DictionaryEx<TKey, TValue> dictionary)
                {
                    this.dictionary = dictionary;
                    this.version = dictionary.version;
                    this.index = 0;
                    this.currentValue = default(TValue);
                }

                /// <summary>
                ///     Releases all resources used by the
                ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection.Enumerator" />.
                /// </summary>
                public void Dispose()
                {
                }

                /// <summary>
                ///     Advances the enumerator to the next element of the
                ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" />.
                /// </summary>
                /// <returns>
                ///     true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of
                ///     the collection.
                /// </returns>
                /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
                public bool MoveNext()
                {
                    if (this.version != this.dictionary.version)
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    for (; (uint)this.index < (uint)this.dictionary.count; ++this.index)
                    {
                        if (this.dictionary.entries[this.index].hashCode >= 0)
                        {
                            this.currentValue = this.dictionary.entries[this.index].value;
                            ++this.index;
                            return true;
                        }
                    }
                    this.index = this.dictionary.count + 1;
                    this.currentValue = default(TValue);
                    return false;
                }

                void IEnumerator.Reset()
                {
                    if (this.version != this.dictionary.version)
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    this.index = 0;
                    this.currentValue = default(TValue);
                }
            }
        }
    }

    public class Factory<T>
        where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }
}