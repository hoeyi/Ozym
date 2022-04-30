using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("Country", Schema = "EulerApp")]
    [Index(nameof(DisplayName), Name = "UNI_Country_DisplayName", IsUnique = true)]
    [Index(nameof(IsoCode3), Name = "UNI_Country_IsoCode3", IsUnique = true)]
    public partial class Country
    {
        public Country()
        {
            CountryAttributeMemberEntries = new HashSet<CountryAttributeMemberEntry>();
        }

        [Key]
        [Column("CountryID")]
        public int CountryId { get; set; }
        [StringLength(256)]
        public string DisplayName { get; set; } = null!;
        [StringLength(3)]
        [Unicode(false)]
        public string IsoCode3 { get; set; } = null!;

        [InverseProperty(nameof(CountryAttributeMemberEntry.Country))]
        public virtual ICollection<CountryAttributeMemberEntry> CountryAttributeMemberEntries { get; set; }
    }
}
