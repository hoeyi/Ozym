using System;

namespace EulerFinancial.Extensions
{
    public static class ToStringExtensions
    {
        public static string ToString(this DateTime? @dateTime, IFormatProvider provider)
        {
            return dateTime?.ToString(provider) ?? string.Empty;
        }

        public static string ToString(this DateTime? @dateTime, string format)
        {
            return @dateTime?.ToString(format) ?? string.Empty;
        }

        public static string ToString(this decimal? @decimal, IFormatProvider provider)
        {
            return @decimal?.ToString(provider) ?? string.Empty;
        }

        public static string ToString(this decimal? @decimal, string format)
        {
            return @decimal?.ToString(format) ?? string.Empty;
        }

        public static string ToString(this int? @int, IFormatProvider provider)
        {
            return @int?.ToString(provider) ?? string.Empty;
        }

        public static string ToString(this int? @int, string format)
        {
            return @int?.ToString(format) ?? string.Empty;
        }

        public static string ToString(this double? @double, IFormatProvider provider)
        {
            return @double?.ToString(provider) ?? string.Empty;
        }

        public static string ToString(this double? @double, string format)
        {
            return @double?.ToString(format) ?? string.Empty;
        }

        public static string ToString(this float? @float, IFormatProvider provider)
        {
            return @float?.ToString(provider) ?? string.Empty;
        }

        public static string ToString(this float? @float, string format)
        {
            return @float?.ToString(format) ?? string.Empty;
        }
    }
}
