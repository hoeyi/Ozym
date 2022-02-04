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
using EulerFinancial.Resources;
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
        IBatchModelService<AccountWallet, int>
    {
        /// <inheritdoc/>
        public AccountWalletService(
            EulerFinancialContext context,
            IModelMetadataService modelMetadata,
            ILogger logger) : base(context, modelMetadata, logger)
        {
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
        public override bool Add(AccountWallet model, int parentKey)
        {
            ParentKey = parentKey;

            model.AccountId = ParentKey;
            context.AccountWallets.Add(model);

            EntityState expectedState = context.Entry(model).State;

            bool result = expectedState == EntityState.Added;

            if (result)
            {
                logger.LogDebug(message: DebugMessage.ModelBatch_Add_Success, model);
            }
            else
            {
                logger.LogDebug(message: DebugMessage.ModelBatch_Add_Failure,
                    model, EntityState.Deleted, expectedState);
            }
            return result;
        }

        /// <inheritdoc/>
        public override bool Delete(AccountWallet model, int parentKey)
        {
            ParentKey = parentKey;

            context.AccountWallets.Remove(model);

            EntityState expectedState = context.Entry(model).State;

            bool result = expectedState == EntityState.Deleted;

            if(result)
            {
                logger.LogDebug(message: DebugMessage.ModelBatch_Delete_Success, model);
            }
            else
            {
                logger.LogDebug(message: DebugMessage.ModelBatch_Delete_Failure,
                    model, EntityState.Deleted, expectedState);
            }
            return result;
        }

        /// <inheritdoc/>
        public override async Task<List<AccountWallet>> SelectWhereAysnc(
            Expression<Func<AccountWallet, bool>> predicate, int parentKey, int maxCount = 0)
        {
            ParentKey = parentKey;

            logger.LogInformation(
                message: InformationMessage.ModelSearch_Request_SubmitSuccess
                    .ConvertToLogTemplate("Model", "Parameters"),
                args: modelMetadata.AttributeFor<NounAttribute>(typeof(AccountWallet)));

            var result = await context.AccountWallets
                            .Include(a => a.Account)
                            .Include(a => a.DenominationSecurity)
                            .Where(a => a.AccountId == ParentKey)
                            .Where(predicate)
                            .ToListAsync();

            logger.LogInformation(
                message: InformationMessage.ModelSearch_Request_ReturnSuccess
                    .ConvertToLogTemplate("Models"),
                args: typeof(AccountWallet));

            return result;
        }
    }
}
