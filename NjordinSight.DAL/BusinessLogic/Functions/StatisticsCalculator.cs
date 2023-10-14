using System;
using MathNet.Numerics.Distributions;

namespace NjordinSight.BusinessLogic.Functions
{
    /// <summary>
    /// Represents a stateless class providing statistics-related mathematical functions.
    /// </summary>
    public class StatisticsCalculator : IStatisticsCalculator
    {
        /// <inheritdoc/>
        public double[] NormalDistributionSamples(double mean, double stddev, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(count), actualValue: count, message: nameof(NormalDistributionSamples));

            var normal = new Normal(mean, stddev);

            var results = new double[count];

            normal.Samples(results);

            return results;
        }


        /// <inheritdoc/>
        public double NormalDistributionSample(double mean, double stddev)
        {
            var normal = new Normal(mean, stddev);

            return normal.Sample();
        }
    }
}
