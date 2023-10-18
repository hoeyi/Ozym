using Ichosys.DataModel.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(InvestmentPerformanceDto_SR.Noun_Plural),
        PluralArticle = nameof(InvestmentPerformanceDto_SR.Noun_Plural_Article),
        Singular = nameof(InvestmentPerformanceDto_SR.Noun_Singular),
        SingularArticle = nameof(InvestmentPerformanceDto_SR.Noun_Singular_Article),
        ResourceType = typeof(InvestmentPerformanceDto_SR)
        )]
    public class InvestmentPerformanceDto : DtoBase
    {
        private int _accountBaseId;
        private DateTime _fromDate;
        private DateTime _toDate;
        private decimal _marketValue;
        private decimal _netContribution;
        private decimal _averageCapital;
        private decimal _gain;
        private decimal _irr;

        [Display(
            Name = nameof(InvestmentPerformanceDto_SR.AccountBaseId_Name),
            Description = nameof(InvestmentPerformanceDto_SR.AccountBaseId_Description),
            ResourceType = typeof(InvestmentPerformanceDto_SR))]
        public int AccountBaseId
        {
            get { return _accountBaseId; }
            set
            {
                if (_accountBaseId != value)
                {
                    _accountBaseId = value;
                    OnPropertyChanged(nameof(AccountBaseId));
                }
            }
        }

        [Display(
            Name = nameof(InvestmentPerformanceDto_SR.FromDate_Name),
            Description = nameof(InvestmentPerformanceDto_SR.FromDate_Description),
            ResourceType = typeof(InvestmentPerformanceDto_SR))]
        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    OnPropertyChanged(nameof(FromDate));
                }
            }
        }

        [Display(
            Name = nameof(InvestmentPerformanceDto_SR.ToDate_Name),
            Description = nameof(InvestmentPerformanceDto_SR.ToDate_Description),
            ResourceType = typeof(InvestmentPerformanceDto_SR))]
        public DateTime ToDate
        {
            get { return _toDate; }
            set
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    OnPropertyChanged(nameof(ToDate));
                }
            }
        }

        [Display(
            Name = nameof(InvestmentPerformanceDto_SR.MarketValue_Name),
            Description = nameof(InvestmentPerformanceDto_SR.MarketValue_Description),
            ResourceType = typeof(InvestmentPerformanceDto_SR))]
        public decimal MarketValue
        {
            get { return _marketValue; }
            set
            {
                if (_marketValue != value)
                {
                    _marketValue = value;
                    OnPropertyChanged(nameof(MarketValue));
                }
            }
        }

        [Display(
            Name = nameof(InvestmentPerformanceDto_SR.NetContribution_Name),
            Description = nameof(InvestmentPerformanceDto_SR.NetContribution_Description),
            ResourceType = typeof(InvestmentPerformanceDto_SR))]
        public decimal NetContribution
        {
            get { return _netContribution; }
            set
            {
                if (_netContribution != value)
                {
                    _netContribution = value;
                    OnPropertyChanged(nameof(NetContribution));
                }
            }
        }

        [Display(
            Name = nameof(InvestmentPerformanceDto_SR.AverageCapital_Name),
            Description = nameof(InvestmentPerformanceDto_SR.AverageCapital_Description),
            ResourceType = typeof(InvestmentPerformanceDto_SR))]
        public decimal AverageCapital
        {
            get { return _averageCapital; }
            set
            {
                if (_averageCapital != value)
                {
                    _averageCapital = value;
                    OnPropertyChanged(nameof(AverageCapital));
                }
            }
        }

        [Display(
            Name = nameof(InvestmentPerformanceDto_SR.Gain_Name),
            Description = nameof(InvestmentPerformanceDto_SR.Gain_Description),
            ResourceType = typeof(InvestmentPerformanceDto_SR))]
        public decimal Gain
        {
            get { return _gain; }
            set
            {
                if (_gain != value)
                {
                    _gain = value;
                    OnPropertyChanged(nameof(Gain));
                }
            }
        }

        [Display(
            Name = nameof(InvestmentPerformanceDto_SR.Irr_Name),
            Description = nameof(InvestmentPerformanceDto_SR.Irr_Description),
            ResourceType = typeof(InvestmentPerformanceDto_SR))]
        public decimal Irr
        {
            get { return _irr; }
            set
            {
                if (_irr != value)
                {
                    _irr = value;
                    OnPropertyChanged(nameof(Irr));
                }
            }
        }
    }
}
