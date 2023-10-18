using Ozym.DataTransfer.Common.Generic;
using System;
using System.Linq;
using Ozym.EntityModel;
using Ozym.EntityModel.Annotations;

namespace Ozym.DataTransfer.Common.Collections
{
    [ModelAttributeSupport(
        SupportedScopes = ModelAttributeScopeCode.Account)]
    public class AccountAttributeDtoCollection : AttributeEntryUnweightedCollection<
            AccountBaseDto,
            AccountBaseAttributeDto,
            AccountAttributeGrouping>
    {
        public AccountAttributeDtoCollection(AccountBaseDto sourceModel)
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
                    return entries.GroupBy(e => e.AttributeMember.Attribute.AttributeId)
                    .Select(g =>
                    {
                        var attribute = g.First().AttributeMember.Attribute;

                        var group = new AttributeGrouping<
                            ModelAttributeDtoBase, AccountBaseAttributeDto>(
                            key: attribute, collection: g);

                        return group;
                    });
                },
                entryMemberSelector: (parent) =>
                {
                    return parent.Attributes;
                },
                entryDateSelector: (entry) => entry.EffectiveDate)
        {
            // Check child entry records were included in the given model.
            if (sourceModel.Attributes is null)
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.Attributes));

            // Check all child records have the ModelAttributeMember related record.
            if (sourceModel.Attributes.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (sourceModel.Attributes.Any(a => a.AttributeMember.Attribute is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember.Attribute));
        }
    }
}
