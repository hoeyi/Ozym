using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ozym.EntityModel.Context;
using Ozym.EntityModel;
using Ozym.EntityModelService.Abstractions;
using System.Threading.Tasks;
using System.Linq;

namespace Ozym.EntityModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="ModelAttribute"/> 
    /// data store.
    /// </summary>
    internal class ModelAttributeService : ModelService<ModelAttribute>
    {
        /// <summary>
        /// Creates a new <see cref="ModelAttributeService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public ModelAttributeService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<ModelAttribute>(
                ContextFactory, modelMetadata, logger)
            {
                IncludeDelegate = (queryable) => queryable
                    .Include(a => a.ModelAttributeScopes)
                    .Include(a => a.ModelAttributeMembers)
            };
            Writer = new ModelWriterService<ModelAttribute>(
                ContextFactory, modelMetadata, logger)
            {
                GetDefaultDelegate = () => new ModelAttribute(),
                UpdateDelegate = async (context, model) =>
                {
                    var result = await UpdateGraphAsync(context, model);

                    return new DbActionResult<bool>(result, result);
                }
            };
        }

        public static async Task<bool> UpdateGraphAsync(FinanceDbContext context, ModelAttribute model)
        {
            using var transaction = await context.Database.BeginTransactionIfSupportedAsync();

            var entity = await context.ModelAttributes
                                .Include(x => x.ModelAttributeMembers)
                                .Include(x => x.ModelAttributeScopes)
                                .FirstAsync(x => x.AttributeId == model.AttributeId);

            
            // Set attributes except for navigation properties.
            context.Entry(entity).CurrentValues.SetValues(model);

            // Determine which items in the scope collection are removed.
            context.ModelAttributeScopes.RemoveRange(
                entity.ModelAttributeScopes.Where(a => !model.ModelAttributeScopes.Any(
                    b => b.ScopeCode == a.ScopeCode)));

            // Determine which items in the scope collection are added.
            context.ModelAttributeScopes.AddRange(
                model.ModelAttributeScopes.Where(a => !entity.ModelAttributeScopes.Any(
                    b => b.ScopeCode == a.ScopeCode)));

            // Determine which items in the value collection are removed.
            context.ModelAttributeMembers.RemoveRange(
                entity.ModelAttributeMembers.Where(a => !model.ModelAttributeMembers.Any(
                    b => b.AttributeMemberId == a.AttributeMemberId)));

            // Determine which items in the value collection added.
            context.ModelAttributeMembers.AddRange(
                model.ModelAttributeMembers.Where(a => !entity.ModelAttributeMembers.Any(
                    b => b.AttributeMemberId == a.AttributeMemberId)));

            // Set values for modified attribute member entries. Scopes is ignore because
            // there no other values captured but the key values identifying the record.
            var attributeValueUpdates = 
                from a in entity.ModelAttributeMembers
                join b in model.ModelAttributeMembers on
                    new { a.AttributeId, a.AttributeMemberId } equals
                    new { b.AttributeId, b.AttributeMemberId }
                where a.DisplayName != b.DisplayName ||
                a.DisplayOrder != b.DisplayOrder
                select new
                {
                    Old = a,
                    New = b
                };

            foreach(var upd in attributeValueUpdates)
            {
                context.Entry(upd.Old).CurrentValues.SetValues(upd.New);
            }

            bool result = await context.SaveChangesAsync() > 0;

            if (transaction is not null)
                await transaction.CommitAsync();

            return result;
        }
    }
}

