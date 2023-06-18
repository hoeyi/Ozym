using NjordinSight.EntityModel;
using NjordinSight.DataTransfer.Common.Generic;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NjordinSight.DataTransfer.Common.Collections
{
    public class AccountAttributeGrouping :
        AttributeEntryUnweightedGrouping<AccountBaseDto, AccountBaseAttributeDto>,
        IAttributeEntryUnweightedGrouping<AccountBaseDto, AccountBaseAttributeDto>
    {
        public AccountAttributeGrouping(
            AccountBaseDto parentEntity, ModelAttributeDto modelAttribute)
            : base(parentEntity, modelAttribute)
        {
        }

        protected override Func<AccountBaseDto, ICollection<AccountBaseAttributeDto>>
            ParentEntryMemberSelector => x => x.Attributes;

        protected override Func<AccountBaseAttributeDto, bool> EntrySelector => x =>
            x.AttributeMember.Attribute.AttributeId == ParentAttribute.AttributeId;

        protected override Func<AccountBaseAttributeDto, decimal> WeightSelector => x => x.PercentWeight;

        public override AccountBaseAttributeDto AddNewEntry()
        {
            AccountBaseAttributeDto newEntry = new()
            {
                AccountObjectId = ParentObject.Id,
                EffectiveDate = DateTime.UtcNow.Date,
                PercentWeight = 1M,
                AttributeMember = new()
                {
                    AttributeMemberId = default,
                    Attribute = ParentAttribute
                }
            };

            AddEntry(newEntry);

            return newEntry;
        }
    }
}
