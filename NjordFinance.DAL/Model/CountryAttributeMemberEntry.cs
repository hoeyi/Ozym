using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("CountryAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(AttributeMemberId), nameof(CountryId), nameof(EffectiveDate), Name = "UNI_CountryAttributeMemberEntry_RowDef", IsUnique = true)]
    public partial class CountryAttributeMemberEntry
    {
        [Key]
        [Column("EntryID")]
        public int EntryId { get; set; }
        [Column("AttributeMemberID")]
        public int AttributeMemberId { get; set; }
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Column(TypeName = "date")]
        public DateTime EffectiveDate { get; set; }
        [Column(TypeName = "decimal(5, 4)")]
        public decimal Weight { get; set; }

        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.CountryAttributeMemberEntries))]
        public virtual ModelAttributeMember AttributeMember { get; set; } = null!;
        [ForeignKey(nameof(CountryId))]
        [InverseProperty("CountryAttributeMemberEntries")]
        public virtual Country Country { get; set; } = null!;
    }
}
