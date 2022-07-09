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
    public class AccountViewModel : AccountObjectViewModel
    {
        private readonly string _objectType = AccountObjectType.Account.ConvertToStringCode();

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

            AccountNumber = account.AccountNumber;
            AccountCustodian = account.AccountCustodian;
            AccountCustodianId = account.AccountCustodianId;
            BooksClosedDate = account.BooksClosedDate;
            IsComplianceTradable = account.IsComplianceTradable;
            HasWallet = account.HasWallet;
            HasBankTransaction = account.HasBankTransaction;
            HasBrokerTransaction = account.HasBrokerTransaction;

            AccountObjectId = account.AccountId;
            AccountObjectCode = accountObject.AccountObjectCode;
            DisplayName = accountObject.ObjectDisplayName;
            Description = accountObject.ObjectDescription;
            StartDate = accountObject.StartDate;
            CloseDate = accountObject.CloseDate;
        }

        [Display(
            Name = nameof(ModelDisplay.Account_AccountNumber_Name),
            Description = nameof(ModelDisplay.Account_AccountNumber_Description),
            ResourceType = typeof(ModelDisplay))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
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

        public AccountCustodian? AccountCustodian { get; init; }

        public Account ToAccount()
        {
            return new()
            {
                AccountId = AccountObjectId,
                AccountNumber = AccountNumber,
                AccountCustodianId = AccountCustodianId,
                BooksClosedDate = BooksClosedDate,
                IsComplianceTradable = IsComplianceTradable,
                HasWallet = HasWallet,
                HasBankTransaction = HasBankTransaction,
                HasBrokerTransaction = HasBrokerTransaction,

                AccountNavigation = new()
                {
                    AccountObjectId = AccountObjectId,
                    AccountObjectCode = AccountObjectCode,
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
