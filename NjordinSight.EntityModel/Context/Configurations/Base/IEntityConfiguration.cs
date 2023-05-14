using Microsoft.EntityFrameworkCore;

namespace NjordinSight.EntityModel.Context.Configurations
{
    /// <summary>
    /// Allows configuration builders to cross-reference entity type key values for a particular 
    /// <see cref="Type"/>.
    /// </summary>
    internal interface IEntityConfiguration
    {
        /// <summary>
        /// Gets the reference type of the t
        /// </summary>
        Type EntityType { get; }

        /// <summary>
        /// Gets the set of reserved <see cref="DatabaseKey"/> records in this configuration.
        /// </summary>
        HashSet<DatabaseKey> ReservedKeys { get; }

        /// <summary>
        /// Gets the unique identifier for this entity configuration instance.
        /// </summary>
        Guid Guid { get; }
    }
    /// <summary>
    /// Allows configuration builders to cross-reference entity type key values used across a 
    /// collection of <see cref="IEntityTypeConfiguration{TEntity}"/> implementations.
    /// Implements: <see cref="IEntityTypeConfiguration{TEntity}"/>.
    /// </summary>
    /// <typeparam name="TEntity">The model type to which the configuration applies.</typeparam>
    internal interface IEntityConfiguration<TEntity> 
        : IEntityConfiguration, IEntityTypeConfiguration<TEntity>
        where TEntity : class
    {
    }

    
    
}
