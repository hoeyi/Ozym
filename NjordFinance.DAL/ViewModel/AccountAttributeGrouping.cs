using NjordFinance.EntityModel;
using NjordFinance.ViewModel.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.ViewModel
{
    public class AccountAttributeGrouping :
        AttributeEntryUnweightedGrouping<AccountObject, AccountAttributeMemberEntry>,
        IAttributeEntryUnweightedGrouping<AccountObject, AccountAttributeMemberEntry>
    {
        public AccountAttributeGrouping(
            AccountObject parentEntity, ModelAttribute modelAttribute)
            : base(parentEntity, modelAttribute)
        {
        }

        protected override Func<AccountObject, ICollection<AccountAttributeMemberEntry>>
            ParentEntryMemberSelector => x => x.AccountAttributeMemberEntries;

        protected override Func<AccountAttributeMemberEntry, bool> EntrySelector => x =>
            x.AttributeMember is null || x.AttributeMember.AttributeId == ParentAttribute.AttributeId;

        protected override Func<AccountAttributeMemberEntry, decimal> WeightSelector =>
            x => x.Weight;

        public override AccountAttributeMemberEntry AddNewEntry()
        {
            AccountAttributeMemberEntry newEntry = new()
            {
                AccountObjectId = ParentObject.AccountObjectId,
                EffectiveDate = DateTime.UtcNow.Date,
                Weight = 1M,
                AttributeMemberId = default,
                AttributeMember = new()
                {
                    AttributeMemberId = default,
                    AttributeId = ParentAttribute.AttributeId,
                    Attribute = ParentAttribute
                }
            };

            AddEntry(newEntry);

            return newEntry;
        }
    }
}
