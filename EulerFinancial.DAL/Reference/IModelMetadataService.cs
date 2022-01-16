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
        string NameFor<TModel>(string memberName);

        /// <summary>
        /// Gets the description for the member declared in the given type.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member description, if defined, else null.</returns>
        string DescriptionFor<TModel>(string memberName);

        /// <summary>
        /// Gets the display order for the member declared in the given type.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member order, if defined, else default <see cref="int"/>.</returns>
        int OrderFor<TModel>(string memberName);

        /// <summary>
        /// Gets the value used to group members..
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns></returns>
        string GroupNameFor<TModel>(string memberName);

        /// <summary>
        /// Gets the value used for the grid column label.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns></returns>
        string ShortNameFor<TModel>(string memberName);

        /// <summary>
        /// Gets the value used to set the watermark for prompts.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns></returns>
        string PromptFor<TModel>(string memberName);
    }
}
