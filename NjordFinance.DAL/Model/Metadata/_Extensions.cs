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
        /// Gets the description text of the member matching the desitination of the given expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="metadata"></param>
        /// <param name="expression">The path to the member for which to receive metadata.</param>
        /// <returns>A <see cref="string"/> representing the description of the 
        /// <typeparamref name="T"/> member, if defined, else null.</returns>
        public static string? DescriptionFor<T>(
            this IModelMetadataService metadata, Expression<Func<T, object>> expression)
        {
            if (metadata is null)
                return null;

            string memberName = GetMemberInfo(expression).Name;

            string s = metadata.DescriptionFor<T>(memberName);
            return s;
        }

        /// <summary>
        /// Gets the display name of the member matching the desitination of the given expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="metadata"></param>
        /// <param name="expression">The path to the member for which to receive metadata.</param>
        /// <returns>A <see cref="string"/> representing the display name of the 
        /// <typeparamref name="T"/> member, if defined, else the name of the member.</returns>
        public static string NameFor<T>(
            this IModelMetadataService metadata, Expression<Func<T, object>> expression)
        {
            if (metadata is null)
                return null;

            // Get the member info.
            MemberInfo memberInfo = GetMemberInfo(expression);

            // Get the defined name, if it exists.
            string s = metadata.NameFor<T>(memberInfo.Name);

            // Coalesce nulls into the member name, if applicable.
            string returnStr = string.IsNullOrEmpty(s) ? memberInfo.Name : s;

            return returnStr;
        }

        /// <summary>
        /// Gets the <see cref="NounAttribute"/> attached to the declarying type of the member  
        /// matching the destination of the given expression.
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="expression">The path to the member for which to receive metadata.</param>
        /// <returns>A <see cref="NounAttribute"/> instance, if defined, else null.</returns>
        public static NounAttribute NounFor(
            this IModelMetadataService metadata, 
            Expression<Func<TargetException, object>> expression)
        {
            if (metadata is null)
                return null;

            // Get the member info.
            MemberInfo memberInfo = GetMemberInfo(expression);

            // Get the defined name, if it exists.
            return metadata.NounFor(memberInfo.DeclaringType);
        }

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

        /// <summary>
        /// Gets the <see cref="MemberInfo"/> instance from the given <see cref="Expression{Func{T, object}}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns>An instance of <see cref="MemberInfo"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception> 
        /// <exception cref="NotSupportedException"></exception>
        private static MemberInfo GetMemberInfo<T>(Expression<Func<T, object>> expression)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            LambdaExpression lambda = expression;
            if (lambda is null)
                throw new NotSupportedException();

            MemberExpression memberExpr = lambda.Body.NodeType switch
            {
                ExpressionType.Convert => ((UnaryExpression)lambda.Body).Operand as MemberExpression,
                ExpressionType.MemberAccess => lambda.Body as MemberExpression,
                _ => throw new NotSupportedException()
            };

            return memberExpr.Member;
        }
    }
}
