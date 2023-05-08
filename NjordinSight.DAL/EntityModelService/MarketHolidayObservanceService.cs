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
    /// The class for servicing single CRUD requests against the <see cref="MarketHolidayObservance"/> 
    /// data store.
    /// </summary>
    internal class MarketHolidayObservanceService : ModelBatchService<MarketHolidayObservance>
    {
        /// <summary>
        /// Creates a new <see cref="MarketHolidayObservanceService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public MarketHolidayObservanceService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<MarketHolidayObservance>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = null
            };

            Writer = new ModelWriterBatchService<MarketHolidayObservance>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = null,
                GetDefaultModelDelegate = () => new()
            };
        }

        public override bool ForParent(int parentId, out Exception e)
        {
            e = new(message: ExceptionString.ModelService_ParentNotSupported);
            return false;
        }
    }
}
