using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("BankTransactionCode", Schema = "FinanceApp")]
    public partial class BankTransactionCode
    {
        public BankTransactionCode()
        {
            BankTransactionCodeAttributeMemberEntries = new HashSet<BankTransactionCodeAttributeMemberEntry>();
            BankTransactions = new HashSet<BankTransaction>();
        }

        [Key]
        [Column("TransactionCodeID")]
        public int TransactionCodeId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(12,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        public string TransactionCode { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelMetadata.Resources.ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelMetadata.Resources.ModelValidation))]
        public string DisplayName { get; set; }

        [InverseProperty(nameof(BankTransactionCodeAttributeMemberEntry.TransactionCode))]
        public virtual ICollection<BankTransactionCodeAttributeMemberEntry> BankTransactionCodeAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(BankTransaction.TransactionCode))]
        public virtual ICollection<BankTransaction> BankTransactions { get; set; }
    }
}
