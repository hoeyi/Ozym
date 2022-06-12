using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using NjordFinance.ModelMetadata.Resources;
using Ichosoft.DataModel.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NjordFinance.Model
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
        [Display(
            Name = nameof(ModelDisplay.Security_SecurityDescription_Name),
            Description = nameof(ModelDisplay.Security_SecurityDescription_Description),
            ResourceType = typeof(ModelDisplay))]
        public string SecurityDescription { get; set; }

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
    }

    [MetadataType(typeof(SecurityMetadata))]
    public partial class Security
    {
        /// <summary>
        /// Gets the effective <see cref="SecuritySymbol.SymbolCode"/> for this security as of 
        /// the current system date and time.
        /// </summary>
        [NotMapped]
        public string SecuritySymbol
        {
            get
            {
                return SecuritySymbols?.
                    Where(s => s.EffectiveDate > DateTime.Now)
                    ?.OrderBy(s => s.EffectiveDate)
                    ?.FirstOrDefault()
                    ?.SymbolCode ?? ModelDisplay.Security_CurrentSecuritySymbol_Empty;
            }
        }
    }
}
