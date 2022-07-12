using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ViewModel
{
    public class AccountObjectAttributeViewModel :
        AttributeEntryViewModel<AccountAttributeMemberEntry, AccountObject>
    {
        public AccountObjectAttributeViewModel(AccountObject accountObject, DateTime effectiveDate)
            : base(accountObject, effectiveDate)
        {
        }

        public override AccountAttributeMemberEntry ToEntryEntity() =>
            new()
            {
                AttributeMemberId = AttributeMemberId,
                AccountObjectId = ParentObject.AccountObjectId,
                EffectiveDate = EffectiveDate,
                Weight = 100M
            };
    }
}
