using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using NjordFinance.Model.Metadata;

namespace NjordFinance.Model
{
    [Table("BankTransaction", Schema = "FinanceApp")]
    [Index(nameof(AccountId), Name = "IX_BankTransaction_AccountID")]
    [Index(nameof(TransactionCodeId), Name = "IX_BankTransaction_TransactionCodeID")]
    public partial class BankTransaction
    {
        [Key]
        [Column("TransactionID")]
        public int TransactionId { get; set; }
        [Column("AccountID")]
        public int AccountId { get; set; }
        [Column(TypeName = "date")]
        public DateTime TransactionDate { get; set; }
        [Column("TransactionCodeID")]
        public int TransactionCodeId { get; set; }
        [Column(TypeName = "decimal(19, 4)")]
        public decimal Amount { get; set; }
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string Comment { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public byte[] TransactionVersion { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("BankTransactions")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(TransactionCodeId))]
        [InverseProperty(nameof(BankTransactionCode.BankTransactions))]
        public virtual BankTransactionCode TransactionCode { get; set; }
    }
}
