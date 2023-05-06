using NjordFinance.EntityModel.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.EntityModel
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

        [Display(
            Name = nameof(ModelDisplay.BankTransactionCode_TransactionCode_Name),
            Description = nameof(ModelDisplay.BankTransactionCode_TransactionCode_Description),
            ResourceType = typeof(ModelDisplay))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(12,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string TransactionCode { get; set; }

        [Display(
            Name = nameof(ModelDisplay.BankTransactionCode_DisplayName_Name),
            Description = nameof(ModelDisplay.BankTransactionCode_DisplayName_Description),
            ResourceType = typeof(ModelDisplay))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string DisplayName { get; set; }

        [InverseProperty(nameof(BankTransactionCodeAttributeMemberEntry.TransactionCode))]
        public virtual ICollection<BankTransactionCodeAttributeMemberEntry> BankTransactionCodeAttributeMemberEntries { get; set; }
        [InverseProperty(nameof(BankTransaction.TransactionCode))]
        public virtual ICollection<BankTransaction> BankTransactions { get; set; }
    }
}
