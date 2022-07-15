using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;

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
                contextFactory, modelMetadata, logger)
            {
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.InvestmentStrategyTargets)
                    .ThenInclude(b => b.AttributeMember)
                    .ThenInclude(c => c.Attribute)
            };

            Writer = new ModelWriterService<InvestmentStrategy>(
                contextFactory, modelMetadata, logger);
        }
    }
}
