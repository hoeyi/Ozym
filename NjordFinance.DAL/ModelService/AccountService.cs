using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.ModelService.Abstractions;
using System.Linq;
using System.Threading.Tasks;

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
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.AccountNavigation)
                    .ThenInclude(a => a.AccountAttributeMemberEntries)
                    .ThenInclude(b => b.AttributeMember)
                    .ThenInclude(c => c.Attribute)
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

                    var result = await UpdateGraphAsync(context, model);

                    return new DbActionResult<bool>(result, result);
                }
            };
        }

        private static async Task<bool> UpdateGraphAsync(
            FinanceDbContext context, Account model)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            // Capture the currently saved entity.
            var existingEntity = await context.Accounts
                .Include(x => x.AccountNavigation)
                .ThenInclude(y => y.AccountAttributeMemberEntries)
                .FirstAsync(x => x.AccountId == model.AccountId);

            // Mark children with altered index as deleted.
            context.AccountAttributeMemberEntries.RemoveRange(
                existingEntity.AccountNavigation.AccountAttributeMemberEntries
                .Where(a => !model.AccountNavigation.AccountAttributeMemberEntries.Any(b =>
                    b.AccountObjectId == a.AccountObjectId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)));

            // Update children where the index is unchanged.
            foreach (var childEntry in model.AccountNavigation.AccountAttributeMemberEntries)
            {
                if (existingEntity.AccountNavigation.AccountAttributeMemberEntries.FirstOrDefault(t =>
                    t.AccountObjectId == childEntry.AccountObjectId &&
                    t.AttributeMemberId == childEntry.AttributeMemberId &&
                    t.EffectiveDate == childEntry.EffectiveDate) is AccountAttributeMemberEntry match)
                {
                    context.Entry(match).CurrentValues.SetValues(childEntry);
                }
            }

            // Add children where there is no current index match.
            foreach (var childEntry in model.AccountNavigation.AccountAttributeMemberEntries.Where(a =>
                !existingEntity.AccountNavigation.AccountAttributeMemberEntries.Any(b =>
                    b.AccountObjectId == a.AccountObjectId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)))
            {
                // Define the new entity, set the key attributes to avoid collision with
                // existing entities.
                var newEntity = new AccountAttributeMemberEntry()
                {
                    AccountObjectId = childEntry.AccountObjectId,
                    AttributeMemberId = childEntry.AttributeMemberId,
                    EffectiveDate = childEntry.EffectiveDate
                };

                context.Add(newEntity);

                // Update the new child entity values.
                context.Entry(newEntity).CurrentValues.SetValues(childEntry);
            }

            // Udpate the curent values for the parameter model.
            context.Entry(existingEntity).CurrentValues.SetValues(model);
            context.Entry(existingEntity.AccountNavigation).CurrentValues.SetValues(model.AccountNavigation);

            bool result = await context.SaveChangesAsync() > 0;

            await transaction.CommitAsync();

            return result;
        }
    }
}
