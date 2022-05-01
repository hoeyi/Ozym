using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="SecuritySymbolType"/>.
    /// </summary>
    public class SecuritySymbolTypeMetadata
    {
    }

    [MetadataType(typeof(SecuritySymbolTypeMetadata))]
    public partial class SecuritySymbolType
    {
        internal SecuritySymbolType(int symbolTypeId, string symbolTypeName)
        {
            SymbolTypeId = symbolTypeId;
            SymbolTypeName = symbolTypeName;
        }
    }
}
