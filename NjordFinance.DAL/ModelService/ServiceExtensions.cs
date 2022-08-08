using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.ModelService
{
    public static class QueryExtensions
    {
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
