using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class InvestmentModelTargetDto : DtoBase
    {
        private int _investmentModelId;
        private int _attributeMemberId;
        private DateTime _effectiveDate;
        private decimal _percentWeight;

        [Display(
            Name = nameof(InvestmentModelTargetDto_SR.InvestmentModelId_Name),
            Description = nameof(InvestmentModelTargetDto_SR.InvestmentModelId_Description),
            ResourceType = typeof(InvestmentModelTargetDto_SR))]
        public int InvestmentModelId
        {
            get { return _investmentModelId; }
            set
            {
                if (_investmentModelId != value)
                {
                    _investmentModelId = value;
                    OnPropertyChanged(nameof(InvestmentModelId));
                }
            }
        }

        [Display(
            Name = nameof(InvestmentModelTargetDto_SR.AttributeMemberId_Name),
            Description = nameof(InvestmentModelTargetDto_SR.AttributeMemberId_Description),
            ResourceType = typeof(InvestmentModelTargetDto_SR))]
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
            Name = nameof(InvestmentModelTargetDto_SR.EffectiveDate_Name),
            Description = nameof(InvestmentModelTargetDto_SR.EffectiveDate_Description),
            ResourceType = typeof(InvestmentModelTargetDto_SR))]
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
            Name = nameof(InvestmentModelTargetDto_SR.PercentWeight_Name),
            Description = nameof(InvestmentModelTargetDto_SR.PercentWeight_Description),
            ResourceType = typeof(InvestmentModelTargetDto_SR))]
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
