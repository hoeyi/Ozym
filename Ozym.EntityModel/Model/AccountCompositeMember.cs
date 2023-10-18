using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosys.DataModel.Annotations;
using Microsoft.EntityFrameworkCore;
using Ozym.EntityModel.Metadata;

namespace Ozym.EntityModel
{
    [Noun(
        Plural = nameof(ModelNoun.AccountCompositeMember_Plural),
        PluralArticle = nameof(ModelNoun.AccountCompositeMember_PluralArticle),
        Singular = nameof(ModelNoun.AccountCompositeMember_Singular),
        SingularArticle = nameof(ModelNoun.AccountCompositeMember_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    [Table("AccountCompositeMember", Schema = "FinanceApp")]
    [Index(nameof(AccountCompositeId), Name = "IX_AccountCompositeMember_AccountCompositeID")]
    [Index(nameof(AccountId), Name = "IX_AccountCompositeMember_AccountID")]
    public partial class AccountCompositeMember
    {
        [Key]
        [Column("AccountCompositeID", Order = 0)]
        public int AccountCompositeId { get; set; }
        [Display(
            Name = nameof(ModelDisplay.AccountCompositeMember_AccountID_Name),
            Description = nameof(ModelDisplay.AccountCompositeMember_AccountID_Description),
            ResourceType = typeof(ModelDisplay))]
        [Key]
        [Column("AccountID", Order = 1)]
        public int AccountId { get; set; }
        [Display(
            Name = nameof(ModelDisplay.AccountCompositeMember_EntryDate_Name),
            Description = nameof(ModelDisplay.AccountCompositeMember_EntryDate_Description),
            ResourceType = typeof(ModelDisplay))]
        [Key]
        [Column(TypeName = "date", Order = 2)]
        public DateTime EntryDate { get; set; }
        [Display(
            Name = nameof(ModelDisplay.AccountCompositeMember_ExitDate_Name),
            Description = nameof(ModelDisplay.AccountCompositeMember_ExitDate_Description),
            ResourceType = typeof(ModelDisplay))]
        [Column(TypeName = "date")]
        public DateTime? ExitDate { get; set; }
        public int DisplayOrder { get; set; }
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [Display(
            Name = nameof(ModelDisplay.AccountCompositeMember_Comment_Name),
            Description = nameof(ModelDisplay.AccountCompositeMember_Comment_Description),
            ResourceType = typeof(ModelDisplay))]
        public string Comment { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("AccountCompositeMembers")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(AccountCompositeId))]
        [InverseProperty("AccountCompositeMembers")]
        public virtual AccountComposite AccountComposite { get; set; }
    }
}
