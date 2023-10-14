using System;
using System.Collections.Generic;
using NjordinSight.EntityModel;
using NjordinSight.EntityModel.Annotations;
using NjordinSight.DataTransfer.Common.Generic;

namespace NjordinSight.DataTransfer.Common.Collections
{
    [ModelAttributeSupport(SupportedScopes = ModelAttributeScopeCode.Country)]
    /// <summary>
    /// Represents a collection of <see cref="CountryAttributeDto"/> instances with the same 
    /// <see cref="CountryDto" />, <see cref="ModelAttributeDtoBase"/>, and effective date.
    /// </summary>
    public class CountryAttributeGrouping :
        AttributeEntryWeightedGrouping<CountryDto, CountryAttributeDto>
    {
        public CountryAttributeGrouping(
            CountryDto parentEntity,
            ModelAttributeDtoBase modelAttribute,
            DateTime effectiveDate) : base(parentEntity, modelAttribute, effectiveDate)
        {
        }

        protected override Func<CountryDto, ICollection<CountryAttributeDto>>
            ParentEntryMemberSelector => x => x.Attributes;

        protected override Func<CountryAttributeDto, bool> EntrySelector => x =>
            x.AttributeMember.Attribute.AttributeId == ParentAttribute.AttributeId
                && x.EffectiveDate == EffectiveDate;

        protected override Func<CountryAttributeDto, decimal> WeightSelector => x => x.PercentWeight;

        public override CountryAttributeDto AddNewEntry()
        {
            CountryAttributeDto newEntry = new()
            {
                CountryId = ParentObject.CountryId,
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
            CountryAttributeDto entry, DateTime effectiveDate)
        {
            entry.EffectiveDate = effectiveDate;
            return entry.EffectiveDate == effectiveDate;
        }
    }
}
