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
    /// Represents an instance of <see cref="InvestmentStrategy"/>.
    /// </summary>
    public class InvestmentPlanViewModel
    {
        private readonly InvestmentStrategy _investmentStrategy;

        /// <summary>
        /// Initializes a new instance of <see cref="InvestmentPlanViewModel"/>
        /// </summary>
        /// <param name="strategy"></param>
        /// <exception cref="ArgumentNullException"><paramref name="strategy"/> was null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="strategy"/> did not include 
        /// the <see cref="InvestmentStrategy.InvestmentStrategyTargets"/> and 
        /// <see cref="InvestmentStrategyTarget.AttributeMember"/> members.</exception>
        public InvestmentPlanViewModel(InvestmentStrategy strategy)
        {
            if (strategy is null)
                throw new ArgumentNullException(paramName: nameof(strategy));

            _investmentStrategy = strategy;

            // Check child entry records were included in the given model.
            if (strategy.InvestmentStrategyTargets is null)
                throw new InvalidOperationException(
                    message: string.Format(
                        Strings.InvestmentStrategyViewModel_Constructor_InvalidOperationException,
                        nameof(InvestmentStrategyTarget)));

            // Check all child records have the ModelAttributeMember related record.
            if (strategy.InvestmentStrategyTargets.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: string.Format(
                        Strings.InvestmentStrategyViewModel_Constructor_InvalidOperationException,
                        nameof(InvestmentStrategyTarget.AttributeMember)));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (strategy.InvestmentStrategyTargets.Any(a => a.AttributeMember.Attribute is null))
                throw new InvalidOperationException(
                    message: string.Format(
                        Strings.InvestmentStrategyViewModel_Constructor_InvalidOperationException,
                        nameof(InvestmentStrategyTarget.AttributeMember.Attribute)));

            var attributeIds = strategy.InvestmentStrategyTargets
                            .Select(a => a.AttributeMember.AttributeId)
                            .Distinct()
                            .ToArray();

            strategy.InvestmentStrategyTargets
                .GroupBy(t => (t.AttributeMember.AttributeId, t.EffectiveDate))
                .ToList()
                .ForEach(g =>
                {
                    var attribute = strategy.InvestmentStrategyTargets
                        .First(a => a.AttributeMember.AttributeId == g.Key.AttributeId)
                        .AttributeMember.Attribute;

                    TargetViewModels.Add(
                        key: (g.Key.AttributeId, g.Key.EffectiveDate), 
                        value: new(strategy, attribute, g.Key.EffectiveDate));
                });
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

        public IDictionary<(int, DateTime), InvestmentPlanTargetViewModel> TargetViewModels { get; } =
            new Dictionary<(int, DateTime), InvestmentPlanTargetViewModel>();

        public InvestmentStrategy ToEntity()
        {
            return new InvestmentStrategy()
            {
                InvestmentStrategyId = _investmentStrategy.InvestmentStrategyId,
                DisplayName = DisplayName,
                InvestmentStrategyTargets = TargetViewModels.SelectMany(
                    kv => kv.Value.ToEntities())
                    .ToList()
            };
        }
    }
}
