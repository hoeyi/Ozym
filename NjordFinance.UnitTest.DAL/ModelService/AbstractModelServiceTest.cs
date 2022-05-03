using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using NjordFinance.ModelService;
using NjordFinance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace NjordFinance.UnitTest.ModelService
{
    /// <summary>
    /// Represents the base class for testing <see cref="ModelService{T}"/> derived classes.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract class AbstractModelServiceTest
    {
        /// <summary>
        /// Gets the last item in the data store collection.
        /// </summary>
        /// <returns>The <typeparamref name="T"/> instance.</returns>
        protected static T GetLast<T>(
            params Expression<Func<T, object>>[] paths)
            where T : class, new()
        {
            if(paths.Length > 3)
            {
                throw new ArgumentException(
                    $"Included navigation paths exceed.\nLimit: 3, Given: {paths.Length}");
            }

            using var context = UnitTest.DbContextFactory.CreateDbContext();

            IQueryable<T> query = context.Set<T>();

            foreach(var path in paths)
            {
                query = query.Include(path);
            }

            return query.OrderBy(a => a).Last();
        }

        /// <summary>
        /// Utility method for creating new <see cref="FinanceDbContext"/> instances.
        /// </summary>
        /// <returns>A new <see cref="FinanceDbContext"/> instance.</returns>
        protected static FinanceDbContext CreateDbContext()
        {
            return UnitTest.DbContextFactory.CreateDbContext();
        }
    }
}
