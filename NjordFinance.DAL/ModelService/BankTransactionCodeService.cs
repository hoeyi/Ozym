using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="BankTransactionCode"/> 
    /// data store.
    /// </summary>
    internal class BankTransactionCodeService : ModelService<BankTransactionCode>
    {
        /// <summary>
        /// Creates a new <see cref="BankTransactionCodeService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public BankTransactionCodeService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<BankTransactionCode>(
                contextFactory, modelMetadata, logger)
            {
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.BankTransactionCodeAttributeMemberEntries)
                    .ThenInclude(b => b.AttributeMember)
                    .ThenInclude(c => c.Attribute)
            };
            Writer = new ModelWriterService<BankTransactionCode>(
                contextFactory, modelMetadata, logger)
            {
                UpdateDelegate = async (context, model) =>
                {
                    var result = await UpdateGraphAsync(context, model);

                    return new DbActionResult<bool>(result, result);
                }
            };
        }

        public static async Task<bool> UpdateGraphAsync(
            FinanceDbContext context, BankTransactionCode model)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            // Capture the currently saved entity.
            var existingEntity = await context.BankTransactionCodes
                .Include(x => x.BankTransactionCodeAttributeMemberEntries)
                .FirstAsync(x => x.TransactionCodeId == model.TransactionCodeId);

            // Mark children with altered index as deleted.
            context.BankTransactionCodeAttributeMemberEntries.RemoveRange(
                existingEntity.BankTransactionCodeAttributeMemberEntries
                .Where(a => !model.BankTransactionCodeAttributeMemberEntries.Any(b =>
                    b.TransactionCodeId == a.TransactionCodeId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)));

            // Update children where the index is unchanged.
            foreach (var childEntry in model.BankTransactionCodeAttributeMemberEntries)
            {
                if (existingEntity.BankTransactionCodeAttributeMemberEntries.FirstOrDefault(t =>
                    t.TransactionCodeId == childEntry.TransactionCodeId &&
                    t.AttributeMemberId == childEntry.AttributeMemberId &&
                    t.EffectiveDate == childEntry.EffectiveDate) is BankTransactionCodeAttributeMemberEntry match)
                {
                    context.Entry(match).CurrentValues.SetValues(childEntry);
                }
            }

            // Add children where there is no current index match.
            foreach (var childEntry in model.BankTransactionCodeAttributeMemberEntries.Where(a =>
                !existingEntity.BankTransactionCodeAttributeMemberEntries.Any(b =>
                    b.TransactionCodeId == a.TransactionCodeId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)))
            {
                // Define the new entity, set the key attributes to avoid collision with
                // existing entities.
                var newEntity = new BankTransactionCodeAttributeMemberEntry()
                {
                    TransactionCodeId = childEntry.TransactionCodeId,
                    AttributeMemberId = childEntry.AttributeMemberId,
                    EffectiveDate = childEntry.EffectiveDate
                };

                context.Add(newEntity);

                // Update the new child entity values.
                context.Entry(newEntity).CurrentValues.SetValues(childEntry);
            }

            // Udpate the curent values for the parameter model.
            context.Entry(existingEntity).CurrentValues.SetValues(model);

            bool result = await context.SaveChangesAsync() > 0;

            await transaction.CommitAsync();

            return result;
        }
    }
}
