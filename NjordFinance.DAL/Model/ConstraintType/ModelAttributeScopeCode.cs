using System;
using System.Runtime.Serialization;

namespace NjordFinance.Model
{
    /// <summary>
    /// Represents the supported values for <see cref="ModelAttributeScope.ScopeCode"/>.
    /// </summary>
    [Flags]
    public enum ModelAttributeScopeCode
    {
        [EnumMember(Value = "acc")]
        Account = 1,

        [EnumMember(Value = "bnk")]
        BankTransactionCode = 2,

        [EnumMember(Value = "brk")]
        BrokerTransactionCode = 4,

        [EnumMember(Value = "cou")]
        Country = 8,

        [EnumMember(Value = "cus")]
        Custodian = 16,
        
        [EnumMember(Value = "exc")]
        Exchange = 32,

        [EnumMember(Value = "sec")]
        Security = 64
    }
}
