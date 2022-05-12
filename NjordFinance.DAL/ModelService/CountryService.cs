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
    /// The class for servicing single CRUD requests against the <see cref="Country"/> 
    /// data store.
    /// </summary>
    internal class CountryService : ModelService<Country>
    {
        /// <summary>
        /// Creates a new <see cref="CountryService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public CountryService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<Country>(
                contextFactory, modelMetadata, logger);
            Writer = new ModelWriterService<Country>(
                contextFactory, modelMetadata, logger)
            {
                CreateDelegate = async (context, model) =>
                {
                    var result = await context
                        .MarkForCreation(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<Country>(model, result);
                },
                DeleteDelegate = async (context, model) =>
                {
                    var result = await context
                        .MarkForDeletion(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<bool>(result, result);
                },
                GetDefaultDelegate = () => new Country(),
                UpdateDelegate = async (context, model) =>
                {
                    var result = await context
                        .MarkForUpdate(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<bool>(result, result);
                }
            };
        }
    }
}
