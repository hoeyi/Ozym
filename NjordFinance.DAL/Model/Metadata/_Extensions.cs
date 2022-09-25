using Ichosys.DataModel;
using Ichosys.DataModel.Annotations;
using NjordFinance.Model;
using System;
using System.Linq;
using System.Linq.Expressions;
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

        public static TEnum? ConvertTo<TEnum>(this string name)
            where TEnum : struct
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
    }
}
