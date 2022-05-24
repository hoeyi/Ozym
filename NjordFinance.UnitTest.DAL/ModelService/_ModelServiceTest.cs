using System;
using System.Linq;
using NjordFinance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using NjordFinance.ModelService;
using Microsoft.Extensions.Logging;
using Ichosoft.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using NjordFinance.Exceptions;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace NjordFinance.Test.ModelService
{
    /// <summary>
    /// Base class for testing units of work done by <typeparamref name="T"/> model services.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract partial class ModelServiceTest<T> : IModelServiceTest<T>
        where T : class, new()
    {
        /// <inheritdoc/>
        [TestMethod]
        public abstract Task DeleteAsync_ValidModel_Returns_True();

        /// <inheritdoc/>
        [TestMethod]
        public abstract Task UpdateAsync_ValidModel_Returns_True();

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task CreateAsync_ValidModel_Returns_Single_Model()
        {
            var service = GetModelService();

            T model = await service.CreateAsync(CreateModelSuccessSample);

            using var context = CreateDbContext();

            var savedModel = GetModel(GetKey(model), IncludePaths);

            Assert.IsTrue(GetKey(model) > 0);

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(
                savedModel, model));
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task GetDefaultAsync_Returns_Single_Model()
        {
            var service = GetModelService();

            T model = await service.GetDefaultAsync();

            Assert.IsInstanceOfType(model, typeof(T));
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task DeleteAsync_InvalidModel_ThrowsModelUpdateException()
        {
            var service = GetModelService();

            await Assert.ThrowsExceptionAsync<ModelUpdateException>(async () =>
            {
                await service.DeleteAsync(DeleteModelFailSample);
            });
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual void ModelExists_KeyIsPresent_Returns_True()
        {
            T model = GetLast();

            var service = GetModelService();

            var result = service.ModelExists(id: GetKey(model));

            Assert.IsTrue(result);
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual void ModelExists_ModelIsPresent_Returns_True()
        {
            T model = GetLast();

            // Use the servied to verify model existance.
            var service = GetModelService();

            var result = service.ModelExists(model);

            Assert.IsTrue(result);
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task ReadAsync_Returns_Single_Model()
        {
            var id = GetKey(GetLast());

            var service = GetModelService();

            var account = await service.ReadAsync(id);

            Assert.IsInstanceOfType(account, typeof(T));
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task SelectAllAsync_Returns_Model_List()
        {
            var service = GetModelService();

            var result = await service.SelectAllAsync();

            Assert.IsInstanceOfType(result, typeof(List<T>));
            Assert.IsTrue(result.Count > 0);
        }

        /// <inheritdoc/>
        [TestMethod]
        public virtual async Task SelectWhereAsync_Returns_Model_Single()
        {
            T expected = GetLast(IncludePaths);

            var service = GetModelService();

            var observed = (await service.SelectWhereAysnc(
                predicate: GetKeySearchExpression(GetKey(expected)),
                maxCount: 1))
                .First();

            Assert.IsTrue(TestUtility.SimplePropertiesAreEqual(expected, observed));
        }
    }

    /// <summary>
    /// Base class for testing units of work done by <typeparamref name="T"/> model services.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    public abstract partial class ModelServiceTest<T>
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
        /// Gets the collection of navigation paths to include in the test.
        /// </summary>
        protected virtual Expression<Func<T, object>>[] IncludePaths { get; } = 
            Array.Empty<Expression<Func<T, object>>>();

        /// <summary>
        /// Gets the <see cref="ILogger"/> instance for this service.
        /// </summary>
        protected ILogger Logger => TestUtility.Logger;

        /// <summary>
        /// Executes set up action including seeding test samples to a shared context.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Executes clean-up action including clearing test cases from a shared context.
        /// </summary>
        public abstract void CleanUp();

        /// <summary>
        /// Utility method for creating new <see cref="FinanceDbContext"/> instances.
        /// </summary>
        /// <returns>A new <see cref="FinanceDbContext"/> instance.</returns>
        protected FinanceDbContext CreateDbContext() => 
            TestUtility.DbContextFactory.CreateDbContext();

        /// <summary>
        /// Gets the <see cref="int"/> key value for the given <typeparamref name="T"/>.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The <see cref="int"/> key value.</returns>
        protected abstract int GetKey(T model);

        /// <summary>
        /// Creates a new <see cref="IModelService{T}"/> instance.
        /// </summary>
        /// <returns></returns>
        protected abstract IModelService<T> GetModelService();

        /// <summary>
        /// Gets the last item in the data store collection.
        /// </summary>
        /// <returns>The <typeparamref name="T"/> instance.</returns>
        protected static T GetLast(
            params Expression<Func<T, object>>[] paths)
        {
            if (paths.Length > 3)
                throw new InvalidOperationException($"'{paths}' parameter cannot exceed 3.");

            using var context = TestUtility.DbContextFactory.CreateDbContext();

            IQueryable<T> dbSet = context.Set<T>();

            foreach (var path in paths)
            {
                dbSet = dbSet.Include(path);
            }

            return dbSet.OrderBy(a => a).Last();
        }

        /// <summary>
        /// Gets the model with the given <paramref name="id"/>, including the given 
        /// navigation paths.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        private T GetModel(int id, params Expression<Func<T, object>>[] paths)
        {
            if (paths.Length > 3)
                throw new InvalidOperationException($"'{paths}' parameter cannot exceed 3.");

            using var context = CreateDbContext();

            IQueryable<T> dbSet = context.Set<T>();

            foreach(var path in paths)
            {
                dbSet = dbSet.Include(path);
            }

            return dbSet.FirstOrDefault(GetKeySearchExpression(id));
        }

        /// <summary>
        /// Creates the <see cref="IModelService{T}"/> to be tested.
        /// </summary>
        /// <returns></returns>
        protected IModelService<T> BuildModelService<TService>()
        {
            return (IModelService<T>)Activator.CreateInstance(
                typeof(TService), TestUtility.DbContextFactory, new ModelMetadataService(), Logger);
        }

        /// <summary>
        /// Gets an <see cref="Expression"/> used to find the model with the key equal to 
        /// the <typeparamref name="TKey"/> value.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        protected static Expression<Func<T, bool>> GetKeySearchExpression<TKey>(TKey key)
        {
            // Get the first property info that matches the expected type and has 
            // the key attribute applied.

            Type modelType = typeof(T);
            Type keyType = typeof(TKey);

            var firstKey = modelType.GetProperties()
                .FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() is not null
                && p.PropertyType == keyType);

            if (firstKey is default(PropertyInfo))
                throw new NotSupportedException(message: nameof(GetKeySearchExpression));

            // Construct the base elements of the left-hand side of the expression.
            ParameterExpression parameterExpression = Expression.Parameter(modelType, "x");
            Expression expressionLeft = Expression.Property(parameterExpression, propertyName: firstKey.Name);
            Expression expressionRight = Expression.Constant(key, keyType);

            Expression expression = Expression.Equal(expressionLeft, expressionRight);

            return Expression.Lambda<Func<T, bool>>(expression, parameterExpression);
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

            var newModels = models
                .Where(a => !dbset.Any(a.matchingFunc))
                .Select(a => a.model)
                .ToArray();

            context.AddRange(newModels);

            context.SaveChanges();
        }
    }
}
