using Ichosoft.DataModel.Annotations;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace EulerFinancial.Reference
{
    public class ModelMetadataService : IModelMetadataService
    {
        /// <summary>
        /// Gets the display text for the member declared in the given type.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member display text, if defined, else 
        /// {<see cref="Type.Name"/>.<paramref name="memberName"/>} as an interpolated
        /// <see cref="string"/>.</returns>
        public string NameFor<TModel>(string memberName)
        {
            string result = GetDisplayAttribute<TModel>(memberName)
                ?.GetName() ?? $"{typeof(TModel).Name}.{memberName}";

            return result;
        }

        /// <summary>
        /// Gets the description for the member declared in the given type.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member description, if defined, else null.</returns>
        public string DescriptionFor<TModel>(string memberName)
        {
            string result = GetDisplayAttribute<TModel>(memberName)
                ?.GetDescription() ?? $"{typeof(TModel).Name}.{memberName}";

            return result;
        }

        /// <summary>
        /// Gets the display order for the member declared in the given type.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member order, if defined, else default <see cref="int"/>.</returns>
        public int OrderFor<TModel>(string memberName)
        {
            int result = GetDisplayAttribute<TModel>(memberName)?.GetOrder() ?? default;

            return result;
        }
        
        /// <summary>
        /// Gets the value used to group members..
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns></returns>
        public string GroupNameFor<TModel>(string memberName)
        {
            string result = GetDisplayAttribute<TModel>(memberName)?.GetGroupName();

            return result;
        }

        /// <summary>
        /// Gets the value used for the grid column label.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns></returns>
        public string ShortNameFor<TModel>(string memberName)
        {
            string result = GetDisplayAttribute<TModel>(memberName)?.GetShortName();

            return result;
        }
        
        /// <summary>
        /// Gets the value used to set the watermark for prompts.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns></returns>
        public string PromptFor<TModel>(string memberName)
        {
            string result = GetDisplayAttribute<TModel>(memberName)?.GetPrompt();

            return result;
        }
        
        private static DisplayAttribute GetDisplayAttribute<TModel>(string memberName)
        {
            if (string.IsNullOrEmpty(memberName))
                return null;

            MemberInfo memberInfo = typeof(TModel).GetMember(memberName: memberName);

            return memberInfo?.GetAttribute<DisplayAttribute>();
        }
    }
}
