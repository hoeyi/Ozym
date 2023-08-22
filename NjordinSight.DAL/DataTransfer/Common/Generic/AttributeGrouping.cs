using System.Collections.Generic;
using System.Linq;
using NjordinSight.EntityModel;

namespace NjordinSight.DataTransfer.Common.Generic
{
    /// <summary>
    /// Represents a collection of <typeparamref name="TElement"/> records grouped by 
    /// a related <see cref="ModelAttributeDto"/> record.
    /// </summary>
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
