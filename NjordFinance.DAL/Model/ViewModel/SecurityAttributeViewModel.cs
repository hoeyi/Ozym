using System;
using System.Collections.Generic;
using NjordFinance.Model.Annotations;
using NjordFinance.Model.ViewModel.Generic;

namespace NjordFinance.Model.ViewModel
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.Country | ModelAttributeScopeCode.Security)]
    /// <summary>
    /// Represents a collection of <see cref="SecurityAttributeMemberEntry"/> instances with the same 
    /// <see cref="Security" />, <see cref="ModelAttribute"/>, and effective date.
    /// </summary>
    public partial class SecurityAttributeViewModel :
        AttributeEntryGrouping<Security, SecurityAttributeMemberEntry>
    {
        public SecurityAttributeViewModel(
            Security parentObject,
            ModelAttribute parentAttribute,
            DateTime effectiveDate) : base(parentObject, parentAttribute, effectiveDate)
        {
        }

        protected override Func<SecurityAttributeMemberEntry, decimal> WeightSelector =>
            x => x.Weight;

        protected override Func<Security, ICollection<SecurityAttributeMemberEntry>> ParentEntryMemberSelector =>
            x => x.SecurityAttributeMemberEntries;

        protected override Func<SecurityAttributeMemberEntry, bool> EntrySelector => x =>
            x.AttributeMember.AttributeId == ParentAttribute.AttributeId && x.EffectiveDate == EffectiveDate;

        public override SecurityAttributeMemberEntry AddNewEntry()
        {
            SecurityAttributeMemberEntry newEntry = new()
            {
                SecurityId = ParentObject.SecurityId,
                EffectiveDate = EffectiveDate,
                Weight = default
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
