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
    /// The class for servicing single CRUD requests against the <see cref="MarketIndexPrice"/> 
    /// data store.
    /// </summary>
    internal class MarketIndexPriceBatchService : ModelCollectionService<MarketIndexPrice>
    {
        /// <summary>
        /// Creates a new <see cref="MarketIndexPriceBatchService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public MarketIndexPriceBatchService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<MarketIndexPrice>(
                ContextFactory, ModelMetadata, Logger)
            {
                IncludeDelegate = (queryable) => queryable.Include(a => a.MarketIndex)
            };

            GetDefaultModelDelegate = () => new()
            {
                PriceCode = string.Empty,
                PriceDate = DateTime.UtcNow.Date
            };
        }
    }
}
