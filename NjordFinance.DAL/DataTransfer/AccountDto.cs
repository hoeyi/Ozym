﻿using NjordFinance.EntityModel.Metadata;
using System;
using System.ComponentModel.DataAnnotations;
using NjordFinance.EntityModel;

namespace NjordFinance.DataTransfer
{
    public class AccountDto : AccountObjectDto
    {
        public override string ObjecTypeCode => AccountObjectType.Account.ConvertToStringCode();

        private readonly Account _account;

        public AccountDto(Account sourceModel)
            : this(sourceModel, sourceModel.AccountNavigation)
        {
        }

        AccountDto(Account account, AccountObject accountObject)
            : base(accountObject)
        {
            if (account is null)
                throw new ArgumentNullException(paramName: nameof(account));

            _account = account;
        }

        [Display(
            Name = nameof(ModelDisplay.Account_AccountNumber_Name),
            Description = nameof(ModelDisplay.Account_AccountNumber_Description),
            ResourceType = typeof(ModelDisplay))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string AccountNumber
        {
            get { return _account.AccountNumber; }
            set
            {
                if (_account.AccountNumber != value)
                    _account.AccountNumber = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.Account_AccountCustodianId_Name),
            Description = nameof(ModelDisplay.Account_AccountCustodianID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int? AccountCustodianId
        {
            get { return _account.AccountCustodianId; }
            set
            {
                if (_account.AccountCustodianId != value)
                    _account.AccountCustodianId = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.Account_BooksClosedDate_Name),
            Description = nameof(ModelDisplay.Account_BooksClosedDate_Description),
            ResourceType = typeof(ModelDisplay))]
        public DateTime? BooksClosedDate
        {
            get { return _account.BooksClosedDate; }
            set
            {
                if (_account.BooksClosedDate != value)
                    _account.BooksClosedDate = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.Account_IsComplianceTradable_Name),
            Description = nameof(ModelDisplay.Account_IsComplianceTradable_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool IsComplianceTradable
        {
            get { return _account.IsComplianceTradable; }
            set
            {
                if (_account.IsComplianceTradable != value)
                    _account.IsComplianceTradable = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.Account_HasWallet_Name),
            Description = nameof(ModelDisplay.Account_HasWallet_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasWallet
        {
            get { return _account.HasWallet; }
            set
            {
                if (_account.HasWallet != value)
                    _account.HasWallet = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.Account_HasBankTransaction_Name),
            Description = nameof(ModelDisplay.Account_HasBankTransaction_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasBankTransaction
        {
            get { return _account.HasBankTransaction; }
            set
            {
                if (_account.HasBankTransaction != value)
                    _account.HasBankTransaction = value;
            }
        }
        [Display(
            Name = nameof(ModelDisplay.Account_HasBrokerTransaction_Name),
            Description = nameof(ModelDisplay.Account_HasBrokerTransaction_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasBrokerTransaction
        {
            get { return _account.HasBrokerTransaction; }
            set
            {
                if (_account.HasBrokerTransaction != value)
                    _account.HasBrokerTransaction = value;
            }
        }

        public Account ToEntity() => _account;
    }
}
