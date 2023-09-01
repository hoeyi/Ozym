namespace NjordinSight.Api.Controllers
{
    /// <summary>
    /// Represents a composite key passed as a URI routing parameter.
    /// </summary>
    public record CompositeKeyParameter
    {
        /// <summary>
        /// Gets the first positional key value.
        /// </summary>
        public int Id1 { get; init; }

        /// <summary>
        /// Gets the second positional key value.
        /// </summary>
        public int Id2 { get; init; }
    }
}
