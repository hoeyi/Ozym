using System;
using System.Linq;
using Ozym.DataTransfer.Common.Generic;
using Ozym.EntityModel.Annotations;
using Ozym.EntityModel;

namespace Ozym.DataTransfer.Common.Collections
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.Country | ModelAttributeScopeCode.Security)]
    public class InvestmentModelTargetDtoCollection
        : AttributeEntryWeightedCollection<
            InvestmentModelDto,
            InvestmentModelTargetDto,
            InvestmentModelTargetGrouping>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="InvestmentModelDto"/>
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceModel"/> was null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="sourceModel"/> did not include 
        /// the <see cref="InvestmentModelDto."/> and/or 
        /// <see cref="InvestmentStrategyTarget.AttributeMember"/> members.</exception>
        public InvestmentModelTargetDtoCollection(InvestmentModelDto sourceModel)
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
                      return entries.GroupBy(e => (e.AttributeMember.Attribute.AttributeId, e.EffectiveDate))
                        .Select(g =>
                        {
                            var attribute = g.First().AttributeMember.Attribute;
                            var forDate = g.Key.EffectiveDate;

                            var group = new AttributeGrouping<
                                (ModelAttributeDtoBase, DateTime),
                                InvestmentModelTargetDto>(
                                key: (attribute, forDate), collection: g);

                            return group;
                        });
                  },
                  entryMemberSelector: (parent) =>
                  {
                      return parent.Targets;
                  })
        {
            // Check child entry records were included in the given model.
            if (sourceModel.Targets is null)
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.Targets));

            // Check all child records have the ModelAttributeMember related record.
            if (sourceModel.Targets.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (sourceModel.Targets.Any(a => a.AttributeMember.Attribute is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember.Attribute));
        }
    }
}
