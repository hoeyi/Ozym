using EulerFinancial.Model;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EulerFinancial.UI
{
    /// <summary>
    /// Reprsents a class that contains helper method for presenting culture-specific
    /// data to a user interface.
    /// </summary>
    public interface IUserInterfaceHelper
    {
        /// <summary>
        /// Gets or sets the culture in use by the user interface helper instance.
        /// </summary>
        CultureInfo Culture { get; set; }

        /// <summary>
        /// Returns the default <see cref="DisplayConfiguration"/> instance.
        /// </summary>
        /// <typeparam name="T">The type to which the configuration applies.</typeparam>
        /// /// <param name="name">The name of the display configuration to retrieve.</param>
        /// <returns>A <see cref="DisplayConfiguration"/> constructed from the saved configuration./returns>
        DisplayConfiguration GetDisplayConfigurationOrDefault<T>(string name = null);

        /// <summary>
        /// Retrieves the description of the property within the given type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> type that has a member matching <paramref name="memberName"/>.</param>
        /// <param name="memberName">The name of the member to retrieve a description for.</param>
        /// <returns>The description of the matched member.</returns>
        string GetModelDescription(Type type, string memberName);

        /// <summary>
        /// Retrieves the display name of the property within the given type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> type that has a member matching <paramref name="memberName"/>.</param>
        /// <param name="memberName">The name of the member to retrieve a display name for.</param>
        /// <returns>The display name of the matched member if deinfed, else an empty string.</returns>
        string GetModelDisplayName(Type type, string memberName);

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
        IEnumerable<ModelMemberMetadata> GetModelMemberMetadata<T>(string dispalyConfigurationName = null);

        /// <summary>
        /// Provides culture-specific title case formatting.
        /// </summary>
        /// <param name="str">The value to format.</param>
        /// <returns>A formatted <see cref="string"/> base on the 
        /// <see cref="Culture"/> value. Returns an empty 
        /// string if <paramref name="str"/> is null.</returns>
        string ToTitleCase(string str);
    }
}
