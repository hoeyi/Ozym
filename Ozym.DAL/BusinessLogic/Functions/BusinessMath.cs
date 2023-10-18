using System;

namespace Ozym.BusinessLogic.Functions
{
    /// <summary>
    /// Container class for buiness-related general purpose mathematical functions.
    /// </summary>
    internal static class BusinessMath
    {
        /// <summary>
        /// Confines the input <paramref name="value"/> to the range defined by inputs 
        /// <paramref name="min"/> and <paramref name="max"/>.
        /// </summary>
        /// <param name="value">The value to be confined.</param>
        /// <param name="min">The minimum allowable value.</param>
        /// <param name="max">Teh maximum allowable value.</param>
        /// <returns>The value of <paramref name="min"/> if <paramref name="value"/> is lesser, 
        /// the value of <paramref name="max"/> if <paramref name="value"/> is greater, else 
        /// <paramref name="value"/>.</returns>
        public static T Clamp<T>(T value, T min, T max)
            where T : IComparable<T>
        {
            // if value is less than min, return min
            // if value is greater than min and less greater than max return max
            // else return value
            return (value.IsLessThan(min)) ? min : (value.IsGreaterThan(max)) ? max : value;
        }

        public static bool IsGreaterThan<T>(this T value, T other) 
            where T : IComparable<T>
        {
            return value.CompareTo(other) > 0;
        }

        public static bool IsLessThan<T>(this T value, T other)
            where T : IComparable<T>
        {
            return value.CompareTo(other) < 0;
        }
    }
}
