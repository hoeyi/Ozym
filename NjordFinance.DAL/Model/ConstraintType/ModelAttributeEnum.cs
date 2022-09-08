using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model.ConstraintType
{
    /// <summary>
    /// Enumerates the built-in <see cref="ModelAttribute"/> entries.
    /// </summary>
    public enum ModelAttributeEnum
    {
        AssetClass = -10,

        SecurityTypeGroup = -20,

        SecurityType = -30,

        BrokerTransactionCategory = -40,

        BrokerTransactionClass = -50,

        CountryExposure = -60
    }
}
