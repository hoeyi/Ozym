using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordinSight.EntityModel.Context;
using NjordinSight.EntityModel;
using NjordinSight.EntityModelService.Abstractions;

namespace NjordinSight.EntityModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="SecurityPrice"/> 
    /// data store.
    /// </summary>
    internal class SecurityPriceService : ModelService<SecurityPrice>
    {
        public SecurityPriceService(
            IDbContextFactory<FinanceDbContext> contextFactory, 
            IModelMetadataService metadataService, 
            ILogger logger) : base(contextFactory, metadataService, logger)
        {
            Reader = new ModelReaderService<SecurityPrice>(
                _contextFactory, _modelMetadata, _logger);

            Writer = new ModelWriterService<SecurityPrice>(
                _contextFactory, _modelMetadata, _logger);
        }
    }
}
