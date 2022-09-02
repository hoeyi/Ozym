using NjordFinance.Model.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model.ViewModel.Generic;
using NjordFinance.Model.Annotations;

namespace NjordFinance.Model.ViewModel
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.Country | ModelAttributeScopeCode.Security)]
    public class InvestmentModelViewModel
        : AttributeEntryViewModel<
            InvestmentStrategy,
            InvestmentStrategyTarget,
            InvestmentModelTargetViewModel>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="InvestmentModelViewModel"/>
        /// </summary>
        /// <param name="strategy"></param>
        /// <exception cref="ArgumentNullException"><paramref name="strategy"/> was null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="strategy"/> did not include 
        /// the <see cref="InvestmentStrategy.InvestmentStrategyTargets"/> and/or 
        /// <see cref="InvestmentStrategyTarget.AttributeMember"/> members.</exception>
        public InvestmentModelViewModel(InvestmentStrategy strategy)
            : base(parentEntity: strategy)
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

            DisplayName = strategy.DisplayName;
            Notes = strategy.Notes;
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

        protected override Func<InvestmentStrategy, IEnumerable<InvestmentStrategyTarget>>
            EntryMemberSelector => (parent) => parent.InvestmentStrategyTargets;

        public override InvestmentStrategy ToEntity() => new()
        {
            InvestmentStrategyId = _parentEntity.InvestmentStrategyId,
            DisplayName = DisplayName,
            Notes = Notes,
            InvestmentStrategyTargets = _parentEntity.InvestmentStrategyTargets
        };

        public override InvestmentModelTargetViewModel AddNew(ModelAttribute forAttribute)
        {
            var lastEntryDateUtc = EntryCollection
                .Where(x => x.ParentAttribute.AttributeId == forAttribute.AttributeId)
                .MaxOrDefault(x => x.EffectiveDate)
                .ToUniversalTime();

            DateTime effectiveDate = lastEntryDateUtc.Date < DateTime.UtcNow.Date ?
                DateTime.UtcNow.Date : lastEntryDateUtc.Date.AddDays(1);
                    
            var newTarget = new InvestmentModelTargetViewModel(
                parentStrategy: _parentEntity, modelAttribute: forAttribute, effectiveDate);

            newTarget.AddNewEntry();

            return newTarget;
        }

        protected override InvestmentModelTargetViewModel ConvertGroupingToViewModel(
            IGrouping<(int, DateTime), InvestmentStrategyTarget> grouping)
        {
            var firstEntry = grouping.Where(x => x.AttributeMember is not null).First();

            return new (
                parentStrategy: _parentEntity,
                modelAttribute: firstEntry.AttributeMember.Attribute,
                effectiveDate: firstEntry.EffectiveDate);
        }
        
        protected override IEnumerable<IGrouping<(int, DateTime), InvestmentStrategyTarget>>
            GroupEntries(IEnumerable<InvestmentStrategyTarget> entries) =>
                entries.GroupBy(e => (e.AttributeMember.AttributeId, e.EffectiveDate));
    }
}
