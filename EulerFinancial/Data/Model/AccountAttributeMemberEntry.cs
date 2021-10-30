using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class AccountAttributeMemberEntry
    {
        public int EntryId { get; set; }
        public int AttributeMemberId { get; set; }
        public int AccountObjectId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal Weight { get; set; }

        public virtual AccountObject AccountObject { get; set; }
        public virtual ModelAttributeMember AttributeMember { get; set; }
    }
}
