using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("SecurityAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(AttributeMemberId), Name = "IX_SecurityAttributeMemberEntry_AttributeMemberID")]
    [Index(nameof(SecurityId), Name = "IX_SecurityAttributeMemberEntry_SecurityID")]
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
