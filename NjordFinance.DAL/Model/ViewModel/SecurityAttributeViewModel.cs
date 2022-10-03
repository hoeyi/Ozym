﻿using NjordFinance.Model.Annotations;
using NjordFinance.Model.ViewModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.Country | ModelAttributeScopeCode.Security)]
    public class SecurityAttributeViewModel
        : AttributeEntryWeightedCollection<
            Security,
            SecurityAttributeMemberEntry,
            SecurityAttributeGrouping>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SecurityAttributeViewModel"/>
        /// </summary>
        /// <param name="strategy"></param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceModel"/> was null.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="sourceModel"/> did not include 
        /// the <see cref="Security.SecurityAttributeMemberEntries"/> and/or 
        /// <see cref="SecurityAttributeMemberEntry.AttributeMember"/> members.</exception>
        public SecurityAttributeViewModel(Security sourceModel)
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
                      return entries.GroupBy(e => (e.AttributeMember.AttributeId, e.EffectiveDate))
                        .Select(g =>
                        {
                            var attribute = g.First().AttributeMember.Attribute;
                            var forDate = g.Key.EffectiveDate;

                            var group = new AttributeGrouping<
                                (ModelAttribute, DateTime),
                                SecurityAttributeMemberEntry>(
                                key: (attribute, forDate), collection: g);

                            return group;
                        });
                  },
                  entryMemberSelector: (parent) =>
                  {
                      return parent.SecurityAttributeMemberEntries;
                  })
        {
            // Check child entry records were included in the given model.
            if (sourceModel.SecurityAttributeMemberEntries is null)
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.SecurityAttributeMemberEntries));

            // Check all child records have the ModelAttributeMember related record.
            if (sourceModel.SecurityAttributeMemberEntries.Any(a => a.AttributeMember is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember));

            // Check all child record ModelAttributeMember records have the ModelAttribute record.
            if (sourceModel.SecurityAttributeMemberEntries.Any(a => a.AttributeMember.Attribute is null))
                throw new InvalidOperationException(
                    message: GetIncompleteObjectGraphMessage(x => x.AttributeMember.Attribute));
        }
    }
}
