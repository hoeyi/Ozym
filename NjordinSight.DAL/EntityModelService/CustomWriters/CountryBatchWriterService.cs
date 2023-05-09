using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordinSight.EntityModel.Context;
using NjordinSight.Logging;
using NjordinSight.EntityModel;
using NjordinSight.EntityModel.ConstraintType;
using NjordinSight.EntityModelService.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NjordinSight.EntityModelService.CustomWriters
{
    internal class CountryBatchWriterService : ModelWriterBatchService<Country>
    {
        /// <summary>
        /// Creates a new <see cref="CountryBatchWriterService"/> instance.
        /// </summary>
        /// <param name="contextFactory">The <see cref="IDbContextFactory{T}"/> 
        /// for this service.</param>
        /// <param name="modelMetadata">The <see cref="IModelMetadataService"/> for this service.
        /// </param>
        /// <param name="logger">The <see cref="ILogger"/> for this service.</param>
        /// <exception cref="ArgumentNullException">A required parameter was null.</exception>
        public CountryBatchWriterService(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger) :
                base(contextFactory, modelMetadata, logger)
        {
        }

        /// <summary>
        /// Base constructor for <see cref="CountryBatchWriterService"/> instances where a
        /// shared context is used.
        /// </summary>
        /// <param name="sharedContext"></param>
        /// <param name="metadataService"></param>
        /// <param name="logger"></param>
        public CountryBatchWriterService(
            FinanceDbContext sharedContext,
            IModelMetadataService metadataService,
            ILogger logger)
            : base(sharedContext, metadataService, logger)
        {
        }

        /// <inheritdoc/>
        public override async Task<int> SaveChangesAsync()
        {
            try
            {
                using var transaction = await SharedContext.Database.BeginTransactionIfSupportedAsync();

                int recordsModified = await SharedContext.SaveChangesAsync();

                var orphanedCountryAttributes = SharedContext.ModelAttributeMembers
                    .Include(a => a.Country)
                    .Where(a => a.Country == null && a.AttributeId == (int)ModelAttributeEnum.CountryExposure);

                if(orphanedCountryAttributes.Any())
                    SharedContext.RemoveRange(orphanedCountryAttributes);

                await SharedContext.SaveChangesAsync();

                if (transaction is not null)
                    await transaction.CommitAsync();

                return recordsModified;     
            }
            catch (InvalidOperationException ioe)
            {
                _logger.LogWarning(ioe, ioe.Message);
                throw new ModelUpdateException(ioe.Message);
            }
            catch (DbUpdateConcurrencyException duc)
            {
                _logger.ModelServiceConcurrencyConflict(duc);
                throw new ModelUpdateException(duc.Message);
            }
            catch (DbUpdateException du)
            {
                _logger.ModelServiceSaveChangesFailed(du);
                throw new ModelUpdateException(du.InnerException.Message, du);
            }
        }
    }
}
