using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class BrokerTransactionCode
    {
        public BrokerTransactionCode()
        {
            BrokerTransactionCodeAttributeMemberEntries = new HashSet<BrokerTransactionCodeAttributeMemberEntry>();
            BrokerTransactions = new HashSet<BrokerTransaction>();
        }

        public int TransactionCodeId { get; set; }
        public string TransactionCode { get; set; }
        public string DisplayName { get; set; }
        public byte CashEffect { get; set; }
        public byte ContributionWithdrawalEffect { get; set; }
        public byte QuantityEffect { get; set; }

        public virtual ICollection<BrokerTransactionCodeAttributeMemberEntry> BrokerTransactionCodeAttributeMemberEntries { get; set; }
        public virtual ICollection<BrokerTransaction> BrokerTransactions { get; set; }
    }
}
