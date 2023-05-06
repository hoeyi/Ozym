using NjordFinance.EntityModel.Metadata;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NjordFinance.EntityModel.Annotations;
using NjordFinance.ViewModel.Generic;
using NjordFinance.EntityModel;

namespace NjordFinance.ViewModel
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.BrokerTransactionCode)]
    public class BrokerTransactionCodeViewModel
        : AttributeEntryUnweightedCollection<
            BrokerTransactionCode,
            BrokerTransactionCodeAttributeMemberEntry,
            BrokerTransactionCodeAttributeGrouping>
    {
        public BrokerTransactionCodeViewModel(BrokerTransactionCode sourceModel)
            : base(
                  parentEntity: sourceModel,
                  groupConstructor: (parent, attriubte) =>
                  {
                      return new BrokerTransactionCodeAttributeGrouping(parent, attriubte);
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
                                ModelAttribute, BrokerTransactionCodeAttributeMemberEntry>(
                                key: attribute, collection: g);

                            return group;
                        });
                  },
                  entryMemberSelector: (parent) =>
                  {
                      return parent.BrokerTransactionCodeAttributeMemberEntries;
                  },
                  entryDateSelector: (entry) => entry.EffectiveDate)
        {
            // Check child entry records were included in the given model.
            if (sourceModel.BrokerTransactionCodeAttributeMemberEntries is null)
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.BrokerTransactionCodeAttributeMemberEntries));

            // Check all child records have the ModelAttributeMember related record.
            if (sourceModel.BrokerTransactionCodeAttributeMemberEntries.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (sourceModel.BrokerTransactionCodeAttributeMemberEntries.Any(a => a.AttributeMember.Attribute is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember.Attribute));
        }

        [Display(
            Name = nameof(ModelDisplay.BrokerTransactionCode_TransactionCode_Name),
            Description = nameof(ModelDisplay.BrokerTransactionCode_TransactionCode_Description),
            ResourceType = typeof(ModelDisplay))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(3,
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
            Name = nameof(ModelDisplay.BrokerTransactionCode_DisplayName_Name),
            Description = nameof(ModelDisplay.BrokerTransactionCode_DisplayName_Description),
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
            Name = nameof(ModelDisplay.BrokerTransactionCode_CashEffect_Name),
            Description = nameof(ModelDisplay.BrokerTransactionCode_CashEffect_Description),
            ResourceType = typeof(ModelDisplay))]
        public short CashEffect
        {
            get { return ParentEntity.CashEffect; }
            set
            {
                if (ParentEntity.CashEffect != value)
                    ParentEntity.CashEffect = value;
            }
        }

        [Display(
            Name = nameof(ModelDisplay.BrokerTransactionCode_ContributionWithdrawalEffect_Name),
            Description = nameof(ModelDisplay.BrokerTransactionCode_ContributionWithdrawalEffect_Description),
            ResourceType = typeof(ModelDisplay))]
        public short ContributionWithdrawalEffect
        {
            get { return ParentEntity.ContributionWithdrawalEffect; }
            set
            {
                if (ParentEntity.ContributionWithdrawalEffect != value)
                    ParentEntity.ContributionWithdrawalEffect = value;
            }
        }

        [Display(
            Name = nameof(ModelDisplay.BrokerTransactionCode_QuantityEffect_Name),
            Description = nameof(ModelDisplay.BrokerTransactionCode_QuantityEffect_Description),
            ResourceType = typeof(ModelDisplay))]
        public short QuantityEffect
        {
            get { return ParentEntity.QuantityEffect; }
            set
            {
                if (ParentEntity.QuantityEffect != value)
                    ParentEntity.QuantityEffect = value;
            }
        }
    }
}
