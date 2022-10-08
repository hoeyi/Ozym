using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.ModelService.Abstractions;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="Account"/> 
    /// data store.
    /// </summary>
    internal class AccountService : ModelService<Account>
    {
        /// <summary>
        /// Creates a new <see cref="AccountService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public AccountService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<Account>(contextFactory, modelMetadata, logger)
            {
                IncludeDelegate = (queryable) => queryable.Include(a => a.AccountNavigation)
            };

            Writer = new ModelWriterService<Account>(contextFactory, modelMetadata, logger)
            {
                CreateDelegate = async (context, model) =>
                {
                    model.AccountCustodianId = model.AccountCustodianId == 0 ? 
                        null : model.AccountCustodianId;

                    var result = await context
                        .MarkForCreation(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<Account>(model, result);
                },
                DeleteDelegate = async (context, model) =>
                {
                    using var transaction = await context.Database.BeginTransactionAsync();

                    // Remove child records.
                    context
                        .MarkForDeletion<BankTransaction>(x => x.AccountId == model.AccountId)
                        .MarkForDeletion<BrokerTransaction>(x => x.AccountId == model.AccountId)
                        .MarkForDeletion<AccountWallet>(x => x.AccountId == model.AccountId)
                        .MarkForDeletion<AccountAttributeMemberEntry>(
                            x => x.AccountObjectId == model.AccountId)
                        .MarkForDeletion<AccountCompositeMember>(
                        x => x.AccountId == model.AccountId);

                    // Save changes because cascade delete is not used.
                    await context.SaveChangesAsync();

                    // Remove account.
                    // Save changes because cascade delete is not used.
                    bool deleteSuccessful = await context
                        .MarkForDeletion(model)
                        .SaveChangesAsync() > 0;

                    await transaction.CommitAsync();

                    return new DbActionResult<bool>(deleteSuccessful, deleteSuccessful);
                },
                GetDefaultDelegate = () => new Account()
                {
                    AccountNavigation = new AccountObject()
                    {
                        ObjectType = AccountObjectType.Account.ConvertToStringCode()
                    }
                },
                UpdateDelegate = async (context, model) =>
                {
                    model.AccountCustodianId = model.AccountCustodianId == 0 ?
                                            null : model.AccountCustodianId;

                    var result = await context
                        .MarkForUpdate(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<bool>(result, result);
                }
            };
        }
    }
}
