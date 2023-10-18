namespace Ozym.ChangeTracking
{
    /// <summary>
    /// Represents a read-only description of an an entry in a 
    /// <see cref="ICommandHistory{T}"/>.
    /// </summary>
    public readonly record struct CommandHistoryEntry
    {
        public int Index { get; init; }

        public string Description { get; init; }
    }
}
