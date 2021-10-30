using System;
using System.Collections.Generic;

#nullable disable

namespace EulerFinancial.Data.Model
{
    public partial class SecuritySymbol
    {
        public SecuritySymbol()
        {
            SecuritySymbolMaps = new HashSet<SecuritySymbolMap>();
        }

        public int SymbolId { get; set; }
        public int SecurityId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public int SymbolTypeId { get; set; }
        public string SymbolCode { get; set; }
        public string Cusip { get; set; }
        public string CustomSymbol { get; set; }
        public string OptionTicker { get; set; }
        public string Ticker { get; set; }

        public virtual Security Security { get; set; }
        public virtual SecuritySymbolType SymbolType { get; set; }
        public virtual ICollection<SecuritySymbolMap> SecuritySymbolMaps { get; set; }
    }
}
