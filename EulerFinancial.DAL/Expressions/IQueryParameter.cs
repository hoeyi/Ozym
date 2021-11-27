using System;

namespace EulerFinancial.Expressions
{
    /// <summary>
    /// Reprsents a paramter used to filter search results.
    /// </summary>
    /// <typeparam name="T">The member type to be evaluated.</typeparam>
    public interface IQueryParameter<TModel>
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
        string Value { get; }
    }


}
