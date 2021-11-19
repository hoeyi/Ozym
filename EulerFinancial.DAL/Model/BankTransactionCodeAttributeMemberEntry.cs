using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("BankTransactionCodeAttributeMemberEntry", Schema = "EulerApp")]
    [Index(nameof(EffectiveDate), nameof(TransactionCodeId), nameof(AttributeMemberId), Name = "UNI_BankTransactionCodeAttributeMemberEntry_RowDef", IsUnique = true)]
    public partial class BankTransactionCodeAttributeMemberEntry
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
        [InverseProperty(nameof(ModelAttributeMember.BankTransactionCodeAttributeMemberEntries))]
        public virtual ModelAttributeMember AttributeMember { get; set; }
        [ForeignKey(nameof(TransactionCodeId))]
        [InverseProperty(nameof(BankTransactionCode.BankTransactionCodeAttributeMemberEntries))]
        public virtual BankTransactionCode TransactionCode { get; set; }
    }
}
