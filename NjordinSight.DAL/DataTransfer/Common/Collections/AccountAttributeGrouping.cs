using NjordinSight.EntityModel;
using NjordinSight.DataTransfer.Common.Generic;
using System;
using System.Collections.Generic;

namespace NjordinSight.DataTransfer.Common.Collections
{
    public class AccountAttributeGrouping :
        AttributeEntryUnweightedGrouping<AccountBaseDto, AccountAttributeDto>,
        IAttributeEntryUnweightedGrouping<AccountBaseDto, AccountAttributeDto>
    {
        public AccountAttributeGrouping(
            AccountBaseDto parentEntity, ModelAttributeDto modelAttribute)
            : base(parentEntity, modelAttribute)
        {
        }

        protected override Func<AccountBaseDto, ICollection<AccountAttributeDto>>
            ParentEntryMemberSelector => x => x.Attributes;

        protected override Func<AccountAttributeDto, bool> EntrySelector => x =>
            x.AttributeMember.Attribute.AttributeId == ParentAttribute.AttributeId;

        protected override Func<AccountAttributeDto, decimal> WeightSelector => x => x.PercentWeight;

        public override AccountAttributeDto AddNewEntry()
        {
            AccountAttributeDto newEntry = new()
            {
                AccountObjectId = ParentObject.Id,
                EffectiveDate = DateTime.UtcNow.Date,
                PercentWeight = 1M,
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
    }
}
