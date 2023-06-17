using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class BrokerTransactionCodeAttributeDto : DtoBase
    {
        private int _attributeMemberId;
        private int _transactionCodeId;
        private DateTime _effectiveDate;
        private decimal _percentWeight;

        [Display(
            Name = nameof(BrokerTransactionCodeAttributeDto_SR.AttributeMemberId_Name),
            Description = nameof(BrokerTransactionCodeAttributeDto_SR.AttributeMemberId_Description),
            ResourceType = typeof(BrokerTransactionCodeAttributeDto_SR))]
        public int AttributeMemberId
        {
            get { return _attributeMemberId; }
            set
            {
                if (_attributeMemberId != value)
                {
                    _attributeMemberId = value;
                    OnPropertyChanged(nameof(AttributeMemberId));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionCodeAttributeDto_SR.TransactionCodeId_Name),
            Description = nameof(BrokerTransactionCodeAttributeDto_SR.TransactionCodeId_Description),
            ResourceType = typeof(BrokerTransactionCodeAttributeDto_SR))]
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
            Name = nameof(BrokerTransactionCodeAttributeDto_SR.EffectiveDate_Name),
            Description = nameof(BrokerTransactionCodeAttributeDto_SR.EffectiveDate_Description),
            ResourceType = typeof(BrokerTransactionCodeAttributeDto_SR))]
        public DateTime EffectiveDate
        {
            get { return _effectiveDate; }
            set
            {
                if (_effectiveDate != value)
                {
                    _effectiveDate = value;
                    OnPropertyChanged(nameof(EffectiveDate));
                }
            }
        }

        [Display(
            Name = nameof(BrokerTransactionCodeAttributeDto_SR.PercentWeight_Name),
            Description = nameof(BrokerTransactionCodeAttributeDto_SR.PercentWeight_Description),
            ResourceType = typeof(BrokerTransactionCodeAttributeDto_SR))]
        public decimal PercentWeight
        {
            get { return _percentWeight; }
            set
            {
                if (_percentWeight != value)
                {
                    _percentWeight = value;
                    OnPropertyChanged(nameof(PercentWeight));
                }
            }
        }

        public ModelAttributeMemberDto AttributeMember { get; set; } = new();
    }

}
