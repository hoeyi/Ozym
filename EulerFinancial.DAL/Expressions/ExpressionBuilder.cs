using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using EulerFinancial.Model.Annotations;
using EulerFinancial.Model;
using EulerFinancial.Resources;

namespace EulerFinancial.Expressions
{
    #region IExpressionBuilder implementation
    /// <summary>
    /// Represents a helper class for building filter expressions.
    /// </summary>
    public partial class ExpressionBuilder : IExpressionBuilder
    {
        public IDictionary<ComparisonOperator, string> GetComparisonOperatorLookup()
        {
            var members = Enum.GetValues(typeof(ComparisonOperator))
                .Cast<ComparisonOperator>()
                .ToDictionary(m => m, m => ResourceHelper.GetAdjective(name: $"{m}"));

            return members;
        }

        public Expression<Func<TModel,bool>> GetExpression<TModel>(
            IQueryParameter<TModel> queryParameter)
        {
            var type = typeof(TModel);
            var memberInfo = queryParameter.MemberName.Split(".");

            PropertyInfo outerPropertyInfo = type.GetProperty(memberInfo[0]);

            // Construct the base elements of the left-hand side of the expression.
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "x");
            Expression expressionLeft = Expression.Property(parameterExpression, propertyName: outerPropertyInfo.Name);
            Expression expressionRight;

            // Handle direct class member scenario.
            if(memberInfo.Length == 1)
            {
                // Check query parameter information is supported.
                ValidateOrThrow(queryParameter.Operator, outerPropertyInfo);

                // Build right-hand side with the search value.
                expressionRight = queryParameter.Operator == ComparisonOperator.IsNull || queryParameter.Operator == ComparisonOperator.IsNotNull ?
                    Expression.Constant(null) : ParseSearchConstant(value: queryParameter.Value, type: outerPropertyInfo.PropertyType);

                // Conver the right-hand side to the appropriate type. Handles support for nullable property types.
                expressionRight = Expression.Convert(expressionRight, type: outerPropertyInfo.PropertyType);
            }

            // Handles single-level nested class member scenario.
            else if(memberInfo.Length == 2)
            {
                PropertyInfo innerPropertyInfo = outerPropertyInfo.PropertyType.GetProperty(memberInfo[1]);

                // Check query parameter information is supported.
                ValidateOrThrow(queryParameter.Operator, innerPropertyInfo);

                // Add the inner property to the left-hand side of the expression.
                expressionLeft = Expression.Property(expressionLeft, propertyName: innerPropertyInfo.Name);

                // Build right-hand side with the search value.
                expressionRight = queryParameter.Operator == ComparisonOperator.IsNull || queryParameter.Operator == ComparisonOperator.IsNotNull ?
                    Expression.Constant(null) : ParseSearchConstant(value: queryParameter.Value, type: innerPropertyInfo.PropertyType);

                // Conver the right-hand side to the appropriate type. Handles support for nullable property types.
                expressionRight = Expression.Convert(expressionRight, type: innerPropertyInfo.PropertyType);
            }
            else
            {
                throw new NotSupportedException(message: ExceptionString.Expression_NestingNotSupported);
            }

