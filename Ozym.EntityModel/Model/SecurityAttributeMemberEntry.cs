using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosys.DataModel.Annotations;
using Microsoft.EntityFrameworkCore;
using Ozym.EntityModel.Metadata;

namespace Ozym.EntityModel
{
    [Table("SecurityAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(AttributeMemberId), Name = "IX_SecurityAttributeMemberEntry_AttributeMemberID")]
    [Index(nameof(SecurityId), Name = "IX_SecurityAttributeMemberEntry_SecurityID")]
    [Noun(
        Plural = nameof(ModelNoun.SecurityAttributeMemberEntry_Plural),
        PluralArticle = nameof(ModelNoun.SecurityAttributeMemberEntry_PluralArticle),
        Singular = nameof(ModelNoun.SecurityAttributeMemberEntry_Singular),
        SingularArticle = nameof(ModelNoun.SecurityAttributeMemberEntry_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public partial class SecurityAttributeMemberEntry
    {
        [Key]
        [Column("AttributeMemberID", Order = 0)]
        public int AttributeMemberId { get; set; }
        [Key]
        [Column("SecurityID", Order = 1)]
        public int SecurityId { get; set; }
        [Key]
        [Column(TypeName = "date", Order = 12)]
        public DateTime EffectiveDate { get; set; }
        [Column(TypeName = "decimal(5, 4)")]
        public decimal Weight { get; set; }

        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.SecurityAttributeMemberEntries))]
        public virtual ModelAttributeMember AttributeMember { get; set; }
        [ForeignKey(nameof(SecurityId))]
        [InverseProperty("SecurityAttributeMemberEntries")]
        public virtual Security Security { get; set; }
    }
}
