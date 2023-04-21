using NjordFinance.Model.Metadata;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NjordFinance.ViewModel.Generic;
using NjordFinance.Model.Annotations;
using NjordFinance.Model;

namespace NjordFinance.ViewModel
{
    [ModelAttributeSupport(SupportedScopes = ModelAttributeScopeCode.Country)]
    public class CountryViewModel
        : AttributeEntryWeightedCollection<
            Country,
            CountryAttributeMemberEntry,
            CountryAttributeGrouping>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CountryViewModel"/>
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceModel"/> was null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="sourceModel"/> did not include 
        /// the <see cref="Country.CountryAttributeMemberEntries"/> and/or 
        /// <see cref="CountryAttributeMemberEntry.AttributeMember"/> members.</exception>
        public CountryViewModel(Country sourceModel)
            : base(
                  parentEntity: sourceModel,
                  groupConstructor: (parent, key) =>
                  {
                      return new CountryAttributeGrouping(parent, key.Item1, key.Item2);
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
                                CountryAttributeMemberEntry>(
                                key: (attribute, forDate), collection: g);

                            return group;
                        });
                  },
                  entryMemberSelector: (parent) =>
                  {
                      return parent.CountryAttributeMemberEntries;
                  })
        {
            // Check child entry records were included in the given model.
            if (sourceModel.CountryAttributeMemberEntries is null)
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.CountryAttributeMemberEntries));

            // Check all child records have the ModelAttributeMember related record.
            if (sourceModel.CountryAttributeMemberEntries.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (sourceModel.CountryAttributeMemberEntries.Any(a => a.AttributeMember.Attribute is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember.Attribute));
        }

        [Display(
                    Name = nameof(ModelDisplay.Country_DisplayName_Name),
                    Description = nameof(ModelDisplay.Country_DisplayName_Description),
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
            Name = nameof(ModelDisplay.Country_IsoCode3_Name),
            Description = nameof(ModelDisplay.Country_IsoCode3_Description),
            ResourceType = typeof(ModelDisplay))]
        public string IsoCode3
        {
            get { return ParentEntity.IsoCode3; }
            set
            {
                if (ParentEntity.IsoCode3 != value)
                    ParentEntity.IsoCode3 = value;
            }
        }
    }
}
