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
        /// <param name="contextFactory"></param>
        /// <param name="modelMetadata"></param>
        /// <param name="logger"></param>
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
                    context.AccountCustodians.Add(model);

                    var result = await context.SaveChangesAsync() > 0;

                    return new DbActionResult<AccountCustodian>(model, result);
                },
                DeleteDelegate = async (context, model) =>
                {
                    context.AccountCustodians.Remove(model);

                    var result = await context.SaveChangesAsync() > 0;

                    return new DbActionResult<bool>(result, result);
                },
                GetDefaultDelegate = () => new AccountCustodian(),
                UpdateDelegate = async (context, model) =>
                {
                    context.Entry(model).State = EntityState.Modified;

                    var result = await context.SaveChangesAsync() > 0;

                    return new DbActionResult<bool>(result, result);
                }
            };
        }
    }
}
