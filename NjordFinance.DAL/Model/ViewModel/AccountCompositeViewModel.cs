using NjordFinance.ModelMetadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NjordFinance.Model.ViewModel
{
    /// <summary>
    /// Provides a flattened view-object for working with complex type <see cref="AccountComposite"/>.
    /// </summary>
    public class AccountCompositeViewModel : AccountObjectViewModel
    {
        private readonly AccountComposite _composite;
        public AccountCompositeViewModel(AccountComposite composite)
            : this(composite, composite.AccountCompositeNavigation)
        {
        }

        AccountCompositeViewModel(AccountComposite composite, AccountObject accountObject) :
            base(accountObject)
        {
            if (composite is null)
                throw new ArgumentNullException(paramName: nameof(composite));

            _composite = composite;
        }

        public override string ObjecTypeCode => AccountObjectType.Composite.ConvertToStringCode();
        
        public IReadOnlyCollection<AccountCompositeMember> Members => 
            _composite.AccountCompositeMembers.ToList();

        public bool AddMember() => throw new NotImplementedException();

        public bool RemoveMember(AccountCompositeMember member) => throw new NotImplementedException();

        public AccountComposite ToAccountComposite() => _composite;
    }
}
