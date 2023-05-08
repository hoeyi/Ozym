using NjordinSight.EntityModel.Metadata;
using Ichosys.DataModel.Annotations;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.EntityModel
{
    /// <summary>
    /// Defines the metadata for <see cref="AccountWallet"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.AccountWallet_Plural),
        PluralArticle = nameof(ModelNoun.AccountWallet_PluralArticle),
        Singular = nameof(ModelNoun.AccountWallet_Singular),
        SingularArticle = nameof(ModelNoun.AccountWallet_SingularArticle),
        ResourceType = typeof(ModelNoun)
    )]
    public class AccountWalletMetadata
    {
        [Display(
            Name = nameof(ModelDisplay.AccountWallet_AddressCode_Name),
            Description = nameof(ModelDisplay.AccountWallet_AddressCode_Description),
            ResourceType = typeof(ModelDisplay))]
        [MinLength(10)]
        public string AddressCode { get; set; }

        [Display(
            Name = nameof(ModelDisplay.AccountWallet_AddressTag_Name),
            Description = nameof(ModelDisplay.AccountWallet_AddressTag_Description),
            ResourceType = typeof(ModelDisplay))]
        [MinLength(5)]
        public string AddressTag { get; set; }

        [Display(
            Name = nameof(ModelDisplay.AccountWallet_DenominationSecurityID_Name),
            Description = nameof(ModelDisplay.AccountWallet_DenominationSecurityID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int DenominationSecurityId { get; set; }
    }

    [MetadataType(typeof(AccountWalletMetadata))]
    public partial class AccountWallet
    {
    }
}
