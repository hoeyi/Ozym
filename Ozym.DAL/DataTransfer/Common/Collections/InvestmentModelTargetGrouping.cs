using System;
using System.Collections.Generic;
using Ozym.DataTransfer.Common.Generic;

namespace Ozym.DataTransfer.Common.Collections
{
    /// <summary>
    /// Represents a collection of <see cref="InvestmentModelTargetDto"/> instances with the same 
    /// <see cref="InvestmentModelDto" />, <see cref="ModelAttributeDtoBase"/>, and effective date.
    /// </summary>
    public class InvestmentModelTargetGrouping
        : AttributeEntryWeightedGrouping<InvestmentModelDto, InvestmentModelTargetDto>
    {
        internal InvestmentModelTargetGrouping(
            InvestmentModelDto parentEntity, ModelAttributeDtoBase modelAttribute, DateTime effectiveDate)
        : base(parentEntity, modelAttribute, effectiveDate)
        {
        }

        protected override Func<InvestmentModelDto, ICollection<InvestmentModelTargetDto>>
            ParentEntryMemberSelector => x => x.Targets;

        protected override Func<InvestmentModelTargetDto, bool> EntrySelector => x =>
            x.AttributeMember.Attribute.AttributeId == ParentAttribute.AttributeId
                && x.EffectiveDate == EffectiveDate;

        protected override Func<InvestmentModelTargetDto, decimal> WeightSelector => x => x.PercentWeight;

        public override InvestmentModelTargetDto AddNewEntry()
        {
            InvestmentModelTargetDto newEntry = new()
            {
                InvestmentModelId = ParentObject.InvestmentModelId,
                EffectiveDate = EffectiveDate,
                PercentWeight = default,
                AttributeMemberId = default,
                AttributeMember = new()
                {
                    AttributeMemberId = default,
                    Attribute = ParentAttribute
                }
            };

            AddEntry(newEntry);

            return newEntry;
        }

        protected override bool UpdateEntryEffectiveDate(
            InvestmentModelTargetDto entry, DateTime effectiveDate)
        {
            entry.EffectiveDate = effectiveDate;
            return entry.EffectiveDate == effectiveDate;
        }
    }
}