using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.ModelMetadata.Resources;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;

namespace NjordFinance.Model
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
