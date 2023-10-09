using NjordinSight.EntityModel.Metadata;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NjordinSight.EntityModel.Annotations;
using NjordinSight.DataTransfer.Common.Generic;
using NjordinSight.EntityModel;

namespace NjordinSight.DataTransfer.Common.Collections
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.BrokerTransactionCode)]
    public class BrokerCodeAttributeDtoCollection
        : AttributeEntryUnweightedCollection<
            BrokerTransactionCodeDto,
            BrokerTransactionCodeAttributeDto,
            BrokerTransactionCodeAttributeGrouping>
    {
        public BrokerCodeAttributeDtoCollection(BrokerTransactionCodeDto sourceModel)
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
                      return entries.GroupBy(e => e.AttributeMember.Attribute.AttributeId)
                        .Select(g =>
                        {
                            var attribute = g.First().AttributeMember.Attribute;

                            var group = new AttributeGrouping<
                                ModelAttributeDtoBase, BrokerTransactionCodeAttributeDto>(
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
