using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines metadata for <see cref="Security"/>.
    /// </summary>
    public class SecurityMetadata
    {
    }

    [MetadataType(typeof(SecurityMetadata))]
    public partial class Security
    {
        /// <summary>
        /// Gets the effective <see cref="SecuritySymbol.SymbolCode"/> for this security 
        /// as of the current date and time.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of the symbol.</returns>
        public string GetCurrentSymbol()
        {
            return SecuritySymbols?.
                Where(s => s.EffectiveDate > DateTime.Now)
                ?.OrderBy(s => s.EffectiveDate)
                ?.FirstOrDefault()
                ?.SymbolCode ?? string.Empty;
        }
    }
}
