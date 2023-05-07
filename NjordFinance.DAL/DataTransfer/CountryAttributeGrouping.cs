using System;
using System.Collections.Generic;
using NjordFinance.EntityModel;
using NjordFinance.EntityModel.Annotations;
using NjordFinance.DataTransfer.Generic;

namespace NjordFinance.DataTransfer
{
    [ModelAttributeSupport(SupportedScopes = ModelAttributeScopeCode.Country)]
    /// <summary>
    /// Represents a collection of <see cref="CountryAttributeMemberEntry"/> instances with the same 
    /// <see cref="Country" />, <see cref="ModelAttribute"/>, and effective date.
    /// </summary>
    public class CountryAttributeGrouping :
        AttributeEntryWeightedGrouping<Country, CountryAttributeMemberEntry>
    {
        public CountryAttributeGrouping(
            Country parentEntity,
            ModelAttribute modelAttribute,
            DateTime effectiveDate) : base(parentEntity, modelAttribute, effectiveDate)
        {
        }

        protected override Func<Country, ICollection<CountryAttributeMemberEntry>>
            ParentEntryMemberSelector => x => x.CountryAttributeMemberEntries;

        protected override Func<CountryAttributeMemberEntry, bool> EntrySelector => x =>
            (x.AttributeMember is null || x.AttributeMember.AttributeId == ParentAttribute.AttributeId)
                && x.EffectiveDate == EffectiveDate;

        protected override Func<CountryAttributeMemberEntry, decimal> WeightSelector => x => x.Weight;

        public override CountryAttributeMemberEntry AddNewEntry()
        {
            CountryAttributeMemberEntry newEntry = new()
            {
                CountryId = ParentObject.CountryId,
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
            CountryAttributeMemberEntry entry, DateTime effectiveDate)
        {
            entry.EffectiveDate = effectiveDate;
            return entry.EffectiveDate == effectiveDate;
        }
    }
}
