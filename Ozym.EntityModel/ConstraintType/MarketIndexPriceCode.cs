using Ozym.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Ozym.EntityModel
{
    /// <summary>
    /// Represents the supported values for <see cref="MarketIndexPrice.PriceCode"/>
    /// </summary>
    public enum MarketIndexPriceCode
    {
        [Display(
            Name = nameof(CheckConstraintDisplay.MarketIndexPrice_PriceCode_PriceReturn),
            ResourceType = typeof(CheckConstraintDisplay))]
        [EnumMember(Value = "p")]
        PriceReturn,

        [Display(
            Name = nameof(CheckConstraintDisplay.MarketIndexPrice_PriceCode_TotalReturn),
            ResourceType = typeof(CheckConstraintDisplay))]
        [EnumMember(Value = "t")]
        TotalReturn
    }
}
