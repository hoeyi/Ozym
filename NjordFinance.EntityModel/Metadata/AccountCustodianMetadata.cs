using NjordFinance.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;

namespace NjordFinance.EntityModel
{
    /// <summary>
    /// Defines the metadata for <see cref="AccountCustodian"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.AccountCustodian_Plural),
        PluralArticle = nameof(ModelNoun.AccountCustodian_PluralArticle),
        Singular = nameof(ModelNoun.AccountCustodian_Singular),
        SingularArticle = nameof(ModelNoun.AccountCustodian_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class AccountCustodianMetadata
    {
        [Display(
            Name = nameof(ModelDisplay.AccountCustodian_CustodianCode_Name),
            Description = nameof(ModelDisplay.AccountCustodian_CustodianCode_Description),
            ResourceType = typeof(ModelDisplay))]
        public string CustodianCode { get; set; }


        [Display(
            Name = nameof(ModelDisplay.AccountCustodian_DisplayName_Name),
            Description = nameof(ModelDisplay.AccountCustodian_DisplayName_Description),
            ResourceType = typeof(ModelDisplay))]
        public string DisplayName { get; set; }
    }

    [MetadataType(typeof(AccountCustodianMetadata))]
    public partial class AccountCustodian
    {
    }
}
