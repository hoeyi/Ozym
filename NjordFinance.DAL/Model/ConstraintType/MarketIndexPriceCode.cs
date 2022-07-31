using System.Runtime.Serialization;

namespace NjordFinance.Model
{
    /// <summary>
    /// Represents the supported values for <see cref="MarketIndexPrice.PriceCode"/>
    /// </summary>
    public enum MarketIndexPriceCode
    {
        [EnumMember(Value = "p")]
        PriceReturn,

        [EnumMember(Value = "t")]
        TotalReturn
    }
}
