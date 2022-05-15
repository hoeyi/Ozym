using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("CountryAttributeMemberEntry", Schema = "FinanceApp")]
    [Index(nameof(CountryId), Name = "IX_CountryAttributeMemberEntry_CountryID")]
    public partial class CountryAttributeMemberEntry
    {
        [Key]
        [Column("AttributeMemberID")]
        public int AttributeMemberId { get; set; }
        [Key]
        [Column("CountryID")]
        public int CountryId { get; set; }
        [Key]
        [Column(TypeName = "date")]
        public DateTime EffectiveDate { get; set; }
        [Column(TypeName = "decimal(5, 4)")]
        public decimal Weight { get; set; }

        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.CountryAttributeMemberEntries))]
        public virtual ModelAttributeMember AttributeMember { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty("CountryAttributeMemberEntries")]
        public virtual Country Country { get; set; }
    }
}
