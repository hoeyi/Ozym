using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NjordinSight.EntityModel.Context;
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
    internal sealed partial class QueryBuilder<TSource> : IQueryBuilder<TSource>
        where TSource : class, new()
    {
        private readonly FinanceDbContext _context;
        
        public QueryBuilder(FinanceDbContext context)
        {
            if (context is null)
                throw new ArgumentNullException(paramName: nameof(context));

            _context = context;
            Queryable = _context.Set<TSource>();

            QueryCompleted += QueryBuilder_QueryCompleted;
        }

        ~QueryBuilder() => Dispose();

        /// <inheritdoc/>
        public void Dispose()
        {
            _context?.Dispose();

            if (Queryable is FinanceDbContext context)
                context.Dispose();

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets or sets the <see cref="IQueryable{T}"/> instance sensitive to requests to 
        /// include direct and indirect relationships.
        /// </summary>
        private IQueryable<TSource> Queryable { get; set; }

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

        private event EventHandler QueryCompleted;

        private void QueryBuilder_QueryCompleted(object sender, EventArgs e) => _ = e;
    }

    internal sealed partial class QueryBuilder<TSource> : IQueryDataStore<TSource>
    {
        /// <inheritdoc/>
        public IQueryDataStore<TSource> Build() => this;

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

        /// <inheritdoc/>
        public async Task<IEnumerable<LookupModel<TKey, TValue>>> SelectDTOsAsync<TKey, TValue>(
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

            IQueryable<LookupModel<TKey, TValue>> query;
            List<LookupModel<TKey, TValue>> resultList;

            try
            {
                if(maxCount == 0)
                {
                    query = Queryable.Where(predicate)
                        .Select(x => new LookupModel<TKey, TValue>()
                        {
                            Key = keyDeleg(x),
                            Display = displayDeleg(x)
                        });
                }
                else
                {
                    query = Queryable.Where(predicate)
                        .Select(x => new LookupModel<TKey, TValue>()
                        {
                            Key = keyDeleg(x),
                            Display = displayDeleg(x)
                        })
                        .Take(maxCount);
                }

                resultList = await query.ToListAsync();

                resultList.Insert(0, LookupModel<TKey, TValue>.GetPlaceHolder(
                    key: defaultKey,
                    display: defaultDisplay));
            }
            catch(Exception e)
            {
                Debug.Write(e);
                throw;
            }
            finally
            {
                QueryCompleted?.Invoke(this, EventArgs.Empty);
            }

            return resultList;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LookupModel<TKey, TValue>>> SelectDTOsAsync<TKey, TValue>(
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
    }
}
