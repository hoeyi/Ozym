using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.Model
{
    [Table("BrokerTransactionTaxLot", Schema = "EulerApp")]
    public partial class BrokerTransactionTaxLot
    {
        [Key]
        [Column("TransactionID")]
        public int TransactionId { get; set; }
        [Column("TransactionIDCloseVersus")]
        public int TransactionIdcloseVersus { get; set; }
        [Column(TypeName = "decimal(19, 6)")]
        public decimal Quantity { get; set; }

        [ForeignKey(nameof(TransactionId))]
        [InverseProperty(nameof(BrokerTransaction.BrokerTransactionTaxLot))]
        public virtual BrokerTransaction Transaction { get; set; } = null!;
    }
}
