using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace NjordinSight.EntityModel.Context.Configurations
{
    /// <summary>
    /// Implements <see cref="IConfigurationCollection"/>. Typically used for defining built-in 
    /// data that is common to a specific deployment scenario.
    /// </summary>
    class ConfigurationCollection : IConfigurationCollection
    {
        private readonly List<Action<ModelBuilder>> _configurationActions;

        /// <summary>
        /// Initializes a new instance of <see cref="ConfigurationCollection"/>.
        /// </summary>
        public ConfigurationCollection()
        {
            _configurationActions = new();
        }

        /// <inheritdoc/>
        public IEnumerator<Action<ModelBuilder>> GetEnumerator() => _configurationActions.GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc/>
        public void AddConfiguration<T>(IEntityConfiguration<T> configuration)
            where T : class
        {
            if (configuration is null)
                throw new ArgumentNullException(paramName: nameof(configuration));

            _configurationActions.Add(
                (modelBuilder) => modelBuilder.ApplyConfiguration(configuration));
        }
    }
}
