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
    /// Represents a collection of <see cref="SecurityAttributeMemberEntry"/> with the same 
    /// security, model attribute, and effective date.
    /// </summary>
    public class SecurityAttributeViewModel : 
        AttributeEntryCollectionViewModel<SecurityAttributeMemberEntry, Security>
    {
        public SecurityAttributeViewModel(
            Security security, ModelAttribute modelAttribute, DateTime effectiveDate)
            : base(security, modelAttribute, effectiveDate)
        {
        }

        public override SecurityAttributeMemberEntry[] ToEntities() =>
            MemberEntries.Select(
                s => new SecurityAttributeMemberEntry()
                {
                    AttributeMemberId = s.Key,
                    SecurityId = ParentObject.SecurityId,
                    EffectiveDate = EffectiveDate,
                    Weight = Math.Round(s.Value / 100M, 4)
                })
                .ToArray();
    }
}
