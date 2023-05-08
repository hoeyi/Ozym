using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosys.DataModel.Annotations;
using Microsoft.EntityFrameworkCore;
using NjordinSight.EntityModel.Metadata;

namespace NjordinSight.EntityModel
{
    [Table("BankTransaction", Schema = "FinanceApp")]
    [Index(nameof(AccountId), Name = "IX_BankTransaction_AccountID")]
    [Index(nameof(TransactionCodeId), Name = "IX_BankTransaction_TransactionCodeID")]
    [Noun(
        Plural = nameof(ModelNoun.BankTransaction_Plural),
        PluralArticle = nameof(ModelNoun.BankTransaction_PluralArticle),
        Singular = nameof(ModelNoun.BankTransaction_Singular),
        SingularArticle = nameof(ModelNoun.BankTransaction_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public partial class BankTransaction
    {
        [Key]
        [Column("TransactionID")]
        public int TransactionId { get; set; }
        
        [Column("AccountID")]
        public int AccountId { get; set; }
        
        [Column(TypeName = "date")]
        [Display(
            Name = nameof(ModelDisplay.BankTransaction_TransactionDate_Name),
            Description = nameof(ModelDisplay.BankTransaction_TransactionDate_Description),
            ResourceType = typeof(ModelDisplay))]
        public DateTime TransactionDate { get; set; }
        
        [Column("TransactionCodeID")]
        [Display(
            Name = nameof(ModelDisplay.BankTransaction_TransactionCodeID_Name),
            Description = nameof(ModelDisplay.BankTransaction_TransactionCodeID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int TransactionCodeId { get; set; }

        [Column(TypeName = "decimal(19, 4)")]
        [Display(
            Name = nameof(ModelDisplay.BankTransaction_Amount_Name),
            Description = nameof(ModelDisplay.BankTransaction_Amount_Description),
            ResourceType = typeof(ModelDisplay))]
        public decimal Amount { get; set; }
        
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [Display(
            Name = nameof(ModelDisplay.BankTransaction_Comment_Name),
            Description = nameof(ModelDisplay.BankTransaction_Comment_Description),
            ResourceType = typeof(ModelDisplay))]
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
