using NjordinSight.DataTransfer.Generic;
using System;
using System.Linq;
using NjordinSight.EntityModel;
using NjordinSight.EntityModel.Annotations;

namespace NjordinSight.DataTransfer
{
    [ModelAttributeSupport(
        SupportedScopes = ModelAttributeScopeCode.Account)]
    public class AccountAttributesDto : AttributeEntryUnweightedCollection<
            AccountObject,
            AccountAttributeMemberEntry,
            AccountAttributeGrouping>
    {
        public AccountAttributesDto(AccountObject sourceModel)
            : base(
            parentEntity: sourceModel,
                  groupConstructor: (parent, attriubte) =>
                  {
                      return new AccountAttributeGrouping(parent, attriubte);
    },
                  groupConverter: (grouping, parent) =>
                  {
                      var firstEntry = grouping.Where(x => x.AttributeMember is not null).First();

                      return new (
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
                                ModelAttribute, AccountAttributeMemberEntry>(
                                key: attribute, collection: g);

                            return group;
                        });
                  },
                  entryMemberSelector: (parent) =>
                  {
                      return parent.AccountAttributeMemberEntries;
                  },
                  entryDateSelector: (entry) => entry.EffectiveDate)
        {
            // Check child entry records were included in the given model.
            if (sourceModel.AccountAttributeMemberEntries is null)
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AccountAttributeMemberEntries));

            // Check all child records have the ModelAttributeMember related record.
            if (sourceModel.AccountAttributeMemberEntries.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (sourceModel.AccountAttributeMemberEntries.Any(a => a.AttributeMember.Attribute is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember.Attribute));
        }
    }
}
