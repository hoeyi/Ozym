using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class CountryAttributeMemberEntry
    {
        public int EntryId { get; set; }
        public int AttributeMemberId { get; set; }
        public int CountryId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal Weight { get; set; }

        public virtual ModelAttributeMember AttributeMember { get; set; }
        public virtual Country Country { get; set; }
    }
}
