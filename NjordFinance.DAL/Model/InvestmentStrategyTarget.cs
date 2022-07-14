using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NjordFinance.Model
{
    [Table("InvestmentStrategyTarget", Schema = "FinanceApp")]
    [Index(nameof(AttributeMemberId), Name = "IX_InvestmentStrategyTarget_AttributeMemberID")]
    [Index(nameof(InvestmentStrategyId), Name = "IX_InvestmentStrategyTarget_InvestmentStrategyID")]
    public partial class InvestmentStrategyTarget
    {
        [Key]
        [Column("InvestmentStrategyID")]
        public int InvestmentStrategyId { get; set; }
        [Key]
        [Column("AttributeMemberID")]
        public int AttributeMemberId { get; set; }
        [Key]
        [Column(TypeName = "date")]
        public DateTime EffectiveDate { get; set; }
        [Column(TypeName = "decimal(5, 4)")]
        public decimal Weight { get; set; }

        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.InvestmentStrategyTargets))]
        public virtual ModelAttributeMember AttributeMember { get; set; }
        [ForeignKey(nameof(InvestmentStrategyId))]
        [InverseProperty("InvestmentStrategyTargets")]
        public virtual InvestmentStrategy InvestmentStrategy { get; set; }
    }
}
