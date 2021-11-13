using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace EulerFinancial.Expressions
{
    class SearchStringParser<T>
    {

        public static Expression<Func<T,bool>> Parse(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                throw new ArgumentNullException(paramName: nameof(searchString));

            try
            {
                PropertyInfo propertyInfo = ParseSearchMember(searchString);
                ParameterExpression paramExpression = Expression.Parameter(typeof(T));
                MemberExpression memberExpression = Expression.Property(paramExpression, propertyInfo);
                ConstantExpression constantExpression = ParseSearchConstant(searchString, propertyInfo.PropertyType);
                string methodName = GetExpressionMethodName(propertyInfo.PropertyType);
                Expression expression = Expression.Call(memberExpression, methodName, null, constantExpression);

                return Expression.Lambda<Func<T, bool>>(expression, paramExpression);
            }
            catch(Exception e)
            {
                throw new ParseException(message: string.Format(
                    Resources.ExceptionString.Search_Parse, searchString), e);
            }
        }

        private static ConstantExpression ParseSearchConstant(string searchString, Type expectedType)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(paramName: nameof(searchString));
            }
            if(expectedType is null)
            {
                throw new ArgumentNullException(paramName: nameof(expectedType));
            }

            string[] elements = searchString.Split(':');
            string searchElement = elements[1].Trim();
            
            switch (expectedType.FullName)
            {
                case "System.String":
                    return Expression.Constant(searchElement, expectedType);
                case "System.DateTime":

                    bool searchValueIsValid = Validation.InputValidator.InputIsValid(
                            searchElement,
                            expectedType,
                            out object parsedSearchValue, out _);

                    if (searchValueIsValid)
                    {
                        return Expression.Constant(parsedSearchValue, expectedType);
                    }
                    else
                    {
                        throw new ArgumentException(nameof(searchString));
                    }
                default:
                    throw new NotImplementedException($"{expectedType}");
            }
        }
        private static PropertyInfo ParseSearchMember(string searchString)
        {
            string[] elements = searchString.Split(':');
            string propertyDisplayName = elements[0];

            PropertyInfo propertyInfo = typeof(T).GetProperties()
                .Where(p =>
                    Resources.ResourceHelper.GetDisplayName(typeof(T), p.Name) ==
                        propertyDisplayName.ToLower()).First();
            return propertyInfo;
        }
        private static string GetExpressionMethodName(Type type)
        {
            Dictionary<Type, string> methodLookup = new Dictionary<Type, string>()
            {
                { typeof(string),"Contains" },
                { typeof(DateTime), "Equals" },
                { typeof(DateTime?), "Equals" }
            };
            methodLookup.TryGetValue(type, out string value);

            return value;
        }
    }
}
