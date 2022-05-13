using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using NjordFinance.ModelService.Abstractions;
using System.Linq;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="InvestmentStrategy"/> 
    /// data store.
    /// </summary>
    internal class InvestmentStrategyService : ModelService<InvestmentStrategy>
    {
        /// <summary>
        /// Creates a new <see cref="InvestmentStrategyService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public InvestmentStrategyService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<InvestmentStrategy>(
                contextFactory, modelMetadata, logger);
            Writer = new ModelWriterService<InvestmentStrategy>(
                contextFactory, modelMetadata, logger);
        }
    }
}
