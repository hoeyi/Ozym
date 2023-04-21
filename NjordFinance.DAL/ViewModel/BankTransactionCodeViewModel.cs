using NjordFinance.Model;
using NjordFinance.Model.Annotations;
using NjordFinance.Model.Metadata;
using NjordFinance.ViewModel.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NjordFinance.ViewModel
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.BankTransactionCode)]
    public class BankTransactionCodeViewModel
        : AttributeEntryUnweightedCollection<
            BankTransactionCode,
            BankTransactionCodeAttributeMemberEntry,
            BankTransactionCodeAttributeGrouping>
    {
        public BankTransactionCodeViewModel(BankTransactionCode sourceModel)
            : base(
                  parentEntity: sourceModel,
                  groupConstructor: (parent, attriubte) =>
                  {
                      return new BankTransactionCodeAttributeGrouping(parent, attriubte);
                  },
                  groupConverter: (grouping, parent) =>
                  {
                      var firstEntry = grouping.Where(x => x.AttributeMember is not null).First();

                      return new(
                          parentEntity: parent,
                          modelAttribute: firstEntry.AttributeMember.Attribute);
                  },
                  groupingFunc: (entries) =>
                  {
                      return entries.GroupBy(e => e.AttributeMember.AttributeId)
                        .Select(g =>
                        {
                            var attribute = g.First().AttributeMember.Attribute;

                            var group = new AttributeGrouping<
                                ModelAttribute, BankTransactionCodeAttributeMemberEntry>(
                                key: attribute, collection: g);

                            return group;
                        });
                  },
                  entryMemberSelector: (parent) =>
                  {
                      return parent.BankTransactionCodeAttributeMemberEntries;
                  },
                  entryDateSelector: (entry) => entry.EffectiveDate)
        {
            // Check child entry records were included in the given model.
            if (sourceModel.BankTransactionCodeAttributeMemberEntries is null)
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.BankTransactionCodeAttributeMemberEntries));

            // Check all child records have the ModelAttributeMember related record.
            if (sourceModel.BankTransactionCodeAttributeMemberEntries.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (sourceModel.BankTransactionCodeAttributeMemberEntries.Any(a => a.AttributeMember.Attribute is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember.Attribute));
        }

        [Display(
            Name = nameof(ModelDisplay.BankTransactionCode_TransactionCode_Name),
            Description = nameof(ModelDisplay.BankTransactionCode_TransactionCode_Description),
            ResourceType = typeof(ModelDisplay))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(12,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string TransactionCode
        {
            get { return ParentEntity.TransactionCode; }
            set
            {
                if (ParentEntity.TransactionCode != value)
                    ParentEntity.TransactionCode = value;
            }
        }

        [Display(
            Name = nameof(ModelDisplay.BankTransactionCode_DisplayName_Name),
            Description = nameof(ModelDisplay.BankTransactionCode_DisplayName_Description),
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
    }
}
