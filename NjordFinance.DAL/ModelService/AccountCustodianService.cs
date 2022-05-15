using NjordFinance.Context;
using NjordFinance.Model;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.ModelService.Abstractions;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing CRUD requests against the <see cref="AccountCustodian"/> 
    /// data store.
    /// </summary>
    internal class AccountCustodianService : ModelService<AccountCustodian>
    {
        /// <summary>
        /// Creates a new <see cref="AccountCustodianService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public AccountCustodianService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<AccountCustodian>(
                contextFactory, modelMetadata, logger);

            Writer = new ModelWriterService<AccountCustodian>(
                contextFactory, modelMetadata, logger)
            {
                CreateDelegate = async (context, model) =>
                {
                    var result = await context
                        .MarkForCreation(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<AccountCustodian>(model, result);
                },
                DeleteDelegate = async (context, model) =>
                {
                    var result = await context
                        .MarkForDeletion(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<bool>(result, result);
                },
                GetDefaultDelegate = () => new AccountCustodian(),
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
