using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosys.DataModel.Annotations;
using Microsoft.EntityFrameworkCore;
using NjordFinance.EntityModel.Metadata;

namespace NjordFinance.EntityModel
{
    [Table("BankTransactionCodeAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(AttributeMemberId), Name = "IX_BankTransactionCodeAttributeMemberEntry_AttributeMemberID")]
    [Index(nameof(TransactionCodeId), Name = "IX_BankTransactionCodeAttributeMemberEntry_TransactionCodeID")]
    [Noun(
        Plural = nameof(ModelNoun.BankTransactionCodeAttributeMemberEntry_Plural),
        PluralArticle = nameof(ModelNoun.BankTransactionCodeAttributeMemberEntry_PluralArticle),
        Singular = nameof(ModelNoun.BankTransactionCodeAttributeMemberEntry_Singular),
        SingularArticle = nameof(ModelNoun.BankTransactionCodeAttributeMemberEntry_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public partial class BankTransactionCodeAttributeMemberEntry
    {
        [Display(
            Name = nameof(ModelDisplay.BankTransactionCodeAttributeMemberEntry_AttributeMemberId_Name),
            Description = nameof(ModelDisplay.BankTransactionCodeAttributeMemberEntry_AttributeMemberID_Description),
            ResourceType = typeof(ModelDisplay))]
        [Key]
        [Column("AttributeMemberID", Order = 0)]
        public int AttributeMemberId { get; set; }
        
        [Key]
        [Column("TransactionCodeID", Order = 1)]
        public int TransactionCodeId { get; set; }

        [Display(
            Name = nameof(ModelDisplay.BankTransactionCodeAttributeMemberEntry_EffectiveDate_Name),
            Description = nameof(ModelDisplay.BankTransactionCodeAttributeMemberEntry_EffectiveDate_Description),
            ResourceType = typeof(ModelDisplay))]
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
