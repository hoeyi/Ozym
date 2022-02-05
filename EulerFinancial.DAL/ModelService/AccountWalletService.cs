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
using EulerFinancial.Logging.Resources;
using Ichosoft.Extensions.Common.Logging;
using Ichosoft.DataModel.Annotations;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// The class for servicing batch CRUD requests against the <see cref="AccountWallet"/> 
    /// data store.
    /// </summary>
    public class AccountWalletService :
        BatchModelServiceBase<AccountWallet, int>,
        IAccountWalletService
    {
        /// <inheritdoc/>
        public AccountWalletService(
            EulerFinancialContext context,
            IModelMetadataService modelMetadata,
            ILogger logger) : base(context, modelMetadata, logger)
        {
        }

        /// <inheritdoc/>
        public override bool ModelExists(AccountWallet model)
        {
            if (model is null)
                return false;

            return context.AccountWallets.Any(m => m.AccountWalletId == model.AccountWalletId);
        }

        /// <inheritdoc/>
        public override async Task<int> SaveChanges()
        {
            // TODO: Determine if this have value.
            // Why return the record count of added/updated/deleted records?

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

            return await context.SaveChangesAsync();
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
        public override bool Add(AccountWallet model)
        {
            model.AccountId = ParentKey;
            context.AccountWallets.Add(model);

            EntityState expectedState = context.Entry(model).State;

            bool result = expectedState == EntityState.Added;

            if (result)
            {
                logger.LogDebug(message: DebugMessage.Context_AddPending_Success, model);
            }
            else
            {
                logger.LogDebug(message: ExceptionMessage.Context_Add_UnexpectedState,
                    model, EntityState.Deleted, expectedState);
            }
            return result;
        }

        /// <inheritdoc/>
        public override bool Delete(AccountWallet model)
        {
            context.AccountWallets.Remove(model);

            EntityState expectedState = context.Entry(model).State;

            bool result = expectedState == EntityState.Deleted;

            if(result)
            {
                logger.LogDebug(message: DebugMessage.Context_DeletePending_Success, model);
            }
            else
            {
                logger.LogDebug(message: ExceptionMessage.Context_Delete_UnexpectedState,
                    model, EntityState.Deleted, expectedState);
            }
            return result;
        }

        /// <inheritdoc/>
        public override async Task<List<AccountWallet>> SelectWhereAysnc(
            Expression<Func<AccountWallet, bool>> predicate, int maxCount = 0)
        {
            maxCount = maxCount < 0 ? int.MaxValue : maxCount;

            logger.LogInformation(
                message: InformationMessage.ModelSearch_Request_SubmitSuccess,
                typeof(AccountWallet), predicate, maxCount);

            var result = await context.AccountWallets
                            .Include(a => a.Account)
                            .Include(a => a.DenominationSecurity)
                            .Where(a => a.AccountId == ParentKey)
                            .Where(predicate)
                            .ToListAsync();

            logger.LogInformation(
                message: InformationMessage.ModelSearch_Request_ReturnSuccess,
                typeof(AccountWallet), result.Count);

            return result;
        }
    }
}
