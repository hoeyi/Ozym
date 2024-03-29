﻿using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;
using System;
using System.Linq.Expressions;

namespace Ozym.Test.EntityModelService
{
    [TestClass]
    [TestCategory("Integration")]
    public class AccountWalletServiceTest : ModelCollectionServiceTest<AccountWallet>
    {
        private const int _accountId = -7;

        /// <inheritdoc/>
        protected override Expression<Func<AccountWallet, bool>> ParentExpression =>
            x => x.AccountId == _accountId;

        /// <inheritdoc/>
        protected override IModelCollectionService<AccountWallet> GetModelService() =>
            BuildModelService<AccountWalletService>();
    }
}
