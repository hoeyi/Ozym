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
    public class SecurityAttributeEntryViewModel
    {
        private readonly Dictionary<int, decimal> _memberEntries = new();

        public SecurityAttributeEntryViewModel(
            int securityId, int modelAttributeId, DateTime effectiveDate)
        {
            SecurityId = securityId;
            ModelAttributeId = modelAttributeId;
            EffectiveDate = effectiveDate;
        }

        /// <summary>
        /// Gets the id of the <see cref="Security"/> entity to which entries in 
        /// <see cref="MemberEntries"/> apply. 
        /// </summary>
        public int SecurityId { get; init; }

        /// <summary>
        /// Gets the id of the <see cref="ModelAttribute"/> entity that is the parent of the 
        /// of the values in <see cref="MemberEntries"/>.
        /// </summary>
        [Display(
            Name = nameof(ModelDisplay.SecurityAttributeEntryViewModel_ModelAttributeId),
            ResourceType = typeof(ModelDisplay))]
        public int ModelAttributeId { get; init; }

        /// <summary>
        /// Gets the effective date of the collection of values in <see cref="MemberEntries"/>.
        /// </summary>
        [Display(
            Name = nameof(ModelDisplay.SecurityAttributeEntryViewModel_EffectiveDate),
            ResourceType = typeof(ModelDisplay))]
        public DateTime EffectiveDate { get; init; }

        [ExactValue(100D)]
        [Display(
            Name = nameof(ModelDisplay.SecurityAttributeEntryViewModel_SumOfWeights),
            ResourceType = typeof(ModelDisplay))]
        public decimal SumOfMemberWeights => MemberEntries.Sum(kv => kv.Value);

        /// <summary>
        /// Gets the collection of entries representing <see cref="SecurityAttributeMemberEntry"/> 
        /// entities, where the key represents <see cref="SecurityAttributeMemberEntry.AttributeMemberId"/> 
        /// and the value represents <see cref="SecurityAttributeMemberEntry.Weight"/>.
        /// </summary>
        public IReadOnlyDictionary<int, decimal> MemberEntries => _memberEntries;

        /// <summary>
        /// Adds an entry with the given <paramref name="attributeMemberId"/> and 
        /// <paramref name="weight"/>.
        /// </summary>
        /// <param name="attributeMemberId"></param>
        /// <param name="weight"></param>
        public void AddEntry(int attributeMemberId, decimal weight) => 
            _memberEntries.Add(key: attributeMemberId, value: weight);

        /// <summary>
        /// Converts this model into <see cref="SecurityAttributeMemberEntry"/> entities.
        /// </summary>
        /// <returns>An <see cref="Array"/> of <see cref="SecurityAttributeMemberEntry"/>.</returns>
        public SecurityAttributeMemberEntry[] ToSecurityAttributeMemberEntries() =>
            MemberEntries.Select(
                s => new SecurityAttributeMemberEntry()
                {
                    AttributeMemberId = s.Key,
                    SecurityId = SecurityId,
                    EffectiveDate = EffectiveDate,
                    Weight = Math.Round(s.Value / 100M, 4)
                })
                .ToArray();
    }
}
