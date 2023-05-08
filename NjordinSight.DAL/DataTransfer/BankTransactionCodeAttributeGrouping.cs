using NjordinSight.EntityModel;
using NjordinSight.DataTransfer.Generic;
using System;
using System.Collections.Generic;

namespace NjordinSight.DataTransfer
{
    public class BankTransactionCodeAttributeGrouping
        : AttributeEntryUnweightedGrouping<BankTransactionCode, BankTransactionCodeAttributeMemberEntry>,
        IAttributeEntryUnweightedGrouping<BankTransactionCode, BankTransactionCodeAttributeMemberEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankTransactionCodeAttributeGrouping"/> 
        /// class.
        /// </summary>
        /// <param name="parentEntity">The <see cref="BankTransactionCode"/> to which entries in the instance apply.</param>
        /// <param name="modelAttribute">The <see cref="ModelAttribute"/> that entries in the instance describe.</param>
        /// <param name="effectiveDate">The effective date for entries in the instance.</param>
        public BankTransactionCodeAttributeGrouping(
            BankTransactionCode parentEntity, ModelAttribute modelAttribute)
            : base(parentEntity, modelAttribute)
        {
        }

        /// <inheritdoc/>
        protected override Func<BankTransactionCode, ICollection<BankTransactionCodeAttributeMemberEntry>>
            ParentEntryMemberSelector => x => x.BankTransactionCodeAttributeMemberEntries;

        /// <inheritdoc/>
        protected override Func<BankTransactionCodeAttributeMemberEntry, bool> EntrySelector => x =>
            x.AttributeMember is null || x.AttributeMember.AttributeId == ParentAttribute.AttributeId;

        /// <inheritdoc/>
        protected override Func<BankTransactionCodeAttributeMemberEntry, decimal> WeightSelector =>
            x => x.Weight;

        /// <inheritdoc/>
        public override BankTransactionCodeAttributeMemberEntry AddNewEntry()
        {
            BankTransactionCodeAttributeMemberEntry newEntry = new()
            {
                TransactionCodeId = ParentObject.TransactionCodeId,
                EffectiveDate = DateTime.UtcNow.Date,
                Weight = 1M,
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
    }
}
