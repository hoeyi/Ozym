using System;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;
using EulerFinancial.ModelMetadata.Resources;

namespace EulerFinancial.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="Account"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.Account_Plural),
        PluralArticle = nameof(ModelNoun.Account_PluralArticle),
        Singular = nameof(ModelNoun.Account_Singular),
        SingularArticle = nameof(ModelNoun.Account_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class AccountMetadata
    {
        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.Account_AccountNumber_Name),
            Description = nameof(ModelDisplay.Account_AccountNumber_Description),
            ResourceType = typeof(ModelDisplay))]
        public string AccountNumber { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.Account_IsComplianceTradable_Name),
            Description = nameof(ModelDisplay.Account_IsComplianceTradable_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool IsComplianceTradable { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.Account_HasWallet_Name), 
            Description = nameof(ModelDisplay.Account_HasWallet_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasWallet { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.Account_HasBankTransaction_Name),
            Description = nameof(ModelDisplay.Account_HasBankTransaction_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasBankTransaction { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.Account_HasBrokerTransaction_Name),
            Description = nameof(ModelDisplay.Account_HasBrokerTransaction_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasBrokerTransaction { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_AccountCustodianId_Name),
            Description = nameof(ModelDisplay.Account_AccountCustodianID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int AccountCustodianId { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_BooksClosedDate_Name),
            Description = nameof(ModelDisplay.Account_BooksClosedDate_Description),
            ResourceType = typeof(ModelDisplay))]
        public DateTime? BooksClosedDate { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_DisplayOrder_Name),
            Description = nameof(ModelDisplay.Account_DisplayOrder_Description),
            ResourceType = typeof(ModelDisplay))]
        public int DisplayOrder { get; set; }
    }

    [MetadataType(typeof(AccountMetadata))]
    public partial class Account
    {
    }
}
