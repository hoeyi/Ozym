using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model
{
    /// <summary>
    /// Represents the supported values for <see cref="ModelAttributeScope.ScopeCode"/>.
    /// </summary>
    public enum AttributeScopeCode
    {
        [EnumMember(Value = "acc")]
        Account,

        [EnumMember(Value = "bnk")]
        BankTransactionCode,

        [EnumMember(Value = "brk")]
        BrokerTransactionCode,

        [EnumMember(Value = "cou")]
        Country,

        [EnumMember(Value = "cus")]
        Custodian,
        
        [EnumMember(Value = "exc")]
        Exchange,

        [EnumMember(Value = "sec")]
        Security
    }
}
