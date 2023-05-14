using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace NjordinSight.EntityModel.Context.Configurations
{
    /// <summary>
    /// Implements <see cref="IConfigurationCollection"/>. Typically used for defining built-in 
    /// data that is common to a specific deployment scenario.
    /// </summary>
    class ConfigurationCollection : IConfigurationCollection
    {
        record ReservedKeyEntry
        {
            public Type EntityType { get; init; }

            public Guid SourceGuid { get; init; }

            public DatabaseKey DbKey { get; init; }
        }

        private readonly List<Action<ModelBuilder>> _configurationActions;
        private readonly List<ReservedKeyEntry> _reservedKeys;

        /// <summary>
        /// Initializes a new instance of <see cref="ConfigurationCollection"/>.
        /// </summary>
        public ConfigurationCollection()
        {
            _configurationActions = new();
            _reservedKeys = new();
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

            var entityType = typeof(T);
            var sourceGuid = configuration.Guid;

            _reservedKeys.AddRange(
                configuration.ReservedKeys.Select(x => new ReservedKeyEntry()
                {
                    EntityType = entityType,
                    SourceGuid = configuration.Guid,
                    DbKey = x
                }));

            _configurationActions.Add(
                (modelBuilder) => modelBuilder.ApplyConfiguration(configuration));
        }

        /// <inheritdoc/>
        public bool IsValid(out IEnumerable<string> validationMessages)
        {
            var results = Validate().Select(x => x.ErrorMessage).ToList();

            if(results.Any())
            {
                results.Insert(0, Strings.ConfigurationCollection_Validation_KeyDuplication);
            }

            validationMessages = results;
            return !results.Any();
        }

        /// <summary>
        /// Determines whether the registered configurations are valid when all are processed.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="ValidationResult"/> 
        /// representing each validation failure.</returns>
        private IEnumerable<ValidationResult> Validate()
        {
            var groupedByTypeAndKey = _reservedKeys
                .GroupBy(x => 
                    new 
                    { 
                        x.EntityType, 
                        KeyValue = x.DbKey.ToString() 
                    }
                );

            var duplicatedKeys = groupedByTypeAndKey
                .Where(g => g.Count() > 1);

            var validationMessages = duplicatedKeys
                .Select(x => 
                    $"Type = {x.Key.EntityType.FullName}; " +
                    $"Key = {x.Key.KeyValue};\nSources:\n{string.Join("\n", x.Select(y => y.SourceGuid))}");

            if (validationMessages?.Any() ?? false)
                foreach (var msg in validationMessages)
                    yield return new ValidationResult(msg);
        }
    }
}
