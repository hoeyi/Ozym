using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Ozym.EntityModelService.Abstractions
{
    /// <summary>
    /// Container class for expression extensions.
    /// </summary>
    public static class ExpressionExtension
    {
        /// <summary>
        /// Joins the given expression with an AND operator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> AndAlso<T>(
                this Expression<Func<T, bool>> expr1,
                Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(left, right), parameter);
        }

        /// <inheritdoc/>
        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                    return _newValue;
                return base.Visit(node);
            }
        }


        public static Expression<Func<T, bool>> GetKeyExpression<T>(this T model)
        {
            var keyProperties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p =>
                    {
                        return new
                        {
                            Property = p,
                            KeyAttribute = p.GetCustomAttribute<KeyAttribute>(),
                            ColumnAttribute = p.GetCustomAttribute<ColumnAttribute>()
                        };
                    })
                .Where(p => p.KeyAttribute is not null && p.ColumnAttribute is not null)
                .OrderBy(p => p.ColumnAttribute.Order)
                .ToArray();

            Expression<Func<T, bool>> expression = default;
            foreach(var keyProp in keyProperties)
            {
                if (expression is null)
                    expression = GetExpression<T>(
                        property: keyProp.Property, 
                        keyValue: keyProp.Property.GetValue(model));
                else
                    expression = expression.AndAlso(
                        GetExpression<T>(
                            property: keyProp.Property,
                            keyValue: keyProp.Property.GetValue(model)));
            }

            return expression;

        }

        private static Expression<Func<T, bool>> GetExpression<T>(PropertyInfo property, object keyValue)
        {
            // Get the first property info that matches the expected type and has 
            // the key attribute applied.

            // Construct the base elements of the left-hand side of the expression.
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
            Expression expressionLeft = Expression.Property(parameterExpression, propertyName: property.Name);
            Expression expressionRight = Expression.Constant(keyValue, property.PropertyType);

            Expression expression = Expression.Equal(expressionLeft, expressionRight);

            return Expression.Lambda<Func<T, bool>>(expression, parameterExpression);
        }

    }
}
