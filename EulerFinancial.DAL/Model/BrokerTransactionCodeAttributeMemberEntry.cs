using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EulerFinancial.Model
{
    [Table("BrokerTransactionCodeAttributeMemberEntry", Schema = "EulerApp")]
    [Index(nameof(EffectiveDate), nameof(TransactionCodeId), nameof(AttributeMemberId), Name = "UNI_BrokerTransactionCodeAttributeMemberEntry_RowDef", IsUnique = true)]
    public partial class BrokerTransactionCodeAttributeMemberEntry
    {
        [Key]
        [Column("EntryID")]
        public int EntryId { get; set; }
        [Column("AttributeMemberID")]
        public int AttributeMemberId { get; set; }
        [Column("TransactionCodeID")]
        public int TransactionCodeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime EffectiveDate { get; set; }
        [Column(TypeName = "decimal(5, 4)")]
        public decimal Weight { get; set; }

        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.BrokerTransactionCodeAttributeMemberEntries))]
        public virtual ModelAttributeMember AttributeMember { get; set; } = null!;
        [ForeignKey(nameof(TransactionCodeId))]
        [InverseProperty(nameof(BrokerTransactionCode.BrokerTransactionCodeAttributeMemberEntries))]
        public virtual BrokerTransactionCode TransactionCode { get; set; } = null!;
    }
}
