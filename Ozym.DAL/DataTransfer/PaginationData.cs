using System;

namespace Ozym.DataTransfer
{
    /// <summary>
    /// Represents a small collection of metadata describing the pagination of query 
    /// result set.
    /// </summary>
    public record PaginationData
    {
        /// <summary>
        /// Gets the index of the page returned.
        /// </summary>
        public int PageIndex { get; init; }

        /// <summary>
        /// Gets record limit per page.
        /// </summary>
        public int PageSize { get; init; }

        /// <summary>
        /// Gets the total count of records matching the query predicate.
        /// </summary>
        public int ItemCount { get; init; }

        /// <summary>
        /// Gets the total estimated pages for all records matching the query predicate.
        /// </summary>
        public int PageCount => (int)Math.Ceiling(ItemCount / (double)PageSize);
    }
}
