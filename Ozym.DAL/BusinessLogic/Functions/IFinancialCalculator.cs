using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Ozym.BusinessLogic.Functions
{
    /// <summary>
    /// Represents a stateless class providing business-related mathematical functions and simulations.
    /// </summary>
    public interface IFinancialCalculator
    {
        /// <summary>
        /// Calculates a series of <see cref="FutureValueResult"/> records representing the 
        /// growth table of a principal amount subject to variable periodic constributions and 
        /// growth rates.
        /// </summary>
        /// <param name="startDate">The start date from which periods are calculated.</param>
        /// <param name="periods">The number of periods / cash flows in the range.</param>
        /// <param name="presentValue">The present value in the range.</param>
        /// <param name="growthRate">The growth rate normal distribution parameters (mu, sigma).</param>
        /// <param name="regularDeposit">The contribution amount normal distribution parameters (mu, sigma).</param>
        /// <param name="periodType">The period type defining the calendar length.</param>
        /// <param name="simulations">The number of simulations to run. Default is one.</param>
        /// <returns>An <see cref="IDictionary{TKey, TValue}"/> where the integer key denotes the simulation index.
        /// <see cref="FutureValueResult"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Parameter <paramref name="periods"/> was 
        /// less than or greater than 100, or parameter <paramref name="simulations"/> was less than 1
        /// or greater than 1000.</exception>
        IDictionary<int, IEnumerable<FutureValueResult>> FutureValueSimulation(
            DateTime startDate,
            int periods,
            float presentValue,
            (float, float) growthRate,
            (float, float) regularDeposit,
            PeriodType periodType,
            int simulations = 1);

        /// <summary>
        /// Calculates a series of <see cref="FutureValueResult"/> records representing the 
        /// growth table of a principal amount subject to variable periodic constributions and 
        /// growth rates.
        /// </summary>
        /// <param name="startDate">The start date from which periods are calculated.</param>
        /// <param name="periods">The number of periods / cash flows in the range.</param>
        /// <param name="presentValue">The present value in the range.</param>
        /// <param name="growthDistribution">The growth rate distribution.</param>
        /// <param name="contributionDistribution">The contribution amount distribution.</param>
        /// <param name="periodType">The period type defining the calendar length.</param>
        /// <param name="simulations">The number of simulations to run. Default is one.</param>
        /// <returns>An <see cref="IDictionary{TKey, TValue}"/> where the integer key denotes the simulation index.
        /// <see cref="FutureValueResult"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Parameter <paramref name="periods"/> was 
        /// less than or greater than 100, or parameter <paramref name="simulations"/> was less than 1
        /// or greater than 1000.</exception>
        IDictionary<int, IEnumerable<FutureValueResult>> FutureValueSimulation(
            DateTime startDate,
            int periods,
            float presentValue,
            IContinuousDistribution growthDistribution,
            IContinuousDistribution contributionDistribution,
            PeriodType periodType,
            int simulations = 1);

        /// <summary>
        /// Annualizes the given cumulative return.
        /// </summary>
        /// <param name="cumulativeReturn">The cumulative return.</param>
        /// <param name="years">The number of years over the cumulative return is measured.</param>
        /// <returns>A <see cref="double"/> representing the annualized return (geometric mean) of 
        /// the cumulative return.</returns>
        double AnnualizedTimeWeightedReturn(float cumulativeReturn, float years);

        /// <summary>
        /// Calculates the cumulative time-weighted return given a series of equal-weighted IRRs.
        /// </summary>
        /// <param name="irrs">An array of <see cref="InternalRateReturnResult"/> representing the 
        /// single-period returns in the series.</param>
        /// <returns>A <see cref="float"/> representing the cumulative growth rate, e.g., 
        /// 0.35 for 35%, or <see cref="double.NaN"/> if undefined.</returns>
        double CumulativeTimeWeightedReturn(params InternalRateReturnResult[] irrs);

        /// <summary>
        /// Calculates the effective annual rate given a nominal annual rate and compounding 
        /// frequency.
        /// </summary>
        /// <param name="nominalRate">The nominal annual rate.</param>
        /// <param name="compounding">The frequency of compounding.</param>
        /// <returns>A <see cref="float"/> representing the effective annual rate, e.g., 0.1 for 10%.
        /// </returns>
        double EffectiveAnnualInterestRate(float nominalRate, CompoundSchedule compounding);

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
        /// <param name="periodType">The period type defining the calendar length.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="FutureValueResult"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException"> Parameter <paramref name="periods"/> was 
        /// less than zero.</exception>
        IEnumerable<FutureValueResult> FutureValue(
            DateTime startDate,
            int periods, 
            float presentValue, 
            float growthRate, 
            float regularDeposit, 
            PeriodType periodType);
    }

    public static class FinancialCalculatorExtensions
    {
        /// <summary>
        /// Returns the simulation results by quartiles, including the minimum and maximumn values.
        /// </summary>
        /// <param name="simulationResults">The dictionary of simulation results.</param>
        /// <returns>An <see cref="IDictionary{TKey, TValue}"/> where the double key denotes the quantile value,
        /// and the value is an <see cref="IEnumerable{T}"/> of <see cref="FutureValueResult"/>.</returns>
        public static IDictionary<double, IEnumerable<FutureValueResult>> ByQuantiles(
            this IDictionary<int, IEnumerable<FutureValueResult>> simulationResults)
        {
            ArgumentNullException.ThrowIfNull(simulationResults);

            var rankedSimulationIds = simulationResults
                                    .Select(x =>
                                        new { SimulationId = x.Key, x.Value.Last().Balance })
                                    .OrderBy(x => x.Balance)
                                    .ToArray();

            Dictionary<double, IEnumerable<FutureValueResult>> percentileData = [];
            (double, double)[] percentiles = (new double[]{ 0, 0.025, 0.25, 0.50, 0.75, 0.975, 1 })
                                    .Select(x => (x, Math.Round(x * rankedSimulationIds.Length, 0)))
                                    .Distinct()
                                    .ToArray();

            foreach (var p in percentiles)
            {
                var id = rankedSimulationIds[(int)Math.Clamp(p.Item2 - 1, 0, rankedSimulationIds.Length - 1)].SimulationId;
                percentileData.Add(p.Item1, simulationResults[id]);
            }

            return percentileData;
        }
    }
}
