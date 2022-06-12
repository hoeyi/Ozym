using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("InvestmentStrategy", Schema = "FinanceApp")]
    public partial class InvestmentStrategy
    {
        public InvestmentStrategy()
        {
            InvestmentStrategyTargets = new HashSet<InvestmentStrategyTarget>();
        }

        [Key]
        [Column("InvestmentStrategyID")]
        public int InvestmentStrategyId { get; set; }
        [Required]
        [StringLength(32)]
        public string DisplayName { get; set; }

        [InverseProperty(nameof(InvestmentStrategyTarget.InvestmentStrategy))]
        public virtual ICollection<InvestmentStrategyTarget> InvestmentStrategyTargets { get; set; }
    }
}
