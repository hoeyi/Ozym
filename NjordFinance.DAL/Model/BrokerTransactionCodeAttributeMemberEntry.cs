using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("BrokerTransactionCodeAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(AttributeMemberId), Name = "IX_BrokerTransactionCodeAttributeMemberEntry_AttributeMemberID")]
    [Index(nameof(TransactionCodeId), Name = "IX_BrokerTransactionCodeAttributeMemberEntry_TransactionCodeID")]
    public partial class BrokerTransactionCodeAttributeMemberEntry
    {
        [Key]
        [Column("AttributeMemberID")]
        public int AttributeMemberId { get; set; }
        [Key]
        [Column("TransactionCodeID")]
        public int TransactionCodeId { get; set; }
        [Key]
        [Column(TypeName = "date")]
        public DateTime EffectiveDate { get; set; }
        [Column(TypeName = "decimal(5, 4)")]
        public decimal Weight { get; set; }

        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.BrokerTransactionCodeAttributeMemberEntries))]
        public virtual ModelAttributeMember AttributeMember { get; set; }
        [ForeignKey(nameof(TransactionCodeId))]
        [InverseProperty(nameof(BrokerTransactionCode.BrokerTransactionCodeAttributeMemberEntries))]
        public virtual BrokerTransactionCode TransactionCode { get; set; }
    }
}
