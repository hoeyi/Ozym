using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NjordinSight.DataTransfer.Common.Collections;

namespace NjordinSight.DataTransfer.Common
{
    public class CountryDto : DtoBase, INotifyPropertyChanged
    {
        private int _countryId;
        private string _displayName;
        private string _isoCode3;

        public CountryDto()
        {
            Attributes = new List<CountryAttributeDto>();
            AttributeCollection = new(this);
        }

        [Display(
            Name = nameof(CountryDto_SR.CountryId_Name),
            Description = nameof(CountryDto_SR.CountryId_Description),
            ResourceType = typeof(CountryDto_SR))]
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
        public int DisplayOrder { get; set; }

        public CountryAttributeDtoCollection AttributeCollection { get; set; }

        public ICollection<CountryAttributeDto> Attributes { get; set; }
    }

}
