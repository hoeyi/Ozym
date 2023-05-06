using NjordFinance.EntityModel.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NjordFinance.EntityModelService
{
    /// <summary>
    /// Container class for <see cref="FinanceDbContext"/> extensions.
    /// </summary>
    internal static class ContextExtension
    {
        /// <summary>
        /// Marks the entries matching the given predicate for deletion,, tracking 
        /// changes for the given entity and related entities.
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="context"></param>
        /// <param name="predicate">The function to match results. Generally, 
        /// this will be an expression to match a foreign key parameter.</param>
        /// <returns>The <see cref="FinanceDbContext"/> instance, modified.</returns>
        public static FinanceDbContext MarkForDeletion<TChild>(
                    this FinanceDbContext context,
                    Expression<Func<TChild, bool>> predicate)
                    where TChild : class, new()
        {
            var dbSet = context.Set<TChild>();

            if (dbSet.Any(predicate))
                dbSet.RemoveRange(dbSet.Where(predicate));

            return context;
        }

        /// <summary>
        /// Marks a single <typeparamref name="T"/> for creation, tracking 
        /// changes for the given entity and related entities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="model">The <typeparamref name="T"/> to be deleted.</param>
        /// <returns>The <see cref="FinanceDbContext"/> instance, modified.</returns>
        public static FinanceDbContext MarkForCreation<T>(
            this FinanceDbContext context,
            T model)
            where T : class, new()
        {
            context.Set<T>().Add(model);

            return context;
        }

        /// <summary>
        /// Marks an array of <typeparamref name="T"/> models for creation, tracking 
        /// changes for the given entity and related entities.
        /// </summary>
        /// <typeparam name="T">The model type.</typeparam>
        /// <param name="context"></param>
        /// <param name="models">The <typeparamref name="T"/> model collection 
        /// to be created.</param>
        /// <returns>The <see cref="FinanceDbContext"/> instance, modified.</returns>
        public static FinanceDbContext MarkRangeForCreation<T>(
            this FinanceDbContext context,
            params T[] models)
            where T : class, new()
        {
            context.Set<T>().AddRange(models);

            return context;
        }

        /// <summary>
        /// Marks a single <typeparamref name="T"/> for deletion, tracking 
        /// changes for the given entity and related entities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="model">The <typeparamref name="T"/> to be deleted.</param>
        /// <returns>The <see cref="FinanceDbContext"/> instance, modified.</returns>
        public static FinanceDbContext MarkForDeletion<T>(
            this FinanceDbContext context, T model)
            where T : class, new()
        {
            context.Set<T>().Remove(model);

            return context;
        }

        /// <summary>
        /// Marks an array of <typeparamref name="T"/> models for deletion, tracking 
        /// changes for the given entity and related entities.
        /// </summary>
        /// <typeparam name="T">The model type.</typeparam>
        /// <param name="context"></param>
        /// <param name="models">The <typeparamref name="T"/> model collection 
        /// to be deleted.</param>
        /// <returns>The <see cref="FinanceDbContext"/> instance, modified.</returns>
        public static FinanceDbContext MarkRangeForDeletion<T>(
            this FinanceDbContext context, params T[] models)
            where T : class, new()
        {
            context.Set<T>().RemoveRange(models);

            return context;
        }

        /// <summary>
        /// Marks a single <typeparamref name="T"/> for update, tracking 
        /// changes for the given entity and related entities.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="model">The <typeparamref name="T"/> to be updated.</param>
        /// <returns>The <see cref="FinanceDbContext"/> instance, modified.</returns>
        public static FinanceDbContext MarkForUpdate<T>(
            this FinanceDbContext context,
            T model)
            where T : class, new()
        {
            context.Set<T>().Update(model);

            return context;
        }

        /// <summary>
        /// Marks an array of <typeparamref name="T"/> models for update, tracking 
        /// changes for the given entity and related entities.
        /// </summary>
        /// <typeparam name="T">The model type.</typeparam>
        /// <param name="context"></param>
        /// <param name="models">The <typeparamref name="T"/> model collection 
        /// to be updated.</param>
        /// <returns>The <see cref="FinanceDbContext"/> instance, modified.</returns>
        public static FinanceDbContext MarkRangeForUpdate<T>(
            this FinanceDbContext context,
            params T[] models)
            where T : class, new()
        {
            context.Set<T>().UpdateRange(models);

            return context;
        }
    }
}
