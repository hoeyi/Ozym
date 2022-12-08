using Microsoft.EntityFrameworkCore;
using NjordFinance.Context;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NjordFinance.ModelService.Query;

namespace NjordFinance.ModelService
{

    public partial class ReferenceDataService : IReferenceDataService
    {
        private readonly IDbContextFactory<FinanceDbContext> _contextFactory;

        /// <inheritdoc/>
        public ReferenceDataService(IDbContextFactory<FinanceDbContext> contextFactory)
        {
            if (contextFactory is null)
                throw new ArgumentNullException(paramName: nameof(contextFactory));

            _contextFactory = contextFactory;   
        }

        /// <inheritdoc/>
        public IQueryBuilder<TSource> CreateQueryBuilder<TSource>()
        where TSource : class, new() => 
            new QueryBuilder<TSource>(_contextFactory.CreateDbContext());

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
    /// Extension method class for converting <see cref="IEnumerable{T}"/> to <see cref="IList{T}"/> 
    /// collections of <see cref="LookupModel"/> instances.
    /// </summary>
    public static partial class ReferenceDataServiceHelper
    {
        /// <summary>
        /// Converts this collection of <see cref="ModelAttributeMember"/> instances to a new list 
        /// of <see cref="LookupModel"/> instances.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="displaySelector">A function for defining <see cref="LookupModel.Display"/>.</param>
        /// <returns>An <see cref="IList{T}"/> containing <see cref="LookupModel"/> instances.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IList<LookupModel> ToLookups(
            this IEnumerable<ModelAttributeMember> collection,
            Func<ModelAttributeMember, string> displaySelector = null)
        {
            if (collection is null)
                throw new ArgumentNullException(paramName: nameof(collection));

            var result = collection.Select(model => new LookupModel()
            {
                Key = model.AttributeMemberId,
                Display = displaySelector is null ?
                    model.DisplayName : displaySelector(model)
            })
            .OrderBy(m => m.Display)
            .ToList();

            result.Insert(0, LookupModel.GetPlaceHolder());

            return result;
        }

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
            var firstMatchDTO = dtos?.FirstOrDefault(x => key.Equals(x));

            if (firstMatchDTO is null)
                return default;
            else
                return firstMatchDTO.Display;
        } 
    }
}
