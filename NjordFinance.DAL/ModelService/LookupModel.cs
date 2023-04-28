namespace NjordFinance.ModelService
{
    /// <summary>
    /// Represents a simplified database record that is referenced in a foreign key relationship.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TDisplay">The diplay type.</typeparam>
    public record LookupModel<TKey, TDisplay>
    {
        /// <summary>
        /// Gets the key of this record.
        /// </summary>
        public TKey Key { get; init; }

        /// <summary>
        /// Gets the display value of this record.
        /// </summary>
        public TDisplay Display { get; init; }

        /// <summary>
        /// Gets a lookup record instance representing a placeholder for an undefined field.
        /// </summary>
        /// <param name="key">Specifies the default <typeparamref name="TKey"/> to use as the key.</param>
        /// <param name="display">Specifies the default <typeparamref name="TDisplay"/> to use 
        /// as the display value.</param>
        /// <returns>A <see cref="LookupModel{TKey, TDisplay}"/> representing a placeholder.</returns>
        public static LookupModel<TKey, TDisplay> GetPlaceHolder(
            TKey key = default, TDisplay display = default) => new()
            {
                Key = key,
                Display = display
            };
    }
}
