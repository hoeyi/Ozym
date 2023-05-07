using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.EntityModel.Context;
using NjordFinance.EntityModel;
using NjordFinance.EntityModelService.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.EntityModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="Security"/> 
    /// data store.
    /// </summary>
    internal class SecurityService : ModelService<Security>
    {
        /// <summary>
        /// Creates a new <see cref="SecurityService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public SecurityService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<Security>(
                contextFactory, modelMetadata, logger)
            {
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.SecuritySymbols)
                    .Include(a => a.SecurityAttributeMemberEntries)
                    .ThenInclude(b => b.AttributeMember)
                    .ThenInclude(c => c.Attribute)
            };

            Writer = new ModelWriterService<Security>(
                contextFactory, modelMetadata, logger)
            {
                DeleteDelegate = async (context, model) =>
                {
                    using var transaction = await context.Database.BeginTransactionAsync();

                    // Remove child records.
                    context.MarkForDeletion<SecurityPrice>(x => x.SecurityId == model.SecurityId);

                    // Save changes because cascade delete is not used.
                    await context.SaveChangesAsync();

                    // Remove model.
                    // Save changes because cascade delete is not used.
                    bool deleteSuccessful = await context
                        .MarkForDeletion(model)
                        .SaveChangesAsync() > 0;

                    await transaction.CommitAsync();

                    return new DbActionResult<bool>(deleteSuccessful, deleteSuccessful);
                },
                GetDefaultDelegate = () => new Security()
                {
                },
                UpdateDelegate = async (context, model) =>
                {
                    var result = await UpdateGraphAsync(context, model);

                    return new DbActionResult<bool>(result, result);
                }
            };
        }
        private static async Task<bool> UpdateGraphAsync(
            FinanceDbContext context, Security model)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            model.SecurityExchangeId = model.SecurityExchangeId == 0 ? null : model.SecurityExchangeId;

            // Capture the currently saved entity.
            var existingEntity = await context.Securities
                .Include(x => x.SecuritySymbols)
                .Include(y => y.SecurityAttributeMemberEntries)
                .FirstAsync(x => x.SecurityId == model.SecurityId);

            UpdateAttributeKeys(context, model, existingEntity);
            UpdateSymbolKeys(context, model, existingEntity);

            // Udpate the curent values for the parameter model.
            context.Entry(existingEntity).CurrentValues.SetValues(model);

            bool result = await context.SaveChangesAsync() > 0;

            await transaction.CommitAsync();

            return result;
        }

        static void UpdateAttributeKeys(
            FinanceDbContext context, Security model, Security entity)
        {
            // Mark children with altered index as deleted.
            context.SecurityAttributeMemberEntries.RemoveRange(
                entity.SecurityAttributeMemberEntries
                .Where(a => !model.SecurityAttributeMemberEntries.Any(b =>
                    b.SecurityId == a.SecurityId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)));

            // Update children where the index is unchanged.
            foreach (var childEntry in model.SecurityAttributeMemberEntries)
            {
                if (entity.SecurityAttributeMemberEntries.FirstOrDefault(t =>
                    t.SecurityId == childEntry.SecurityId &&
                    t.AttributeMemberId == childEntry.AttributeMemberId &&
                    t.EffectiveDate == childEntry.EffectiveDate) is SecurityAttributeMemberEntry match)
                {
                    context.Entry(match).CurrentValues.SetValues(childEntry);
                }
            }

            // Add children where there is no current index match.
            foreach (var childEntry in model.SecurityAttributeMemberEntries.Where(a =>
                !entity.SecurityAttributeMemberEntries.Any(b =>
                    b.SecurityId == a.SecurityId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)))
            {
                // Define the new entity, set the key attributes to avoid collision with
                // existing entities.
                var newEntity = new SecurityAttributeMemberEntry()
                {
                    SecurityId = childEntry.SecurityId,
                    AttributeMemberId = childEntry.AttributeMemberId,
                    EffectiveDate = childEntry.EffectiveDate
                };

                context.Add(newEntity);

                // Update the new child entity values.
                context.Entry(newEntity).CurrentValues.SetValues(childEntry);
            }
        }

        static void UpdateSymbolKeys(
            FinanceDbContext context, Security model, Security entity)
        {
            // Mark children with altered index as deleted.
            context.SecuritySymbols.RemoveRange(
                entity.SecuritySymbols
                .Where(a => !model.SecuritySymbols.Any(b =>
                    b.SecurityId == a.SecurityId &&
                    b.EffectiveDate == a.EffectiveDate)));

            // Update children where the index is unchanged.
            foreach (var childEntry in model.SecuritySymbols)
            {
                if (entity.SecuritySymbols.FirstOrDefault(t =>
                    t.SecurityId == childEntry.SecurityId &&
                    t.EffectiveDate == childEntry.EffectiveDate) is SecuritySymbol match)
                {
                    context.Entry(match).CurrentValues.SetValues(childEntry);
                }
            }

            // Add children where there is no current index match.
            foreach (var childEntry in model.SecuritySymbols.Where(a =>
                !entity.SecuritySymbols.Any(b =>
                    b.SecurityId == a.SecurityId &&
                    b.EffectiveDate == a.EffectiveDate)))
            {
                // Define the new entity, set the key attributes to avoid collision with
                // existing entities.
                var newEntity = new SecuritySymbol()
                {
                    SecurityId = childEntry.SecurityId,
                    EffectiveDate = childEntry.EffectiveDate
                };

                context.Add(newEntity);

                // Update the new child entity values.
                context.Entry(newEntity).CurrentValues.SetValues(childEntry);
            }
        }
    }
}
