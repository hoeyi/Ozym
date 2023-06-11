using System;

namespace NjordinSight.BusinessLogic.Functions
{
    /// <summary>
    /// Represents the future value result of a single period in a series.
    /// </summary>
    public record FutureValueResult
    {
        /// <summary>
        /// Get or sets the period index this record represents. Generally a one-based index.
        /// </summary>
        public int Period { get; init; }

        /// <summary>
        /// Gets or sets the ending date of the period.
        /// </summary>
        public DateTime PeriodDate { get; init; }

        /// <summary>
        /// Gets or sets the cumulative principal at the start of this period.
        /// </summary>
        public float Principal { get; init; }

        /// <summary>
        /// Gets or sets the interest earned at the end of this period.
        /// </summary>
        public float Interest { get; init; }
    }
}
