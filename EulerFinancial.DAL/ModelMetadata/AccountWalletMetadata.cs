using EulerFinancial.ModelMetadata.Resources;
using Ichosoft.DataModel.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EulerFinancial.Model
{
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
        public string AddressCode { get; set; }

        [Display(
            Name = nameof(ModelDisplay.AccountWallet_AddressTag_Name),
            Description = nameof(ModelDisplay.AccountWallet_AddressTag_Description),
            ResourceType = typeof(ModelDisplay))]
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
