using System.Runtime.Serialization;

namespace NjordFinance.Model
{
    /// <summary>
    /// Represents the supported values for <see cref="ModelAttributeScope.ScopeCode"/>.
    /// </summary>
    public enum ModelAttributeScopeCode
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
