using System;
using MathNet.Numerics.Distributions;

namespace Ozym.BusinessLogic.Functions
{
    /// <summary>
    /// Represents a stateless class providing statistics-related mathematical functions.
    /// </summary>
    public class StatisticsCalculator : IStatisticsCalculator
    {
        /// <inheritdoc/>
        public double NormalDistributionSample(double mean, double stddev)
        {
            var normal = new Normal(mean, stddev);

            return normal.Sample();
        }

        /// <inheritdoc/>
        public double[] NormalDistributionSamples(double mean, double stddev, int count)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(count, 0, paramName: nameof(count));

            var normal = new Normal(mean, stddev);

            var results = new double[count];

            normal.Samples(results);

            return results;
        }

        /// <inheritdoc/>
        public double StudentTDistributionSample(
            double mu, double scale, double degreesOfFreedom)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(
                degreesOfFreedom, 0, paramName: nameof(degreesOfFreedom));

            var student = new StudentT(mu, scale, degreesOfFreedom);

            return student.Sample();
        }

        /// <inheritdoc/>
        public double[] StudentTDistributionSamples(
            double mu, double scale, double degreesOfFreedom, int count)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(count, 0, paramName: nameof(count));

            var student = new StudentT(mu, scale, degreesOfFreedom);

            var results = new double[count];

            student.Samples(results);

            return results;
        }
    }
}
