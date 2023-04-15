using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.ViewModel
{
    public class BrokerTransactionViewModel
    {
        public class TransactionCode
        {
            internal int TransactionCodeId { get; set; }
        }

        public int TransactionId { get; set; }
        public int AccountId { get; set; }

        public TransactionCode TranCode { get; set; }

        public DateTime TradeDate { get; set; }

        public DateTime? SettleDate { get; set; }

        public DateTime? AcquisitionDate { get; set; }
        public decimal Amount { get; set; }

        public decimal? Quantity { get; set; }

    }
}
