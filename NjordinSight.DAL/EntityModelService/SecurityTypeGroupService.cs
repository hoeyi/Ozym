using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordinSight.EntityModel.Context;
using NjordinSight.EntityModel;
using NjordinSight.EntityModel.ConstraintType;
using NjordinSight.EntityModelService.Abstractions;

namespace NjordinSight.EntityModelService
{
    /// <summary>
    /// The class for servicing single CRUD requests against the <see cref="SecurityTypeGroup"/> 
    /// data store.
    /// </summary>
    internal class SecurityTypeGroupService : ModelService<SecurityTypeGroup>
    {
        /// <summary>
        /// Creates a new <see cref="SecurityTypeGroupService"/> instance.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{FinanceDbContext}" /> 
        /// instance.</param>
        /// <param name="modelMetadata">An <see cref="IModelMetadataService"/> instance.</param>
        /// <param name="logger">An <see cref="ILogger"/> instance.</param>
        public SecurityTypeGroupService(
                IDbContextFactory<FinanceDbContext> contextFactory,
                IModelMetadataService modelMetadata,
                ILogger logger)
            : base(contextFactory, modelMetadata, logger)
        {
            Reader = new ModelReaderService<SecurityTypeGroup>(
                contextFactory, modelMetadata, logger)
            {
                IncludeDelegate = (queryable) => queryable.Include(a => a.AttributeMemberNavigation)
            };

            Writer = new ModelWriterService<SecurityTypeGroup>(
                contextFactory, modelMetadata, logger)
            {
                CreateDelegate = async (context, model) =>
                {
                    var result = await context
                        .MarkForCreation(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<SecurityTypeGroup>(model, result);
                },
                DeleteDelegate = async(context, model) =>
                {
                    using var transaction = await context.Database.BeginTransactionIfSupportedAsync();

                    context.MarkForDeletion(model);

                    // Save changes because cascade delete is not used.
                    await context.SaveChangesAsync();

                    context.MarkForDeletion<ModelAttributeMember>(
                            x => x.AttributeMemberId == model.SecurityTypeGroupId);

                    bool deleteSuccessful = await context.SaveChangesAsync() > 0;

                    if (transaction is not null)
                        await transaction.CommitAsync();

                    return new DbActionResult<bool>(deleteSuccessful, deleteSuccessful);
                },
                GetDefaultDelegate = () => new SecurityTypeGroup()
                {
                    AttributeMemberNavigation = new()
                    {
                        AttributeId = (int)ModelAttributeEnum.SecurityTypeGroup
                    }
                },
                UpdateDelegate = async (context, model) =>
                {
                    var result = await context
                        .MarkForUpdate(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<bool>(result, result);
                }
            };
        }
    }
}
