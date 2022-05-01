using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="SecurityType"/>.
    /// </summary>
    public class SecurityTypeMetadata
    {
    }

    [MetadataType(typeof(SecurityTypeMetadata))]
    public partial class SecurityType
    {
        internal SecurityType(
            int securityTypeId,
            int securityTypeGroupId,
            string securityTypeName,
            decimal valuationFactor, 
            bool canHavePosition,
            bool canHaveDerivative)
        {
            SecurityTypeId = securityTypeId;
            SecurityTypeGroupId = securityTypeGroupId;
            SecurityTypeName = securityTypeName;
            ValuationFactor = valuationFactor;
            CanHavePosition = canHavePosition;
            CanHaveDerivative = canHaveDerivative;
        }
    }
}
