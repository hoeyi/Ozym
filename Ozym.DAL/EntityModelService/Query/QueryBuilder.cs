using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Ozym.BusinessLogic.Functions;
using Ozym.DataTransfer;
using Ozym.EntityModel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ozym.EntityModelService.Query
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

        /// <inheritdoc/>
        public async Task<(IEnumerable<TSource>, PaginationData)> SelectAsync(
            Expression<Func<TSource, bool>> predicate, 
            int pageNumber = 1, 
            int pageSize = 20)
        {
            // TODO: Determine a better way to limit results such that performance impacts 
            //       are mitigated.
            int limitPageSize = BusinessMath.Clamp(pageSize, 0, 10000);

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

        /// <inheritdoc/>
        public async Task<(IEnumerable<KeyValuePair<TKey, TValue>>, PaginationData)> SelectDTOsAsync<TKey, TValue>(
            Expression<Func<TSource, bool>> predicate, 
            Expression<Func<TSource, TKey>> key, 
            Expression<Func<TSource, TValue>> display, 
            TKey defaultKey = default, 
            TValue defaultDisplay = default, 
            int pageNumber = 1, 
            int pageSize = 20)
        {
            var (items, pageData) = await SelectAsync(predicate, pageNumber, pageSize);

            var keyDeleg = key.Compile();
            var displayDeleg = display.Compile();

            return (items.ToDictionary(x => keyDeleg(x), x => displayDeleg(x)), pageData);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<KeyValuePair<TKey, TValue>>> SelectDTOsAsync<TKey, TValue>(
            Expression<Func<TSource, TKey>> key,
            Expression<Func<TSource, TValue>> display,
            TKey defaultKey = default,
            TValue defaultDisplay = default) 
        {
            var (items, _) = await SelectDTOsAsync(
                    predicate: x => true,
                    key: key,
                    display: display,
                    defaultKey: defaultKey,
                    defaultDisplay: defaultDisplay,
                    pageNumber: 1,
                    pageSize: int.MaxValue);

            return items;
        }
    }
    #endregion
}
