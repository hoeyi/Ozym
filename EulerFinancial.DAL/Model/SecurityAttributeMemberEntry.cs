using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("SecurityAttributeMemberEntry", Schema = "EulerApp")]
    [Index(nameof(EffectiveDate), nameof(SecurityId), nameof(AttributeMemberId), Name = "UNI_SecurityAttributeMemberEntry_RowDef", IsUnique = true)]
    public partial class SecurityAttributeMemberEntry
    {
        [Key]
        [Column("EntryID")]
        public int EntryId { get; set; }
        [Column("AttributeMemberID")]
        public int AttributeMemberId { get; set; }
        [Column("SecurityID")]
        public int SecurityId { get; set; }
        [Column(TypeName = "date")]
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
