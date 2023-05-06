using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.EntityModel.Context;
using NjordFinance.EntityModel;
using NjordFinance.EntityModelService.Abstractions;
using System;

namespace NjordFinance.EntityModelService
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
                Context, _modelMetadata, _logger)
            {
                ParentExpression = null,
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.MarketIndex)
            };

            Writer = new ModelWriterBatchService<MarketIndexPrice>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = null,
                GetDefaultModelDelegate = () => new()
                {
                    PriceCode = string.Empty,
                    PriceDate = DateTime.UtcNow.Date
                }
            };
        }

        public override bool ForParent(int parentId, out Exception e)
        {
            e = new NotSupportedException(
                message: Exceptions.ExceptionString.ModelService_ParentNotSupported);
            return false;
        }
    }
}
