using Ichosys.DataModel.Expressions;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Linq.Expressions;

namespace NjordinSight.Web.Components.Common
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
            IQueryParameter<TModel> parameter)
        {
            MouseEventArgs = mouseEventArgs;
            Parameter = parameter;
        }

        public MouseEventArgs MouseEventArgs { get; init; }

        public IQueryParameter<TModel> Parameter { get; init; }

    }
}
