using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("Country", Schema = "FinanceApp")]
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
        [StringLength(72)]
        public string DisplayName { get; set; }
        [Required]
        [StringLength(3)]
        public string IsoCode3 { get; set; }

        [InverseProperty(nameof(CountryAttributeMemberEntry.Country))]
        public virtual ICollection<CountryAttributeMemberEntry> CountryAttributeMemberEntries { get; set; }
    }
}
