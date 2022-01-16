using System;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;
using EulerFinancial.Resources;

namespace EulerFinancial.Model
{
    /// <summary>
    /// Defines the metadata for the <see cref="Account"/> model.
    /// </summary>
    public class AccountMetadata
    {
        [Searchable]
        [Display(
            Name = nameof(ModelDisplayName.Account_AccountNumber), 
            ResourceType = typeof(ModelDisplayName))]
        public string AccountNumber { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplayName.Account_IsComplianceTradable), 
            ResourceType = typeof(ModelDisplayName))]
        public bool IsComplianceTradable { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplayName.Account_HasWallet), 
                ResourceType = typeof(ModelDisplayName))]
        public bool HasWallet { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplayName.Account_HasBankTransaction),
            ResourceType = typeof(ModelDisplayName))]
        public bool HasBankTransaction { get; set; }

        [Searchable]
        [Display(
            Name = nameof(ModelDisplayName.Account_HasBrokerTransaction),
            ResourceType = typeof(ModelDisplayName))]
        public bool HasBrokerTransaction { get; set; }

        [Display(
            Name = nameof(ModelDisplayName.Account_AccountCustodianId),
            ResourceType = typeof(ModelDisplayName))]
        public int AccountCustodianId { get; set; }

        [Display(
            Name = nameof(ModelDisplayName.Account_BooksClosedDate),
            ResourceType = typeof(ModelDisplayName))]
        public DateTime? BooksClosedDate { get; set; }

        [Display(
            Name = nameof(ModelDisplayName.Account_DisplayOrder),
            ResourceType = typeof(ModelDisplayName))]
        public int DisplayOrder { get; set; }
    }

    [MetadataType(typeof(AccountMetadata))]
    public partial class Account
    {
    }
}
