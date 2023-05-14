using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NjordinSight.EntityModel.Context.Configurations
{
    /// <summary>
    /// Base class implementing <see cref="IEntityConfiguration{TEntity}"/>. Use to build collections 
    /// of seed data that may be layered in varying ways depending on end use.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class EntityConfiguration<T> : IEntityConfiguration<T>
            where T : class
    {
        /// <summary>
        /// Initializes a new instance of <see cref="EntityConfiguration{T}"/> with the given 
        /// <paramref name="entries"/> as seed data.
        /// </summary>
        /// <param name="callerGuid">Unique identifier supplied by caller. Callers should define a 
        /// constant value to make tracing validation errors to their source easier.
        /// <param name="entries"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public EntityConfiguration(Guid callerGuid, params T[] entries)
        {
            if (!entries?.Any(x => x is not null) ?? false)
                throw new ArgumentNullException(paramName: nameof(entries));

            if (Guid.Empty == callerGuid)
                throw new ArgumentOutOfRangeException(paramName: nameof(callerGuid), callerGuid, string.Empty);

            Guid = callerGuid;
        }

        /// <summary>
        /// Gets or sets the array of <typeparamref name="T"/> entities this configuration seeds.
        /// </summary>
        protected T[] Entries { get; init; }

        /// <inheritdoc/>
        public Type EntityType { get; } = typeof(T);

        /// <inheritdoc/>
        public HashSet<DatabaseKey> ReservedKeys => Entries.Select(x => GetKeyValue(x)).ToHashSet();

        /// <inheritdoc/>
        public Guid Guid { get; private init; }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (Entries?.Any(x => x is not null) ?? false)
                builder.HasData(Entries);
        }

        /// <summary>
        /// Gets the <see cref="DatabaseKey"/> that uniquely identifies a <typeparamref name="T"/> 
        /// instance.
        /// </summary>
        /// <param name="entity">An instance of <typeparamref name="T"/>.</param>
        /// <returns>A <see cref="DatabaseKey"/> from <paramref name="entity"/>that can be used to 
        /// compare to other <typeparamref name="T"/> instances.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        private DatabaseKey GetKeyValue(T entity)
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
                    Strings.ConfigurationBase_Exception_NoKeyForType,
                    typeof(T).FullName,
                    nameof(KeyAttribute)));

            // Throw an exception if a composite key and any of the value orders are null.
            if (keyColumns.Count() > 1 && keyColumns.Any(x => x.Order is null))
                throw new InvalidOperationException(string.Format(
                    Strings.ConfigurationBase_Exception_CompositeKeyNotOrdered,
                    typeof(T).FullName));

            // Return a new instance of DatabaseKey with the 1- or n-length array.
            return new(keyColumns.OrderBy(x => x.Order).ToArray());
        }
    }
}
