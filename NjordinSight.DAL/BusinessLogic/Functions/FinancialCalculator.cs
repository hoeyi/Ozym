using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NjordinSight.BusinessLogic.Functions
{
    public enum PeriodType
    {
        Day,

        Week,

        Month,

        Quarter,

        Annual
    }

    /// <summary>
    /// Defines the supported interest compounding schedules.
    /// </summary>
    public enum CompoundSchedule
    {
        /// <summary>
        /// Compound using formula: PV * e^rt where
        /// <list type="bullet">
        /// <item><em>PV</em> is the present value</item>
        /// <item><em>r</em> is the rate</item>
        /// <item><em>t</em> is the number of periods</item>
        /// </list>
        /// </summary>
        Continuous,

        /// <summary>
        /// Compound using a 365-day year.
        /// </summary>
        Daily,

        /// <summary>
        /// Compound using monthly schedule.
        /// </summary>
        Monthly,

        /// <summary>
        /// Compound using a 6-month schedule.
        /// </summary>
        SemiAnnually, 

        /// <summary>
        /// Compound using annual schedule.
        /// </summary>
        Annually
    }

    /// <summary>
    /// Represents a basic financial calculator.
    /// </summary>
    public class FinancialCalculator : IFinancialCalculator
    {
        private const int PercentPrecision = 4;
        private const int CurrencyPrecision = 2;

        /// <inheritdoc/>
        public double AnnualizedTimeWeightedReturn(float cumulativeReturn, float years)
        {
            if (years > 0.0)
                return Math.Round(Math.Pow(cumulativeReturn + 1.0F, 1.0 / years) - 1.0, PercentPrecision);

            return double.NaN;
        }

        /// <inheritdoc/>
        public double CumulativeTimeWeightedReturn(params InternalRateReturnResult[] irrs)
        {
            if (irrs is null)
                throw new ArgumentNullException(paramName: nameof(irrs));

            // Attempt to access the first result. Throws InvalidOperationException if 
            // array is empty.
            _ = irrs.First();

            var productSeries = from i in irrs
                                select new
                                {
                                    AdjustedIrr = Math.Log(i.Irr + 1.0)
                                };

            var result = Math.Exp(productSeries.Sum(x => x.AdjustedIrr)) - 1.0;

            return Math.Round(result, PercentPrecision);
        }

        /// <inheritdoc/>
        public double EffectiveAnnualInterestRate(float nominalRate, CompoundSchedule compounding)
        {
            // Handle continuous case, if applicable.
            if (compounding == CompoundSchedule.Continuous)
                return Math.Round(Math.Exp(nominalRate) - 1, 4);

            // If not continuous, we use the following formula:
            // EAR = (1 + nominal / n)^n -1 where n is the number of sub-periods
            float n = compounding switch
            {
                CompoundSchedule.Continuous => throw new NotImplementedException(),
                CompoundSchedule.Daily => 365,
                CompoundSchedule.Monthly => 12,
                CompoundSchedule.SemiAnnually => 2,
                CompoundSchedule.Annually => 1,
                _ => throw new NotImplementedException(),
            };

            return Math.Round(Math.Pow(1F + nominalRate / n, n) - 1F, 4);
        }

        /// <inheritdoc/>
        public IEnumerable<FutureValueResult> FutureValue(
            DateTime startDate,
            int periods, 
            float presentValue, 
            float growthRate, 
            float regularDeposit,
            PeriodType periodType)
        {
            if (periods < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(periods));

            var results = new List<FutureValueResult>();

            // Set the initial period values.
            int period = 0;
            DateTime periodDate = startDate;
            float principal = presentValue;
            float interest = 0F;

            // Run in a checked context to throw an OverflowException
            checked
            {
                // Loop through the periods and calculate results based on the prior values.
                for(int i = 0; i <= periods; i++)
                {
                    // If period == 0, intialized values are appropriate.
                    // Else calculate results for the current iteration.
                    if(i > 0)
                    {
                        period = i;
                        periodDate = periodType switch
                        {
                            PeriodType.Day => startDate.AddDays(i),
                            PeriodType.Week => startDate.AddDays(i * 7),
                            PeriodType.Month => startDate.AddMonths(i),
                            PeriodType.Quarter => startDate.AddMonths(i * 3),
                            PeriodType.Annual => startDate.AddYears(i),
                            _ => throw new NotImplementedException(),
                        };
                        interest += (principal + interest) * growthRate;
                        principal += regularDeposit;
                    }
                
                    // Add the record to the result set.
                    results.Add(new()
                    {
                        Period = period,
                        PeriodDate = periodDate,
                        Principal = (float)Math.Round(principal, CurrencyPrecision),
                        Interest = (float)Math.Round(interest, CurrencyPrecision)
                    });
                }
            }

            return results;
        }
    }
}
