using System.ComponentModel.DataAnnotations;

namespace Ozym.BusinessLogic.MarketFeed
{
    /// <summary>
    /// Represents a market quote for an exchange-traded security or an index.
    /// </summary>
    public record Quote
    {
        /// <summary>
        /// Gets or sets the exchange identifier of the security/index.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.Quote_Symbol_Name),
            Description = nameof(DisplayString.Quote_Symbol_Description),
            ResourceType = typeof(DisplayString))]
        public string Symbol { get; init; }

        /// <summary>
        /// Gets or sets the description of the security/index.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.Quote_Description_Name),
            Description = nameof(DisplayString.Quote_Description_Description),
            ResourceType = typeof(DisplayString))]
        public string Description { get; init; }

        /// <summary>
        /// Gets or sets the last price observed.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.Quote_LastPrice_Name),
            Description = nameof(DisplayString.Quote_LastPrice_Description),
            ResourceType = typeof(DisplayString))]
        public double LastPrice { get; set; }

        /// <summary>
        /// Gets or sets the signed change from the previous quote.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.Quote_Change_Name),
            Description = nameof(DisplayString.Quote_Change_Description),
            ResourceType = typeof(DisplayString))]
        public double Change { get; set; }

        /// <summary>
        /// Gets the signed proportional change from the previous quote.
        /// </summary>
        [Display(
            Name = nameof(DisplayString.Quote_PercentChange_Name),
            Description = nameof(DisplayString.Quote_PercentChange_Description),
            ResourceType = typeof(DisplayString))]
        public double PercentChange => Change / (LastPrice - Change);
    }
}
