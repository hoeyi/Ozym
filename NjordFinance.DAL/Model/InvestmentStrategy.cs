using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("InvestmentStrategy", Schema = "EulerApp")]
    [Index(nameof(DisplayName), Name = "UNI_InvestmentStrategy_DisplayName", IsUnique = true)]
    public partial class InvestmentStrategy
    {
        public InvestmentStrategy()
        {
            InvestmentStrategyTargets = new HashSet<InvestmentStrategyTarget>();
        }

        [Key]
        [Column("InvestmentStrategyID")]
        public int InvestmentStrategyId { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string DisplayName { get; set; } = null!;

        [InverseProperty(nameof(InvestmentStrategyTarget.InvestmentStrategy))]
        public virtual ICollection<InvestmentStrategyTarget> InvestmentStrategyTargets { get; set; }
    }
}
