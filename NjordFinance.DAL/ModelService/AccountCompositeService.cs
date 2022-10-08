using Ichosys.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using NjordFinance.ModelService.Abstractions;


namespace NjordFinance.ModelService
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
                    using var transaction = await context.Database.BeginTransactionAsync();

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
                    var result = await context
                        .MarkForUpdate(model)
                        .SaveChangesAsync() > 0;

                    return new DbActionResult<bool>(result, result);
                }
            };
        }
    }
}
