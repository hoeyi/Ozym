namespace Ozym.EntityModel.Context
{
    /// <summary>
    /// Represents a database key that may be a single column or a composite key.
    /// </summary>
    /// <remarks>This record is designed for use in validating an EF Core model configuration process.
    /// For example, given collections of <see cref="Type"/> and used <see cref="DatabaseKey"/> records, 
    /// consumers may check layered configuration steps for conflicts and report repeated keys before 
    /// trying to deploy the model.
    /// </remarks>
    public sealed record DatabaseKey : IEquatable<DatabaseKey>
    {
        /// <summary>
        /// An object array storing the values representing a single-column or composite key.
        /// </summary>
        private readonly object[] _keyComponents;

        public DatabaseKey(params object[] keyComponents)
        {
            // Check key components is a non-null and non-empty arrary.
            if (!keyComponents?.Any() ?? false)
                throw new ArgumentNullException(paramName: nameof(keyComponents));

            _keyComponents = new object[keyComponents.Length];
            Array.Copy(
                sourceArray: keyComponents, 
                destinationArray: _keyComponents, 
                length: keyComponents.Length);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _keyComponents.Length == 1 ?
                _keyComponents[0].ToString() :
                $"({string.Join(", ", _keyComponents)})";
        }

        /// <inheritdoc/>
        public bool Equals(DatabaseKey other)
        {
            if (other is null)
                return false;

            return _keyComponents.SequenceEqual(other._keyComponents);
        }

        /// <summary>
        /// Overrides the base behavior of <see cref="object.GetHashCode"/> by using 
        /// <see cref="HashCode.Combine"/> iteration over each key component.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                // Initialize with the first value.
                int hash = _keyComponents[0].GetHashCode();

                if (_keyComponents.Length == 1) return hash;

                // Iterate over the remaining elements using current hash as input to the next.
                for (int i = 1; i < _keyComponents.Length; i++)
                {
                    hash = HashCode.Combine(hash, _keyComponents[i].GetHashCode());
                }

                return hash;
            }
        }
    }
}
