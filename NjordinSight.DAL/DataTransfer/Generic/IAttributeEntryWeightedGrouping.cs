using System;

namespace NjordinSight.DataTransfer.Generic
{
    public interface IAttributeEntryWeightedGrouping<TParentEntity, TEntryEntity>
        : IAttributeEntryUnweightedGrouping<TParentEntity, TEntryEntity>
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
