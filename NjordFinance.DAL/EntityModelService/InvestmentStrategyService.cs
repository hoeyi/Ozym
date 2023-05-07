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
    /// The class for servicing single CRUD requests against the <see cref="InvestmentStrategy"/> 
    /// data store.
    /// </summary>
    internal class InvestmentStrategyService : ModelService<InvestmentStrategy>
    {
        /// <summary>
        /// Creates a new <see cref="InvestmentStrategyService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public InvestmentStrategyService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<InvestmentStrategy>(
                contextFactory, modelMetadata, logger)
            {
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.InvestmentStrategyTargets)
                    .ThenInclude(b => b.AttributeMember)
                    .ThenInclude(c => c.Attribute)
            };

            Writer = new ModelWriterService<InvestmentStrategy>(
                contextFactory, modelMetadata, logger)
            {
                UpdateDelegate = async (context, model) =>
                {
                    var result = await UpdateGraphAsync(context, model);

                    return new DbActionResult<bool>(result, result);
                }
            };
        }

        public static async Task<bool> UpdateGraphAsync(FinanceDbContext context, InvestmentStrategy model)
        {
            using var transaction = await context.Database.BeginTransactionAsync();

            // Capture the currently saved entity.
            var existingEntity = await context.InvestmentStrategies
                            .Include(a => a.InvestmentStrategyTargets)
                            .FirstAsync(m => m.InvestmentStrategyId == model.InvestmentStrategyId);

            // Mark children with altered index as deleted.
            context.InvestmentStrategyTargets.RemoveRange(existingEntity.InvestmentStrategyTargets
                .Where(a => !model.InvestmentStrategyTargets.Any(b =>
                    b.InvestmentStrategyId == a.InvestmentStrategyId &&
                    b.AttributeMemberId == a.AttributeMemberId &&
                    b.EffectiveDate == a.EffectiveDate)));

            // Update children where the index is unchanged.
            foreach(var target in model.InvestmentStrategyTargets)
            {
                if(existingEntity.InvestmentStrategyTargets.FirstOrDefault(t =>
                    t.AttributeMemberId == target.AttributeMemberId &&
                    t.InvestmentStrategyId == target.InvestmentStrategyId &&
                    t.EffectiveDate == target.EffectiveDate) is InvestmentStrategyTarget match)
                {
                    context.Entry(match).CurrentValues.SetValues(target);
                }
            }

            // Add children where there is no current index match.
            foreach(var target in model.InvestmentStrategyTargets.Where(a =>
                !existingEntity.InvestmentStrategyTargets.Any(b => 
                    b.InvestmentStrategyId == a.InvestmentStrategyId &&
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
