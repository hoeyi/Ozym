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
        /// /// <param name="name">The name of the display configuration to retrieve.</param>
        /// <returns>A <see cref="DisplayConfiguration"/> constructed from the saved configuration./returns>
        public DisplayConfiguration GetDisplayConfigurationOrDefault<T>(string name = null)
        {
            if(string.IsNullOrEmpty(name))
            {
                var configJson = ResourceHelper.GetDefaultDisplayConfiguration(typeof(T));
                var config = JsonConvert.DeserializeObject<DisplayConfiguration>(configJson);

                return config;
            }
            else
            {
                throw new NotImplementedException($"Member not implemented: {nameof(GetDisplayConfigurationOrDefault)}.");
            }
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
        /// Constructs a collection of model field metadata for use in presenting data in a user interface, 
        /// including the display order.
        /// </summary>
        /// <typeparam name="T">The type for which metadata is constructed.</typeparam>
        /// <param name="dispalyConfigurationName">The name of the display configurtion name to use for 
        /// ordering </param>
        /// <returns>An enumerable collection of <see cref="ModelMemberMetadata"/>.</returns>
        /// <remarks>Inlcudes only columns visible in the requested display configuration, or the default configuration 
        /// if none are requested. </remarks>
        public IEnumerable<ModelMemberMetadata> GetModelMemberMetadata<T>(string dispalyConfigurationName = null)
        {
            var type = typeof(T);
            var members = type.GetProperties();

            var displayConfig = GetDisplayConfigurationOrDefault<T>(dispalyConfigurationName);

            return members.Select(m =>
            {
                if (displayConfig.DisplayOrder.TryGetValue($"{type.Name}.{m.Name}", out int memberDisplayOrder))
                {
                    return new ModelMemberMetadata(
                        declaringMemberName: $"{type.Name}.{m.Name}",
                        qualifiedMemberName: string.Empty,
                        displayName: GetModelDisplayName(type, m.Name),
                        description: GetModelDescription(type, m.Name),
                        displayOrder: memberDisplayOrder);
                }
                else
                {
                    return null;
                }
            })
            .Where(m => !(m is null) && !string.IsNullOrEmpty(m.DisplayName))
            .ToList();
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
