﻿using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelService.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="Country"/> 
    /// data store.
    /// </summary>
    internal class CountryService : ModelService<Country>
    {
        /// <summary>
        /// Creates a new <see cref="CountryService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public CountryService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<Country>(
                contextFactory, modelMetadata, logger)
            {
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.CountryAttributeMemberEntries)
                    .ThenInclude(b => b.AttributeMember)
                    .ThenInclude(c => c.Attribute)
            };

            Writer = new ModelWriterService<Country>(
                contextFactory, modelMetadata, logger)
            {
                UpdateDelegate = async (context, model) =>
                {
                    var result = await UpdateGraphAsync(context, model);

                    return new DbActionResult<bool>(result, result);
                }
            };
        }

        public static async Task<bool> UpdateGraphAsync(FinanceDbContext context, Country model)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            // Capture the currently saved entity.
            var existingEntity = await context.Countries
                            .Include(a => a.CountryAttributeMemberEntries)
                            .FirstAsync(m => m.CountryId == model.CountryId);

            // Mark children with altered index as deleted.
            context.CountryAttributeMemberEntries.RemoveRange(existingEntity.CountryAttributeMemberEntries
                .Where(a => !model.CountryAttributeMemberEntries.Any(b =>
                    b.CountryId == a.CountryId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)));

            // Update children where the index is unchanged.
            foreach (var target in model.CountryAttributeMemberEntries)
            {
                if (existingEntity.CountryAttributeMemberEntries.FirstOrDefault(t =>
                    t.AttributeMemberId == target.AttributeMemberId &&
                    t.CountryId == target.CountryId &&
                    t.EffectiveDate == target.EffectiveDate) is CountryAttributeMemberEntry match)
                {
                    context.Entry(match).CurrentValues.SetValues(target);
                }
            }

            // Add children where there is no current index match.
            foreach (var target in model.CountryAttributeMemberEntries.Where(a =>
                !existingEntity.CountryAttributeMemberEntries.Any(b =>
                    b.CountryId == a.CountryId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)))
            {
                // Define the new entity.
                var newEntity = new InvestmentStrategyTarget();
                context.Add(newEntity);

                // Update the new entity values.
                context.Entry(newEntity).CurrentValues.SetValues(target);
            }

            // Udpate the curent values for the parameter model.
            context.Entry(existingEntity).CurrentValues.SetValues(model);

            bool result = await context.SaveChangesAsync() > 0;

            await transaction.CommitAsync();

            return result;
        }
    }
}
