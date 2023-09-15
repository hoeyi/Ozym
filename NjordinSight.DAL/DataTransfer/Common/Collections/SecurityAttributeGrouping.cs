using System;
using System.Collections.Generic;
using NjordinSight.EntityModel;
using NjordinSight.EntityModel.Annotations;
using NjordinSight.DataTransfer.Common.Generic;
using NjordinSight.DataTransfer.Common;

namespace NjordinSight.DataTransfer.Common.Collections
{
    [ModelAttributeSupport(
            SupportedScopes = ModelAttributeScopeCode.Country | ModelAttributeScopeCode.Security)]
    /// <summary>
    /// Represents a collection of <see cref="SecurityAttributeDtoCollection"/> instances with the same 
    /// <see cref="SecurityDto" />, <see cref="ModelAttributeDtoBase"/>, and effective date.
    /// </summary>
    public class SecurityAttributeGrouping :
        AttributeEntryWeightedGrouping<SecurityDto, SecurityAttributeDto>
    {
        public SecurityAttributeGrouping(
            SecurityDto parentEntity,
            ModelAttributeDtoBase modelAttribute,
            DateTime effectiveDate) : base(parentEntity, modelAttribute, effectiveDate)
        {
        }

        protected override Func<SecurityDto, ICollection<SecurityAttributeDto>>
            ParentEntryMemberSelector => x => x.Attributes;

        protected override Func<SecurityAttributeDto, bool> EntrySelector => x =>
            x.AttributeMember.Attribute.AttributeId == ParentAttribute.AttributeId
                && x.EffectiveDate == EffectiveDate;

        protected override Func<SecurityAttributeDto, decimal> WeightSelector => x => x.PercentWeight;

        public override SecurityAttributeDto AddNewEntry()
        {
            SecurityAttributeDto newEntry = new()
            {
                SecurityId = ParentObject.SecurityId,
                EffectiveDate = EffectiveDate,
                PercentWeight = default,
                AttributeMemberId = default,
                AttributeMember = new()
                {
                    AttributeMemberId = default,
                    Attribute = ParentAttribute
                }
            };

            AddEntry(newEntry);

            return newEntry;
        }

        protected override bool UpdateEntryEffectiveDate(
            SecurityAttributeDto entry, DateTime effectiveDate)
        {
            entry.EffectiveDate = effectiveDate;
            return entry.EffectiveDate == effectiveDate;
        }
    }
}
