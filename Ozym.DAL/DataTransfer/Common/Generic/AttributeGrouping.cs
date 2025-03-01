﻿using System.Collections.Generic;
using System.Linq;

namespace Ozym.DataTransfer.Common.Generic
{
    /// <summary>
    /// Represents a collection of objects that have a common key.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TElement"></typeparam>
    public class AttributeGrouping<TKey, TElement> : List<TElement>, IGrouping<TKey, TElement>
    {
        public AttributeGrouping(TKey key) : base() => Key = key;
        public AttributeGrouping(TKey key, int capacity) : base(capacity) => Key = key;
        public AttributeGrouping(TKey key, IEnumerable<TElement> collection)
            : base(collection) => Key = key;

        /// <summary>
        /// Gets the <typeparamref name="TKey"/> that serves as the key for this grouping.
        /// </summary>
        public TKey Key { get; }
    }
}
