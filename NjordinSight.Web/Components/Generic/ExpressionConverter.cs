using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Reflection;

namespace NjordinSight.Web.Components.Generic
{
    /// <summary>
    /// Helper static methods converting expressions.
    /// </summary>
    static class ExpressionConverter
    {
        /// <summary>
        /// Converts the given expression to a parameterized expression with input type 
        /// <typeparamref name="T"/> and output type <typeparamref name="TValue"/>.
        /// </summary>
        /// <typeparam name="T">The input type.</typeparam>
        /// <typeparam name="TValue">The output type.</typeparam>
        /// <param name="accessor">The expression to convert.</param>
        /// <returns>An <see cref="Expression{TDelegate}"/> of <see cref="Func{T, TResult}"/> 
        /// having <typeparamref name="T"/> input and <typeparamref name="TValue"/> output.</returns>
        /// <exception cref="ArgumentException">Conversion method for <paramref name="accessor"/> 
        /// could not be determined.</exception>
        public static Expression<Func<T, TValue>> ConvertAccessor<T, TValue>(
            Expression<Func<TValue>> accessor)
        {
            // Check the result for a unary expression. Might be fixed by not passing an
            // Expression<Func<object>> as the accessor paramter.
            if (accessor.Body is UnaryExpression unary &&
                (unary.NodeType == ExpressionType.Convert ||
                (unary.NodeType == ExpressionType.ConvertChecked)))
            {
                // Assume the body is not a nested complex member. Applies in situations 
                // where a direct member of T is a System.DateTime object. Not entirely sure
                // why this is necessary, but resolves exception related to it.
                FieldIdentifier fieldIdentifier = FieldIdentifier.Create(accessor);

                if (fieldIdentifier.Model.GetType() != typeof(T))
                    throw new ArgumentException();

                ParameterExpression paramExpression = Expression
                    .Parameter(typeof(T), "x");

                Expression expression = Expression.Convert(
                    Expression.Property(paramExpression, propertyName: fieldIdentifier.FieldName),
                    typeof(TValue));

                var parameterizedExpression = Expression
                    .Lambda<Func<T, TValue>>(expression, paramExpression);

                return parameterizedExpression;
            }

            // Check to see if the accessor nested complex members.
            else if (accessor.Body is MemberExpression memberExpression)
            {
                List<MemberInfo> memberList = new();

                var expressionPath = GetNestedExpressionPath(memberExpression, memberList);

                ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
                Expression expression = BuildExpression(parameterExpression, memberList);

                var parameterizedExpression = Expression.Lambda<Func<T, TValue>>(
                    expression, parameterExpression);

                return parameterizedExpression;
            }
            throw new ArgumentException();

        }

        /// <summary>
        /// Creates an instance of <see cref="Expression"/> from the given 
        /// <see cref="ParameterExpression"/> and <see cref="MemberInfo"/> list. 
        /// </summary>
        /// <param name="parameterExpression"></param>
        /// <param name="memberInfoList">The <see cref="List{T}"/> of <see cref="MemberInfo"/> 
        /// representing the ordered path to the </param>
        /// <returns>An instance of <see cref="Expression"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
        private static Expression BuildExpression(
            ParameterExpression parameterExpression,
            List<MemberInfo> memberInfoList)
        {
            if (memberInfoList.Count == 0)
                throw new ArgumentException($"Parameter {nameof(memberInfoList)} cannot be empty.");

            Expression expressionLeft = Expression.Property(
                parameterExpression, memberInfoList[0].Name);

            foreach (var memberInfo in memberInfoList.GetRange(1, memberInfoList.Count - 1))
            {
                expressionLeft = Expression.Property(expressionLeft, memberInfo.Name);
            }

            return expressionLeft;
        }

        /// <summary>
        /// Recursively collects the <see cref="MemberInfo"/> instances traversed in a complex 
        /// <see cref="MemberExpression"/>, then returns reverses the order of the list.
        /// </summary>
        /// <param name="memberExpression">The member expression to traverse.</param>
        /// <param name="memberList">The list instance of <see cref="MemberInfo"/> to which 
        /// results are appended.</param>
        /// <param name="recursionCount">A counter incrementing for each call to this method. Breaker</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"><paramref name="recursionCount"/> was less than zero.</exception>
        /// <exception cref="ArgumentException">Max recursion limit reached.</exception>
        /// <remarks>
        /// <list type="bullet">
        /// <item>Checks on nested member depth are not done. A recursive call beyond 5 will 
        /// result in an exception.</item>
        /// <item>Recursion may not be ideal for this purpose. Consider a for loop with a stack 
        /// structure instead.</item>
        /// </list>
        /// </remarks>
        private static List<MemberInfo> GetNestedExpressionPath(
            MemberExpression memberExpression,
            List<MemberInfo> memberList,
            int recursionCount = 0)
        {
            if (recursionCount < 0)
                throw new InvalidOperationException($"Recursion count cannot be less than zero.");

            if (recursionCount == 5)
                throw new ArgumentException($"Recursion limit of {5} reached.");

            memberList.Add(memberExpression.Member);

            // If the given expression has a child member expression, continue the 
            // call the method with an incremented recursion count.
            if (memberExpression.Expression is MemberExpression childMemberExpression
                && childMemberExpression!.Expression?.NodeType != ExpressionType.Constant)
                return GetNestedExpressionPath(childMemberExpression, memberList, ++recursionCount);
            else
            {
                // List items will apear with the selected member as the first index moving 
                // backwards to the input type. Reverse the list to traverse the path building from 
                // left to right.
                memberList.Reverse();

                return memberList;
            }
        }
    }
}
