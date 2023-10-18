using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ozym.EntityModel.Context;
using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;
using System;

namespace Ozym.EntityModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="MarketIndexPrice"/> 
    /// data store.
    /// </summary>
    internal class MarketIndexPriceService : ModelCollectionService<MarketIndexPrice>
    {
        /// <summary>
        /// Creates a new <see cref="MarketIndexPriceService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public MarketIndexPriceService(
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
