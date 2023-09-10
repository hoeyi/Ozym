using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using NjordinSight.BusinessLogic.Functions;
using NjordinSight.DataTransfer;
using NjordinSight.EntityModel.Context;
using NjordinSight.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NjordinSight.EntityModelService.Query
{
    /// <summary>
    /// Builder class for constructing and executing complex reads of the model data store.
    /// </summary>
    /// <typeparam name="TSource">The origin model type for the query.</typeparam>
    /// <remarks>
    /// Reltionship inclusions must be expressed in terms of <typeparamref name="TSource"/>.
    /// </remarks>
    internal partial class QueryBuilder<TSource> : IQueryBuilder<TSource>, IDisposable
        where TSource : class, new()
    {
        private readonly FinanceDbContext _context;

        public QueryBuilder(FinanceDbContext context)
        {
            if (context is null)
                throw new ArgumentNullException(paramName: nameof(context));

            _context = context;
            Queryable = _context.Set<TSource>();
        }

        ~QueryBuilder() => Dispose();

        // TODO: Review this. Disposal for types resolved via dependency injection 
        // is discourage. Adopt the same pattern as ModelSerivce classes?
        /// <inheritdoc/>
        public void Dispose()
        {
            _context?.Dispose();

            if (Queryable is FinanceDbContext context)
                context.Dispose();

            GC.SuppressFinalize(this);
        }


        /// <inheritdoc/>
        public IQueryBuilder<TSource> WithDirectRelationship<TProperty>(
            Expression<Func<TSource, TProperty>> navigationPropertyPath) 
        {
            Queryable = Queryable.Include(navigationPropertyPath);

            return this;
        }

        /// <inheritdoc/>
        public IQueryBuilder<TSource> WithIndirectRelationship<TPreviousProperty, TProperty>(
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
            where TPreviousProperty : class, new()
            where TProperty : class, new()
        {
            if (Queryable is IIncludableQueryable<TSource, TPreviousProperty> includableQuery)
                Queryable = includableQuery.ThenInclude(navigationPropertyPath);
            else
                throw new InvalidOperationException(Strings.QueryBuilder_Exception_InvalidJoin);

            return this;
        }

        /// <summary>
        /// Gets or sets the <see cref="IQueryable{T}"/> instance representing the constructed 
        /// query.
        /// </summary>
        private IQueryable<TSource> Queryable { get; set; }
    }

    #region IQueryDataStore<TSource> implementation
    internal partial class QueryBuilder<TSource> : IQueryDataStore<TSource>
    {
        /// <inheritdoc/>
        public IQueryDataStore<TSource> Build() => this;

        [Obsolete($"Superseded by '{nameof(SelectAsync)}'.")]
        /// <inheritdoc/>
        public async Task<IEnumerable<TSource>> SelectWhereAsync(
            Expression<Func<TSource, bool>> predicate, int maxCount = 0)
        {
            if (maxCount < 0)
                throw new InvalidOperationException(
                    message: string.Format(
                        Strings.QueryBuilder_Execute_InvalidCount, maxCount.ToString()));

            IEnumerable<TSource> result;

            if (maxCount == 0)
                result = await Queryable.Where(predicate).ToListAsync();
            else
                result = await Queryable.Where(predicate).Take(maxCount).ToListAsync();

            //QueryCompleted?.Invoke(this, EventArgs.Empty);

            return result;
        }

        // TODO: Clean this method up. Should use pagination instead of max count parameter.
        /// <inheritdoc/>
        public async Task<IEnumerable<KeyValuePair<TKey, TValue>>> SelectDTOsAsync<TKey, TValue>(
            Expression<Func<TSource, bool>> predicate, 
            int maxCount, 
            Expression<Func<TSource, TKey>> key, 
            Expression<Func<TSource, TValue>> display,
            TKey defaultKey = default,
            TValue defaultDisplay = default
            )
        {
            if (maxCount < 0)
                throw new InvalidOperationException(
                    message: string.Format(
                        Strings.QueryBuilder_Execute_InvalidCount, maxCount.ToString()));

            var keyDeleg = key.Compile();
            var displayDeleg = display.Compile();

            IQueryable<KeyValuePair<TKey, TValue>> query;
            List<KeyValuePair<TKey, TValue>> resultList;

            try
            {
                if(maxCount == 0)
                {
                    query = Queryable.Where(predicate)
                        .Select(x => new KeyValuePair<TKey, TValue>(keyDeleg(x), displayDeleg(x)));
                }
                else
                {
                    query = Queryable.Where(predicate)
                        .Select(x => new KeyValuePair<TKey, TValue>(keyDeleg(x), displayDeleg(x)))
                        .Take(maxCount);
                }

                resultList = await query.ToListAsync();

                resultList.Insert(0, new KeyValuePair<TKey, TValue>(defaultKey, defaultDisplay));
            }
            catch(Exception e)
            {
                Debug.Write(e);
                throw;
            }

            return resultList;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<KeyValuePair<TKey, TValue>>> SelectDTOsAsync<TKey, TValue>(
            Expression<Func<TSource, TKey>> key,
            Expression<Func<TSource, TValue>> display,
            TKey defaultKey = default, TValue
            defaultDisplay = default) => await SelectDTOsAsync(
                predicate: x => true,
                maxCount: 0,
                key: key,
                display: display,
                defaultKey: defaultKey,
                defaultDisplay: defaultDisplay);

        /// <inheritdoc/>
        public async Task<(IEnumerable<TSource>, PaginationData)> SelectAsync(
            Expression<Func<TSource, bool>> predicate, int pageNumber = 1, int pageSize = 20)
        {
            int limitPageSize = BusinessMath.Clamp(pageSize, 0, 1000);

            Queryable = Queryable.Where(predicate);

            PaginationData pageData = new()
            {
                ItemCount = await Queryable.CountAsync(),
                PageIndex = pageNumber,
                PageSize = pageSize
            };

            // TODO: This needs an ORDER BY clause in order to generate consistent results.
            var items = await Queryable
                .Skip(limitPageSize * (pageNumber - 1))
                .Take(limitPageSize)
                .ToListAsync();

            return (items, pageData);
        }
    }
    #endregion
}
