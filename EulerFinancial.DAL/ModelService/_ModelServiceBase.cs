using EulerFinancial.Context;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// Represents the base class from which model service classes are derived.
    /// </summary>
    public abstract class ModelServiceBase
    {
        /// <summary>
        /// The data context factory for this service.
        /// </summary>
        protected readonly IDbContextFactory<EulerDbContext> _contextFactory;

        /// <summary>
        /// The <see cref="IModelMetadataService"/> instance for this service.
        /// </summary>
        protected readonly IModelMetadataService _modelMetadata;

        /// <summary>
        /// The <see cref="ILogger"/> instance for this service.
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// Base constructor for use by dervied types.
        /// </summary>
        /// <param name="contextFactory">The factory instance for constructing data contexts.</param>
        /// <param name="metadataService">An <see cref="IModelMetadataService"/> for the service to use.</param>
        /// <param name="logger">An <see cref="ILogger"/> for the service to use.</param>
        protected ModelServiceBase(
            IDbContextFactory<EulerDbContext> contextFactory,
            IModelMetadataService metadataService,
            ILogger logger)
        {
            if (contextFactory is null)
                throw new ArgumentNullException(paramName: nameof(contextFactory));

            if (metadataService is null)
                throw new ArgumentNullException(paramName: nameof(metadataService));

            if (logger is null)
                throw new ArgumentNullException(paramName: nameof(logger));

            _contextFactory = contextFactory;
            _modelMetadata = metadataService;
            _logger = logger;
        }
    }
}
