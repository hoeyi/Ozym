﻿namespace Ozym.DataTransfer
{
    /// <summary>
    /// Describes a created resource.
    /// </summary>
    public record class CreationRecord<TKey, T>
    {
        /// <summary>
        /// Gets the <typeparamref name="TKey"/> value uniquely identifying the created resource.
        /// </summary>
        public TKey Id { get; init; }

        /// <summary>
        /// Gets the name for the type of resource created.
        /// </summary>
        public string TypeName { get; } = typeof(T).Name;
    }
}
