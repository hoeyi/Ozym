using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class InvestmentPerformanceAttributeMemberEntry
    {
        public int EntryId { get; set; }
        public int AccountObjectId { get; set; }
        public int AttributeMemberId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal MarketValue { get; set; }
        public decimal NetContribution { get; set; }
        public decimal AverageCapital { get; set; }
        public decimal Gain { get; set; }
        public decimal Irr { get; set; }

        public virtual AccountObject AccountObject { get; set; }
        public virtual ModelAttributeMember AttributeMember { get; set; }
    }
}
