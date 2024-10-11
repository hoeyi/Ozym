using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ozym.EntityModel.Context;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Ozym.EntityModel.Context
{
    
    /// <summary>
    /// Provides extension methods for the <see cref="FinanceDbContext"/> class.
    /// </summary>
    public static class ContextExtension
    {
        /// <summary>
        /// Gets the <see cref="DatabaseKey"/> that uniquely identifies a <typeparamref name="T"/> 
        /// instance.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="entity">An instance of <typeparamref name="T"/>.</param>
        /// <returns>A <see cref="DatabaseKey"/> from <paramref name="entity"/> that can be used to 
        /// compare to other <typeparamref name="T"/> instances.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="entity"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when no key columns are defined for the entity or 
        /// a composite key is not ordered properly.</exception>
        public static DatabaseKey GetKeyValue<T>(this T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(paramName: nameof(entity));

#pragma warning disable IDE0037 // Use inferred member name
            var keyColumns = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetCustomAttribute<KeyAttribute>() is not null)
                .Select(x => new
                {
                    // Select the property so that we can retrieve the value later.
                    Property = x,
                    // Select the order so that we consistently build the same composite key.
                    Order = x.GetCustomAttribute<ColumnAttribute>()?.Order
                });
#pragma warning restore IDE0037 // Use inferred member name

            // Throw an exception if no key columns are defined.
            if (!keyColumns?.Any() ?? false)
                throw new InvalidOperationException(string.Format(
                    Strings.EntityConfiguration_Exception_NoKeyForType,
                    typeof(T).FullName,
                    nameof(KeyAttribute)));

            // Throw an exception if a composite key and any of the value orders are null.
            if (keyColumns.Count() > 1 && keyColumns.Any(x => x.Order is null))
                throw new InvalidOperationException(string.Format(
                    Strings.EntityConfiguration_Exception_CompositeKeyNotOrdered,
                    typeof(T).FullName));

            // Return a new instance of DatabaseKey with the 1- or n-length array.
            return new(keyColumns
                .OrderBy(x => x.Order)
                .Select(x => x.Property.GetValue(entity))
                .ToArray());
        }

        /// <summary>
        /// Returns the net balance of the given bank account as of the given date.
        /// </summary>
        /// <param name="accountId">The account identifer.</param>
        /// <param name="date">The balance date.</param>
        /// <returns>A <see cref="float"/> giving the balance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static float? BankBalance(int accountId, DateTime date) =>
            throw new NotImplementedException();
    }
}
