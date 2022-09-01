using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.ModelService
{
    /// <summary>
    /// Extension methods for simplifying query building.
    /// </summary>
    public static class QueryExtensions
    {
        /// <summary>
        /// Converts this <see cref="ModelAttributeScopeCode"/> to an array of the string 
        /// representations for each included flag.
        /// </summary>
        /// <param name="scopeCodes"></param>
        /// <returns>A <see cref="string[]"/> containing the codes representing each flag.</returns>
        public static string[] ToStringArray(this ModelAttributeScopeCode scopeCodes) =>
            Enum
            .GetValues(typeof(ModelAttributeScopeCode))
            .Cast<Enum>()
            .Where(scopeCodes.HasFlag)
            .Cast<ModelAttributeScopeCode>()
            .Select(m => m.ConvertToStringCode())
            .ToArray();
    }
}
