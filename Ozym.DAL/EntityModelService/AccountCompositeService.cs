using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ozym.EntityModel.Context;
using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Ozym.EntityModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="AccountComposite"/> 
    /// data store.
    /// </summary>
    internal class AccountCompositeService : ModelService<AccountComposite>
    {
        /// <summary>
        /// Creates a new <see cref="AccountCompositeService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public AccountCompositeService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<AccountComposite>(
                contextFactory, modelMetadata, logger)
            {
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.AccountCompositeNavigation)
                    .ThenInclude(b => b.AccountAttributeMemberEntries)
                    .ThenInclude(c => c.AttributeMember)
                    .ThenInclude(d => d.Attribute)
                    .Include(a => a.AccountCompositeMembers)
            };
            Writer = new ModelWriterService<AccountComposite>(
                contextFactory, modelMetadata, logger)
            {
                CreateDelegate = async (context, model) =>
                {
                    var result = await context
                        .MarkForCreation(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<AccountComposite>(model, result);
                },
                DeleteDelegate = async (context, model) =>
                {
                    using var transaction = await context.Database.BeginTransactionIfSupportedAsync();

                    // Delete child records.
                    await context
                        .MarkForDeletion<AccountCompositeMember>(
                            x => x.AccountCompositeId == model.AccountCompositeId)
                        .MarkForDeletion<AccountAttributeMemberEntry>(
                            x => x.AccountObjectId == model.AccountCompositeId)
                        .SaveChangesAsync();

                    // Delete composite model.
                    bool deleteSuccessful = await context.MarkForDeletion(model)
                        .SaveChangesAsync() > 0;

                    if (transaction is not null)
                        await transaction.CommitAsync();

                    return new DbActionResult<bool>(deleteSuccessful, deleteSuccessful);
                },
                GetDefaultDelegate = () => new AccountComposite()
                {
                    AccountCompositeNavigation = new AccountObject()
                    {
                        ObjectType = AccountObjectType.Composite.ConvertToStringCode()
                    }
                },
                UpdateDelegate = async (context, model) =>
                {
                    var result = await UpdateGraphAsync(context, model);

                    return new DbActionResult<bool>(result, result);
                }
            };

        }

        private static async Task<bool> UpdateGraphAsync(
        FinanceDbContext context, AccountComposite model)
        {
            using var transaction = await context.Database.BeginTransactionIfSupportedAsync();

            // Capture the currently saved entity.
            var existingEntity = await context.AccountComposites
                .Include(x => x.AccountCompositeNavigation)
                .ThenInclude(y => y.AccountAttributeMemberEntries)
                .FirstAsync(x => x.AccountCompositeId == model.AccountCompositeId);

            // Mark children with altered index as deleted.
            context.AccountAttributeMemberEntries.RemoveRange(
                existingEntity.AccountCompositeNavigation.AccountAttributeMemberEntries
                .Where(a => !model.AccountCompositeNavigation.AccountAttributeMemberEntries.Any(b =>
                    b.AccountObjectId == a.AccountObjectId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)));

            // Update children where the index is unchanged.
            foreach (var childEntry in model.AccountCompositeNavigation.AccountAttributeMemberEntries)
            {
                if (existingEntity.AccountCompositeNavigation.AccountAttributeMemberEntries.FirstOrDefault(t =>
                    t.AccountObjectId == childEntry.AccountObjectId &&
                    t.AttributeMemberId == childEntry.AttributeMemberId &&
                    t.EffectiveDate == childEntry.EffectiveDate) is AccountAttributeMemberEntry match)
                {
                    context.Entry(match).CurrentValues.SetValues(childEntry);
                }
            }

            // Add children where there is no current index match.
            foreach (var childEntry in model.AccountCompositeNavigation.AccountAttributeMemberEntries
                .Where(a => !existingEntity.AccountCompositeNavigation.AccountAttributeMemberEntries
                    .Any(b =>
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
            context.Entry(existingEntity.AccountCompositeNavigation)
                .CurrentValues
                .SetValues(model.AccountCompositeNavigation);

            bool result = await context.SaveChangesAsync() > 0;

            if (transaction is not null)
                await transaction.CommitAsync();

            return result;
        }
    }
}
