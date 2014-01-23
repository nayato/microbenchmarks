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
        private int[] buckets;
        private Entry[] entries;
        private int count;
        private int version;
        private int freeList;
        private int freeCount;
        private IEqualityComparer<TKey> comparer;
        private KeyCollection keys;
        private ValueCollection values;
        private object _syncRoot;
        private const string VersionName = "Version";
        private const string HashSizeName = "HashSize";
        private const string KeyValuePairsName = "KeyValuePairs";
        private const string ComparerName = "Comparer";

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
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            get { return comparer; }
        }

        /// <summary>
        ///     Gets the number of key/value pairs contained in the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </summary>
        /// <returns>
        ///     The number of key/value pairs contained in the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </returns>
        public int Count
        {
            get { return count - freeCount; }
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
                if (keys == null)
                    keys = new KeyCollection(this);
                return keys;
            }
        }


        ICollection<TKey> IDictionary<TKey, TValue>.Keys
        {
            get
            {
                if (keys == null)
                    keys = new KeyCollection(this);
                return (ICollection<TKey>) keys;
            }
        }


        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys
        {
            get
            {
                if (keys == null)
                    keys = new KeyCollection(this);
                return keys;
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
                if (values == null)
                    values = new ValueCollection(this);
                return values;
            }
        }


        ICollection<TValue> IDictionary<TKey, TValue>.Values
        {
            get
            {
                if (values == null)
                    values = new ValueCollection(this);
                return values;
            }
        }


        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values
        {
            get
            {
                if (values == null)
                    values = new ValueCollection(this);
                return values;
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
                int entry = FindEntry(key);
                if (entry >= 0)
                    return entries[entry].value;
                throw new KeyNotFoundException();
            }

            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            set { Insert(key, value, false); }
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
                if (_syncRoot == null)
                    Interlocked.CompareExchange<object>(ref _syncRoot, new object(), (object) null);
                return _syncRoot;
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> class that is empty, has
        ///     the default initial capacity, and uses the default equality comparer for the key type.
        /// </summary>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public DictionaryEx()
            : this(0, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> class that is empty, has
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
        ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> class that is empty, has
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
        ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> class that is empty, has
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
                Initialize(capacity);
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
                Add(keyValuePair.Key, keyValuePair.Value);
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
            Insert(key, value, true);
        }

        public void AddOrUpdate(TKey key, TValue value, Func<TKey, TValue, TValue, TValue> updateFunc)
        {
            Insert(key, value, false, updateFunc);
        }

        //public void AddOrUpdate<TValue, TTransientValue>(TKey key,
        //    Func<TValue> addValueFactory,
        //    Func<TKey, TValue, TTransientValue, TValue> updateFactory)
        //{
        //    Insert(key, value, false, updateFunc);
        //}

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> keyValuePair)
        {
            Add(keyValuePair.Key, keyValuePair.Value);
        }


        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> keyValuePair)
        {
            int entry = FindEntry(keyValuePair.Key);
            return entry >= 0 && EqualityComparer<TValue>.Default.Equals(entries[entry].value, keyValuePair.Value);
        }


        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> keyValuePair)
        {
            int entry = FindEntry(keyValuePair.Key);
            if (entry < 0 || !EqualityComparer<TValue>.Default.Equals(entries[entry].value, keyValuePair.Value))
                return false;
            Remove(keyValuePair.Key);
            return true;
        }

        /// <summary>
        ///     Removes all keys and values from the <see cref="T:System.Collections.Generic.DictionaryEx`2" />.
        /// </summary>
        public void Clear()
        {
            if (count <= 0)
                return;
            for (int index = 0; index < buckets.Length; ++index)
            {
                buckets[index] = -1;
            }
            Array.Clear((Array) entries, 0, count);
            freeList = -1;
            count = 0;
            freeCount = 0;
            ++version;
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
            return FindEntry(key) >= 0;
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> contains a specific value.
        /// </summary>
        /// <returns>
        ///     true if the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> contains an element with the specified value;
        ///     otherwise, false.
        /// </returns>
        /// <param name="value">
        ///     The value to locate in the <see cref="T:System.Collections.Generic.DictionaryEx`2" />. The value can
        ///     be null for reference types.
        /// </param>
        public bool ContainsValue(TValue value)
        {
            if ((object) value == null)
            {
                for (int index = 0; index < count; ++index)
                {
                    if (entries[index].hashCode >= 0 && (object) entries[index].value == null)
                        return true;
                }
            }
            else
            {
                EqualityComparer<TValue> @default = EqualityComparer<TValue>.Default;
                for (int index = 0; index < count; ++index)
                {
                    if (entries[index].hashCode >= 0 && @default.Equals(entries[index].value, value))
                        return true;
                }
            }
            return false;
        }

        private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("array"); 
            if (index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_NeedNonNegNum")
            ;
            if (array.Length - index < Count)
                throw new ArgumentException("Arg_ArrayPlusOffTooSmall"); 
            int num = count;
            Entry[] entryArray = entries;
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

        private int FindEntry(TKey key)
        {
            if ((object) key == null)
                throw new ArgumentNullException("key"); 
            if (buckets != null)
            {
                int num = comparer.GetHashCode(key) & int.MaxValue;
                for (int index = buckets[num % buckets.Length]; index >= 0; index = entries[index].next)
                {
                    if (entries[index].hashCode == num && comparer.Equals(entries[index].key, key))
                        return index;
                }
            }
            return -1;
        }

        private void Initialize(int capacity)
        {
            int prime = GetPrime(capacity);
            buckets = new int[prime];
            for (int index = 0; index < buckets.Length; ++index)
            {
                buckets[index] = -1;
            }
            entries = new Entry[prime];
            freeList = -1;
        }

        private void Insert(TKey key, TValue value, bool add, Func<TKey, TValue, TValue, TValue> updateFunc = null)
        {
            if ((object)key == null)
                throw new ArgumentNullException("key");
            if (buckets == null)
                Initialize(0);
            int num1 = comparer.GetHashCode(key) & int.MaxValue;
            int index1 = num1 % buckets.Length;
            int num2 = 0;
            for (int index2 = buckets[index1]; index2 >= 0; index2 = entries[index2].next)
            {
                if (entries[index2].hashCode == num1 && comparer.Equals(entries[index2].key, key))
                {
                    if (add)
                        throw new ArgumentException("Argument_AddingDuplicate");
                    entries[index2].value = updateFunc == null ? value : updateFunc(key, entries[index2].value, value);
                    ++version;
                    return;
                }
                else
                    ++num2;
            }
            int index3;
            if (freeCount > 0)
            {
                index3 = freeList;
                freeList = entries[index3].next;
                --freeCount;
            }
            else
            {
                if (count == entries.Length)
                {
                    Resize();
                    index1 = num1 % buckets.Length;
                }
                index3 = count;
                ++count;
            }
            entries[index3].hashCode = num1;
            entries[index3].next = buckets[index1];
            entries[index3].key = key;
            entries[index3].value = value;
            buckets[index1] = index3;
            ++version;
            if (num2 <= 100 || (comparer != null && comparer != EqualityComparer<string>.Default))
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

        private void Resize()
        {
            Resize(ExpandPrime(count), false);
        }

        #region Prime routines
		        
        private static readonly int[] primes = new int[72]
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

        private void Resize(int newSize, bool forceNewHashCodes)
        {
            int[] numArray = new int[newSize];
            for (int index = 0; index < numArray.Length; ++index)
            {
                numArray[index] = -1;
            }
            Entry[] entryArray = new Entry[newSize];
            Array.Copy((Array) entries, 0, (Array) entryArray, 0, count);
            if (forceNewHashCodes)
            {
                for (int index = 0; index < count; ++index)
                {
                    if (entryArray[index].hashCode != -1)
                        entryArray[index].hashCode = comparer.GetHashCode(entryArray[index].key) & int.MaxValue;
                }
            }
            for (int index1 = 0; index1 < count; ++index1)
            {
                int index2 = entryArray[index1].hashCode % newSize;
                entryArray[index1].next = numArray[index2];
                numArray[index2] = index1;
            }
            buckets = numArray;
            entries = entryArray;
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
            if ((object) key == null)
                throw new ArgumentNullException("key");
            if (buckets != null)
            {
                int num = comparer.GetHashCode(key) & int.MaxValue;
                int index1 = num % buckets.Length;
                int index2 = -1;
                for (int index3 = buckets[index1]; index3 >= 0; index3 = entries[index3].next)
                {
                    if (entries[index3].hashCode == num && comparer.Equals(entries[index3].key, key))
                    {
                        if (index2 < 0)
                            buckets[index1] = entries[index3].next;
                        else
                            entries[index2].next = entries[index3].next;
                        entries[index3].hashCode = -1;
                        entries[index3].next = freeList;
                        entries[index3].key = default(TKey);
                        entries[index3].value = default(TValue);
                        freeList = index3;
                        ++freeCount;
                        ++version;
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
            int entry = FindEntry(key);
            if (entry >= 0)
            {
                value = entries[entry].value;
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
            int entry = FindEntry(key);
            if (entry >= 0)
                return entries[entry].value;
            else
                return default(TValue);
        }


        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
        {
            CopyTo(array, index);
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
            if (array.Length - index < Count)
                throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
            KeyValuePair<TKey, TValue>[] array1 = array as KeyValuePair<TKey, TValue>[];
            if (array1 != null)
                CopyTo(array1, index);
            else if (array is DictionaryEntry[])
            {
                DictionaryEntry[] dictionaryEntryArray = array as DictionaryEntry[];
                Entry[] entryArray = entries;
                for (int index1 = 0; index1 < count; ++index1)
                {
                    if (entryArray[index1].hashCode >= 0)
                    {
                        dictionaryEntryArray[index++] = new DictionaryEntry((object) entryArray[index1].key,
                            (object) entryArray[index1].value);
                    }
                }
            }
            else
            {
                object[] objArray = array as object[];
                if (objArray == null)
                    throw new ArgumentException("Argument_InvalidArrayType");
                try
                {
                    int num = count;
                    Entry[] entryArray = entries;
                    for (int index1 = 0; index1 < num; ++index1)
                    {
                        if (entryArray[index1].hashCode >= 0)
                            objArray[index++] = (object) new KeyValuePair<TKey, TValue>(entryArray[index1].key, entryArray[index1].value);
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

        private struct Entry
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
            private DictionaryEx<TKey, TValue> dictionary;
            private int version;
            private int index;
            private KeyValuePair<TKey, TValue> current;
            private int getEnumeratorRetType;

            /// <summary>
            ///     Gets the element at the current position of the enumerator.
            /// </summary>
            /// <returns>
            ///     The element in the <see cref="T:System.Collections.Generic.DictionaryEx`2" /> at the current position of the
            ///     enumerator.
            /// </returns>
            public KeyValuePair<TKey, TValue> Current
            {
                [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
                get { return current; }
            }


            object IEnumerator.Current
            {
                get
                {
                    if (index == 0 || index == dictionary.count + 1)
                        throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                    if (getEnumeratorRetType == 1)
                        return (object) new DictionaryEntry((object) current.Key, (object) current.Value);
                    else
                        return (object) new KeyValuePair<TKey, TValue>(current.Key, current.Value);
                }
            }

            internal Enumerator(DictionaryEx<TKey, TValue> dictionary, int getEnumeratorRetType)
            {
                this.dictionary = dictionary;
                version = dictionary.version;
                index = 0;
                this.getEnumeratorRetType = getEnumeratorRetType;
                current = new KeyValuePair<TKey, TValue>();
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
                if (version != dictionary.version)
                    throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                for (; (uint) index < (uint) dictionary.count; ++index)
                {
                    if (dictionary.entries[index].hashCode >= 0)
                    {
                        current = new KeyValuePair<TKey, TValue>(dictionary.entries[index].key, dictionary.entries[index].value);
                        ++index;
                        return true;
                    }
                }
                index = dictionary.count + 1;
                current = new KeyValuePair<TKey, TValue>();
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
                if (version != dictionary.version)
                    throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                index = 0;
                current = new KeyValuePair<TKey, TValue>();
            }
        }

        /// <summary>
        ///     Represents the collection of keys in a <see cref="T:System.Collections.Generic.DictionaryEx`2" />. This class cannot
        ///     be inherited.
        /// </summary>
        [DebuggerDisplay("Count = {Count}")]
        [Serializable]
        public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, ICollection, IEnumerable
        {
            private DictionaryEx<TKey, TValue> dictionary;

            /// <summary>
            ///     Gets the number of elements contained in the <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" />
            ///     .
            /// </summary>
            /// <returns>
            ///     The number of elements contained in the <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" />
            ///     .Retrieving the value of this property is an O(1) operation.
            /// </returns>
            public int Count
            {
                get { return dictionary.Count; }
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
                get { return ((ICollection)dictionary).SyncRoot; }
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" /> class that
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
                return new Enumerator(dictionary);
            }

            /// <summary>
            ///     Copies the <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" /> elements to an existing
            ///     one-dimensional <see cref="T:System.Array" />, starting at the specified array index.
            /// </summary>
            /// <param name="array">
            ///     The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied
            ///     from <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" />. The <see cref="T:System.Array" /> must
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
                if (array.Length - index < dictionary.Count)
                    throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
                int num = dictionary.count;
                Entry[] entryArray = dictionary.entries;
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
                return dictionary.ContainsKey(item);
            }


            bool ICollection<TKey>.Remove(TKey item)
            {
                throw new NotSupportedException("NotSupported_KeyCollectionSet");
                return false;
            }


            IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
            {
                return (IEnumerator<TKey>) new Enumerator(dictionary);
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator) new Enumerator(dictionary);
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
                if (array.Length - index < dictionary.Count)
                    throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
                TKey[] array1 = array as TKey[];
                if (array1 != null)
                    CopyTo(array1, index);
                else
                {
                    object[] objArray = array as object[];
                    if (objArray == null)
                        throw new ArgumentException("Argument_InvalidArrayType");
                    int num = dictionary.count;
                    Entry[] entryArray = dictionary.entries;
                    try
                    {
                        for (int index1 = 0; index1 < num; ++index1)
                        {
                            if (entryArray[index1].hashCode >= 0)
                                objArray[index++] = (object) entryArray[index1].key;
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
                private DictionaryEx<TKey, TValue> dictionary;
                private int index;
                private int version;
                private TKey currentKey;

                /// <summary>
                ///     Gets the element at the current position of the enumerator.
                /// </summary>
                /// <returns>
                ///     The element in the <see cref="T:System.Collections.Generic.DictionaryEx`2.KeyCollection" /> at the current position
                ///     of the enumerator.
                /// </returns>
                public TKey Current
                {
                    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
                    get { return currentKey; }
                }


                object IEnumerator.Current
                {
                    get
                    {
                        if (index == 0 || index == dictionary.count + 1)
                            throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                        return (object) currentKey;
                    }
                }

                internal Enumerator(DictionaryEx<TKey, TValue> dictionary)
                {
                    this.dictionary = dictionary;
                    version = dictionary.version;
                    index = 0;
                    currentKey = default(TKey);
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
                    if (version != dictionary.version)
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    for (; (uint) index < (uint) dictionary.count; ++index)
                    {
                        if (dictionary.entries[index].hashCode >= 0)
                        {
                            currentKey = dictionary.entries[index].key;
                            ++index;
                            return true;
                        }
                    }
                    index = dictionary.count + 1;
                    currentKey = default(TKey);
                    return false;
                }


                void IEnumerator.Reset()
                {
                    if (version != dictionary.version)
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    index = 0;
                    currentKey = default(TKey);
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
            private DictionaryEx<TKey, TValue> dictionary;

            /// <summary>
            ///     Gets the number of elements contained in the
            ///     <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" />.
            /// </summary>
            /// <returns>
            ///     The number of elements contained in the <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" />.
            /// </returns>
            public int Count
            {
                get { return dictionary.Count; }
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
                get { return ((ICollection)dictionary).SyncRoot; }
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
                return new Enumerator(dictionary);
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
                if (array.Length - index < dictionary.Count)
                    throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
                int num = dictionary.count;
                Entry[] entryArray = dictionary.entries;
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
                return dictionary.ContainsValue(item);
            }


            IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
            {
                return (IEnumerator<TValue>) new Enumerator(dictionary);
            }


            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator) new Enumerator(dictionary);
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
                if (array.Length - index < dictionary.Count)
                    throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
                TValue[] array1 = array as TValue[];
                if (array1 != null)
                    CopyTo(array1, index);
                else
                {
                    object[] objArray = array as object[];
                    if (objArray == null)
                        throw new ArgumentException("Argument_InvalidArrayType");
                    int num = dictionary.count;
                    Entry[] entryArray = dictionary.entries;
                    try
                    {
                        for (int index1 = 0; index1 < num; ++index1)
                        {
                            if (entryArray[index1].hashCode >= 0)
                                objArray[index++] = (object) entryArray[index1].value;
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
                private DictionaryEx<TKey, TValue> dictionary;
                private int index;
                private int version;
                private TValue currentValue;

                /// <summary>
                ///     Gets the element at the current position of the enumerator.
                /// </summary>
                /// <returns>
                ///     The element in the <see cref="T:System.Collections.Generic.DictionaryEx`2.ValueCollection" /> at the current position
                ///     of the enumerator.
                /// </returns>
                public TValue Current
                {
                    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
                    get { return currentValue; }
                }


                object IEnumerator.Current
                {
                    get
                    {
                        if (index == 0 || index == dictionary.count + 1)
                            throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
                        return (object) currentValue;
                    }
                }

                internal Enumerator(DictionaryEx<TKey, TValue> dictionary)
                {
                    this.dictionary = dictionary;
                    version = dictionary.version;
                    index = 0;
                    currentValue = default(TValue);
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
                    if (version != dictionary.version)
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    for (; (uint) index < (uint) dictionary.count; ++index)
                    {
                        if (dictionary.entries[index].hashCode >= 0)
                        {
                            currentValue = dictionary.entries[index].value;
                            ++index;
                            return true;
                        }
                    }
                    index = dictionary.count + 1;
                    currentValue = default(TValue);
                    return false;
                }


                void IEnumerator.Reset()
                {
                    if (version != dictionary.version)
                        throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
                    index = 0;
                    currentValue = default(TValue);
                }
            }
        }
    }

    public class Factory<T>
        where T: new()
    {
        public T Create()
        {
            return new T();
        }
    }
}