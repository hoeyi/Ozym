using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.ModelMetadata.Resources;

namespace NjordFinance.Model.ViewModel
{
    /// <summary>
    /// Represents a collection of <see cref="SecurityAttributeMemberEntry"/> instances with the same 
    /// <see cref="Security" />, <see cref="ModelAttribute"/>, and effective date.
    /// </summary>
    public class SecurityAttributeViewModel : 
        AttributeEntryCollectionViewModel<SecurityAttributeMemberEntry, Security>
    {
        public SecurityAttributeViewModel(
            Security security, ModelAttribute modelAttribute, DateTime effectiveDate)
            : base(security, modelAttribute, effectiveDate)
        {
        }

        protected override Func<SecurityAttributeMemberEntry, decimal> WeightSelector => x => x.Weight;

        public override SecurityAttributeMemberEntry[] ToEntities() =>
            MemberEntries.Select(
                s => new SecurityAttributeMemberEntry()
                {
                    AttributeMemberId = s.AttributeMemberId,
                    SecurityId = ParentObject.SecurityId,
                    EffectiveDate = EffectiveDate,
                    Weight = s.Weight
                })
                .ToArray();
    }
}
