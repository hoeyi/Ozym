using Ichosys.DataModel.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(SecuritySymbolDto_SR.Noun_Plural),
        PluralArticle = nameof(SecuritySymbolDto_SR.Noun_Plural_Article),
        Singular = nameof(SecuritySymbolDto_SR.Noun_Singular),
        SingularArticle = nameof(SecuritySymbolDto_SR.Noun_Singular_Article),
        ResourceType = typeof(SecuritySymbolDto_SR)
        )]
    public class SecuritySymbolDto : DtoBase
    {
        private int _symbolId;
        private int _securityId;
        private DateTime _effectiveDate;
        private int _symbolTypeId;
        private string _symbol;
        private string _cusip;
        private string _customSymbol;
        private string _optionTicker;
        private string _ticker;

        [Key]
        public int SymbolId
        {
            get { return _symbolId; }
            set
            {
                if (_symbolId != value)
                {
                    _symbolId = value;
                    OnPropertyChanged(nameof(SymbolId));
                }
            }
        }

        [Display(
            Name = nameof(SecuritySymbolDto_SR.SecurityId_Name),
            Description = nameof(SecuritySymbolDto_SR.SecurityId_Description),
            ResourceType = typeof(SecuritySymbolDto_SR))]
        public int SecurityId
        {
            get { return _securityId; }
            set
            {
                if (_securityId != value)
                {
                    _securityId = value;
                    OnPropertyChanged(nameof(SecurityId));
                }
            }
        }

        [Display(
            Name = nameof(SecuritySymbolDto_SR.EffectiveDate_Name),
            Description = nameof(SecuritySymbolDto_SR.EffectiveDate_Description),
            ResourceType = typeof(SecuritySymbolDto_SR))]
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
            Name = nameof(SecuritySymbolDto_SR.SymbolTypeId_Name),
            Description = nameof(SecuritySymbolDto_SR.SymbolTypeId_Description),
            ResourceType = typeof(SecuritySymbolDto_SR))]
        public int SymbolTypeId
        {
            get { return _symbolTypeId; }
            set
            {
                if (_symbolTypeId != value)
                {
                    _symbolTypeId = value;
                    OnPropertyChanged(nameof(SymbolTypeId));
                }
            }
        }

        [Display(
            Name = nameof(SecuritySymbolDto_SR.Symbol_Name),
            Description = nameof(SecuritySymbolDto_SR.Symbol_Description),
            ResourceType = typeof(SecuritySymbolDto_SR))]
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                if (_symbol != value)
                {
                    _symbol = value;
                    OnPropertyChanged(nameof(Symbol));
                }
            }
        }

        [Display(
            Name = nameof(SecuritySymbolDto_SR.Cusip_Name),
            Description = nameof(SecuritySymbolDto_SR.Cusip_Description),
            ResourceType = typeof(SecuritySymbolDto_SR))]
        public string Cusip
        {
            get { return _cusip; }
            set
            {
                if (_cusip != value)
                {
                    _cusip = value;
                    OnPropertyChanged(nameof(Cusip));
                }
            }
        }

        [Display(
            Name = nameof(SecuritySymbolDto_SR.CustomSymbol_Name),
            Description = nameof(SecuritySymbolDto_SR.CustomSymbol_Description),
            ResourceType = typeof(SecuritySymbolDto_SR))]
        public string CustomSymbol
        {
            get { return _customSymbol; }
            set
            {
                if (_customSymbol != value)
                {
                    _customSymbol = value;
                    OnPropertyChanged(nameof(CustomSymbol));
                }
            }
        }

        [Display(
            Name = nameof(SecuritySymbolDto_SR.OptionTicker_Name),
            Description = nameof(SecuritySymbolDto_SR.OptionTicker_Description),
            ResourceType = typeof(SecuritySymbolDto_SR))]
        public string OptionTicker
        {
            get { return _optionTicker; }
            set
            {
                if (_optionTicker != value)
                {
                    _optionTicker = value;
                    OnPropertyChanged(nameof(OptionTicker));
                }
            }
        }

        [Display(
            Name = nameof(SecuritySymbolDto_SR.Ticker_Name),
            Description = nameof(SecuritySymbolDto_SR.Ticker_Description),
            ResourceType = typeof(SecuritySymbolDto_SR))]
        public string Ticker
        {
            get { return _ticker; }
            set
            {
                if (_ticker != value)
                {
                    _ticker = value;
                    OnPropertyChanged(nameof(Ticker));
                }
            }
        }
    }
}