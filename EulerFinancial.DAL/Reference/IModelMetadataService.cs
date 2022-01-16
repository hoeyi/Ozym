using System;

namespace EulerFinancial.Reference
{
    /// <summary>
    /// Provides methods for accessing object metadata.
    /// </summary>
    public interface IModelMetadataService
    {
        /// <summary>
        /// Gets the display text for the member declared in the given type.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member display text, if defined, else 
        /// {<see cref="Type.Name"/>.<paramref name="memberName"/>} as an interpolated
        /// <see cref="string"/>.</returns>
        string DisplayTextFor<TModel>(string memberName);

        /// <summary>
        /// Gets the description for the member declared in the given type.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member description, if defined, else null.</returns>
        string DescriptionFor<TModel>(string memberName);
    }
}
