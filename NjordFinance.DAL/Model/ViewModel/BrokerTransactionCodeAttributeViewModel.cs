using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel
{
    public class BrokerTransactionCodeAttributeViewModel :
        AttributeEntryViewModel<BrokerTransactionCodeAttributeMemberEntry, BrokerTransactionCode>
    {
        public BrokerTransactionCodeAttributeViewModel(
            BrokerTransactionCode transactionCode, DateTime effectiveDate)
            : base(transactionCode, effectiveDate)
        {
        }

        public override BrokerTransactionCodeAttributeMemberEntry ToEntryEntity() =>
            new()
            {
                AttributeMemberId = AttributeMemberId,
                TransactionCodeId = ParentObject.TransactionCodeId,
                EffectiveDate = EffectiveDate,
                Weight = 100M
            };
    }
}
