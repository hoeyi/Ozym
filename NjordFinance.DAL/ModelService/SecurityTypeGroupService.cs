using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using NjordFinance.ModelService.Abstractions;
using System.Linq;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="SecurityTypeGroup"/> 
    /// data store.
    /// </summary>
    internal class SecurityTypeGroupService : ModelService<SecurityTypeGroup>
    {
        /// <summary>
        /// Creates a new <see cref="SecurityTypeGroupService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public SecurityTypeGroupService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<SecurityTypeGroup>(
                contextFactory, modelMetadata, logger);
            Writer = new ModelWriterService<SecurityTypeGroup>(
                contextFactory, modelMetadata, logger)
            {
                CreateDelegate = async (context, model) =>
                {
                    model.SecurityTypeGroupNavigation.DisplayName = model.SecurityTypeGroupName;

                    var result = await context
                        .MarkForCreation(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<SecurityTypeGroup>(model, result);
                },
                UpdateDelegate = async (context, model) =>
                {
                    model.SecurityTypeGroupNavigation.DisplayName = model.SecurityTypeGroupName;

                    var result = await context
                        .MarkForUpdate(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<bool>(result, result);
                }
            };

            Reader.AddNavigationPath(a => a.SecurityTypeGroupNavigation);
        }
    }
}
