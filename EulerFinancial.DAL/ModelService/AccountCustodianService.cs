using EulerFinancial.Context;
using EulerFinancial.Model;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="AccountCustodian"/> 
    /// data store.
    /// </summary>
    public class AccountCustodianService :
        ModelService<AccountCustodian>, IModelService<AccountCustodian>
    {
        /// <inheritdoc/>
        public AccountCustodianService(
                IDbContextFactory<EulerDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
        }

        /// <inheritdoc/>
        protected override Func<
            EulerDbContext, AccountCustodian, Task<DbActionResult<AccountCustodian>>
            > CreateDelegate => async (context, model) =>
            {
                context.AccountCustodians.Add(model);

                var result = await context.SaveChangesAsync() > 0;

                return new DbActionResult<AccountCustodian>(model, result);
            };

        /// <inheritdoc/>
        protected override Func<
            EulerDbContext, AccountCustodian, Task<DbActionResult<bool>>
            > DeleteDelegate => async (context, model) =>
            {
                context.AccountCustodians.Remove(model);

                var result = await context.SaveChangesAsync() > 0;

                return new DbActionResult<bool>(result, result);
            };

        /// <inheritdoc/>
        protected override Func<
            EulerDbContext, AccountCustodian, Task<DbActionResult<bool>>
            > UpdateDelegate => async (context, model) =>
            {
                context.Entry(model).State = EntityState.Modified;

                var result = await context.SaveChangesAsync() > 0;

                return new DbActionResult<bool>(result, result);
            };

        /// <inheritdoc/>   
        public override async Task<AccountCustodian> GetDefaultAsync()
        {
            var defaultTask = Task.Run(() => new AccountCustodian());

            return await defaultTask;
        }
    }
}
