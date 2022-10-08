using Ichosys.DataModel.Annotations;
using NjordFinance.Model.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
{
    [Table("InvestmentStrategy", Schema = "FinanceApp")]
    [Noun(
        Plural = nameof(ModelNoun.InvestmentStrategy_Plural),
        PluralArticle = nameof(ModelNoun.InvestmentStrategy_PluralArticle),
        Singular = nameof(ModelNoun.InvestmentStrategy_Singular),
        SingularArticle = nameof(ModelNoun.InvestmentStrategy_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public partial class InvestmentStrategy
    {
        public InvestmentStrategy()
        {
            InvestmentStrategyTargets = new HashSet<InvestmentStrategyTarget>();
        }

        [Key]
        [Column("InvestmentStrategyID")]
        public int InvestmentStrategyId { get; set; }
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [Display(
            Name = nameof(ModelDisplay.InvestmentStrategy_DisplayName_Name),
            Description = nameof(ModelDisplay.InvestmentStrategy_DisplayName_Description),
            ResourceType = typeof(ModelDisplay))]
        public string DisplayName { get; set; }

        [Display(
            Name = nameof(ModelDisplay.InvestmentStrategy_Notes_Name),
            Description = nameof(ModelDisplay.InvestmentStrategy_Notes_Description),
            ResourceType = typeof(ModelDisplay))]
        public string Notes { get; set; }

        [InverseProperty(nameof(InvestmentStrategyTarget.InvestmentStrategy))]
        public virtual ICollection<InvestmentStrategyTarget> InvestmentStrategyTargets { get; set; }
    }
}
