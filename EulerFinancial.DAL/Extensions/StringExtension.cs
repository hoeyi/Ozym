using System;
using System.Globalization;
using System.Threading;

namespace EulerFinancial.Extensions
{
    public static class StringExtension
    {
        public static string ConvertToLogTemplate(this string template, params string[] parameterNames)
        {
            if (string.IsNullOrEmpty(template))
                return null;

            if (parameterNames is null)
                return template;

            string logTemplate = null;
            for (int i = 0; i < parameterNames.Length; i++)
            {
                logTemplate = template.Replace($"{{{i}}}", $"{{{parameterNames[i]}}}");
            }

            return logTemplate;
        }

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

        /// <summary>
        /// Converts this string to title case using the provider <see cref="CultureInfo.CurrentUICulture"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>The <see cref="string"/>, converted to title case.</returns>
        public static string ToTitleCase(this string str)
        {
            return str?.ToTitleCase(CultureInfo.CurrentUICulture);
        }

        /// <summary>
        /// Converts this string to title case using the provider <see cref="CultureInfo.CurrentUICulture"/>.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> to use as a formatting provider.</param>
        /// <returns>The <see cref="string"/>, converted to title case.</returns>
        private static string ToTitleCase(this string str, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            else
            {
                return cultureInfo.TextInfo.ToTitleCase(str);
            }
        }
    }
}
