using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordinSight.EntityModel.Context;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;

namespace NjordinSight.EntityModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="SecuritySymbolType"/> 
    /// data store.
    /// </summary>
    internal class SecuritySymbolTypeService : ModelService<SecuritySymbolType>
    {
        /// <summary>
        /// Creates a new <see cref="SecuritySymbolTypeService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public SecuritySymbolTypeService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<SecuritySymbolType>(
                contextFactory, modelMetadata, logger);
            Writer = new ModelWriterService<SecuritySymbolType>(
                contextFactory, modelMetadata, logger);
        }
    }
}
