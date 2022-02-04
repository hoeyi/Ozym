using EulerFinancial.Context;
using EulerFinancial.Model;
using Ichosoft.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EulerFinancial.ModelService
{
    /// <summary>
    /// The class for servicing batch CRUD requests agains the <see cref="AccountWallet"/> 
    /// data store.
    /// </summary>
    public class AccountWalletService :
        BatchModelServiceBase<AccountWallet, int>,
        IBatchModelService<AccountWallet>
    {
        /// <summary>
        /// The <see cref="Account"/> key representing the parent of objects worked using 
        /// this service.
        /// </summary>
        private readonly int accountId;

        /// <inheritdoc/>
        public AccountWalletService(
            EulerFinancialContext context,
            IModelMetadataService modelMetadata,
            ILogger logger,
            int parentKey) : base(context, modelMetadata, logger, parentKey)
        {
        }

        /// <inheritdoc/>
        public override async Task<int> SaveChanges()
        {
            // TODO: Determine if this have value.
            // Why return the record count of added/updated/deleted records?

            //EntityState[] dirtyStates = new[]
            //{
            //    EntityState.Added,
            //    EntityState.Modified,
            //    EntityState.Deleted
            //};

            //int modifiedCount = context
            //    .AccountWallets
            //    .Where(e => dirtyStates.Contains(context.Entry(e).State))
            //    .Count();

            return await context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public override bool Add(AccountWallet model)
        {
            model.AccountId = accountId;
            context.AccountWallets.Add(model);

            return context.Entry(model).State == EntityState.Added;
        }

        /// <inheritdoc/>
        public override bool Delete(AccountWallet model)
        {
            context.AccountWallets.Remove(model);

            return context.Entry(model).State == EntityState.Deleted;
        }

        /// <inheritdoc/>
        public override async Task<List<AccountWallet>> SelectWhereAysnc(Expression<Func<AccountWallet, bool>> predicate, int maxCount = 0)
        {

            return await context.AccountWallets
                            .Include(a => a.Account)
                            .Include(a => a.DenominationSecurity)
                            .Where(a => a.AccountId == ParentKey)
                            .Where(predicate)
                            .ToListAsync();
        }
    }
}
