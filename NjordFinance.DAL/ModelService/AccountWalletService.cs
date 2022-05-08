using NjordFinance.Context;
using NjordFinance.Model;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.ModelService.Abstractions;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing batch CRUD requests against the <see cref="AccountWallet"/> 
    /// data store.
    /// </summary>
    internal class AccountWalletService : ModelBatchService<AccountWallet>
    {
        /// <summary>
        /// Creates a new <see cref="AccountWalletService"/> instance.
        /// </summary>
        /// <param name="contextFactory"></param>
        /// <param name="modelMetadata"></param>
        /// <param name="logger"></param>
        public AccountWalletService(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger)
                : base(contextFactory, modelMetadata, logger)
        {
        }

        public override bool ForParent(int parentId)
        {
            Reader = new ModelReaderService<AccountWallet>(
                _contextFactory, _modelMetadata, _logger)
            {
                ParentExpression = x => x.AccountId == parentId
            };

            Writer = new ModelWriterBatchService<AccountWallet>(
                _contextFactory, _modelMetadata, _logger)
            {
                ParentExpression = x => x.AccountId == parentId,
                GetDefaultModelDelegate = () => new AccountWallet() { AccountId = parentId }
            };

            return true;
        }
    }
}
