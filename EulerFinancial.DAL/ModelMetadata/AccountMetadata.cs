using System;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;
using EulerFinancial.ModelMetadata.Resources;

namespace EulerFinancial.Model
{
    /// <summary>
    /// Defines the metadata for the <see cref="Account"/> model.
    /// </summary>
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
            ResourceType = typeof(ModelDisplay))]
        public bool IsComplianceTradable { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.Account_HasWallet_Name), 
                ResourceType = typeof(ModelDisplay))]
        public bool HasWallet { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.Account_HasBankTransaction_Name),
            ResourceType = typeof(ModelDisplay))]
        public bool HasBankTransaction { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplay.Account_HasBrokerTransaction_Name),
            ResourceType = typeof(ModelDisplay))]
        public bool HasBrokerTransaction { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_AccountCustodianId_Name),
            ResourceType = typeof(ModelDisplay))]
        public int AccountCustodianId { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_BooksClosedDate_Name),
            ResourceType = typeof(ModelDisplay))]
        public DateTime? BooksClosedDate { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_DisplayOrder_Name),
            ResourceType = typeof(ModelDisplay))]
        public int DisplayOrder { get; set; }
    }

    [MetadataType(typeof(AccountMetadata))]
    public partial class Account
    {
    }
}
