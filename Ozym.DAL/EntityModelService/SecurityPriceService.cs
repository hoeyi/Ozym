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
    /// The class for servicing batch CRUD requests against the <see cref="SecurityPrice"/> 
    /// data store.
    /// </summary>
    internal class SecurityPriceService : ModelCollectionService<SecurityPrice>
    {
        /// <summary>
        /// Creates a new <see cref="SecurityPriceService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public SecurityPriceService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<SecurityPrice>(
                ContextFactory, ModelMetadata, Logger);
        }
    }
}
