using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Test.ViewModel
{
    internal static class ViewModelTestHelper
    {
        /// <summary>
        /// Adds each element in the <paramref name="values"/> parameter to the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="values"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddEach<T>(this IList<T> list, IEnumerable<T> values)
        {
            if (list is null)
                throw new ArgumentNullException(paramName: nameof(list));

            if (values is null)
                throw new ArgumentNullException(paramName: nameof(values));

            foreach (var value in values)
                list.Add(value);
        }
    }
}
