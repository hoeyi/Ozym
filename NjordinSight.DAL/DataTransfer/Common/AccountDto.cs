using NjordinSight.EntityModel;
using NjordinSight.EntityModel.Metadata;
using System;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class AccountDto : AccountBaseDto
    {
        private string _accountNumber;
        private int? _accountCustodianId;
        private DateTime? _booksClosedDate;
        private bool _hasWallet;
        private bool _hasBankTransaction;
        private bool _hasBrokerTransaction;

        [Display(
            Name = nameof(AccountCompositeDto_SR.ShortCode_Name),
            Description = nameof(AccountCompositeDto_SR.ShortCode_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(12,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public override string ShortCode { get => base.ShortCode; set => base.ShortCode = value; }

        [Display(
            Name = nameof(AccountCompositeDto_SR.StartDate_Name),
            Description = nameof(AccountCompositeDto_SR.StartDate_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        public override DateTime StartDate { get => base.StartDate; set => base.StartDate = value; }

        [Display(
            Name = nameof(AccountCompositeDto_SR.CloseDate_Name),
            Description = nameof(AccountCompositeDto_SR.CloseDate_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        public override DateTime? CloseDate { get => base.CloseDate; set => base.CloseDate = value; }

        [Display(
            Name = nameof(AccountCompositeDto_SR.Description_Name),
            Description = nameof(AccountCompositeDto_SR.Description_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        [StringLength(128,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public override string Description { get => base.Description; set => base.Description = value; }

        [Display(
            Name = nameof(AccountCompositeDto_SR.DisplayName_Name),
            Description = nameof(AccountCompositeDto_SR.DisplayName_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public override string DisplayName { get => base.DisplayName; set => base.DisplayName = value; }


        [Display(
            Name = nameof(AccountDto_SR.AccountNumber_Name),
            Description = nameof(AccountDto_SR.AccountNumber_Description),
            ResourceType = typeof(AccountDto_SR))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                if (_accountNumber != value)
                {
                    _accountNumber = value;
                    OnPropertyChanged(nameof(AccountNumber));
                }
            }
        }

        [Display(
            Name = nameof(AccountDto_SR.AccountCustodianId_Name),
            Description = nameof(AccountDto_SR.AccountCustodianId_Description),
            ResourceType = typeof(AccountDto_SR))]
        public int? AccountCustodianId
        {
            get { return _accountCustodianId; }
            set
            {
                if (_accountCustodianId != value)
                {
                    _accountCustodianId = value;
                    OnPropertyChanged(nameof(AccountCustodianId));
                }
            }
        }

        [Display(
            Name = nameof(AccountDto_SR.BooksClosedDate_Name),
            Description = nameof(AccountDto_SR.BooksClosedDate_Description),
            ResourceType = typeof(AccountDto_SR))]
        public DateTime? BooksClosedDate
        {
            get { return _booksClosedDate; }
            set
            {
                if (_booksClosedDate != value)
                {
                    _booksClosedDate = value;
                    OnPropertyChanged(nameof(BooksClosedDate));
                }
            }
        }

        [Display(
            Name = nameof(AccountDto_SR.HasWallet_Name),
            Description = nameof(AccountDto_SR.HasWallet_Description),
            ResourceType = typeof(AccountDto_SR))]
        public bool HasWallet
        {
            get { return _hasWallet; }
            set
            {
                if (_hasWallet != value)
                {
                    _hasWallet = value;
                    OnPropertyChanged(nameof(HasWallet));
                }
            }
        }

        [Display(
            Name = nameof(AccountDto_SR.HasBankTransaction_Name),
            Description = nameof(AccountDto_SR.HasBankTransaction_Description),
            ResourceType = typeof(AccountDto_SR))]
        public bool HasBankTransaction
        {
            get { return _hasBankTransaction; }
            set
            {
                if (_hasBankTransaction != value)
                {
                    _hasBankTransaction = value;
                    OnPropertyChanged(nameof(HasBankTransaction));
                }
            }
        }

        [Display(
            Name = nameof(AccountDto_SR.HasBrokerTransaction_Name),
            Description = nameof(AccountDto_SR.HasBrokerTransaction_Description),
            ResourceType = typeof(AccountDto_SR))]
        public bool HasBrokerTransaction
        {
            get { return _hasBrokerTransaction; }
            set
            {
                if (_hasBrokerTransaction != value)
                {
                    _hasBrokerTransaction = value;
                    OnPropertyChanged(nameof(HasBrokerTransaction));
                }
            }
        }

        public override string ObjectType { get; } = AccountObjectType.Account.ConvertToStringCode();
    }
}
