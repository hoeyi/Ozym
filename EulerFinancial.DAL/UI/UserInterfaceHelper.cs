using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EulerFinancial.Model;
using EulerFinancial.Resources;
using Newtonsoft.Json;

namespace EulerFinancial.UI
{
    /// <summary>
    /// Reprsents a class that contains helper method for presenting culture-specific
    /// data to a user interface.
    /// </summary>
    public class UserInterfaceHelper : IUserInterfaceHelper
    {
        /// <summary>
        /// Gets or sets the culture in use by the user interface helper instance.
        /// </summary>
        public CultureInfo Culture
        {
            get { return ResourceHelper.Culture; }
            set{ ResourceHelper.Culture = value; }
        }

        /// <summary>
        /// Returns the default <see cref="DisplayConfiguration"/> instance.
        /// </summary>
        /// <typeparam name="T">The type to which the configuration applies.</typeparam>
        /// <returns>A <see cref="DisplayConfiguration"/> instance defined in the application resources.</returns>
        public DisplayConfiguration GetDefaultDisplayConfiguration<T>()
        {
            var configJson = ResourceHelper.GetDefaultDisplayConfiguration($"Display.{typeof(T).Name}");
            var config = JsonConvert.DeserializeObject<DisplayConfiguration>(configJson);

            return config;
        }

        /// <summary>
        /// Retrieves the description of the property within the given type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> type that has a member matching <paramref name="memberName"/>.</param>
        /// <param name="memberName">The name of the member to retrieve a description for.</param>
        /// <returns>The description of the matched member.</returns>
        public string GetModelDescription(Type type, string memberName)
        {
            return ResourceHelper.GetModelDescription(type: type, memberName: memberName);
        }

        /// <summary>
        /// Retrieves the display name of the property within the given type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> type that has a member matching <paramref name="memberName"/>.</param>
        /// <param name="memberName">The name of the member to retrieve a display name for.</param>
        /// <returns>The display name of the matched member if deinfed, else an empty string.</returns>
        public string GetModelDisplayName(Type type, string memberName)
        {
            return ResourceHelper.GetModelDisplayName(type: type, memberName: memberName);
        }

        /// <summary>
        /// Constructs a collection of model field metadata for use in presenting data in a user interface.
        /// </summary>
        /// <typeparam name="T">The type for which metadata is constructed.</typeparam>
        /// <returns>An enumerable collection of <see cref="ModelMetadata"/>.</returns>
        public IEnumerable<ModelMetadata> GetModelMetadata<T>()
        {
            var type = typeof(T);
            var members = type.GetProperties();

            return members.Select(m =>
                new ModelMetadata(
                    declaringMemberName: $"{type.Name}.{m.Name}",
                    qualifiedMemberName: string.Empty,
                    displayName: GetModelDisplayName(type, m.Name),
                    description: GetModelDescription(type, m.Name)
                ))
                .Where(m => !string.IsNullOrEmpty(m.DisplayName))
                .ToArray();
        }

        /// <summary>
        /// Provides culture-specific title case formatting.
        /// </summary>
        /// <param name="str">The value to format.</param>
        /// <returns>A formatted <see cref="string"/> base on the 
        /// <see cref="Culture"/> value. Returns an empty 
        /// string if <paramref name="str"/> is null.</returns>
        public string ToTitleCase(string str)
        {
            return ResourceHelper.ToTitleCase(str: str);
        }
    }
}
