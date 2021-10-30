using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class BrokerTransactionTaxLot
    {
        public int TransactionId { get; set; }
        public int TransactionIdcloseVersus { get; set; }
        public decimal Quantity { get; set; }

        public virtual BrokerTransaction Transaction { get; set; }
    }
}
