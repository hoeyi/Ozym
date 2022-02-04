using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
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
        [Required]
        [StringLength(256)]
        public string DisplayName { get; set; }
        [Required]
        [StringLength(3)]
        public string IsoCode3 { get; set; }

        [InverseProperty(nameof(CountryAttributeMemberEntry.Country))]
        public virtual ICollection<CountryAttributeMemberEntry> CountryAttributeMemberEntries { get; set; }
    }
}
