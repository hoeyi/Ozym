namespace Ozym.BusinessLogic.Functions
{
    /// <summary>
    /// Represents a stateless class providing statistics-related mathematical functions.
    /// </summary>
    public interface IStatisticsCalculator
    {
        /// <summary>
        /// Generates a normally-distrubted random number using the Box-Muller transform.
        /// </summary>
        /// <param name="mean">The mean of the distribution sampled.</param>
        /// <param name="stddev">The standard deviation of the distribution sampled.</param>
        /// <returns>A <see cref="double"/> given the generated sample.</returns>
        double NormalDistributionSample(double mean, double stddev);

        /// <summary>
        /// Generates a series of normally-distributed random numbers using the Box-Muller transform.
        /// </summary>
        /// <param name="mean"></param>
        /// <param name="stddev"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        double[] NormalDistributionSamples(double mean, double stddev, int count);
    }
}
