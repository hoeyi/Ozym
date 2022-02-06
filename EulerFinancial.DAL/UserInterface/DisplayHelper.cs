﻿using System;

namespace EulerFinancial.UserInterface
{
    /// <summary>
    /// Extension methods for retrieving and formating user-interface display text.
    /// </summary>
    public static class DisplayHelper
    {
        /// <summary>
        /// The application name. Used as page title component.
        /// </summary>
        private static string appName;

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

        /// <summary>
        /// Converts this string to an application-specific page title in the format: 
        /// <br/>{s} | {AssemblyProduct}
        /// </summary>
        /// <param name="s"></param>
        /// <returns>A new <see cref="string"/> formatted as a page title.</returns>
        public static string AsPageTitle(this string s)
        {
            appName ??= Configuration.AssemblyInfo.AssemblyProduct;

            return $"{s} | {appName}";
        }
    }
}
