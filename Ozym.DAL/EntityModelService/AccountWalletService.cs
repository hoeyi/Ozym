using Ozym.EntityModel.Context;
using Ozym.EntityModel;
using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ozym.EntityModelService.Abstractions;

namespace Ozym.EntityModelService
{
    /// <summary>
    /// The class for servicing batch CRUD requests against the <see cref="AccountWallet"/> 
    /// data store.
    /// </summary>
    internal class AccountWalletService : ModelCollectionService<AccountWallet>
    {
        /// <summary>
        /// Creates a new <see cref="AccountWalletService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public AccountWalletService(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger)
                : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<AccountWallet>(ContextFactory, ModelMetadata, Logger);
            GetDefaultModelDelegate = () => new AccountWallet();
        }
    }
}
