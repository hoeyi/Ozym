using NjordFinance.Model.Metadata;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NjordFinance.ViewModel.Generic;
using NjordFinance.Model.Annotations;
using NjordFinance.Model;

namespace NjordFinance.ViewModel
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.Country | ModelAttributeScopeCode.Security)]
    public class InvestmentModelViewModel
        : AttributeEntryWeightedCollection<
            InvestmentStrategy,
            InvestmentStrategyTarget,
            InvestmentModelTargetGrouping>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="InvestmentModelViewModel"/>
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceModel"/> was null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="sourceModel"/> did not include 
        /// the <see cref="InvestmentStrategy.InvestmentStrategyTargets"/> and/or 
        /// <see cref="InvestmentStrategyTarget.AttributeMember"/> members.</exception>
        public InvestmentModelViewModel(InvestmentStrategy sourceModel)
            : base(
                  parentEntity: sourceModel,
                  groupConstructor: (parent, key) =>
                  {
                      return new InvestmentModelTargetGrouping(parent, key.Item1, key.Item2);
                  },
                  groupingConverterFunc: (grouping, parent) =>
                  {
                      var firstEntry = grouping.Where(x => x.AttributeMember is not null).First();

                      return new(
                          parentEntity: parent,
                          modelAttribute: firstEntry.AttributeMember.Attribute,
                          effectiveDate: firstEntry.EffectiveDate);
                  },
                  groupingFunc: (entries) =>
                  {
                      return entries.GroupBy(e => (e.AttributeMember.AttributeId, e.EffectiveDate))
                        .Select(g =>
                        {
                            var attribute = g.First().AttributeMember.Attribute;
                            var forDate = g.Key.EffectiveDate;

                            var group = new AttributeGrouping<
                                (ModelAttribute, DateTime),
                                InvestmentStrategyTarget>(
                                key: (attribute, forDate), collection: g);

                            return group;
                        });
                  },
                  entryMemberSelector: (parent) =>
                  {
                      return parent.InvestmentStrategyTargets;
                  })
        {
            // Check child entry records were included in the given model.
            if (sourceModel.InvestmentStrategyTargets is null)
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.InvestmentStrategyTargets));

            // Check all child records have the ModelAttributeMember related record.
            if (sourceModel.InvestmentStrategyTargets.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (sourceModel.InvestmentStrategyTargets.Any(a => a.AttributeMember.Attribute is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember.Attribute));
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
        public string DisplayName
        {
            get { return ParentEntity.DisplayName; }
            set
            {
                if (ParentEntity.DisplayName != value)
                    ParentEntity.DisplayName = value;
            }
        }

        [Display(
            Name = nameof(ModelDisplay.InvestmentStrategy_Notes_Name),
            Description = nameof(ModelDisplay.InvestmentStrategy_Notes_Description),
            ResourceType = typeof(ModelDisplay))]
        public string Notes
        {
            get { return ParentEntity.Notes; }
            set
            {
                if (ParentEntity.Notes != value)
                    ParentEntity.Notes = value;
            }
        }
    }
}
