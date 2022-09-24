using NjordFinance.Model.Annotations;
using NjordFinance.Model.Metadata;
using NjordFinance.Model.ViewModel.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Xml.Linq;

namespace NjordFinance.Model.ViewModel
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.BankTransactionCode)]
    public class BankTransactionCodeViewModel
        : AttributeEntryUnweightedCollection<
            BankTransactionCode,
            BankTransactionCodeAttributeMemberEntry,
            BankTransactionCodeAttributeGrouping,
            ModelAttribute>
    {
        public BankTransactionCodeViewModel(BankTransactionCode transactionCode)
            : base(
                  parentEntity: transactionCode,
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
                  currencyPredicate: x => x.EffectiveDate <= DateTime.UtcNow.Date)
        {
            // Check child entry records were included in the given model.
            if (transactionCode.BankTransactionCodeAttributeMemberEntries is null)
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.BankTransactionCodeAttributeMemberEntries));

            // Check all child records have the ModelAttributeMember related record.
            if (transactionCode.BankTransactionCodeAttributeMemberEntries.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (transactionCode.BankTransactionCodeAttributeMemberEntries.Any(a => a.AttributeMember.Attribute is null))
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
