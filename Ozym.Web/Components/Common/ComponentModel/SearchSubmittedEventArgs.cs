using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Components.Web;
using Ozym.DataTransfer.Common.Query;
using System;
using System.Linq.Expressions;

namespace Ozym.Web.Components.Common
{
    /// <summary>
    /// Class the contains event data from a search submission event.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class SearchSubmittedEventArgs<TModel> : EventArgs
    {
        public readonly Expression<Func<TModel, bool>> SearchExpression;

        public SearchSubmittedEventArgs(
            MouseEventArgs mouseEventArgs,
            Expression<Func<TModel, bool>> searchExpression)
        {
            SearchExpression = searchExpression;
            MouseEventArgs = mouseEventArgs;
        }

        public SearchSubmittedEventArgs(
            MouseEventArgs mouseEventArgs,
            ParameterDto<TModel> parameter)
        {
            MouseEventArgs = mouseEventArgs;
            Parameter = parameter;
        }

        public MouseEventArgs MouseEventArgs { get; init; }

        public ParameterDto<TModel> Parameter { get; init; }

    }
}
