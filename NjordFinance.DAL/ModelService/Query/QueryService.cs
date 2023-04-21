using Microsoft.EntityFrameworkCore;
using NjordFinance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordFinance.ModelService.Query
{
    /// <summary>
    /// Represents an implementation of <see cref="IQueryService"/>, providing features 
    /// for querying varying data stores and conversion to DTOs.
    /// </summary>
    public partial class QueryService : IQueryService
    {
        private readonly IDbContextFactory<FinanceDbContext> _contextFactory;
        static readonly object _locker = new();

        /// <summary>
        /// Initializes a new instance of <see cref="FinanceDbContext"/> from the factory instance
        /// assigned to <see cref="_contextFactory"/>.
        /// </summary>
        /// <returns></returns>
        private FinanceDbContext NewDbContext()
        {
            lock (_locker)
            {
                return _contextFactory.CreateDbContext();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryService"/> class.
        /// </summary>
        /// <param name="contextFactory">An <see cref="IDbContextFactory{TContext}"/> to use for 
        /// generating data contexts.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contextFactory"/> was null.</exception>
        public QueryService(IDbContextFactory<FinanceDbContext> contextFactory)
        {
            if (contextFactory is null)
                throw new ArgumentNullException(paramName: nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        /// <inheritdoc/> 
        public IQueryBuilder<TSource> CreateQueryBuilder<TSource>()
        where TSource : class, new() =>
            new QueryBuilder<TSource>(context: NewDbContext());

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetManyAsync<T>(
            Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null)
            where T : class, new()
        {
            using var context = _contextFactory.CreateDbContext();

            if (include is null)
                return await context.Set<T>().Where(predicate).ToListAsync();
            else
                return await context.Set<T>().Where(predicate).Include(include).ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<T> GetSingleAsync<T>(
            Expression<Func<T, bool>> predicate, Expression<Func<T, object>> include = null)
            where T : class, new()
        {
            using var context = _contextFactory.CreateDbContext();

            if (include is null)
                return await context.Set<T>()
                                .SingleAsync();
            else
                return await context.Set<T>()
                                .Include(include)
                                .SingleAsync(predicate);
        }
    }

    /// <summary>
    /// Extension method class for collections of <see cref="LookupModel{TKey, TDisplay}"/>.
    /// </summary>
    public static partial class ReferenceDataServiceHelper
    {
        /// <summary>
        /// Gets the display <typeparamref name="TValue"/> value for the first DTO in the 
        /// collection matching the given <typeparamref name="TKey"/> key.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dtos"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue? GetDisplayName<TKey, TValue>(
            this IEnumerable<LookupModel<TKey, TValue>> dtos,
            TKey key)
        {
            if (dtos is null || key is null)
                return default;

            // Match the first or default result. Use of object.Equals could be problematic, 
            // but need more information. May be fine since TKey will almost always be an integer.
            var firstMatchDTO = dtos?.FirstOrDefault(x => x.Key.Equals(key));

            if (firstMatchDTO is null)
                return default;
            else
                return firstMatchDTO.Display;
        }
    }
}
