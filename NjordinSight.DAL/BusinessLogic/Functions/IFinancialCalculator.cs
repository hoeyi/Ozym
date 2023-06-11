using System;
using System.Collections.Generic;

namespace NjordinSight.BusinessLogic.Functions
{
    /// <summary>
    /// Represents a stateless class providing business-related mathematical functions.
    /// </summary>
    public interface IFinancialCalculator
    {
        /// <summary>
        /// Calculates the annualized time-weighted return from the given cumulative return over 
        /// the given years.
        /// </summary>
        /// <param name="cumulativeReturn">The cumulative growth rate, expressed as a proportion, 
        /// e.g., 0.35 for 35%.</param>
        /// <param name="years"></param>
        /// <returns>A <see cref="double"/> representing the constant growth rate, expressed as a 
        /// proportion, e.g., 0.35 for 35%, or <see cref="double.NaN"/> if undefined.</returns>
        /// <remarks>Results returned by this function have a precision of 4 (1 basis point).
        /// </remarks>
        public double AnnualizedTimeWeightedReturn(float cumulativeReturn, float years);

        /// <summary>
        /// Calculates the cumulative time-weighted return given a series of equal-weighted IRRs.
        /// </summary>
        /// <param name="irrs">An array of <see cref="InternalRateReturnResult"/> representing the 
        /// single-period returns in the series.</param>
        /// <returns>A <see cref="float"/> representing the cumulative growth rate, e.g., 
        /// 0.35 for 35%, or <see cref="double.NaN"/> if undefined.</returns>
        public double CumulativeTimeWeightedReturn(params InternalRateReturnResult[] irrs);

        /// <summary>
        /// Calculates the effective annual rate given a nominal annual rate and compounding 
        /// frequency.
        /// </summary>
        /// <param name="nominalRate">The nominal annual rate.</param>
        /// <param name="compounding">The frequency of compounding.</param>
        /// <returns>A <see cref="float"/> representing the effective annual rate, e.g., 0.1 for 10%.
        /// </returns>
        public double EffectiveAnnualInterestRate(float nominalRate, CompoundSchedule compounding);

        /// <summary>
        /// Calculates a series of <see cref="FutureValueResult"/> records representing the 
        /// growth table of a principal amount subject to constant periodic constributions and 
        /// growth rate.
        /// </summary>
        /// <param name="startDate">The start date from which periods are calculated.</param>
        /// <param name="periods">The number of periods / cash flows in the range.</param>
        /// <param name="presentValue">The present value in the range.</param>
        /// <param name="growthRate">The growth rate per period in the range.</param>
        /// <param name="regularDeposit">The value of the regular contribution.</param>
        /// <param name="periodType">The period type defining the calendar legnth.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="FutureValueResult"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"> Parameter <paramref name="periods"/> was 
        /// less than zero.</exception>
        public IEnumerable<FutureValueResult> FutureValue(
            DateTime startDate,
            int periods, 
            float presentValue, 
            float growthRate, 
            float regularDeposit, 
            PeriodType periodType);

        
    }
}
