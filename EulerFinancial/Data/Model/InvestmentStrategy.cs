using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class InvestmentStrategy
    {
        public InvestmentStrategy()
        {
            InvestmentStrategyTargets = new HashSet<InvestmentStrategyTarget>();
        }

        public int InvestmentStrategyId { get; set; }
        public string DisplayName { get; set; }

        public virtual ICollection<InvestmentStrategyTarget> InvestmentStrategyTargets { get; set; }
    }
}
