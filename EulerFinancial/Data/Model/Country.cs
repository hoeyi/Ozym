using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class Country
    {
        public Country()
        {
            CountryAttributeMemberEntries = new HashSet<CountryAttributeMemberEntry>();
        }

        public int CountryId { get; set; }
        public string DisplayName { get; set; }
        public string IsoCode3 { get; set; }

        public virtual ICollection<CountryAttributeMemberEntry> CountryAttributeMemberEntries { get; set; }
    }
}
