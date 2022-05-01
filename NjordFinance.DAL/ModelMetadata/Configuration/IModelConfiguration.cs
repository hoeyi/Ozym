namespace NjordFinance.Model.Configuration
{
    /// <summary>
    /// Represents the seed data and settings for <see cref="Context.FinanceDbContext"/>.
    /// </summary>
    internal interface IModelConfiguration
    {
        /// <summary>
        /// Gets the default <see cref="ModelAttribute"/> records.
        /// </summary>
        ModelAttributeMember[] ModelAttributeMembers { get; init; }

        /// <summary>
        /// Gets the default <see cref="ModelAttributeScope"/> records.
        /// </summary>
        ModelAttribute[] ModelAttributes { get; init; }

        /// <summary>
        /// Gets the default <see cref="ModelAttributeMember"/> records.
        /// </summary>
        ModelAttributeScope[] ModelAttributeScopes { get; init; }

        /// <summary>
        /// Gets the default <see cref="SecurityTypeGroup"/> records.
        /// </summary>
        SecuritySymbolType[] SecuritySymbolTypes { get; init; }

        /// <summary>
        /// Gets the default <see cref="SecurityType"/> records.
        /// </summary>
        SecurityTypeGroup[] SecurityTypeGroups { get; init; }

        /// <summary>
        /// Gets the default <see cref="SecuritySymbolType"/> records.
        /// </summary>
        SecurityType[] SecurityTypes { get; init; }
    }
}