using System;
using System.ComponentModel.DataAnnotations;

namespace Ozym.BusinessLogic.Functions
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
        [Display(
            Name = nameof(DisplayString.FutureValueResult_PeriodDate_Name),
            Description = nameof(DisplayString.FutureValueResult_PeriodDate_Description),
            ResourceType = typeof(DisplayString))]
        public DateTime PeriodDate { get; init; }

        /// <summary>
        /// Gets or sets the cumulative principal at the start of this period.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.FutureValueResult_Principal_Name),
            Description = nameof(DisplayString.FutureValueResult_Principal_Description),
            ResourceType = typeof(DisplayString))]
        public float Principal { get; init; }

        /// <summary>
        /// Gets or sets the interest earned at the end of this period.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.FutureValueResult_Interest_Name),
            Description = nameof(DisplayString.FutureValueResult_Interest_Description),
            ResourceType = typeof(DisplayString))]
        public float Interest { get; init; }

        /// <summary>
        /// Gets the balance at the end of the period.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.FutureValueResult_Balance_Name),
            Description = nameof(DisplayString.FutureValueResult_Balance_Description),
            ResourceType = typeof(DisplayString))]
        public float Balance => Principal + Interest;
    }
}
