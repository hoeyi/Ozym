using NjordFinance.Model.Metadata;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NjordFinance.Model
{
    /// <summary>
    /// Represents the supported values for <see cref="ModelAttributeScope.ScopeCode"/>.
    /// </summary>
    [Flags]
    public enum ModelAttributeScopeCode
    {
        [Display(
            Name = nameof(CheckConstraintDisplay.ModelAttributeScope_Account),
            ResourceType = typeof(CheckConstraintDisplay)
            )]
        [EnumMember(Value = "acc")]
        Account = 1,

        [Display(
            Name = nameof(CheckConstraintDisplay.ModelAttributeScope_BankTransactionCode),
            ResourceType = typeof(CheckConstraintDisplay)
            )]
        [EnumMember(Value = "bnk")]
        BankTransactionCode = 2,

        [Display(
            Name = nameof(CheckConstraintDisplay.ModelAttributeScope_BrokerTransactionCode),
            ResourceType = typeof(CheckConstraintDisplay)
            )]
        [EnumMember(Value = "brk")]
        BrokerTransactionCode = 4,

        [Display(
            Name = nameof(CheckConstraintDisplay.ModelAttributeScope_Country),
            ResourceType = typeof(CheckConstraintDisplay)
            )]
        [EnumMember(Value = "cou")]
        Country = 8,

        [Display(
            Name = nameof(CheckConstraintDisplay.ModelAttributeScope_Custodian),
            ResourceType = typeof(CheckConstraintDisplay)
            )]
        [EnumMember(Value = "cus")]
        Custodian = 16,

        [Display(
            Name = nameof(CheckConstraintDisplay.ModelAttributeScope_Exchange),
            ResourceType = typeof(CheckConstraintDisplay)
            )]
        [EnumMember(Value = "exc")]
        Exchange = 32,

        [Display(
            Name = nameof(CheckConstraintDisplay.ModelAttributeScope_Security),
            ResourceType = typeof(CheckConstraintDisplay)
            )]
        [EnumMember(Value = "sec")]
        Security = 64
    }
}
