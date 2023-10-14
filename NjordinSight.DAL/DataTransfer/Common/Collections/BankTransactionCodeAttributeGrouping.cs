using NjordinSight.DataTransfer.Common.Generic;
using System;
using System.Collections.Generic;

namespace NjordinSight.DataTransfer.Common.Collections
{
    public class BankTransactionCodeAttributeGrouping
        : AttributeEntryUnweightedGrouping<BankTransactionCodeDto, BankTransactionCodeAttributeDto>,
        IAttributeEntryUnweightedGrouping<BankTransactionCodeDto, BankTransactionCodeAttributeDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankTransactionCodeAttributeGrouping"/> 
        /// class.
        /// </summary>
        /// <param name="parentEntity">The <see cref="BankTransactionCodeDto"/> to which entries in the instance apply.</param>
        /// <param name="modelAttribute">The <see cref="ModelAttributeDtoBase"/> that entries in the instance describe.</param>
        /// <param name="effectiveDate">The effective date for entries in the instance.</param>
        public BankTransactionCodeAttributeGrouping(
            BankTransactionCodeDto parentEntity, ModelAttributeDtoBase modelAttribute)
            : base(parentEntity, modelAttribute)
        {
        }

        /// <inheritdoc/>
        protected override Func<BankTransactionCodeDto, ICollection<BankTransactionCodeAttributeDto>>
            ParentEntryMemberSelector => x => x.Attributes;

        /// <inheritdoc/>
        protected override Func<BankTransactionCodeAttributeDto, bool> EntrySelector => x =>
            x.AttributeMember.Attribute.AttributeId == ParentAttribute.AttributeId;

        /// <inheritdoc/>
        protected override Func<BankTransactionCodeAttributeDto, decimal> WeightSelector =>
            x => x.PercentWeight;

        /// <inheritdoc/>
        public override BankTransactionCodeAttributeDto AddNewEntry()
        {
            BankTransactionCodeAttributeDto newEntry = new()
            {
                TransactionCodeId = ParentObject.TransactionCodeId,
                EffectiveDate = DateTime.UtcNow.Date,
                PercentWeight = 1M,
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
    }
}
