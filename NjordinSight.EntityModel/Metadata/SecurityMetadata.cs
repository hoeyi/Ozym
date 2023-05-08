using System.ComponentModel.DataAnnotations;
using NjordinSight.EntityModel.Metadata;
using Ichosys.DataModel.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordinSight.EntityModel
{
    /// <summary>
    /// Defines metadata for <see cref="Security"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.Security_Plural),
        PluralArticle = nameof(ModelNoun.Security_PluralArticle),
        Singular = nameof(ModelNoun.Security_Singular),
        SingularArticle = nameof(ModelNoun.Security_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class SecurityMetadata
    {
        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.Security_SecurityDescription_Name),
            Description = nameof(ModelDisplay.Security_SecurityDescription_Description),
            ResourceType = typeof(ModelDisplay))]
        public string SecurityDescription { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.Security_Issuer_Name),
            Description = nameof(ModelDisplay.Security_Issuer_Description),
            ResourceType = typeof(ModelDisplay))]
        public string Issuer { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Security_SecurityTypeID_Name),
            Description = nameof(ModelDisplay.Security_SecurityTypeID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int SecurityTypeId { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Security_SecurityExchangeID_Name),
            Description = nameof(ModelDisplay.Security_SecurityExchangeID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int? SecurityExchangeId { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Security_HasPerpetualMarket_Name),
            Description = nameof(ModelDisplay.Security_HasPerpetualMarket_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasPerpetualMarket { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Security_HasPerpetualPrice_Name),
            Description = nameof(ModelDisplay.Security_HasPerpetualPrice_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasPerpetualPrice { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Security_CurrentSymbol_Name),
            Description = nameof(ModelDisplay.Security_CurrentSymbol_Description),
            ResourceType = typeof(ModelDisplay))]
        public string SecuritySymbol { get; }

    }

    [MetadataType(typeof(SecurityMetadata))]
    public partial class Security
    {
        /// <summary>
        /// Gets the effective <see cref="SecuritySymbol.SymbolCode"/> for this security as of 
        /// the current system date and time.
        /// </summary>
        [NotMapped]
        public string SecuritySymbol => 
            $"({CurrentSecuritySymbol?.SymbolCode?.ToUpper() ?? ModelDisplay.Security_CurrentSecuritySymbol_Empty})";

        /// <summary>
        /// Gets the current symbol based on the current UTC system time.
        /// </summary>
        [NotMapped]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        private SecuritySymbol? CurrentSecuritySymbol =>
            SecuritySymbols?.
                Where(s => s.EffectiveDate < DateTime.UtcNow.Date)
                ?.OrderByDescending(s => s.EffectiveDate)
                ?.FirstOrDefault();
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    }
}
