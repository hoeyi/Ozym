using System;
using System.Collections.Generic;
using NjordinSight.EntityModel;
using NjordinSight.EntityModel.Annotations;
using NjordinSight.DataTransfer.Generic;

namespace NjordinSight.DataTransfer
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.Country | ModelAttributeScopeCode.Security)]
    /// <summary>
    /// Represents a collection of <see cref="SecurityAttributeMemberEntry"/> instances with the same 
    /// <see cref="Security" />, <see cref="ModelAttribute"/>, and effective date.
    /// </summary>
    public class SecurityAttributeGrouping :
        AttributeEntryWeightedGrouping<Security, SecurityAttributeMemberEntry>
    {
        public SecurityAttributeGrouping(
            Security parentEntity,
            ModelAttribute modelAttribute,
            DateTime effectiveDate) : base(parentEntity, modelAttribute, effectiveDate)
        {
        }

        protected override Func<Security, ICollection<SecurityAttributeMemberEntry>>
            ParentEntryMemberSelector => x => x.SecurityAttributeMemberEntries;

        protected override Func<SecurityAttributeMemberEntry, bool> EntrySelector => x =>
            (x.AttributeMember is null || x.AttributeMember.AttributeId == ParentAttribute.AttributeId)
                && x.EffectiveDate == EffectiveDate;

        protected override Func<SecurityAttributeMemberEntry, decimal> WeightSelector => x => x.Weight;

        public override SecurityAttributeMemberEntry AddNewEntry()
        {
            SecurityAttributeMemberEntry newEntry = new()
            {
                SecurityId = ParentObject.SecurityId,
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
            SecurityAttributeMemberEntry entry, DateTime effectiveDate)
        {
            entry.EffectiveDate = effectiveDate;
            return entry.EffectiveDate == effectiveDate;
        }
    }
}
