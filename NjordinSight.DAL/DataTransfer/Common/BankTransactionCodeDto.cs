using Ichosys.DataModel.Annotations;
using NjordinSight.DataTransfer.Common.Collections;
using NjordinSight.EntityModel.Metadata;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(BankTransactionCodeDto_SR.Noun_Plural),
        PluralArticle = nameof(BankTransactionCodeDto_SR.Noun_Plural_Article),
        Singular = nameof(BankTransactionCodeDto_SR.Noun_Singular),
        SingularArticle = nameof(BankTransactionCodeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(BankTransactionCodeDto_SR)
        )]
    public class BankTransactionCodeDtoBase : DtoBase
    {
        private int _transactionCodeId;
        private string _transactionCode;
        private string _displayName;

        [Key]
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

    [Noun(
        Plural = nameof(BankTransactionCodeDto_SR.Noun_Plural),
        PluralArticle = nameof(BankTransactionCodeDto_SR.Noun_Plural_Article),
        Singular = nameof(BankTransactionCodeDto_SR.Noun_Singular),
        SingularArticle = nameof(BankTransactionCodeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(BankTransactionCodeDto_SR)
        )]
    public class BankTransactionCodeDto : BankTransactionCodeDtoBase
    {
        private ICollection<BankTransactionCodeAttributeDto> _attributes;
        public BankTransactionCodeDto()
        {
            Attributes = new HashSet<BankTransactionCodeAttributeDto>();
        }

        public ICollection<BankTransactionCodeAttributeDto> Attributes
        {
            get { return _attributes; }
            set
            {
                if (_attributes != value)
                {
                    _attributes = value;
                    AttributeCollection = new(this);
                }
            }
        }

        [JsonIgnore]
        public BankCodeAttributeDtoCollection AttributeCollection { get; private set; }
    }

}
