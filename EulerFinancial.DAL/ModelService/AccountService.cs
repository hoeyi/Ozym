using EulerFinancial.Context;
using EulerFinancial.Model;
using EulerFinancial.ModelMetadata;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="Account"/> 
    /// data store.
    /// </summary>
    public class AccountService : ModelService<Account>, IModelService<Account>
    {
        /// <inheritdoc/>
        public AccountService(
            IDbContextFactory<EulerFinancialContext> contextFactory,
            IModelMetadataService modelMetadata,
            ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            PathCollection.AddPath(a => a.AccountCustodian);
            PathCollection.AddPath(a => a.AccountNavigation);
        }

        /// <inheritdoc/>
        protected override Func<
            EulerFinancialContext, Account, Task<DbActionResult<Account>>
            > CreateDelegate => async (context, model) =>
            {
                using var transaction = await context.Database.BeginTransactionAsync();

                context.AccountObjects.Add(model.AccountNavigation);

                model.AccountId = model.AccountNavigation.AccountObjectId;
                context.Accounts.Add(model);

                var count = await context.SaveChangesAsync();

                await transaction.CommitAsync();

                var result = count > 0;

                return new DbActionResult<Account>(model, result);
            };

        /// <inheritdoc/>
        protected override Func<
            EulerFinancialContext, Account, Task<DbActionResult<bool>>
            > DeleteDelegate => async (context, model) =>
            {
                bool deleteSuccessful = false;
                using var transaction = await context.Database.BeginTransactionAsync();

                // Remove bank transaction children.
                if (context.BankTransactions.Any(bt => bt.AccountId == model.AccountId))
                    context.BankTransactions.RemoveRange(
                        context.BankTransactions.Where(bt => bt.AccountId == model.AccountId));

                // Remove broker transaction children.
                if (context.BrokerTransactions.Any(bt => bt.AccountId == model.AccountId))
                    context.BrokerTransactions.RemoveRange(
                        context.BrokerTransactions.Where(bt => bt.AccountId == model.AccountId));

                // Remove account wallet children.
                if (context.AccountWallets.Any(aw => aw.AccountId == model.AccountId))
                    context.AccountWallets.RemoveRange(
                        context.AccountWallets.Where(w => w.AccountId == model.AccountId));

                // Remove account attribute children.
                if (context.AccountAttributeMemberEntries.Any(gm => gm.AccountObjectId == model.AccountId))
                    context.AccountAttributeMemberEntries.RemoveRange(
                        context.AccountAttributeMemberEntries.Where(
                            aa => aa.AccountObjectId == model.AccountId));

                // Remove account group memberships.
                if (context.AccountGroupMembers.Any(gm => gm.AccountId == model.AccountId))
                    context.AccountGroupMembers.RemoveRange(
                        context.AccountGroupMembers.Where(agm => agm.AccountId == model.AccountId));

                // Save changes because cascade delete is not used.
                await context.SaveChangesAsync();

                // Remove account.
                context.Accounts.Remove(model);

                // Save changes because cascade delete is not used.
                await context.SaveChangesAsync();

                // Remove account object.
                context.AccountObjects.Remove(
                    context.AccountObjects.Where(
                        a => a.AccountObjectId == model.AccountId).First());

                deleteSuccessful = await context.SaveChangesAsync() > 0;

                await transaction.CommitAsync();

                return new DbActionResult<bool>(deleteSuccessful, deleteSuccessful);
            };

        /// <inheritdoc/>
        protected override Func<
            EulerFinancialContext, Account, Task<DbActionResult<bool>>
            > UpdateDelegate => async (context, model) =>
            {
                context.Entry(model).State = EntityState.Modified;
                context.Entry(model.AccountNavigation).State = EntityState.Modified;

                var count = await context.SaveChangesAsync();
                var result = count > 0;

                return new DbActionResult<bool>(result, result);
            };

        /// <inheritdoc/>
        public override async Task<Account> GetDefaultAsync()
        {
            var defaultTask = Task.Run(() => new Account()
            {
                AccountNavigation = new AccountObject()
                {
                    ObjectType = AccountObjectType.Account.ConvertToStringCode()
                }
            });

            return await defaultTask;
        }
    }
}
