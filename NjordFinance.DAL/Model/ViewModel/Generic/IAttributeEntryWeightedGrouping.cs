using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel.Generic
{
    public interface IAttributeEntryWeightedGrouping<TParentEntity, TEntryEntity>
        : IAttributeEntryGrouping<TParentEntity, TEntryEntity>
        where TParentEntity : class, new()
        where TEntryEntity : class, new()
    {

        /// <summary>
        /// Gets the effective date for entries in this collection.
        /// </summary>
        DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Gets the sum of all entry weights in this grouping.
        /// </summary>
        public decimal SumOfMemberWeights { get; }
    }
}
