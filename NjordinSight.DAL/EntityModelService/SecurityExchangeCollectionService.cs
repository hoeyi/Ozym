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
    /// The class for servicing batch CRUD requests against the <see cref="SecurityExchange"/> 
    /// data store.
    /// </summary>
    internal class SecurityExchangeCollectionService : ModelCollectionService<SecurityExchange>
    {
        /// <summary>
        /// Creates a new <see cref="SecurityExchangeCollectionService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public SecurityExchangeCollectionService(
            IDbContextFactory<FinanceDbContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger)
                : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<SecurityExchange>(
                ContextFactory, ModelMetadata, Logger);

            GetDefaultModelDelegate = () => new SecurityExchange();
        }
    }
}
