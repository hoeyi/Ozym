using NjordFinance.Model.ViewModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;

namespace NjordFinance.Model.ViewModel
{
    public class BrokerTransactionCodeAttributeGrouping
        : AttributeEntryUnweightedGrouping<BrokerTransactionCode, BrokerTransactionCodeAttributeMemberEntry>,
        IAttributeEntryUnweightedGrouping<BrokerTransactionCode, BrokerTransactionCodeAttributeMemberEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankTransactionCodeAttributeGrouping"/> 
        /// class.
        /// </summary>
        /// <param name="parentEntity">The <see cref="BrokerTransactionCode"/> to which entries in the instance apply.</param>
        /// <param name="modelAttribute">The <see cref="ModelAttribute"/> that entries in the instance describe.</param>
        /// <param name="effectiveDate">The effective date for entries in the instance.</param>
        public BrokerTransactionCodeAttributeGrouping(
            BrokerTransactionCode parentEntity, ModelAttribute modelAttribute)
            : base(parentEntity, modelAttribute)
        {
        }

        /// <inheritdoc/>
        protected override Func<BrokerTransactionCode, ICollection<BrokerTransactionCodeAttributeMemberEntry>>
            ParentEntryMemberSelector => x => x.BrokerTransactionCodeAttributeMemberEntries;

        /// <inheritdoc/>
        protected override Func<BrokerTransactionCodeAttributeMemberEntry, bool> EntrySelector => x =>
            (x.AttributeMember is null || x.AttributeMember.AttributeId == ParentAttribute.AttributeId);

        /// <inheritdoc/>
        protected override Func<BrokerTransactionCodeAttributeMemberEntry, decimal> WeightSelector =>
            x => x.Weight;

        /// <inheritdoc/>
        public override BrokerTransactionCodeAttributeMemberEntry AddNewEntry()
        {
            BrokerTransactionCodeAttributeMemberEntry newEntry = new()
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
