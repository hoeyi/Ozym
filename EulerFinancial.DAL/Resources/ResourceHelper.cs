using System;
using System.Resources;
using System.Globalization;
using EulerFinancial.Extensions;

namespace EulerFinancial.Resources
{

    /// <summary>
    /// Contains helper methods for accessing culture-specific application resources.
    /// </summary>
    static class ResourceHelper
    {
        private static readonly ResourceManager adjectiveManager = new(typeof(Adjective));
        private static readonly ResourceManager defualtConfigurationManager = new(typeof(DefaultConfiguration));
        private static readonly ResourceManager descriptionManager = new(typeof(ModelDescription));
        private static readonly ResourceManager displayManager = new(typeof(ModelDisplayName));
        private static readonly ResourceManager nounManager = new(typeof(NounString));
        
        /// <summary>
        /// Gets or sets the culture to use for the <see cref="ResourceHelper"/>. Default is <see cref="CultureInfo.CurrentUICulture"/>.
        /// </summary>
        public static CultureInfo Culture { get; set; } = CultureInfo.CurrentUICulture;

        /// <summary>
        /// Retrieves the adjective matching the given name.
        /// </summary>
        /// <param name="name">The identifier for the adjective to retrieve.</param>
        /// <returns>A <see cref="string"/> that is the culture-specific variant of the adjective.</returns>
        public static string GetAdjective(string name)
        {
            try
            {
                return adjectiveManager.GetString(name: name);
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns the JSON-serialized <see cref="UI.DisplayConfiguration"/> matching the given name.
        /// </summary>
        /// <param name="name">The identifier for the configuration to retrieve.</param>
        /// <returns>A JSON-serialized string representing a <see cref="UI.DisplayConfiguration"/>.</returns>
        public static string GetDefaultDisplayConfiguration(Type type)
        {
            try
            {
                return defualtConfigurationManager.GetString(name: $"Display.{type.Name}", culture: Culture);
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Retrieves the display name of the property within the given type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> type that has a member matching <paramref name="memberName"/>.</param>
        /// <param name="memberName">The name of the member to retrieve a display name for.</param>
        /// <returns>The display name of the matched member if deinfed, else an empty string.</returns>
        public static string GetModelDisplayName(Type type, string memberName)
        {
            try
            {
                return displayManager.GetString(name: $"{type.Name}.{memberName}", culture: Culture);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Retrieves the description of the property within the given type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> type that has a member matching <paramref name="memberName"/>.</param>
        /// <param name="memberName">The name of the member to retrieve a description for.</param>
        /// <returns>The description of the matched member.</returns>
        public static string GetModelDescription(Type type, string memberName)
        {
            try
            {
                return descriptionManager.GetString(name: $"{type.Name}.{memberName}", culture: Culture);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Retrieves noun-metadata matching the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>A <see cref="NounMetadata"/> that is the culture-sepcific variant of the noun.</returns>
        public static NounMetadata GetNounMetadata(string name)
        {
            string noun = nounManager.GetString(name: name);

            return NounMetadata.Parse(noun);
        }
        
        /// <summary>
        /// Provides culture-specific title case formatting.
        /// </summary>
        /// <param name="str">The value to format.</param>
        /// <returns>A formatted <see cref="string"/> base on the 
        /// <see cref="Culture"/> value. Returns an empty 
        /// string if <paramref name="str"/> is null.</returns>
        public static string ToTitleCase(string str)
        {
            return str?.ToTitleCase(Culture) ?? string.Empty;
        }

    }
}
