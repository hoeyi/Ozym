using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordinSight.EntityModel.Context;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;
using System;

namespace NjordinSight.EntityModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="InvestmentPerformanceEntry"/> 
    /// data store.
    /// </summary>
    internal class InvestmentPerformanceService : ModelCollectionService<InvestmentPerformanceEntry, int>
    {
        /// <summary>
        /// Creates a new <see cref="InvestmentPerformanceService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public InvestmentPerformanceService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
        }

        /// <inheritdoc/>
        public override void SetParent(int parent)
        {
            Reader = new ModelReaderService<InvestmentPerformanceEntry>(
                ContextFactory, ModelMetadata, Logger)
            {
                ParentExpression = x => x.AccountObjectId == parent
            };
            GetDefaultModelDelegate = () => new() { AccountObjectId = parent };
        }
    }
}
