﻿using System;

namespace EulerFinancial.Expressions
{
    public class QueryParameter<TModel, TParam> : IQueryParameter<TModel, TParam>
    {
        public QueryParameter(string memberName, ComparisonOperator @operator, TParam paramValue)
        {
            if (SearchObjectType?.GetProperty(memberName) is null)
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
