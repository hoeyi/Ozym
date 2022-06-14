using Ichosys.DataModel;
using Ichosys.DataModel.Annotations;
using System;
using System.Runtime.Serialization;

namespace NjordFinance.ModelMetadata
{
    /// <summary>
    /// Extensions methods useful for accessing model metadata.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Gets the <see cref="NounAttribute"/> applied to the given type.
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="type">The type decorated with a noun attribute.</param>
        /// <returns>A <see cref="NounAttribute"/> if applied to the type, else null.</returns>
        public static NounAttribute NounFor(this IModelMetadataService metadata, Type type)
        {
            if (type is null)
                return null;

            return metadata?.AttributeFor<NounAttribute>(type);
        }

        /// <summary>
        /// Returns the string value assigned to the member <see cref="EnumMemberAttribute"/>.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="enum"></param>
        /// <returns>The string representation of this member.</returns>
        public static string ConvertToStringCode<TEnum>(this TEnum @enum)
            where TEnum : struct
        {
            var enumType = typeof(TEnum);
            var name = Enum.GetName(enumType, @enum);

            var memberAttribute = enumType.AttributeFor<EnumMemberAttribute>(name);

            return memberAttribute?.Value;
        }
    }
}
