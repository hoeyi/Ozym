using NjordFinance.ModelMetadata.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel
{
    /// <summary>
    /// Represents a collection of <see cref="InvestmentStrategyTarget"/> with the same 
    /// strategy, model attribute, and effective date.
    /// </summary>
    public class InvestmentStrategyTargetViewModel
        : AttributeEntryCollectionViewModel<InvestmentStrategyTarget, InvestmentStrategy>
    {
        public InvestmentStrategyTargetViewModel(
            InvestmentStrategy strategy, ModelAttribute modelAttribute, DateTime effectiveDate)
        : base(strategy, modelAttribute, effectiveDate)
        {
            if(strategy.InvestmentStrategyTargets?.Any() ?? false)
                MemberEntries.AddRange(strategy.InvestmentStrategyTargets);
        }

        [Display(
            Name = nameof(ModelDisplay.InvestmentStrategy_DisplayName_Name),
            Description = nameof(ModelDisplay.InvestmentStrategy_DisplayName_Description),
            ResourceType = typeof(ModelDisplay))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string DisplayName { get; set; }

        protected override Func<InvestmentStrategyTarget, decimal> WeightSelector => x => x.Weight;

        public override InvestmentStrategyTarget[] ToEntities() =>
            MemberEntries.Select(
                s => new InvestmentStrategyTarget()
                {
                    AttributeMemberId = s.AttributeMemberId,
                    InvestmentStrategyId = ParentObject.InvestmentStrategyId,
                    EffectiveDate = EffectiveDate,
                    Weight = s.Weight
                })
            .ToArray();
    }
}