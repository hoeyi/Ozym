using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NjordFinance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.ModelService.Query
{
    /// <summary>
    /// Builder class for constructing and executing complex reads of the model data store.
    /// </summary>
    /// <typeparam name="TSource">The origin model type for the query.</typeparam>
    /// <remarks>
    /// Reltionship inclusions must be expressed in terms of <typeparamref name="TSource"/>.
    /// </remarks>
    internal sealed class QueryBuilder<TSource> : IQueryBuilder<TSource>
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

        private IQueryable<TSource> Queryable { get; set; }

        public void Dispose()
        {
            _context?.Dispose();

            if (Queryable is FinanceDbContext context)
                context.Dispose();

            GC.SuppressFinalize(this);
        }

        public IQueryBuilder<TSource> WithDirectRelationship<TProperty>(
            Expression<Func<TSource, TProperty>> navigationPropertyPath) 
        {
            Queryable = Queryable.Include(navigationPropertyPath);

            return this;
        }

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

            ResetQueryable();

            return result;
        }

        private void ResetQueryable() => Queryable = _context.Set<TSource>();
    }
}
