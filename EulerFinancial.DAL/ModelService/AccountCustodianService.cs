using EulerFinancial.Context;
using EulerFinancial.Logging;
using EulerFinancial.Model;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
                IDbContextFactory<EulerFinancialContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
        }

        /// <inheritdoc/>
        public override async Task<AccountCustodian> CreateAsync(AccountCustodian model)
        {
            using var context = _contextFactory.CreateDbContext();

            return await DoWriteOperationAsync(async () =>
            {
                context.AccountCustodians.Add(model);

                var count = await context.SaveChangesAsync();

                var result = count > 0;

                if (result)
                    _logger.ModelServiceCreatedModel(
                        new
                        {
                            Type = typeof(AccountCustodian).Name,
                            Id = model.AccountCustodianId,
                            Code = model.CustodianCode
                        });

                return model;
            });
        }

        /// <inheritdoc/>
        public override async Task<bool> DeleteAsync(AccountCustodian model)
        {
            using var context = _contextFactory.CreateDbContext();

            return await DoWriteOperationAsync(async () =>
            {
                context.AccountCustodians.Add(model);

                var count = await context.SaveChangesAsync();

                var result = count > 0;

                if (result)
                    _logger.ModelServiceCreatedModel(
                        new
                        {
                            Type = typeof(AccountCustodian).Name,
                            Id = model.AccountCustodianId,
                            Code = model.CustodianCode
                        });

                return result;
            });
        }

        /// <inheritdoc/>   
        public override async Task<AccountCustodian> GetDefaultAsync()
        {
            var defaultTask = Task.Run(() => new AccountCustodian());

            return await defaultTask;
        }

        /// <inheritdoc/>
        public override async Task<bool> UpdateAsync(AccountCustodian model)
        {
            using var context = _contextFactory.CreateDbContext();

            return await DoWriteOperationAsync(async () =>
            {
                context.Entry(model).State = EntityState.Modified;

                var count = await context.SaveChangesAsync();
                var result = count == 1;

                if (result)
                    _logger.ModelServiceUpdatedModel(
                        model: new
                        {
                            Type = typeof(Account).Name,
                            model.AccountCustodianId,
                            model.CustodianCode
                        });

                return result;
            });
        }
    }
}
