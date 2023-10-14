using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NjordinSight.DataTransfer.Common.Collections;
using NjordinSight.EntityModel.Metadata;
using System.Text.Json.Serialization;
using Ichosys.DataModel.Annotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(CountryDto_SR.Noun_Plural),
        PluralArticle = nameof(CountryDto_SR.Noun_Plural_Article),
        Singular = nameof(CountryDto_SR.Noun_Singular),
        SingularArticle = nameof(CountryDto_SR.Noun_Singular_Article),
        ResourceType = typeof(CountryDto_SR)
        )]
    public class CountryDtoBase : DtoBase
    {
        private int _countryId;
        private string _displayName;
        private string _isoCode3;
        private int _displayOrder;

        [Key]
        public int CountryId
        {
            get { return _countryId; }
            set
            {
                if (_countryId != value)
                {
                    _countryId = value;
                    OnPropertyChanged(nameof(CountryId));
                }
            }
        }

        [Display(
            Name = nameof(CountryDto_SR.DisplayName_Name),
            Description = nameof(CountryDto_SR.DisplayName_Description),
            ResourceType = typeof(CountryDto_SR))]
        [Required(
                    ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
                    ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(32,
                    ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
                    ErrorMessageResourceType = typeof(ModelValidation))]
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    OnPropertyChanged(nameof(DisplayName));
                }
            }
        }

        [Display(
            Name = nameof(CountryDto_SR.IsoCode3_Name),
            Description = nameof(CountryDto_SR.IsoCode3_Description),
            ResourceType = typeof(CountryDto_SR))]
        public string IsoCode3
        {
            get { return _isoCode3; }
            set
            {
                if (_isoCode3 != value)
                {
                    _isoCode3 = value;
                    OnPropertyChanged(nameof(IsoCode3));
                }
            }
        }

        [Display(
            Name = nameof(CountryDto_SR.DisplayOrder_Name),
            Description = nameof(CountryDto_SR.DisplayOrder_Description),
            ResourceType = typeof(CountryDto_SR))]
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set
            {
                if(_displayOrder != value)
                {
                    _displayOrder = value;
                    OnPropertyChanged(nameof(DisplayOrder));
                }
            }
        }
    }

    [Noun(
        Plural = nameof(CountryDto_SR.Noun_Plural),
        PluralArticle = nameof(CountryDto_SR.Noun_Plural_Article),
        Singular = nameof(CountryDto_SR.Noun_Singular),
        SingularArticle = nameof(CountryDto_SR.Noun_Singular_Article),
        ResourceType = typeof(CountryDto_SR)
        )]
    public class CountryDto : CountryDtoBase
    {
        private ICollection<CountryAttributeDto> _attributes;

        public CountryDto()
        {
            Attributes = new HashSet<CountryAttributeDto>();
        }
        public ICollection<CountryAttributeDto> Attributes
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

        [JsonIgnore]
        public CountryAttributeDtoCollection AttributeCollection { get; set; }
    }
}
