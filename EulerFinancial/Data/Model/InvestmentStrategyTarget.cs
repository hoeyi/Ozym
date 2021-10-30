using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class InvestmentStrategyTarget
    {
        public int InvestmentStrategyTargetId { get; set; }
        public int InvestmentStrategyId { get; set; }
        public int AttributeMemberId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public byte TargetPercent { get; set; }

        public virtual ModelAttributeMember AttributeMember { get; set; }
        public virtual InvestmentStrategy InvestmentStrategy { get; set; }
    }
}
