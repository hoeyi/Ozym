using System;
using System.Linq;
using NjordFinance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using NjordFinance.ModelService;
using Microsoft.Extensions.Logging;
using Ichosoft.DataModel;

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
        /// Gets the <see cref="ILogger"/> instance for this service.
        /// </summary>
        protected ILogger Logger => UnitTest.Logger;

        /// <summary>
        /// Gets the <see cref="IDbContextFactory{TContext}"/> instace for this service.
        /// </summary>
        protected IDbContextFactory<FinanceDbContext> DbContextFactory => UnitTest.DbContextFactory;

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
        /// Creates a new <see cref="IModelService{T}"/>. instance.
        /// </summary>
        /// <returns></returns>
        protected abstract IModelService<T> GetModelService();

        /// <summary>
        /// Creates the <see cref="IModelService{T}"/> to be tested.
        /// </summary>
        /// <returns></returns>
        protected IModelService<T> BuildModelService<TService>()
        {
            return (IModelService<T>)Activator.CreateInstance(
                typeof(TService), DbContextFactory,
                new ModelMetadataService(),
                Logger);
        }

        /// <summary>
        /// Seeds the given <typeparamref name="T"/> models if their partner pattern matches 
        /// no results.
        /// </summary>
        /// <param name="including">The navigation path to include.</param>
        /// <param name="models">Collection of model/predicate pairs to add if the predicate 
        /// does not yield a match.</param>
        protected void SeedModelsIfNotExists(
            Expression<Func<T, object>> including = null,
            params (T model, Expression<Func<T, bool>> matchingFunc)[] models)
        {
            using var context = CreateDbContext();

            IQueryable<T> dbset = context.Set<T>();

            if (including is not null)
                dbset = dbset.Include(including);

            foreach(var (model, matchingFunc) in models)
            {
                if (!dbset.Any(matchingFunc))
                {
                    context.Add(model);
                }
            }

            context.SaveChanges();
        }
    }
}
