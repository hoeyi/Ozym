using NjordFinance.Context;
using NjordFinance.Model;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordFinance.Logging;
using NjordFinance.ModelService.Abstractions;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing batch CRUD requests against the <see cref="AccountWallet"/> 
    /// data store.
    /// </summary>
    public class AccountWalletService : ModelServiceBase<AccountWallet>,
        IModelServiceMultiple<AccountWallet>
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

        /// <inheritdoc/>
        public IModelReaderService<AccountWallet> Reader { get; private set; }

        /// <inheritdoc/>
        public IModelWriterBatchService<AccountWallet> Writer { get; private set; }

        public bool ForParent(int parentId)
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
