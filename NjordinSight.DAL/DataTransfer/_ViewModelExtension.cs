using System;
using System.Collections.Generic;
using System.Linq;

namespace NjordinSight.DataTransfer
{
    /// <summary>
    /// Extensions methods used by the Model.ViewModel namespace.
    /// </summary>
    static class ViewModelExtension
    {
        /// <summary>
        /// Returns the maximum value found in the collection using the given selector, or the 
        /// default of <typeparamref name="TValue"/> if the collection is empty.
        /// </summary>
        /// <typeparam name="TModel">The type contained in the enumerable.</typeparam>
        /// <typeparam name="TValue">The type of the member that is the target of the selector.</typeparam>
        /// <param name="enumerable">The enumerable being queried.</param>
        /// <param name="selector">The delegate that returns the targeted member.</param>
        /// <returns>A <typeparamref name="TValue"/> with value equal to the maximum in the collection, 
        /// or the default value if the collection is empty.</returns>
        public static TValue MaxOrDefault<TModel, TValue>(
        this IEnumerable<TModel> @enumerable,
            Func<TModel, TValue> selector) => enumerable.Any() ? enumerable.Max(selector) : default;
    }
}
