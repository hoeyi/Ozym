using System;
using System.Linq;

namespace EulerFinancial.Model
{
    public static class SecurityExt
    {
        public static string GetCurrentSymbol(this Security security)
        {
            return security?.SecuritySymbols?.
                Where(s => s.EffectiveDate > DateTime.Now)
                ?.OrderBy(s => s.EffectiveDate)
                ?.FirstOrDefault()
                ?.SymbolCode ?? string.Empty;
        }
    }
}
