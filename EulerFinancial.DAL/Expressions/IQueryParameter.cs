using System;

namespace EulerFinancial.Expressions
{
    /// <summary>
    /// Reprsents a paramter used to filter search results.
    /// </summary>
    /// <typeparam name="T">The member type to be evaluated.</typeparam>
    public interface IQueryParameter<TModel, TParam>
    {
        /// <summary>
        /// The type of object being searched.
        /// </summary>
        Type SearchObjectType { get; }
        /// <summary>
        /// The name of the member to which the search value is compared.
        /// </summary>
        string MemberName { get; }
        
        /// <summary>
        /// The comparison operator to use.
        /// </summary>
        ComparisonOperator Operator { get; }

        /// <summary>
        /// The value the matching member is to be compared to.
        /// </summary>
        TParam Value { get; }
    }

    public class QueryParameter<TModel, TParam> : IQueryParameter<TModel, TParam>
    {
        public QueryParameter(string memberName, ComparisonOperator @operator, TParam paramValue)
        {
            if(SearchObjectType?.GetProperty(memberName) is null)
            {
                var invalidMemberMessage = string.Format(Resources.ExceptionString.Search_ParameterNotValidForType,
                    memberName ?? Resources.Adjective.Empty, SearchObjectType.Name);

                throw new InvalidOperationException(message: invalidMemberMessage);
            }
            MemberName = memberName;
            Operator = @operator;
            Value = paramValue;
        }

        public Type SearchObjectType { get => typeof(TModel); }

        public string MemberName { get; }

        public ComparisonOperator Operator { get; }

        public TParam Value { get; }
    }
}
