using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Ozym.EntityModel.Context.Configurations
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
        /// <param name="sourceGuid">Unique identifier supplied by caller. Callers should define a 
        /// constant value to make tracing validation errors to their source easier.
        /// <param name="entries"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public EntityConfiguration(Guid sourceGuid, params T[] entries)
        {
            if (entries?.Any(x => x is null) ?? true)
                throw new ArgumentNullException(
                    paramName: nameof(entries),
                    message: string.Format(
                        Strings.EntityConfiguration_Exception_NullEntryNotPermitted,
                        nameof(entries)));

            if (Guid.Empty == sourceGuid)
                throw new ArgumentOutOfRangeException(paramName: nameof(sourceGuid), sourceGuid, string.Empty);


            Guid = sourceGuid;
            Entries = new T[entries.Length];
            Array.Copy(entries, Entries, entries.Length);
        }

        /// <summary>
        /// Gets or sets the array of <typeparamref name="T"/> entities this configuration seeds.
        /// </summary>
        protected T[] Entries { get; init; }

        /// <inheritdoc/>
        public Type EntityType { get; } = typeof(T);

        /// <inheritdoc/>
        public HashSet<DatabaseKey> ReservedKeys => Entries.Select(x => x.GetKeyValue()).ToHashSet();

        /// <inheritdoc/>
        public Guid Guid { get; private init; }

        /// <inheritdoc/>
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (Entries?.Any(x => x is not null) ?? false)
                builder.HasData(Entries);
        }
    }
}
