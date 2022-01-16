using Ichosoft.DataModel.Annotations;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace EulerFinancial.Reference
{
    public class ModelMetadataService : IModelMetadataService
    {
        private readonly ResourceManager resourceManager = new(typeof(Resources.ModelDescription));

        /// <summary>
        /// Gets the display text for the member declared in the given type.
        /// </summary>
        /// <typeparam name="TModel">The declaring type.</typeparam>
        /// <param name="memberName">The member name.</param>
        /// <returns>The member display text, if defined, else 
        /// {<see cref="Type.Name"/>.<paramref name="memberName"/>} as an interpolated
        /// <see cref="string"/>.</returns>
        public string DisplayTextFor<TModel>(string memberName)
        {
            if (string.IsNullOrEmpty(memberName))
                return null;

            MemberInfo memberInfo = typeof(TModel).GetMember(memberName: memberName);

            string result = memberInfo
                ?.GetAttribute<DisplayAttribute>()
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
            if (string.IsNullOrEmpty(memberName))
                return null;

            return resourceManager.GetString($"{typeof(TModel).Name}.{memberName}");
        }
    }
}
