﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("BrokerTransaction", Schema = "EulerApp")]
    public partial class BrokerTransaction
    {
        [Key]
        [Column("TransactionID")]
        public int TransactionId { get; set; }
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Column("TransactionCodeID")]
        public int? TransactionCodeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime TradeDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? SettleDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? AcquisitionDate { get; set; }
        [Column("SecurityID")]
        public int SecurityId { get; set; }
        [Column(TypeName = "decimal(19, 6)")]
        public decimal? Quantity { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "decimal(9, 4)")]
        public decimal? Fee { get; set; }
        [Column(TypeName = "decimal(9, 4)")]
        public decimal? Withholding { get; set; }
        [Column("DepSecurityID")]
        public int DepSecurityId { get; set; }
        [Column("TaxLotID")]
        public int? TaxLotId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("BrokerTransactions")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(DepSecurityId))]
        [InverseProperty("BrokerTransactionDepSecurities")]
        public virtual Security DepSecurity { get; set; }
        [ForeignKey(nameof(SecurityId))]
        [InverseProperty("BrokerTransactionSecurities")]
        public virtual Security Security { get; set; }
        [ForeignKey(nameof(TransactionCodeId))]
        [InverseProperty(nameof(BrokerTransactionCode.BrokerTransactions))]
        public virtual BrokerTransactionCode TransactionCode { get; set; }
        [InverseProperty("Transaction")]
        public virtual BrokerTransactionTaxLot BrokerTransactionTaxLot { get; set; }
    }
}
