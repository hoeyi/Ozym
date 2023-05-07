using NjordFinance.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NjordFinance.DataTransfer
{
    public class AccountCompositeDto : AccountObjectDto
    {
        private readonly AccountComposite _composite;

        public AccountCompositeDto(AccountComposite sourceModel)
            : this(sourceModel, sourceModel.AccountCompositeNavigation)
        {
        }

        AccountCompositeDto(AccountComposite composite, AccountObject accountObject)
            : base(accountObject)
        {
            if (composite is null)
                throw new ArgumentNullException(paramName: nameof(composite));

            _composite = composite;
        }

        public override string ObjecTypeCode => AccountObjectType.Composite.ConvertToStringCode();

        public IReadOnlyCollection<AccountCompositeMember> Members =>
            _composite.AccountCompositeMembers.ToList();

        public void AddMember() =>
            _composite.AccountCompositeMembers.Add(new()
            {
                AccountCompositeId = _composite.AccountCompositeId,
                EntryDate = DateTime.UtcNow.Date
            });

        public bool RemoveMember(AccountCompositeMember member) =>
            _composite.AccountCompositeMembers.Remove(member);

        public AccountComposite ToEntity() => _composite;
    }
}
