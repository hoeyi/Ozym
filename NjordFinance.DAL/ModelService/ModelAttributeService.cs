using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;
using System.Collections.Generic;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="ModelAttribute"/> 
    /// data store.
    /// </summary>
    internal class ModelAttributeService : ModelService<ModelAttribute>
    {
        /// <summary>
        /// Creates a new <see cref="ModelAttributeService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public ModelAttributeService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<ModelAttribute>(
                Context, modelMetadata, logger)
            {
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.ModelAttributeScopes)
                    .Include(a => a.ModelAttributeMembers)
            };
            Writer = new ModelWriterService<ModelAttribute>(
                Context, modelMetadata, logger)
            {
                GetDefaultDelegate = () => new ModelAttribute()
                {
                    ModelAttributeScopes = new List<ModelAttributeScope>()
                }
            };
        }
    }
}

