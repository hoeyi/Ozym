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
        public static IDictionary<string, string> GetSearchFieldLookup<T>()
            where T : class
        {
            var type = typeof(T);
            var searchableMembers = type.GetCustomAttribute<SearchableAttribute>()?.SearchableMembers ?? Array.Empty<string>();
            var query = from p in type.GetProperties().Where(p => searchableMembers.Contains(p.Name))
                         select new
                         {
                             MemberName = p.Name,
                             DisplayName = Resources.ResourceHelper.GetDisplayName(type, p.Name)
                         };

           var queryWhereNotEmpty = query.Where(p => !string.IsNullOrEmpty(p.DisplayName));


            return queryWhereNotEmpty.ToDictionary(p => p.MemberName, p => p.DisplayName);
        }

        public static IDictionary<ComparisonOperator, string> GetComparisonOperatorLookup()
        {
            var members = Enum.GetValues(typeof(ComparisonOperator))
                .Cast<ComparisonOperator>()
                .ToDictionary(m => m, m => Resources.ResourceHelper.GetExpressionString(name: $"{m}"));

            return members;
        }

        public static Expression<Func<TModel, bool>> GetExpression<TModel>(
            IQueryParameter<TModel> queryParameter)
        {
            try
            {
                PropertyInfo propertyInfo = GetSearchMember<TModel>(queryParameter.MemberName);
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), queryParameter.MemberName);
                MemberExpression memberExpression = Expression.Property(parameterExpression, property: propertyInfo);
                //ConstantExpression constantExpression = Expression
                //    .Constant(value: queryParameter.Value, queryParameter.Value.GetType());

                ConstantExpression constantExpression = ParseSearchConstant(queryParameter.Value, propertyInfo.PropertyType);

                Expression expression = queryParameter.Operator switch
                {
                    ComparisonOperator.EqualTo => Expression.Equal(memberExpression, constantExpression),
                    ComparisonOperator.NotEqualTo => Expression.NotEqual(memberExpression, constantExpression),
                    ComparisonOperator.GreaterThan => Expression.GreaterThan(memberExpression, constantExpression),
                    ComparisonOperator.GreaterThanOrEqualTo => Expression.GreaterThanOrEqual(memberExpression, constantExpression),
                    ComparisonOperator.LessThan => Expression.LessThan(memberExpression, constantExpression),
                    ComparisonOperator.LessThanOrEqualTo => Expression.LessThanOrEqual(memberExpression, constantExpression),
                    ComparisonOperator.Contains => Expression.Call(memberExpression, nameof(string.Contains), null, constantExpression),

                    _ => throw new InvalidOperationException(),
                };
                //Expression expression = Expression.Call(memberExpression, methodName, null, constantExpression);

                return Expression.Lambda<Func<TModel, bool>>(expression, parameterExpression);
            }
            catch (Exception e)
            {
                throw new ParseException(message: Resources.ExceptionString.Search_General_Invalid, e);
            }
        }
        private static Expression<Func<TModel, bool>> GetExpressionOld<TModel>(
            IQueryParameter<TModel> queryParameter)
        {
            try
            {
                PropertyInfo propertyInfo = GetSearchMember<TModel>(queryParameter.MemberName);
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), queryParameter.MemberName);
                MemberExpression memberExpression = Expression.Property(parameterExpression, property: propertyInfo);
                //ConstantExpression constantExpression = Expression
                //    .Constant(value: queryParameter.Value, queryParameter.Value.GetType());

                ConstantExpression constantExpression = ParseSearchConstant(queryParameter.Value, propertyInfo.PropertyType);

                Expression expression = queryParameter.Operator switch
                {
                    ComparisonOperator.EqualTo => Expression.Equal(memberExpression, constantExpression),
                    ComparisonOperator.NotEqualTo => Expression.NotEqual(memberExpression, constantExpression),
                    ComparisonOperator.GreaterThan => Expression.GreaterThan(memberExpression, constantExpression),
                    ComparisonOperator.GreaterThanOrEqualTo => Expression.GreaterThanOrEqual(memberExpression, constantExpression),
                    ComparisonOperator.LessThan => Expression.LessThan(memberExpression, constantExpression),
                    ComparisonOperator.LessThanOrEqualTo => Expression.LessThanOrEqual(memberExpression, constantExpression),
                    ComparisonOperator.Contains => Expression.Call(memberExpression, nameof(string.Contains), null, constantExpression),

                    _ => throw new InvalidOperationException(),
                };
                //Expression expression = Expression.Call(memberExpression, methodName, null, constantExpression);

                return Expression.Lambda<Func<TModel, bool>>(expression);
            }
            catch(Exception e)
            {
                throw new ParseException(message: Resources.ExceptionString.Search_General_Invalid, e);
            }
        }
        public static DateTime? TryParseDateTime(string s)
        {
            var dateFormats =
                new string[]
                {
                    Resources.ResourceHelper.Culture.DateTimeFormat.ShortDatePattern,
                    "MM/dd/yyyy",
                    "MMddyyyy"
                };

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

        private static PropertyInfo GetSearchMember<T>(string name)
        {
            return typeof(T).GetProperty(name);
        }

        private static ConstantExpression ParseSearchConstant(string value, Type type)
        {
            var parameterType = Nullable.GetUnderlyingType(type) ?? type;

            return parameterType.FullName switch
            {
                "System.String" => Expression.Constant(value: value, type: parameterType),
                "System.DateTime" => Expression.Constant(value: TryParseDateTime(value.ToString()), type: parameterType),
                _ => throw new InvalidOperationException()
            };
        }
    }
}
