using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("BankTransactionCodeAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(AttributeMemberId), Name = "IX_BankTransactionCodeAttributeMemberEntry_AttributeMemberID")]
    [Index(nameof(TransactionCodeId), Name = "IX_BankTransactionCodeAttributeMemberEntry_TransactionCodeID")]
    public partial class BankTransactionCodeAttributeMemberEntry
    {
        [Key]
        [Column("AttributeMemberID", Order = 0)]
        public int AttributeMemberId { get; set; }
        
        [Key]
        [Column("TransactionCodeID", Order = 1)]
        public int TransactionCodeId { get; set; }
        [Key]
        [Column(TypeName = "date", Order = 2)]
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
