using Ichosys.DataModel.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(SecurityPriceDto_SR.Noun_Plural),
        PluralArticle = nameof(SecurityPriceDto_SR.Noun_Plural_Article),
        Singular = nameof(SecurityPriceDto_SR.Noun_Singular),
        SingularArticle = nameof(SecurityPriceDto_SR.Noun_Singular_Article),
        ResourceType = typeof(SecurityPriceDto_SR)
        )]
    public class SecurityPriceDto : DtoBase
    {
        private int _priceId;
        private int _securityId;
        private DateTime _priceDate;
        private decimal _priceClose;
        private decimal _priceOpen;
        private decimal _priceHigh;
        private decimal _priceLow;
        private int _volume;

        [Key]
        public int PriceId
        {
            get { return _priceId; }
            set
            {
                if (_priceId != value)
                {
                    _priceId = value;
                    OnPropertyChanged(nameof(PriceId));
                }
            }
        }

        [Display(
            Name = nameof(SecurityPriceDto_SR.SecurityId_Name),
            Description = nameof(SecurityPriceDto_SR.SecurityId_Description),
            ResourceType = typeof(SecurityPriceDto_SR))]
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
            Name = nameof(SecurityPriceDto_SR.PriceDate_Name),
            Description = nameof(SecurityPriceDto_SR.PriceDate_Description),
            ResourceType = typeof(SecurityPriceDto_SR))]
        public DateTime PriceDate
        {
            get { return _priceDate; }
            set
            {
                if (_priceDate != value)
                {
                    _priceDate = value;
                    OnPropertyChanged(nameof(PriceDate));
                }
            }
        }

        [Display(
            Name = nameof(SecurityPriceDto_SR.PriceClose_Name),
            Description = nameof(SecurityPriceDto_SR.PriceClose_Description),
            ResourceType = typeof(SecurityPriceDto_SR))]
        public decimal PriceClose
        {
            get { return _priceClose; }
            set
            {
                if (_priceClose != value)
                {
                    _priceClose = value;
                    OnPropertyChanged(nameof(PriceClose));
                }
            }
        }

        [Display(
            Name = nameof(SecurityPriceDto_SR.PriceOpen_Name),
            Description = nameof(SecurityPriceDto_SR.PriceOpen_Description),
            ResourceType = typeof(SecurityPriceDto_SR))]
        public decimal PriceOpen
        {
            get { return _priceOpen; }
            set
            {
                if (_priceOpen != value)
                {
                    _priceOpen = value;
                    OnPropertyChanged(nameof(PriceOpen));
                }
            }
        }

        [Display(
            Name = nameof(SecurityPriceDto_SR.PriceHigh_Name),
            Description = nameof(SecurityPriceDto_SR.PriceHigh_Description),
            ResourceType = typeof(SecurityPriceDto_SR))]
        public decimal PriceHigh
        {
            get { return _priceHigh; }
            set
            {
                if (_priceHigh != value)
                {
                    _priceHigh = value;
                    OnPropertyChanged(nameof(PriceHigh));
                }
            }
        }

        [Display(
            Name = nameof(SecurityPriceDto_SR.PriceLow_Name),
            Description = nameof(SecurityPriceDto_SR.PriceLow_Description),
            ResourceType = typeof(SecurityPriceDto_SR))]
        public decimal PriceLow
        {
            get { return _priceLow; }
            set
            {
                if (_priceLow != value)
                {
                    _priceLow = value;
                    OnPropertyChanged(nameof(PriceLow));
                }
            }
        }

        [Display(
            Name = nameof(SecurityPriceDto_SR.Volume_Name),
            Description = nameof(SecurityPriceDto_SR.Volume_Description),
            ResourceType = typeof(SecurityPriceDto_SR))]
        public int Volume
        {
            get { return _volume; }
            set
            {
                if (_volume != value)
                {
                    _volume = value;
                    OnPropertyChanged(nameof(Volume));
                }
            }
        }
    }

}