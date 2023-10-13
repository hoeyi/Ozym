using System;

namespace NjordinSight.UserInterface
{
    public static class StringExtension
    {
        /// <summary>
        /// The application name. Used as page title component.
        /// </summary>
        private static string appName;

        /// <summary>
        /// Converts this string to an application-specific page title in the format: 
        /// <br/>{s} | {AssemblyProduct}
        /// </summary>
        /// <param name="s"></param>
        /// <returns>A new <see cref="string"/> formatted as a page title.</returns>
        public static string AsPageTitle(this string s)
        {
            appName ??= Configuration.AssemblyInfo.AssemblyProduct;

            return $"{appName} | {s}";
        }

        /// <summary>
        /// Formats this string with the given values.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="args">The array of string values to insert.</param>
        /// <returns>A formatted <see cref="string"/>.</returns>
        public static string Format(this string s, params string[] args)
        {
            if ((args ?? Array.Empty<string>()).Length == 0)
                return s;

            return string.Format(s, args);
        }
    }
}
