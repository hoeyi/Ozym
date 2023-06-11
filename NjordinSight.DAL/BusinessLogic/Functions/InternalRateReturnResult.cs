using System;

namespace NjordinSight.BusinessLogic.Functions
{
    /// <summary>
    /// Represents the internal rate of return for a single period.
    /// </summary>
    public record InternalRateReturnResult
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
        /// Gets or sets the proportional IRR for this result, e.g., 0.35
        /// </summary>
        public float Irr { get; init; }
    }
}
