using NjordinSight.EntityModel;
using NjordinSight.EntityModel.Annotations;
using NjordinSight.DataTransfer.Common.Generic;
using System;
using System.Linq;

namespace NjordinSight.DataTransfer.Common.Collections
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.Country | ModelAttributeScopeCode.Security)]
    public class SecurityAttributeDtoCollection
        : AttributeEntryWeightedCollection<
            SecurityDto,
            SecurityAttributeDto,
            SecurityAttributeGrouping>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityAttributeDtoCollection"/> class with 
        /// an instance <see cref="Security"/> initialized with its parameterless constructor.
        /// </summary>
        public SecurityAttributeDtoCollection() : this(sourceModel: new())
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SecurityAttributeDtoCollection"/>
        /// </summary>
        /// <param name="strategy"></param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceModel"/> was null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="sourceModel"/> did not include 
        /// the <see cref="SecurityDto.Attributes"/> and/or 
        /// <see cref="SecurityAttributeMemberEntry.AttributeMember"/> members.</exception>
        public SecurityAttributeDtoCollection(SecurityDto sourceModel)
            : base(
                  parentEntity: sourceModel,
                  groupConstructor: (parent, key) =>
                  {
                      return new SecurityAttributeGrouping(parent, key.Item1, key.Item2);
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
                      return entries.GroupBy(e => (e.AttributeMember.Attribute.AttributeId, e.EffectiveDate))
                        .Select(g =>
                        {
                            var attribute = g.First().AttributeMember.Attribute;
                            var forDate = g.Key.EffectiveDate;

                            var group = new AttributeGrouping<
                                (ModelAttributeDtoBase, DateTime),
                                SecurityAttributeDto>(
                                key: (attribute, forDate), collection: g);

                            return group;
                        });
                  },
                  entryMemberSelector: (parent) =>
                  {
                      return parent.Attributes;
                  })
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
