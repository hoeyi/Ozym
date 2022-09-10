using NjordFinance.Model.ViewModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;

namespace NjordFinance.Model.ViewModel
{
    public class BankTransactionCodeAttriubeEntryViewModel
        : AttributeEntryGrouping<BankTransactionCode, BankTransactionCodeAttributeMemberEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankTransactionCodeAttriubeEntryViewModel"/> 
        /// class.
        /// </summary>
        /// <param name="parentEntity">The <see cref="BankTransactionCode"/> to which entries in the instance apply.</param>
        /// <param name="modelAttribute">The <see cref="ModelAttribute"/> that entries in the instance describe.</param>
        /// <param name="effectiveDate">The effective date for entries in the instance.</param>
        public BankTransactionCodeAttriubeEntryViewModel(
            BankTransactionCode parentEntity, ModelAttribute modelAttribute, DateTime effectiveDate) 
            : base(parentEntity, modelAttribute, effectiveDate)
        {
        }

        protected override Func<BankTransactionCode, ICollection<BankTransactionCodeAttributeMemberEntry>>
            ParentEntryMemberFor => x => x.BankTransactionCodeAttributeMemberEntries;

        protected override Func<BankTransactionCodeAttributeMemberEntry, bool> EntrySelector => x =>
            (x.AttributeMember is null || x.AttributeMember.AttributeId == ParentAttribute.AttributeId)
            && x.EffectiveDate == EffectiveDate;

        protected override Func<BankTransactionCodeAttributeMemberEntry, decimal> WeightSelector =>
            x => x.Weight;

        public override BankTransactionCodeAttributeMemberEntry AddNewEntry()
        {
            BankTransactionCodeAttributeMemberEntry newEntry = new()
            {
                TransactionCodeId = ParentObject.TransactionCodeId,
                EffectiveDate = EffectiveDate,
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

        protected override bool UpdateEntryEffectiveDate(
            BankTransactionCodeAttributeMemberEntry entry, DateTime effectiveDate)
        {
            entry.EffectiveDate = effectiveDate;
            return entry.EffectiveDate == effectiveDate;
        }
    }
}
