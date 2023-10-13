using System;
using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(BankTransactionCodeAttributeDto_SR.Noun_Plural),
        PluralArticle = nameof(BankTransactionCodeAttributeDto_SR.Noun_Plural_Article),
        Singular = nameof(BankTransactionCodeAttributeDto_SR.Noun_Singular),
        SingularArticle = nameof(BankTransactionCodeAttributeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(BankTransactionCodeAttributeDto_SR)
        )]
    public class BankTransactionCodeAttributeDto : DtoBase
    {
        private int _attributeMemberId;
        private int _transactionCodeId;
        private DateTime _effectiveDate;
        private decimal _percentWeight;

        [Display(
            Name = nameof(BankTransactionCodeAttributeDto_SR.AttributeMemberId_Name),
            Description = nameof(BankTransactionCodeAttributeDto_SR.AttributeMemberId_Description),
            ResourceType = typeof(BankTransactionCodeAttributeDto_SR))]
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
            Name = nameof(BankTransactionCodeAttributeDto_SR.TransactionCodeId_Name),
            Description = nameof(BankTransactionCodeAttributeDto_SR.TransactionCodeId_Description),
            ResourceType = typeof(BankTransactionCodeAttributeDto_SR))]
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
            Name = nameof(BankTransactionCodeAttributeDto_SR.EffectiveDate_Name),
            Description = nameof(BankTransactionCodeAttributeDto_SR.EffectiveDate_Description),
            ResourceType = typeof(BankTransactionCodeAttributeDto_SR))]
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
            Name = nameof(BankTransactionCodeAttributeDto_SR.PercentWeight_Name),
            Description = nameof(BankTransactionCodeAttributeDto_SR.PercentWeight_Description),
            ResourceType = typeof(BankTransactionCodeAttributeDto_SR))]
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
