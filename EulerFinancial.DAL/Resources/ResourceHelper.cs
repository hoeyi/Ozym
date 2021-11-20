using System;
using System.Resources;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using EulerFinancial.Model;
using EulerFinancial.Extensions;

namespace EulerFinancial.Resources
{
    public static class ResourceHelper
    {
        private static readonly ResourceManager displayManager = new(typeof(ModelDisplayName));
        private static readonly ResourceManager descriptionManager = new(typeof(ModelDescription));
        private static readonly ResourceManager nounManager = new(typeof(Noun));
        private static readonly ResourceManager expressionStringManager = new(typeof(ExpressionString));
        public static NounMetadata GetNounMetadata(string key)
        {
            string noun = nounManager.GetString(name: key);

            return NounMetadata.Parse(noun);
        }
        

        public static IDictionary<string, ModelMetadata> GetModelMetaData<T>()
        {
            var type = typeof(T);
            var members = type.GetProperties();

            return members.ToDictionary(m =>
                $"{type.Name}.{m.Name}",
                m => new ModelMetadata()
                {
                    Description = GetDescription(type, m.Name),
                    DisplayName = GetDisplayName(type, m.Name)
                });
        }

        /// <summary>
        /// Gets or sets the culture to use for the <see cref="ResourceHelper"/>. Default is <see cref="CultureInfo.CurrentUICulture"/>.
        /// </summary>
        public static CultureInfo Culture { get; set; } = CultureInfo.CurrentUICulture;

        /// <summary>
        /// Retrieves the display name of the property within the given type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> type that has a member matching <paramref name="memberName"/>.</param>
        /// <param name="memberName">The name of the member to retrieve a display name for.</param>
        /// <returns>The display name of the matched member.</returns>
        public static string GetDisplayName(Type type, string memberName)
        {
            try
            {
                return displayManager.GetString($"{type.Name}.{memberName}", Culture); 
            }
            catch(Exception)
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
        public static string GetDescription(Type type, string memberName)
        {
            try
            {
                return descriptionManager.GetString($"{type.Name}.{memberName}", Culture);
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Provides culture-specific title case formatting.
        /// </summary>
        /// <param name="str">The value to format.</param>
        /// <returns>A formatted <see cref="string"/> base on the 
        /// <see cref="ResourceHelper.Culture"/> value. Returns an empty 
        /// string if <paramref name="str"/> is null.</returns>
        public static string ToTitleCase(string str)
        {
            return str?.ToTitleCase(Culture) ?? string.Empty;
        }

        internal static string GetExpressionString(string name)
        {
            return expressionStringManager.GetString(name: name);
        }
    }
}
