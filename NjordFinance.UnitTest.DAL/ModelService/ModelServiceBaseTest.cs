using System;
using System.Linq;
using NjordFinance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using NjordFinance.ModelService;

namespace NjordFinance.UnitTest.ModelService
{
    /// <summary>
    /// Base class for testing units of work done by <typeparamref name="T"/> model services.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract class ModelServiceBaseTest<T>
        where T : class, new()
    {
        /// <summary>
        /// Gets the <typeparamref name="T"/> instance used for testing successful model creation.
        /// </summary>
        protected abstract T CreateModelSuccessSample { get; }

        /// <summary>
        /// Gets the <typeparamref name="T"/> instance used for testing successful model deletion.
        /// </summary>
        protected abstract T DeleteModelSuccessSample { get; }

        /// <summary>
        /// Gets the <typeparamref name="T"/> instance used for testing failed model deletion.
        /// </summary>
        protected abstract T DeleteModelFailSample { get; }
        
        /// <summary>
        /// Gets the <typeparamref name="T"/> instance used for testing successful model 
        /// modification.
        /// </summary>
        protected abstract T UpdateModelSuccessSample { get; }

        /// <summary>
        /// Executes set up action including seeding test samples to a shared context.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Executes clean-up action including clearing test cases from a shared context.
        /// </summary>
        public abstract void CleanUp();

        /// <summary>
        /// Gets the last item in the data store collection.
        /// </summary>
        /// <returns>The <typeparamref name="T"/> instance.</returns>
        protected static T GetLast(
            params Expression<Func<T, object>>[] paths)
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

        /// <summary>
        /// Creates the <see cref="IModelService{T}"/> to be tested.
        /// </summary>
        /// <returns></returns>
        protected abstract IModelService<T> GetModelService();
    }
}
