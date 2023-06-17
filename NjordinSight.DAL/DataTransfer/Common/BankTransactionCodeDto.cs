using NjordinSight.DataTransfer.Common.Collections;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class BankTransactionCodeDto : DtoBase
    {
        private int _transactionCodeId;
        private string _transactionCode;
        private string _displayName;

        public BankTransactionCodeDto()
        {
            Attributes = new List<BankTransactionCodeAttributeDto>();
            AttributeCollection = new(this);
        }

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

        public BankCodeAttributeDtoCollection AttributeCollection { get; set; }

        public ICollection<BankTransactionCodeAttributeDto> Attributes { get; set; }
    }

}
