using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using EulerFinancial.Expressions;
using EulerFinancial.Model;
using System.Linq.Expressions;

namespace EulerFinancial.Test.Expressions
{
    [TestClass]
    public class Expression_Test
    {
        [TestMethod]
        public void GetSearchableAccountMetadata_YieldsInstance()
        {
            var expressionBuilder = new ExpressionBuilder();
            var searchableMetadata = expressionBuilder.GetSearchableMetadata<Account>();

            Assert.IsInstanceOfType(searchableMetadata, typeof(IEnumerable<ModelMetadata>));
        }

        [TestMethod]
        public void GetAccountExpression_YieldsInstance()
        {
            var paramName = nameof(AccountObject.StartDate);
            var paramValue = "12/31/2021";

            var expressionBuilder = new ExpressionBuilder();

            var modelMetadata = expressionBuilder.GetSearchableMetadata<Account>()
                                .Where(m => m.DeclaringMemberName == $"{typeof(AccountObject).Name}.{paramName}")
                                .FirstOrDefault();

            var queryParamter = new QueryParameter<Account>(
                memberName: modelMetadata.QualifiedMemberName, 
                @operator: ComparisonOperator.EqualTo, 
                paramValue: paramValue);

            var expression = expressionBuilder.GetExpression(queryParamter);

            Assert.IsInstanceOfType(expression, typeof(Expression<Func<Account, bool>>));
        }

        [TestMethod]
        public void GetAccountExpression_MemberIsNull_YieldsInstance()
        {
            var paramName = nameof(AccountObject.CloseDate);
            var paramValue = "12/31/2021";

            var expressionBuilder = new ExpressionBuilder();

            var modelMetadata = expressionBuilder.GetSearchableMetadata<Account>()
                                .Where(m => m.DeclaringMemberName == $"{typeof(AccountObject).Name}.{paramName}")
                                .FirstOrDefault();

            var queryParamter = new QueryParameter<Account>(
                memberName: modelMetadata.QualifiedMemberName,
                @operator: ComparisonOperator.IsNull,
                paramValue: paramValue);

            var expression = expressionBuilder.GetExpression(queryParamter);

            Assert.IsInstanceOfType(expression, typeof(Expression<Func<Account, bool>>));
        }
    }
}
