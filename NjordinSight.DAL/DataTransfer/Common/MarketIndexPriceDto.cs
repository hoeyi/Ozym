using Ichosys.DataModel.Annotations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(MarketIndexPriceDto_SR.Noun_Plural),
        PluralArticle = nameof(MarketIndexPriceDto_SR.Noun_Plural_Article),
        Singular = nameof(MarketIndexPriceDto_SR.Noun_Singular),
        SingularArticle = nameof(MarketIndexPriceDto_SR.Noun_Singular_Article),
        ResourceType = typeof(MarketIndexPriceDto_SR)
        )]
    public class MarketIndexPriceDtoBase : DtoBase
    {
        private int _indexPriceId;
        private int _marketIndexId;
        private DateTime _priceDate;
        private string _priceCode;
        private decimal _price;

        [Key]
        public int IndexPriceId
        {
            get { return _indexPriceId; }
            set
            {
                if (_indexPriceId != value)
                {
                    _indexPriceId = value;
                    OnPropertyChanged(nameof(IndexPriceId));
                }
            }
        }

        [Display(
            Name = nameof(MarketIndexPriceDto_SR.MarketIndexId_Name),
            Description = nameof(MarketIndexPriceDto_SR.MarketIndexId_Description),
            ResourceType = typeof(MarketIndexPriceDto_SR))]
        public int MarketIndexId
        {
            get { return _marketIndexId; }
            set
            {
                if (_marketIndexId != value)
                {
                    _marketIndexId = value;
                    OnPropertyChanged(nameof(MarketIndexId));
                }
            }
        }

        [Display(
            Name = nameof(MarketIndexPriceDto_SR.PriceDate_Name),
            Description = nameof(MarketIndexPriceDto_SR.PriceDate_Description),
            ResourceType = typeof(MarketIndexPriceDto_SR))]
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
            Name = nameof(MarketIndexPriceDto_SR.PriceCode_Name),
            Description = nameof(MarketIndexPriceDto_SR.PriceCode_Description),
            ResourceType = typeof(MarketIndexPriceDto_SR))]
        public string PriceCode
        {
            get { return _priceCode; }
            set
            {
                if (_priceCode != value)
                {
                    _priceCode = value;
                    OnPropertyChanged(nameof(PriceCode));
                }
            }
        }

        [Display(
            Name = nameof(MarketIndexPriceDto_SR.Price_Name),
            Description = nameof(MarketIndexPriceDto_SR.Price_Description),
            ResourceType = typeof(MarketIndexPriceDto_SR))]
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
    }

    [Noun(
        Plural = nameof(MarketIndexPriceDto_SR.Noun_Plural),
        PluralArticle = nameof(MarketIndexPriceDto_SR.Noun_Plural_Article),
        Singular = nameof(MarketIndexPriceDto_SR.Noun_Singular),
        SingularArticle = nameof(MarketIndexPriceDto_SR.Noun_Singular_Article),
        ResourceType = typeof(MarketIndexPriceDto_SR)
        )]
    public class MarketIndexPriceDto : MarketIndexPriceDtoBase
    {
        public MarketIndexDto MarketIndex { get; set; }
    }
}
