using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel
{
    public class BankTransactionCodeAttributeViewModel :
        AttributeEntryViewModel<BankTransactionCodeAttributeMemberEntry, BankTransactionCode>
    {
        public BankTransactionCodeAttributeViewModel(
            BankTransactionCode transactionCode, DateTime effectiveDate)
            : base(transactionCode, effectiveDate)
        {
        }

        public override BankTransactionCodeAttributeMemberEntry ToEntryEntity() =>
            new()
            {
                AttributeMemberId = AttributeMemberId,
                TransactionCodeId = ParentObject.TransactionCodeId,
                EffectiveDate = EffectiveDate,
                Weight = 100M
            };
    }
}
