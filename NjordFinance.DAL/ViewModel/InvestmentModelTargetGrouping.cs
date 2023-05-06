using System;
using System.Collections.Generic;
using NjordFinance.EntityModel;
using NjordFinance.ViewModel.Generic;

namespace NjordFinance.ViewModel
{
    /// <summary>
    /// Represents a collection of <see cref="InvestmentStrategyTarget"/> instances with the same 
    /// <see cref="InvestmentStrategy" />, <see cref="ModelAttribute"/>, and effective date.
    /// </summary>
    public class InvestmentModelTargetGrouping
        : AttributeEntryWeightedGrouping<InvestmentStrategy, InvestmentStrategyTarget>
    {
        internal InvestmentModelTargetGrouping(
            InvestmentStrategy parentEntity, ModelAttribute modelAttribute, DateTime effectiveDate)
        : base(parentEntity, modelAttribute, effectiveDate)
        {
        }

        protected override Func<InvestmentStrategy, ICollection<InvestmentStrategyTarget>>
            ParentEntryMemberSelector => x => x.InvestmentStrategyTargets;

        protected override Func<InvestmentStrategyTarget, bool> EntrySelector => x =>
            (x.AttributeMember is null || x.AttributeMember.AttributeId == ParentAttribute.AttributeId)
                && x.EffectiveDate == EffectiveDate;

        protected override Func<InvestmentStrategyTarget, decimal> WeightSelector => x => x.Weight;

        public override InvestmentStrategyTarget AddNewEntry()
        {
            InvestmentStrategyTarget newEntry = new()
            {
                InvestmentStrategyId = ParentObject.InvestmentStrategyId,
                EffectiveDate = EffectiveDate,
                Weight = default,
                AttributeMemberId = default,
                AttributeMember = new()
                {
                    AttributeMemberId = default,
                    AttributeId = ParentAttribute.AttributeId,
                    Attribute = ParentAttribute
                }
            };

            AddEntry(newEntry);

            return newEntry;
        }

        protected override bool UpdateEntryEffectiveDate(
            InvestmentStrategyTarget entry, DateTime effectiveDate)
        {
            entry.EffectiveDate = effectiveDate;
            return entry.EffectiveDate == effectiveDate;
        }
    }
}