using Ichosys.DataModel.Annotations;
using Ozym.DataTransfer.Common.Collections;
using Ozym.EntityModel.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(SecurityDto_SR.Noun_Plural),
        PluralArticle = nameof(SecurityDto_SR.Noun_Plural_Article),
        Singular = nameof(SecurityDto_SR.Noun_Singular),
        SingularArticle = nameof(SecurityDto_SR.Noun_Singular_Article),
        ResourceType = typeof(SecurityDto_SR)
        )]
    public class SecurityDtoBase : DtoBase
    {
        private int _securityId;
        private int _securityTypeId;
        private int? _securityExchangeId;
        private string _securityDescription;
        private string _issuer;
        private bool _hasPerpetualMarket;
        private bool _hasPerpetualPrice;

        [Key]
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
        public int? SecurityExchangeId
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
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
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
        [StringLength(96,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
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

        [Display(
            Name = nameof(SecurityDto_SR.CurrentySymbol_Name),
            Description = nameof(SecurityDto_SR.CurrentSymbol_Description),
            ResourceType = typeof(SecurityDto_SR))]
        public string? CurrentSymbol { get; set; }
    }

    [Noun(
        Plural = nameof(SecurityDto_SR.Noun_Plural),
        PluralArticle = nameof(SecurityDto_SR.Noun_Plural_Article),
        Singular = nameof(SecurityDto_SR.Noun_Singular),
        SingularArticle = nameof(SecurityDto_SR.Noun_Singular_Article),
        ResourceType = typeof(SecurityDto_SR)
        )]
    public class SecurityDto : SecurityDtoBase
    {
        private ICollection<SecurityAttributeDto> _attributes;

        public SecurityDto()
        {
            Attributes = new HashSet<SecurityAttributeDto>();
            Symbols = new HashSet<SecuritySymbolDto>();
        }

        public ICollection<SecurityAttributeDto> Attributes
        {
            get { return _attributes; }
            set
            {
                if (_attributes != value)
                {
                    _attributes = value;
                    AttributeCollection = new(this);
                }
            }
        }

        public ICollection<SecuritySymbolDto> Symbols { get; set; }

        [JsonIgnore]
        public SecurityAttributeDtoCollection AttributeCollection { get; private set; }
    }
}
