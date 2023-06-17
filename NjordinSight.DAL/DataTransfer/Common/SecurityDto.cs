using NjordinSight.DataTransfer.Common.Collections;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public  class SecurityDto : DtoBase
    {
        private int _securityId;
        private int _securityTypeId;
        private int _securityExchangeId;
        private string _securityDescription;
        private string _issuer;
        private bool _hasPerpetualMarket;
        private bool _hasPerpetualPrice;

        public SecurityDto()
        {
            Attributes = new List<SecurityAttributeDto>();
            AttributeCollection = new(this);
            Symbols = new List<SecuritySymbolDto>();
        }

        [Display(
            Name = nameof(SecurityDto_SR.SecurityId_Name),
            Description = nameof(SecurityDto_SR.SecurityId_Description),
            ResourceType = typeof(SecurityDto_SR))]
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
            Name = nameof(SecurityDto_SR.SecurityTypeId_Name),
            Description = nameof(SecurityDto_SR.SecurityTypeId_Description),
            ResourceType = typeof(SecurityDto_SR))]
        public int SecurityTypeId
        {
            get { return _securityTypeId; }
            set
            {
                if (_securityTypeId != value)
                {
                    _securityTypeId = value;
                    OnPropertyChanged(nameof(SecurityTypeId));
                }
            }
        }

        [Display(
            Name = nameof(SecurityDto_SR.SecurityExchangeId_Name),
            Description = nameof(SecurityDto_SR.SecurityExchangeId_Description),
            ResourceType = typeof(SecurityDto_SR))]
        public int SecurityExchangeId
        {
            get { return _securityExchangeId; }
            set
            {
                if (_securityExchangeId != value)
                {
                    _securityExchangeId = value;
                    OnPropertyChanged(nameof(SecurityExchangeId));
                }
            }
        }

        [Display(
            Name = nameof(SecurityDto_SR.SecurityDescription_Name),
            Description = nameof(SecurityDto_SR.SecurityDescription_Description),
            ResourceType = typeof(SecurityDto_SR))]
        public string SecurityDescription
        {
            get { return _securityDescription; }
            set
            {
                if (_securityDescription != value)
                {
                    _securityDescription = value;
                    OnPropertyChanged(nameof(SecurityDescription));
                }
            }
        }

        [Display(
            Name = nameof(SecurityDto_SR.Issuer_Name),
            Description = nameof(SecurityDto_SR.Issuer_Description),
            ResourceType = typeof(SecurityDto_SR))]
        public string Issuer
        {
            get { return _issuer; }
            set
            {
                if (_issuer != value)
                {
                    _issuer = value;
                    OnPropertyChanged(nameof(Issuer));
                }
            }
        }

        [Display(
            Name = nameof(SecurityDto_SR.HasPerpetualMarket_Name),
            Description = nameof(SecurityDto_SR.HasPerpetualMarket_Description),
            ResourceType = typeof(SecurityDto_SR))]
        public bool HasPerpetualMarket
        {
            get { return _hasPerpetualMarket; }
            set
            {
                if (_hasPerpetualMarket != value)
                {
                    _hasPerpetualMarket = value;
                    OnPropertyChanged(nameof(HasPerpetualMarket));
                }
            }
        }

        [Display(
            Name = nameof(SecurityDto_SR.HasPerpetualPrice_Name),
            Description = nameof(SecurityDto_SR.HasPerpetualPrice_Description),
            ResourceType = typeof(SecurityDto_SR))]
        public bool HasPerpetualPrice
        {
            get { return _hasPerpetualPrice; }
            set
            {
                if (_hasPerpetualPrice != value)
                {
                    _hasPerpetualPrice = value;
                    OnPropertyChanged(nameof(HasPerpetualPrice));
                }
            }
        }

        public SecurityAttributeDtoCollection AttributeCollection { get; set; }

        public ICollection<SecurityAttributeDto> Attributes { get; set; }

        public ICollection<SecuritySymbolDto> Symbols { get; set; }
    }
}
