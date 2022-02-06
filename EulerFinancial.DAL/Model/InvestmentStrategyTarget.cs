using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EulerFinancial.Model
{
    [Table("InvestmentStrategyTarget", Schema = "EulerApp")]
    [Index(nameof(EffectiveDate), nameof(AttributeMemberId), nameof(InvestmentStrategyId), Name = "UNI_InvestmentStrategyTarget_RowDef", IsUnique = true)]
    public partial class InvestmentStrategyTarget
    {
        [Key]
        [Column("InvestmentStrategyTargetID")]
        public int InvestmentStrategyTargetId { get; set; }
        [Column("InvestmentStrategyID")]
        public int InvestmentStrategyId { get; set; }
        [Column("AttributeMemberID")]
        public int AttributeMemberId { get; set; }
        [Column(TypeName = "date")]
        public DateTime EffectiveDate { get; set; }
        public byte TargetPercent { get; set; }

        [ForeignKey(nameof(AttributeMemberId))]
        [InverseProperty(nameof(ModelAttributeMember.InvestmentStrategyTargets))]
        public virtual ModelAttributeMember AttributeMember { get; set; }
        [ForeignKey(nameof(InvestmentStrategyId))]
        [InverseProperty("InvestmentStrategyTargets")]
        public virtual InvestmentStrategy InvestmentStrategy { get; set; }
    }
}
