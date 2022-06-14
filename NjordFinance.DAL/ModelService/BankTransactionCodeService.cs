using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="BankTransactionCode"/> 
    /// data store.
    /// </summary>
    internal class BankTransactionCodeService : ModelService<BankTransactionCode>
    {
        /// <summary>
        /// Creates a new <see cref="BankTransactionCodeService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public BankTransactionCodeService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<BankTransactionCode>(
                contextFactory, modelMetadata, logger);
            Writer = new ModelWriterService<BankTransactionCode>(
                contextFactory, modelMetadata, logger);
        }
    }
}
