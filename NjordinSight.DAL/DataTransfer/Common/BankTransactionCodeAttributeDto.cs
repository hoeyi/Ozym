using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NjordinSight.DataTransfer.Common
{
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
    }

}
