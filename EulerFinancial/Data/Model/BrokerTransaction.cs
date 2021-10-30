using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class BrokerTransaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public int? TransactionCodeId { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime? SettleDate { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public int SecurityId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Fee { get; set; }
        public decimal? Withholding { get; set; }
        public int DepSecurityId { get; set; }
        public int? TaxLotId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Security DepSecurity { get; set; }
        public virtual Security Security { get; set; }
        public virtual BrokerTransactionCode TransactionCode { get; set; }
        public virtual BrokerTransactionTaxLot BrokerTransactionTaxLot { get; set; }
    }
}
