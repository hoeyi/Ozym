using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;
using System;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="MarketIndexPrice"/> 
    /// data store.
    /// </summary>
    internal class MarketIndexPriceBatchService : ModelBatchService<MarketIndexPrice>
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
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => true,
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.MarketIndex)
            };

            Writer = new ModelWriterBatchService<MarketIndexPrice>(
                this, _modelMetadata, _logger)
            {
                GetDefaultModelDelegate = () => new()
                {
                    PriceCode = string.Empty,
                    PriceDate = DateTime.UtcNow.Date
                }
            };
        }

        public override bool ForParent(int parentId, out Exception e)
        {
            Reader = new ModelReaderService<MarketIndexPrice>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => x.MarketIndexId == parentId
            };

            Writer = new ModelWriterBatchService<MarketIndexPrice>(
                this, _modelMetadata, _logger)
            {
                ParentExpression = x => x.MarketIndexId == parentId,
                GetDefaultModelDelegate = () => new()
                {
                    MarketIndexId = parentId
                }
            };

            e = null;
            return true;
        }
    }
}
