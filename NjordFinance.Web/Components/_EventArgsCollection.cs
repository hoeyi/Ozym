using Microsoft.AspNetCore.Components.Web;
using System;
using System.Linq.Expressions;

namespace NjordFinance.Web.Components
{
    /// <summary>
    /// Class the contains event data from a search submission event.
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class SearchSubmittedEventArgs<TModel> : EventArgs
    {
        public readonly Expression<Func<TModel, bool>> SearchExpression;

        public readonly MouseEventArgs MouseEventArgs;

        public SearchSubmittedEventArgs(
            MouseEventArgs mouseEventArgs,
            Expression<Func<TModel, bool>> searchExpression)
        {
            SearchExpression = searchExpression;
            MouseEventArgs = mouseEventArgs;
        }
    }
}
