using NjordFinance.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace NjordFinance.ModelMetadata
{
    /// <summary>
    /// Extensions methods useful for accessing model metadata.
    /// </summary>
    public static class Extensions
    {
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

            var memberAttribute = enumType
                .GetMember(name)
                .FirstOrDefault()
                ?.GetCustomAttribute<EnumMemberAttribute>();

            return memberAttribute?.Value;
        }

        /// <summary>
        /// Returns the <typeparamref name="TEnum"/> whose assign <see cref="EnumMemberAttribute"/> 
        /// has a value matching the string.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="str"></param>
        /// <returns>The <typeparamref name="TEnum"/> value matching this string.</returns>
        public static TEnum? ConvertFromStringCode<TEnum>(this string str)
            where TEnum: struct, Enum
        {
            var enumType = typeof(TEnum)
                .GetMembers()
                .FirstOrDefault(x => x.GetCustomAttribute<EnumMemberAttribute>()?.Value == str);

            return ConvertTo<TEnum>(enumType.Name);
        }

        public static TEnum? ConvertTo<TEnum>(this string name)
            where TEnum : struct, Enum
        {
            if (Enum.TryParse(name, out TEnum value))
                return value;
            else
                return null;
        }

        /// <summary>
        /// Converts this <see cref="ModelAttributeScopeCode"/> into an array of string codes
        /// representing 
        /// </summary>
        /// <param name="scopeCodes"></param>
        /// <returns></returns>
        public static string[] ToStringArray(this ModelAttributeScopeCode scopeCodes) =>
            Enum.GetValues(typeof(ModelAttributeScopeCode))
                .Cast<Enum>()
                .Where(scopeCodes.HasFlag)
                .Cast<ModelAttributeScopeCode>()
                .Select(m => m.ConvertToStringCode())
                .ToArray();

        /// <summary>
        /// Converts each value declared in type <typeparamref name="TEnum"/> to the 
        /// string code representing them.
        /// </summary>
        /// <returns></returns>
        public static string[] ToStringArray<TEnum>()
            where TEnum : struct, Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<Enum>()
                .Cast<TEnum>()
                .Select(m => m.ConvertToStringCode())
                .ToArray();
        }

        /// <summary>
        /// Gets the display name applied to a field of this <see cref="ModelAttributeScopeCode". />
        /// </summary>
        /// <param name="attributeScope"></param>
        /// <returns>A localized string representing the field, or null if not defined.</returns>
        /// <remarks>The behavior of this function has not been tested on enumeration types 
        /// defined as bit flags.</remarks>
        public static string GetDisplayName(this ModelAttributeScopeCode attributeScope)
        {
            return typeof(ModelAttributeScopeCode)
                .GetField(Enum.GetName(typeof(ModelAttributeScopeCode), attributeScope))
                ?.GetCustomAttribute<DisplayAttribute>()
                ?.GetName();
        }
    }
}
