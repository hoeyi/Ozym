using EulerFinancial.Context;
using EulerFinancial.Model;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EulerFinancial.Logging;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// The class for servicing batch CRUD requests against the <see cref="AccountWallet"/> 
    /// data store.
    /// </summary>
    public class AccountWalletService :
        BatchModelServiceBase<AccountWallet, int>,
        IBatchModelService<AccountWallet>
    {
        /// <inheritdoc/>
        public AccountWalletService(
            IDbContextFactory<EulerFinancialContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger) : base(contextFactory, modelMetadata, logger)
        {
        }

        /// <inheritdoc/>
        public override bool ModelExists(AccountWallet model)
        {
            if (model is null)
                return false;

            using var context = _contextFactory.CreateDbContext();

            return context.AccountWallets.Any(m => m.AccountWalletId == model.AccountWalletId);
        }

        /// <inheritdoc/>
        public override async Task<int> SaveChanges()
        {
            // TODO: Determine if this have value.
            // Why return the record count of added/updated/deleted records?

            // TODO: What is this for? Checking for valid update row counts before submitting?
            // Would it be better to try/catch concurrency exception?
            //EntityState[] dirtyStates = new[]
            //{
            //    EntityState.Added,
            //    EntityState.Modified,
            //    EntityState.Deleted
            //};

            //int modifiedCount = context
            //    .AccountWallets
            //    .Where(e => dirtyStates.Contains(context.Entry(e).State))
            //    .Count();

            using var context = _contextFactory.CreateDbContext();

            return await DoWriteOperationAsync(async () =>
            {
                return await context.SaveChangesAsync();
            });
        }

        /// <inheritdoc/>
        public override async Task<AccountWallet> GetDefault()
        {
            AccountWallet New()
            {
                return new()
                {
                    AccountId = ParentKey
                };
            }

            var defaultWallet = await Task.Run(() => New());

            return defaultWallet;
        }

        /// <inheritdoc/>
        public override bool AddPendingSave(AccountWallet model)
        {
            model.AccountId = ParentKey;

            using var context = _contextFactory.CreateDbContext();

            context.AccountWallets.Add(model);

            EntityState observedState = context.Entry(model).State;

            bool result = observedState == EntityState.Added;

            object m = new
            {
                Type = typeof(AccountWallet).Name,
                model.AccountWalletId,
                model.AccountId
            };

            if (result)
            {
                _logger.ModelServiceAddedPendingSave(m);
            }
            else
            {
                _logger.ModelServiceAddReturnedInvalidState(m, EntityState.Added, observedState);
            }
            return result;
        }

        /// <inheritdoc/>
        public override bool DeletePendingSave(AccountWallet model)
        {
            using var context = _contextFactory.CreateDbContext();

            context.AccountWallets.Remove(model);

            EntityState observedState = context.Entry(model).State;

            bool result = observedState == EntityState.Deleted;

            object m = new
            {
                Type = typeof(AccountWallet).Name,
                model.AccountWalletId,
                model.AccountId
            };

            if (result)
            {
                _logger.ModelServiceDeletedPendingSave(m);
            }
            else
            {
                _logger.ModelServiceDeleteReturnedInvalidState(m, EntityState.Deleted, observedState);
            }
            return result;
        }

        /// <inheritdoc/>
        public override async Task<List<AccountWallet>> SelectWhereAysnc(
            Expression<Func<AccountWallet, bool>> predicate, int maxCount = 0)
        {
            maxCount = maxCount < 0 ? int.MaxValue : maxCount;

            var searchGuid = Guid.NewGuid();

            _logger.ModelServiceSearchRequestAccepted(
                requestGuid: searchGuid,
                type: typeof(AccountWallet),
                predicate: predicate.Body,
                recordLimit: maxCount);

            using var context = _contextFactory.CreateDbContext();

            var result = await context.AccountWallets
                            .Include(a => a.Account)
                            .Include(a => a.DenominationSecurity)
                            .Where(a => a.AccountId == ParentKey)
                            .Where(predicate)
                            .ToListAsync();

            _logger.ModelServiceSearchResultReturned(
                requestGuid: searchGuid,
                type: typeof(AccountWallet),
                resultCount: result?.Count ?? default);

            return result;
        }
    }
}
