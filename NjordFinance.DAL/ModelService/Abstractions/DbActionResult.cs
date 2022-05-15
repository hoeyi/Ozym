namespace NjordFinance.ModelService.Abstractions
{
    /// <summary>
    /// Represents the result of an action against a data store.
    /// </summary>
    /// <typeparam name="TResult">The action result type.</typeparam>
    public record DbActionResult<TResult>
    {
        /// <summary>
        /// Creates a new <see cref="DbActionResult{TResult}"/> record.
        /// </summary>
        /// <param name="result">The <typeparamref name="TResult"/> result.</param>
        /// <param name="successful">Whether the operation was successful.</param>
        public DbActionResult(TResult result, bool successful)
        {
            Result = result;
            Successful = successful;
        }

        /// <summary>
        /// Gets the result of the action.
        /// </summary>
        public TResult Result { get; init; }

        /// <summary>
        /// Gets whether the action was successful.
        /// </summary>
        public bool Successful { get; init; }
    }

}
