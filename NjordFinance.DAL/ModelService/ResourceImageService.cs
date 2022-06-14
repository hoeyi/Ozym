using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="ResourceImage"/> 
    /// data store.
    /// </summary>
    internal class ResourceImageService : ModelService<ResourceImage>
    {
        /// <summary>
        /// Creates a new <see cref="ResourceImageService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public ResourceImageService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<ResourceImage>(
                contextFactory, modelMetadata, logger);
            Writer = new ModelWriterService<ResourceImage>(
                contextFactory, modelMetadata, logger);
        }
    }
}
