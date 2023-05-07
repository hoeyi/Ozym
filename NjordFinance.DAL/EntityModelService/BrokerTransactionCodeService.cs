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
    /// The class for servicing single CRUD requests against the 
    /// <see cref="BrokerTransactionCode"/> data store.
    /// </summary>
    internal class BrokerTransactionCodeService : ModelService<BrokerTransactionCode>
    {
        /// <summary>
        /// Creates a new <see cref="BankTransactionCodeService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public BrokerTransactionCodeService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<BrokerTransactionCode>(
                contextFactory, modelMetadata, logger)
            {
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.BrokerTransactionCodeAttributeMemberEntries)
                    .ThenInclude(b => b.AttributeMember)
                    .ThenInclude(c => c.Attribute)
            };
            Writer = new ModelWriterService<BrokerTransactionCode>(
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
            FinanceDbContext context, BrokerTransactionCode model)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            // Capture the currently saved entity.
            var existingEntity = await context.BrokerTransactionCodes
                .Include(x => x.BrokerTransactionCodeAttributeMemberEntries)
                .FirstAsync(x => x.TransactionCodeId == model.TransactionCodeId);

            // Mark children with altered index as deleted.
            context.BrokerTransactionCodeAttributeMemberEntries.RemoveRange(
                existingEntity.BrokerTransactionCodeAttributeMemberEntries
                .Where(a => !model.BrokerTransactionCodeAttributeMemberEntries.Any(b =>
                    b.TransactionCodeId == a.TransactionCodeId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)));

            // Update children where the index is unchanged.
            foreach (var childEntry in model.BrokerTransactionCodeAttributeMemberEntries)
            {
                if (existingEntity.BrokerTransactionCodeAttributeMemberEntries.FirstOrDefault(t =>
                    t.TransactionCodeId == childEntry.TransactionCodeId &&
                    t.AttributeMemberId == childEntry.AttributeMemberId &&
                    t.EffectiveDate == childEntry.EffectiveDate) is BrokerTransactionCodeAttributeMemberEntry match)
                {
                    context.Entry(match).CurrentValues.SetValues(childEntry);
                }
            }

            // Add children where there is no current index match.
            foreach (var childEntry in model.BrokerTransactionCodeAttributeMemberEntries.Where(a =>
                !existingEntity.BrokerTransactionCodeAttributeMemberEntries.Any(b =>
                    b.TransactionCodeId == a.TransactionCodeId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)))
            {
                // Define the new entity.
                var newEntity = new BrokerTransactionCodeAttributeMemberEntry()
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
