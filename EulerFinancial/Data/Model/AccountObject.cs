using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class AccountObject
    {
        public AccountObject()
        {
            AccountAttributeMemberEntries = new HashSet<AccountAttributeMemberEntry>();
            InvestmentPerformanceAttributeMemberEntries = new HashSet<InvestmentPerformanceAttributeMemberEntry>();
            InvestmentPerformanceEntries = new HashSet<InvestmentPerformanceEntry>();
        }

        public int AccountObjectId { get; set; }
        public string AccountObjectCode { get; set; }
        public string ObjectType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public string ObjectDipslayName { get; set; }
        public string ObjectDescription { get; set; }
        public string PrefixedObjectCode { get; set; }

        public virtual Account Account { get; set; }
        public virtual AccountGroup AccountGroup { get; set; }
        public virtual ICollection<AccountAttributeMemberEntry> AccountAttributeMemberEntries { get; set; }
        public virtual ICollection<InvestmentPerformanceAttributeMemberEntry> InvestmentPerformanceAttributeMemberEntries { get; set; }
        public virtual ICollection<InvestmentPerformanceEntry> InvestmentPerformanceEntries { get; set; }
    }
}
