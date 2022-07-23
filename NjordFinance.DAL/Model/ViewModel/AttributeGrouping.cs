using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel
{
    /// <summary>
    /// Represents a collection of <typeparamref name="TElement"/> records grouped by 
    /// a related <see cref="ModelAttribute"/> record.
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    public class AttributeGrouping<TElement> : List<TElement>, IGrouping<ModelAttribute, TElement>
    {
        public AttributeGrouping(ModelAttribute key) : base() => Key = key;
        public AttributeGrouping(ModelAttribute key, int capacity) : base(capacity) => Key = key;
        public AttributeGrouping(ModelAttribute key, IEnumerable<TElement> collection)
            : base(collection) => Key = key;

        public ModelAttribute Key { get; }
    }
}
