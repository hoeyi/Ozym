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
            ParentObject = security;
            EffectiveDate = effectiveDate;
        }

        /// <summary>
        /// Adds an entry with the given <paramref name="attributeMemberId"/> and 
        /// <paramref name="weight"/>.
        /// </summary>
        /// <param name="attributeMemberId"></param>
        /// <param name="weight"></param>
        public new void AddEntry(int attributeMemberId, decimal weight) => 
            base.AddEntry(attributeMemberId, weight);

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