            try
            {
                // Combine the left- and right-hand sides with the appropriate method.
                Expression expression = queryParameter.Operator switch
                {
                    ComparisonOperator.EqualTo => Expression.Equal(expressionLeft, expressionRight),
                    ComparisonOperator.NotEqualTo => Expression.NotEqual(expressionLeft, expressionRight),
                    ComparisonOperator.GreaterThan => Expression.GreaterThan(expressionLeft, expressionRight),
                    ComparisonOperator.GreaterThanOrEqualTo => Expression.GreaterThanOrEqual(expressionLeft, expressionRight),
                    ComparisonOperator.LessThan => Expression.LessThan(expressionLeft, expressionRight),
                    ComparisonOperator.LessThanOrEqualTo => Expression.LessThanOrEqual(expressionLeft, expressionRight),
                    ComparisonOperator.Contains => Expression.Call(expressionLeft, nameof(string.Contains), null, expressionRight),
                    ComparisonOperator.IsNull => Expression.Equal(expressionLeft, expressionRight),
                    ComparisonOperator.IsNotNull => Expression.NotEqual(expressionLeft, expressionRight),

                    _ => throw new InvalidOperationException(),
                };

                return Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);
            }
            catch(Exception e)
            {
                throw new ParseException(message: ExceptionString.Expression_General_Invalid, e);
            }
        }

        public IEnumerable<ModelMemberMetadata> GetSearchableMemberMetadata<T>()
            where T : class, new()
        {
            var type = typeof(T);

            var searchMembers = GetSearchableMembers(type).Select(s => new ModelMemberMetadata(
                declaringMemberName: $"{type.Name}.{s.Name}",
                qualifiedMemberName: $"{s.Name}",
                displayName: ResourceHelper.GetModelDisplayName(type, s.Name),
                description: ResourceHelper.GetModelDescription(type, s.Name),
                displayOrder: default));

            var nestedSearchMembers = (from p in type.GetProperties()
                                       select p)
                                        .SelectMany(p => GetSearchableMembers(p.PropertyType)
                                            .Select(s => new ModelMemberMetadata(
                                                declaringMemberName: $"{s.DeclaringType.Name}.{s.Name}",
                                                qualifiedMemberName: $"{p.Name}.{s.Name}",
                                                displayName: ResourceHelper.GetModelDisplayName(s.DeclaringType, s.Name),
                                                description: ResourceHelper.GetModelDescription(s.DeclaringType, s.Name),
                                                displayOrder: default)));

            return searchMembers.Concat(nestedSearchMembers).ToArray();
        }
    }
    #endregion

    public partial class ExpressionBuilder
    {
        /// <summary>
        /// Returns the names of the searchable members for the given type.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> decorated with <see cref="SearchableAttribute"/>.</param>
        /// <returns>An enumerable collection of strings, one for each member name.</returns>
        private static IEnumerable<PropertyInfo> GetSearchableMembers(Type type)
        {
            var searchMembers = (from s in type.GetCustomAttribute<SearchableAttribute>()?.SearchableMembers ?? Array.Empty<string>()
                                 join p in type.GetProperties() on s equals p.Name
                                 select p);

            return searchMembers.ToArray();
        }

        /// <summary>
        /// Creates a constant (RHS) expression given a string and expected type.
        /// </summary>
        /// <param name="value">The string representation the constant value.</param>
        /// <param name="type">The type to which the <paramref name="value"/> will be converted.</param>
        /// <returns>A <see cref="ConstantExpression"/> representing the right-hand side of a comparison.</returns>
        private static ConstantExpression ParseSearchConstant(string value, Type type)
        {
            // Adjust the parameter type for nullable data types.
            var parameterType = Nullable.GetUnderlyingType(type) ?? type;

            return parameterType.FullName switch
            {
                "System.String" => Expression.Constant(value: value, type: parameterType),
                "System.DateTime" => Expression.Constant(value: TryParseDateTime(value.ToString()), type: parameterType),
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// Validates the given <see cref="ComparisonOperator"/> is valid for use with the given <see cref="PropertyInfo"/>.
        /// Throws a <see cref="NotSupportedException"/> if the use is invalid.
        /// </summary>
        /// <param name="operator">The operator to check.</param>
        /// <param name="property">The property to check</param>
        private static void ValidateOrThrow(ComparisonOperator @operator, PropertyInfo property)
        {
            if (property is null)
                throw new ArgumentNullException(paramName: nameof(property));

            var underlyingType = Nullable.GetUnderlyingType(property.PropertyType);

            // Get the underlying type if property type is nullable.
            var type = underlyingType ?? property.PropertyType;
            var typeIsNullable = !(underlyingType is null);

            // Define comparisons valid for numeric types.
            var numericOperators = new ComparisonOperator[]
            {
                ComparisonOperator.EqualTo,
                ComparisonOperator.NotEqualTo,
                ComparisonOperator.GreaterThan,
                ComparisonOperator.GreaterThanOrEqualTo,
                ComparisonOperator.LessThan,
                ComparisonOperator.LessThanOrEqualTo
            };

            // Define comparisons valid for text types.
            var textOperators = new ComparisonOperator[]
            {
                ComparisonOperator.EqualTo,
                ComparisonOperator.NotEqualTo,
                ComparisonOperator.Contains,
                ComparisonOperator.IsNull,
                ComparisonOperator.IsNotNull
            };

            if(typeIsNullable)
            {
                Array.Resize(ref numericOperators, numericOperators.Length + 2);
                numericOperators[numericOperators.Length - 2] = ComparisonOperator.IsNull;
                numericOperators[numericOperators.Length - 1] = ComparisonOperator.IsNotNull;

            }

            

            // Map the types to their supported operators.
            var typeOperatorLookup = new Dictionary<Type, ComparisonOperator[]>()
            {
                { typeof(short), numericOperators },
                { typeof(int), numericOperators },
                { typeof(long), numericOperators },
                { typeof(float), numericOperators },
                { typeof(double), numericOperators },
                { typeof(decimal), numericOperators },
                { typeof(DateTime), numericOperators },

                { typeof(char), textOperators },
                { typeof(string), textOperators },
            };

            // Throw exception if mapped array does not contain the comparison operator, or if 
            // the mapping does not contain the type.
            if (!typeOperatorLookup.ContainsKey(type) ||
                !typeOperatorLookup[type].Contains(@operator))
                throw new NotSupportedException(
                    string.Format(
                        ExceptionString.Expression_Parameter_InvalidMethod,
                        ResourceHelper.GetAdjective(name: $"{@operator}"),
                        ResourceHelper.GetModelDisplayName(property.DeclaringType, property.Name)));
        }
    }

    #region Type-string converters
    public partial class ExpressionBuilder
    {
        /// <summary>
        /// Parses the given string into a <see cref="DateTime?"/> value, using culture-specific
        /// date formats./>.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>A <see cref="DateTime"/> value if parsed successfully, else null.</returns>
        private static DateTime? TryParseDateTime(string s)
        {
            // Specify the list of culture and misc. supported formats.
            var dateFormats =
                new string[]
                {
                    ResourceHelper.Culture.DateTimeFormat.ShortDatePattern,
                    "MM/dd/yyyy",
                    "MMddyyyy",
                    "yyyyMMdd"
                };

            // Check each format and break the loop when the first result is found.
            foreach (var format in dateFormats)
            {
                if (DateTime.TryParseExact(
                    s: s,
                    format: format,
                    provider: ResourceHelper.Culture,
                    style: DateTimeStyles.None,
                    out DateTime result))

                    return result;
            }

            return null;
        }
    }
    #endregion
}
