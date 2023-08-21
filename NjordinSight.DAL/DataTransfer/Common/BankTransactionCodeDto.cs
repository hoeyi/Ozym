using NjordinSight.DataTransfer.Common.Collections;
using NjordinSight.EntityModel.Metadata;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class BankTransactionCodeDtoBase : DtoBase
    {
        private int _transactionCodeId;
        private string _transactionCode;
        private string _displayName;

        [Display(
            Name = nameof(BankTransactionCodeDto_SR.TransactionCodeId_Name),
            Description = nameof(BankTransactionCodeDto_SR.TransactionCodeId_Description),
            ResourceType = typeof(BankTransactionCodeDto_SR))]
        public int TransactionCodeId
        {
            get { return _transactionCodeId; }
            set
            {
                if (_transactionCodeId != value)
                {
                    _transactionCodeId = value;
                    OnPropertyChanged(nameof(TransactionCodeId));
                }
            }
        }

        [Display(
            Name = nameof(BankTransactionCodeDto_SR.TransactionCode_Name),
            Description = nameof(BankTransactionCodeDto_SR.TransactionCode_Description),
            ResourceType = typeof(BankTransactionCodeDto_SR))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(12,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string TransactionCode
        {
            get { return _transactionCode; }
            set
            {
                if (_transactionCode != value)
                {
                    _transactionCode = value;
                    OnPropertyChanged(nameof(TransactionCode));
                }
            }
        }

        [Display(
            Name = nameof(BankTransactionCodeDto_SR.DisplayName_Name),
            Description = nameof(BankTransactionCodeDto_SR.DisplayName_Description),
            ResourceType = typeof(BankTransactionCodeDto_SR))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(32,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    OnPropertyChanged(nameof(DisplayName));
                }
            }
        }
    }

    public class BankTransactionCodeDto : BankTransactionCodeDtoBase
    {
        public BankTransactionCodeDto()
        {
            Attributes = new List<BankTransactionCodeAttributeDto>();
            AttributeCollection = new(this);
        }

        public BankCodeAttributeDtoCollection AttributeCollection { get; set; }

        public ICollection<BankTransactionCodeAttributeDto> Attributes { get; set; }
    }

}
