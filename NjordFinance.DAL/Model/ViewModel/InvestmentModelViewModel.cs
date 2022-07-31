using NjordFinance.Model.Metadata;
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
    public class InvestmentModelViewModel
    {
        private readonly InvestmentStrategy _investmentStrategy;
        private readonly List<InvestmentModelTargetViewModel> _investmentPlanTargets = new();

        /// <summary>
        /// Initializes a new instance of <see cref="InvestmentModelViewModel"/>
        /// </summary>
        /// <param name="strategy"></param>
        /// <exception cref="ArgumentNullException"><paramref name="strategy"/> was null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="strategy"/> did not include 
        /// the <see cref="InvestmentStrategy.InvestmentStrategyTargets"/> and 
        /// <see cref="InvestmentStrategyTarget.AttributeMember"/> members.</exception>
        public InvestmentModelViewModel(InvestmentStrategy strategy)
        {
            if (strategy is null)
                throw new ArgumentNullException(paramName: nameof(strategy));

            // Check child entry records were included in the given model.
            if (strategy.InvestmentStrategyTargets is null)
                throw new InvalidOperationException(
                    message: string.Format(
                        Strings.InvestmentModelViewModel_Constructor_InvalidOperationException,
                        nameof(InvestmentStrategyTarget)));

            // Check all child records have the ModelAttributeMember related record.
            if (strategy.InvestmentStrategyTargets.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: string.Format(
                        Strings.InvestmentModelViewModel_Constructor_InvalidOperationException,
                        nameof(InvestmentStrategyTarget.AttributeMember)));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (strategy.InvestmentStrategyTargets.Any(a => a.AttributeMember.Attribute is null))
                throw new InvalidOperationException(
                    message: string.Format(
                        Strings.InvestmentModelViewModel_Constructor_InvalidOperationException,
                        nameof(InvestmentStrategyTarget.AttributeMember.Attribute)));

            _investmentStrategy = strategy;
            DisplayName = strategy.DisplayName;
            Notes = strategy.Notes;

            var targetGroups = _investmentStrategy.InvestmentStrategyTargets
                .GroupBy(tvm => (tvm.AttributeMember.AttributeId, tvm.EffectiveDate));

            var targetViewModels = targetGroups
                .Select(g => new InvestmentModelTargetViewModel(
                    parentStrategy: _investmentStrategy,
                    modelAttribute: g.First().AttributeMember.Attribute,
                    effectiveDate: g.Key.EffectiveDate));

            _investmentPlanTargets.AddRange(targetViewModels);

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

        [Display(
            Name = nameof(ModelDisplay.InvestmentStrategy_Notes_Name),
            Description = nameof(ModelDisplay.InvestmentStrategy_Notes_Description),
            ResourceType = typeof(ModelDisplay))]
        public string Notes { get; set; }

        /// <summary>
        /// Gets the collection of <see cref="InvestmentModelTargetViewModel"/> that represent the 
        /// defined targets for the <see cref="InvestmentStrategy"/> instance this model represents.
        /// </summary>
        public IList<InvestmentModelTargetViewModel> TargetCollection => _investmentPlanTargets;

        /// <summary>
        /// Gets the collection of <see cref="InvestmentModelTargetViewModel"/> in 
        /// <see cref="TargetCollection"/> grouped by common instances of <see cref="ModelAttribute"/>. 
        /// </summary>
        /// <remarks>
        /// A 'common' instance is defined by the <see cref="KeyAttribute"/> value for 
        /// <see cref="ModelAttribute"/>.
        /// </remarks>
        public IEnumerable<IGrouping<ModelAttribute, InvestmentModelTargetViewModel>>
            AttributeTargetCollection => TargetCollection
                                .GroupBy(tvm => tvm.ParentAttribute.AttributeId)
                                .Select(grp =>
                                {
                                    var grouping = new AttributeGrouping<InvestmentModelTargetViewModel>(
                                        grp.First().ParentAttribute, grp);

                                    return grouping;
                                });

        /// <summary>
        /// Gets the collection of <see cref="InvestmentModelTargetViewModel"/> in that are current, 
        /// <see cref="TargetCollection"/> grouped by common instances of <see cref="ModelAttribute"/>. 
        /// </summary>
        /// <remarks>
        /// 'Current' is defined by the system's local date, but not time.
        /// A 'common' instance is defined by the <see cref="KeyAttribute"/> value for 
        /// <see cref="ModelAttribute"/>.
        /// </remarks>
        public IEnumerable<IGrouping<ModelAttribute, InvestmentModelTargetViewModel>>
            CurrentTargetCollection => AttributeTargetCollection
                .Select(grp =>
                    new AttributeGrouping<InvestmentModelTargetViewModel>(
                        key: grp.Key,
                        collection: grp
                                        .Where(grp => grp.EffectiveDate <= DateTime.Now.Date)
                                        .OrderByDescending(grp => grp.EffectiveDate).Take(1))
                );

        public InvestmentStrategy ToEntity() => new()
        {
            InvestmentStrategyId = _investmentStrategy.InvestmentStrategyId,
            DisplayName = DisplayName,
            InvestmentStrategyTargets = TargetCollection
                    .SelectMany(t => t.ToEntities())
                    .ToList()
        };
    }
}
