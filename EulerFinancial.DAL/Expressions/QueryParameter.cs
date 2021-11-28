using System;

namespace EulerFinancial.Expressions
{
    public class QueryParameter<TModel> : IQueryParameter<TModel>
    {
        public QueryParameter(string memberName, ComparisonOperator @operator, string paramValue)
        {
            if (string.IsNullOrEmpty(memberName))
                throw new ArgumentNullException(Resources.ExceptionString.Validation_SearchMember_IsNull);

            MemberName = memberName;
            Operator = @operator;
            Value = paramValue;
        }

        public Type SearchObjectType { get => typeof(TModel); }

        public string MemberName { get; }

        public ComparisonOperator Operator { get; }

        public string Value { get; }
    }
}
