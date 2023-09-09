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
        Plural = nameof(BrokerTransactionCodeDto_SR.Noun_Plural),
        PluralArticle = nameof(BrokerTransactionCodeDto_SR.Noun_Plural_Article),
        Singular = nameof(BrokerTransactionCodeDto_SR.Noun_Singular),
        SingularArticle = nameof(BrokerTransactionCodeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(BrokerTransactionCodeDto_SR)
        )]
    public class BrokerTransactionCodeDtoBase : DtoBase
    {
        private int _transactionCodeId;
        private string _transactionCode;
        private string _displayName;
        private short _cashEffect;
        private short _contributionWithdrawalEffect;
        private short _quantityEffect;

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
            Name = nameof(BrokerTransactionCodeDto_SR.TransactionCode_Name),
            Description = nameof(BrokerTransactionCodeDto_SR.TransactionCode_Description),
            ResourceType = typeof(BrokerTransactionCodeDto_SR))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(3,
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
            Name = nameof(BrokerTransactionCodeDto_SR.DisplayName_Name),
            Description = nameof(BrokerTransactionCodeDto_SR.DisplayName_Description),
            ResourceType = typeof(BrokerTransactionCodeDto_SR))]
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

        [Display(
            Name = nameof(BrokerTransactionCodeDto_SR.CashEffect_Name),
            Description = nameof(BrokerTransactionCodeDto_SR.CashEffect_Description),
            ResourceType = typeof(BrokerTransactionCodeDto_SR))]
        public short CashEffect
        {
            get { return _cashEffect; }
            set
            {
                if (_cashEffect != value)
                {
                    _cashEffect = value;
                    OnPropertyChanged(nameof(CashEffect));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionCodeDto_SR.ContributionWithdrawalEffect_Name),
            Description = nameof(BrokerTransactionCodeDto_SR.ContributionWithdrawalEffect_Description),
            ResourceType = typeof(BrokerTransactionCodeDto_SR))]
        public short ContributionWithdrawalEffect
        {
            get { return _contributionWithdrawalEffect; }
            set
            {
                if (_contributionWithdrawalEffect != value)
                {
                    _contributionWithdrawalEffect = value;
                    OnPropertyChanged(nameof(ContributionWithdrawalEffect));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionCodeDto_SR.QuantityEffect_Name),
            Description = nameof(BrokerTransactionCodeDto_SR.QuantityEffect_Description),
            ResourceType = typeof(BrokerTransactionCodeDto_SR))]
        public short QuantityEffect
        {
            get { return _quantityEffect; }
            set
            {
                if (_quantityEffect != value)
                {
                    _quantityEffect = value;
                    OnPropertyChanged(nameof(QuantityEffect));
                }
            }
        }

    }

    [Noun(
        Plural = nameof(BrokerTransactionCodeDto_SR.Noun_Plural),
        PluralArticle = nameof(BrokerTransactionCodeDto_SR.Noun_Plural_Article),
        Singular = nameof(BrokerTransactionCodeDto_SR.Noun_Singular),
        SingularArticle = nameof(BrokerTransactionCodeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(BrokerTransactionCodeDto_SR)
        )]
    public class BrokerTransactionCodeDto : BrokerTransactionCodeDtoBase
    {
        private ICollection<BrokerTransactionCodeAttributeDto> _attributes;
        public BrokerTransactionCodeDto()
        {
            Attributes = new HashSet<BrokerTransactionCodeAttributeDto>();
        }

        public ICollection<BrokerTransactionCodeAttributeDto> Attributes
        {
            get { return _attributes; }
            set
            {
                if(_attributes != value)
                {
                    _attributes = value;
                    AttributeCollection = new(this);
                }
            }
        }

        [JsonIgnore]
        public BrokerCodeAttributeDtoCollection AttributeCollection { get; private set; }
    }
}
