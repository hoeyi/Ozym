using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using EulerFinancial.Model.Annotations;

namespace EulerFinancial.Expressions
{
    public static class ExpressionBuilder
    {
        /// <summary>
        /// Creates a reference collection of searchable fields that are members or nested members 
        /// of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>An <see cref="IDictionary{TKey, TValue}"/> where <see cref="IDictionary{TKey, TValue}.Keys"/> 
        /// reprsent the completed nested name of the searchable property, and <see cref="IDictionary{TKey, TValue}.Values"/> are
        /// the display names of those properites. Direct members have no prefix to their key; nested members are prefixed with 
        /// the complete navigation property name, e.g., DirectPropertyName.NestedPropertyName.
        /// </returns>
        public static IDictionary<string, string> GetSearchablePropertyLookup<T>()
            where T : class, new()
        {
            var type = typeof(T);

            var searchableMetadata = GetSearchableMetadata<T>();
            var query = from s in searchableMetadata
                        select new
                        {
                            MemberName = (string.IsNullOrEmpty(s.Item1?.Name) ? string.Empty : $"{s.Item1.Name}.") + s.Item2,
                            DisplayName = Resources.ResourceHelper.GetDisplayName(s.Item1?.PropertyType ?? type, s.Item2)
                        };

            // Return dictionary where the keys are '{Type.Name}.{Member.Name}' and the values are the display names for
            // those members.
            return query.ToDictionary(q => q.MemberName, q => q.DisplayName);
        }

        /// <summary>
        /// Creates a reference collection of search comparison operators and their display names.
        /// </summary>
        /// <returns>A <see cref="IDictionary{TKey, TValue}"/> where <see cref="IDictionary{TKey, TValue}.Keys"/> 
        /// are <see cref="ComparisonOperator"/> and <see cref="IDictionary{TKey, TValue}.Values"/> are string their string representations.</returns>
        public static IDictionary<ComparisonOperator, string> GetComparisonOperatorLookup()
        {
            var members = Enum.GetValues(typeof(ComparisonOperator))
                .Cast<ComparisonOperator>()
                .ToDictionary(m => m, m => Resources.ResourceHelper.GetExpressionString(name: $"{m}"));

            return members;
        }

        /// <summary>
        /// Creates a dynamic <see cref="Expression{TDelegate}"/> of <see cref="Func{T, TResult}"/>
        /// where <typeparamref name="TModel"/> is the query object type and <paramref name="queryParameter"/> 
        /// is the instance containing the query parameter information.
        /// </summary>
        /// <typeparamref name="TModel"></typeparamref>
        /// <param name="queryParameter">The instance carrying the query parameter information.</param>
        /// <returns>An <see cref="Expression{TDelegate}"/> with <typeparamref name="TModel"/> input type and <see cref="bool"/> return type.</returns>
        public static Expression<Func<TModel,bool>> GetExpression<TModel>(
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
                expressionRight = ParseSearchConstant(value: queryParameter.Value, type: outerPropertyInfo.PropertyType);

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
                expressionRight = ParseSearchConstant(value: queryParameter.Value, type: innerPropertyInfo.PropertyType);

                // Conver the right-hand side to the appropriate type. Handles support for nullable property types.
                expressionRight = Expression.Convert(expressionRight, type: innerPropertyInfo.PropertyType);
            }
            else
            {
                throw new NotSupportedException(message: Resources.ExceptionString.Expression_NestingNotSupported);
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

                    _ => throw new InvalidOperationException(),
                };

                return Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);
            }
            catch(Exception e)
            {
                throw new ParseException(message: Resources.ExceptionString.Expression_General_Invalid, e);
            }
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

            // Get the underlying type if property type is nullable.
            var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

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
                ComparisonOperator.Contains
            };

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
                        Resources.ExceptionString.Expression_Parameter_InvalidMethod, 
                        Resources.ResourceHelper.GetExpressionString(name: $"{@operator}"),
                        Resources.ResourceHelper.GetDisplayName(property.DeclaringType, property.Name)));
        }
        
        /// <summary>
        /// Creates an enumerable collection of property metadata from a class <typeparamref name="T"/> 
        /// and child properties whose type has the <see cref="SearchableAttribute"/> attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Tuple{T1, T2}"/>, where <see cref=Tuple{T1, T2}.Item1"/>
        /// is the searchable property, and <see cref="Tuple{T1, T2}.Item2"/> is the dipslay name of the property.</returns>
        private static IEnumerable<Tuple<PropertyInfo, string>> GetSearchableMetadata<T>()
            where T : class, new()
        {
            var type = typeof(T);
            var searchableMembers = (from prop in type.GetProperties()
                                     select new
                                     {
                                         PropertyInfo = prop,
                                         SearchableAttribute = prop.PropertyType.GetCustomAttribute<SearchableAttribute>()
                                     })
                                    .Where(prop => prop.SearchableAttribute is not null)
                                    .ToDictionary(prop => prop.PropertyInfo, prop => prop.SearchableAttribute);


            var flattenedSearchMembers = searchableMembers.SelectMany(p => p.Value.SearchableMembers.Select(s => new Tuple<PropertyInfo, string>(p.Key, s)))
                .Concat(type.GetCustomAttribute<SearchableAttribute>()?.SearchableMembers.Select(s => new Tuple<PropertyInfo, string>(null, s)));

            return flattenedSearchMembers.Select(sm => new Tuple<PropertyInfo, string>(sm.Item1, sm.Item2));
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
                    Resources.ResourceHelper.Culture.DateTimeFormat.ShortDatePattern,
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
                    provider: Resources.ResourceHelper.Culture,
                    style: DateTimeStyles.None,
                    out DateTime result))

                    return result;
            }

            return null;
        }
    }
}
