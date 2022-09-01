using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ichosys.DataModel.Annotations;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using NjordFinance.Model.Metadata;

namespace NjordFinance.Model
{
    [Table("InvestmentStrategyTarget", Schema = "FinanceApp")]
    [Index(nameof(AttributeMemberId), Name = "IX_InvestmentStrategyTarget_AttributeMemberID")]
    [Index(nameof(InvestmentStrategyId), Name = "IX_InvestmentStrategyTarget_InvestmentStrategyID")]
    [Noun(
        Plural = nameof(ModelNoun.InvestmentStrategyTarget_Plural),
        PluralArticle = nameof(ModelNoun.InvestmentStrategyTarget_PluralArticle),
        Singular = nameof(ModelNoun.InvestmentStrategyTarget_Singular),
        SingularArticle = nameof(ModelNoun.InvestmentStrategyTarget_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public partial class InvestmentStrategyTarget
    {
        [Key]
        [Column("InvestmentStrategyID")]
        public int InvestmentStrategyId { get; set; }
        [Key]
        [Column("AttributeMemberID")]
        [Display(
            Name = nameof(ModelDisplay.InvestmentStrategyTarget_AttributeMemberID_Name),
            Description = nameof(ModelDisplay.InvestmentStrategyTarget_AttributeMemberID_Description),
            ResourceType = typeof(ModelDisplay))]
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
