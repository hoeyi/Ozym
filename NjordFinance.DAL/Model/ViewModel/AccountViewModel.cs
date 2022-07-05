using NjordFinance.Model;
using NjordFinance.ModelMetadata;
using NjordFinance.ModelMetadata.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace NjordFinance.Model.ViewModel
{
    // TODO: Implement INotifyPropertyChanged and keep 
    // an instance of Account/AccountNavigation in sync 
    // with the view model.

    /// <summary>
    /// Provides a flattened view-object for working with complex type <see cref="Account"/>.
    /// </summary>
    public class AccountViewModel
    {
        /// <summary>
        /// Initializes a new <see cref="AccountViewModel"/> instance from the given 
        /// <see cref="Account"/> instance.
        /// </summary>
        /// <param name="account"></param>
        /// <remarks>Member <see cref="Account.AccountNavigation"/> must be defined, 
        /// and <see cref="Account.AccountCustodian"/> <em>should</em> be defined, if 
        /// it exists.</remarks>
        public AccountViewModel(Account account)
            : this(account, account.AccountNavigation)
        {
        }

        AccountViewModel(Account account, AccountObject accountObject)
        {
            if (account is null)
                throw new ArgumentNullException(paramName: nameof(account));

            if (accountObject is null)
                throw new ArgumentNullException(paramName: nameof(accountObject));

            AccountId = account.AccountId;
            AccountNumber = account.AccountNumber;
            AccountCustodianId = account.AccountCustodianId;
            BooksClosedDate = account.BooksClosedDate;
            IsComplianceTradable = account.IsComplianceTradable;
            HasWallet = account.HasWallet;
            HasBankTransaction = account.HasBankTransaction;
            HasBrokerTransaction = account.HasBrokerTransaction;

            AccountCustodian = account.AccountCustodian;

            AccountCode = accountObject.AccountObjectCode;
            DisplayName = accountObject.ObjectDisplayName;
            Description = accountObject.ObjectDescription;
            StartDate = accountObject.StartDate;
            CloseDate = accountObject.CloseDate;
        }

        public int AccountId { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_AccountNumber_Name),
            Description = nameof(ModelDisplay.Account_AccountNumber_Description),
            ResourceType = typeof(ModelDisplay))]
        [StringLength(72)]
        public string AccountNumber { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_AccountCustodianId_Name),
            Description = nameof(ModelDisplay.Account_AccountCustodianID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int? AccountCustodianId { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_BooksClosedDate_Name),
            Description = nameof(ModelDisplay.Account_BooksClosedDate_Description),
            ResourceType = typeof(ModelDisplay))]
        public DateTime? BooksClosedDate { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_IsComplianceTradable_Name),
            Description = nameof(ModelDisplay.Account_IsComplianceTradable_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool IsComplianceTradable { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_HasWallet_Name),
            Description = nameof(ModelDisplay.Account_HasWallet_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasWallet { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_HasBankTransaction_Name),
            Description = nameof(ModelDisplay.Account_HasBankTransaction_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasBankTransaction { get; set; }

        [Display(
            Name = nameof(ModelDisplay.Account_HasBrokerTransaction_Name),
            Description = nameof(ModelDisplay.Account_HasBrokerTransaction_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasBrokerTransaction { get; set; }

        // AccountObject attrtibutes
        [Display(
            Name = nameof(ModelDisplay.AccountObject_AccountObjectCode_Name),
            Description = nameof(ModelDisplay.AccountObject_AccountObjectCode_Description),
            ResourceType = typeof(ModelDisplay))]
        [Required]
        [StringLength(12)]
        public string AccountCode { get; set; }

        [Display(
            Name = nameof(ModelDisplay.AccountObject_ObjectDisplayName_Name),
            Description = nameof(ModelDisplay.AccountObject_ObjectDipslayName_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        [Required]
        [StringLength(72)]
        public string DisplayName { get; set; }

        [Display(
            Name = nameof(ModelDisplay.AccountObject_ObjectDescription_Name),
            Description = nameof(ModelDisplay.AccountObject_ObjectDescription_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        [StringLength(128)]
        public string Description { get; set; }

        [Display(
            Name = nameof(ModelDisplay.AccountObject_StartDate_Name),
            Description = nameof(ModelDisplay.AccountObject_StartDate_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public DateTime StartDate { get; set; }

        [Display(
            Name = nameof(ModelDisplay.AccountObject_CloseDate_Name),
            Description = nameof(ModelDisplay.AccountObject_CloseDate_Description),
            ResourceType = typeof(ModelDisplay)
            )]
        public DateTime? CloseDate { get; set; }

        public AccountCustodian? AccountCustodian { get; init; }

        private readonly string _objectType = AccountObjectType.Account.ConvertToStringCode();

        public Account ToAccount()
        {
            return new()
            {
                AccountId = AccountId,
                AccountNumber = AccountNumber,
                AccountCustodianId = AccountCustodianId,
                BooksClosedDate = BooksClosedDate,
                IsComplianceTradable = IsComplianceTradable,
                HasWallet = HasWallet,
                HasBankTransaction = HasBankTransaction,
                HasBrokerTransaction = HasBrokerTransaction,

                AccountNavigation = new()
                {
                    AccountObjectId = AccountId,
                    AccountObjectCode = AccountCode,
                    ObjectDisplayName = DisplayName,
                    ObjectDescription = Description,
                    StartDate = StartDate,
                    CloseDate = CloseDate,
                    ObjectType = _objectType
                }
            };
        }
    }
}
