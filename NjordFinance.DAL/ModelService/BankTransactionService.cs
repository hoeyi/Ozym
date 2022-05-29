using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="BankTransaction"/> 
    /// data store.
    /// </summary>
    internal class BankTransactionService : ModelBatchService<BankTransaction>
    {
        /// <summary>
        /// Creates a new <see cref="BankTransactionService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public BankTransactionService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
        }

        public override bool ForParent(int parentId)
        {
            Reader = new ModelReaderService<BankTransaction>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => x.AccountId == parentId
            };

            Writer = new ModelWriterBatchService<BankTransaction>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => x.AccountId == parentId,
                GetDefaultModelDelegate = () => new BankTransaction()
                {
                    AccountId = parentId
                }
            };

            return true;
        }
    }
}
