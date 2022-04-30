using NjordFinance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.Reference
{
    /// <summary>
    /// Worker class for reading models from a data store.
    /// </summary>
    /// <remarks>Implements <see cref="IReferenceDataService"/>.</remarks>
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly EulerDbContext context;
        public ReferenceDataService(EulerDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<T> GetSingleAsync<T>(
            Expression<Func<T, bool>> predicate, string includeNavigationPath = null)
            where T: class, new()
        {
            if (string.IsNullOrEmpty(includeNavigationPath))
                return await context.Set<T>()
                                .SingleAsync();
            else
                return await context.Set<T>()
                                .Include(includeNavigationPath)
                                .SingleAsync(predicate);
        }

        /// <inheritdoc/>
        public async Task<IList<T>> GetAllAsync<T>() where T : class, new()
        {
            return await context.Set<T>().ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IList<T>> GetWhereAsync<T>(Expression<Func<T, bool>> predicate) 
            where T : class, new()
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }
    }
}
