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
    /// The class for servicing batch CRUD requests against the <see cref="SecurityPrice"/> 
    /// data store.
    /// </summary>
    internal class SecurityPriceBatchService : ModelBatchService<SecurityPrice>
    {
        /// <summary>
        /// Creates a new <see cref="SecurityPriceBatchService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public SecurityPriceBatchService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<SecurityPrice>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = null
            };

            Writer = new ModelWriterBatchService<SecurityPrice>(
                Context, _modelMetadata, _logger)
            {
                ParentExpression = null,
                GetDefaultModelDelegate = () => new()
            };
        }

        public override bool ForParent(int parentId, out Exception e)
        {
            e = new NotSupportedException(
                message: ExceptionString.ModelService_ParentNotSupported);
            return false;
        }
    }
}
