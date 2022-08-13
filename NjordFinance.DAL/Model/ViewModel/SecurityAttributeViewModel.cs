using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model.Annotations;
using NjordFinance.Model.Metadata;
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

        protected override IEnumerable<SecurityAttributeMemberEntry> SelectEntries(
            Security parentEntity, ModelAttribute parentAttribute, DateTime effectiveDate)
            => parentEntity.SecurityAttributeMemberEntries.Where(s =>
                s.AttributeMember.AttributeId == parentAttribute.AttributeId &&
                s.EffectiveDate == effectiveDate);
    }
}
