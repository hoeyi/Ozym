using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosys.DataModel.Annotations;
using Microsoft.EntityFrameworkCore;
using NjordinSight.EntityModel.Metadata;

namespace NjordinSight.EntityModel
{
    [Table("AccountAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(AccountObjectId), Name = "IX_AccountAttributeMemberEntry_AccountObjectID")]
    [Index(nameof(AttributeMemberId), Name = "IX_AccountAttributeMemberEntry_AttributeMemberID")]
    [Noun(
        Plural = nameof(ModelNoun.AccountAttributeMemberEntry_Plural),
        PluralArticle = nameof(ModelNoun.AccountAttributeMemberEntry_PluralArticle),
        Singular = nameof(ModelNoun.AccountAttributeMemberEntry_Singular),
        SingularArticle = nameof(ModelNoun.AccountAttributeMemberEntry_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public partial class AccountAttributeMemberEntry
    {
        [Key]
        [Column("AttributeMemberID", Order = 0)]
        public int AttributeMemberId { get; set; }
        [Key]
        [Column("AccountObjectID", Order = 1)]
        public int AccountObjectId { get; set; }
        [Key]
        [Column(TypeName = "date", Order = 2)]
        public DateTime EffectiveDate { get; set; }
        [Column(TypeName = "decimal(5, 4)")]
        public decimal Weight { get; set; }

        [ForeignKey(nameof(AccountObjectId))]
        [InverseProperty("AccountAttributeMemberEntries")]
        public virtual AccountObject AccountObject { get; set; }
        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.AccountAttributeMemberEntries))]
        public virtual ModelAttributeMember AttributeMember { get; set; }
    }
}
