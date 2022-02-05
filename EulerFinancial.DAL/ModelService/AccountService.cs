using EulerFinancial.Context;
using EulerFinancial.Logging.Resources;
using EulerFinancial.Model;
using EulerFinancial.ModelMetadata;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="Account"/> 
    /// data store.
    /// </summary>
    public class AccountService : ModelServiceBase<Account>, IAccountService
    {
        /// <inheritdoc/>
        public AccountService(
            EulerFinancialContext context,
            IModelMetadataService modelMetadata,
            ILogger logger)
            : base(context, modelMetadata, logger)
        {
        }

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

        /// <inheritdoc/>
        public override async Task<Account> CreateAsync(Account model)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            context.AccountObjects.Add(model.AccountNavigation);

            await context.SaveChangesAsync();

            model.AccountId = model.AccountNavigation.AccountObjectId;
            context.Accounts.Add(model);

            var count = await context.SaveChangesAsync();
            var result = count == 1;

            await transaction.CommitAsync();

            if (result)
                logger.LogInformation(
                    InformationMessage.Model_Create_Success,
                    model);
            else
                logger.LogWarning(
                    message: ExceptionMessage.Context_SingleAdd_UnexpectedResult,
                    count);

            return model;
        }

        /// <inheritdoc/>   
        public override async Task<Account> ReadAsync(int? id)
        {
            var result = await context.Accounts
                                .Include(a => a.AccountCustodian)
                                .Include(a => a.AccountNavigation)
                                .FirstOrDefaultAsync(a => a.AccountId == id);

            if (result is not null)
                logger.LogInformation(
                    InformationMessage.Model_Read_Success,
                    result);
            else if(id is not null)
                logger.LogWarning(
                    ExceptionMessage.Context_SingleRead_Failure,
                    id);

            return result;
        }

        /// <inheritdoc/>
        public override async Task<bool> UpdateAsync(Account model)
        {
            context.Entry(model).State = EntityState.Modified;

            var count = await context.SaveChangesAsync();
            var result = count > 1;

            if (result)
                logger.LogInformation(
                    InformationMessage.Model_Update_Success,
                    model);
            else
                logger.LogWarning(
                    message: ExceptionMessage.Context_SingleUpdate_UnexpectedResult,
                    count);

            return result;
        }

        /// <inheritdoc/>
        public override async Task<bool> DeleteAsync(Account model)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                context.BankTransactions.RemoveRange(
                    context.BankTransactions.Where(bt => bt.AccountId == model.AccountId));

                context.BrokerTransactions.RemoveRange(
                    context.BrokerTransactions.Where(bt => bt.AccountId == model.AccountId));

                context.AccountGroupMembers.RemoveRange(
                    context.AccountGroupMembers.Where(agm => agm.AccountId == model.AccountId));

                context.AccountWallets.RemoveRange(
                    context.AccountWallets.Where(w => w.AccountId == model.AccountId));

                await context.SaveChangesAsync();

                context.Accounts.Remove(model);

                context.AccountAttributeMemberEntries.RemoveRange(
                    context.AccountAttributeMemberEntries.Where(aa => aa.AccountObjectId == model.AccountId));

                await context.SaveChangesAsync();

                context.AccountObjects.Remove(
                    context.AccountObjects.Where(a => a.AccountObjectId == model.AccountId).First());

                var count = await context.SaveChangesAsync();
                var result = count == 1;

                await transaction.CommitAsync();

                if (result)
                    logger.LogInformation(
                        InformationMessage.Model_Delete_Success,
                        model);
                else
                    logger.LogWarning(
                        message: ExceptionMessage.Context_SingleDelete_UnexpectedResult,
                        count);

                return true;
            }
            catch (DbUpdateException e)
            {
                logger.LogError(
                    exception: e,
                    message: e.Message);

                return !ModelExists(model.AccountId);
            }
        }

        /// <inheritdoc/>
        public override bool ModelExists(int? id)
        {
            if (id is null)
            {
                return false;
            }

            return context.Accounts.Any(m => m.AccountId == id);
        }

        /// <inheritdoc/>
        public override bool ModelExists(Account model)
        {
            if (model is null)
            {
                return false;
            }

            return context.Accounts.Any(m => m.AccountId == model.AccountId);
        }

        /// <inheritdoc/>
        public override async Task<List<Account>> SelectAllAsync()
        {
            Expression<Func<Account, bool>> expression = x => true;

            logger.LogInformation(
                message: InformationMessage.ModelSearch_Request_SubmitSuccess,
                typeof(Account), expression, int.MaxValue);

            var result = await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .ToListAsync();

            logger.LogInformation(
                message: InformationMessage.ModelSearch_Request_ReturnSuccess,
                typeof(Account), result.Count);

            return result;
        }

        /// <inheritdoc/>
        public override async Task<List<Account>> SelectWhereAysnc(
            Expression<Func<Account, bool>> predicate, int maxCount = 0)
        {
            maxCount = maxCount < 0 ? int.MaxValue : maxCount;

            logger.LogInformation(
                message: InformationMessage.ModelSearch_Request_SubmitSuccess,
                typeof(Account), predicate, maxCount);

            var result = await context.Accounts
                            .Include(a => a.AccountCustodian)
                            .Include(a => a.AccountNavigation)
                            .Where(predicate)
                            .Take(maxCount)
                            .ToListAsync();

            logger.LogInformation(
                message: InformationMessage.ModelSearch_Request_ReturnSuccess,
                typeof(Account), result.Count);

            return result;
        }

    }
}
