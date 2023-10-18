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
    /// The class for servicing single CRUD requests against the <see cref="MODEL"/> 
    /// data store.
    /// </summary>
    public static class ContextExtension
    {
        /// <summary>
        /// Gets the <see cref="DatabaseKey"/> that uniquely identifies a <typeparamref name="T"/> 
        /// instance.
        /// </summary>
        /// <param name="entity">An instance of <typeparamref name="T"/>.</param>
        /// <returns>A <see cref="DatabaseKey"/> from <paramref name="entity"/>that can be used to 
        /// compare to other <typeparamref name="T"/> instances.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
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
    }
}
