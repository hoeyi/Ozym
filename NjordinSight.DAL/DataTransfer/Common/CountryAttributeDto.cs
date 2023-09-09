using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ichosys.DataModel.Annotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(CountryAttributeDto_SR.Noun_Plural),
        PluralArticle = nameof(CountryAttributeDto_SR.Noun_Plural_Article),
        Singular = nameof(CountryAttributeDto_SR.Noun_Singular),
        SingularArticle = nameof(CountryAttributeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(CountryAttributeDto_SR)
        )]
    public class CountryAttributeDto : DtoBase
    {
        private int _attributeMemberId;
        private int _countryId;
        private DateTime _effectiveDate;
        private decimal _percentWeight;

        [Display(
            Name = nameof(CountryAttributeDto_SR.AttributeMemberId_Name),
            Description = nameof(CountryAttributeDto_SR.AttributeMemberId_Description),
            ResourceType = typeof(CountryAttributeDto_SR))]
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
            Name = nameof(CountryAttributeDto_SR.CountryId_Name),
            Description = nameof(CountryAttributeDto_SR.CountryId_Description),
            ResourceType = typeof(CountryAttributeDto_SR))]
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
            Name = nameof(CountryAttributeDto_SR.EffectiveDate_Name),
            Description = nameof(CountryAttributeDto_SR.EffectiveDate_Description),
            ResourceType = typeof(CountryAttributeDto_SR))]
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
            Name = nameof(CountryAttributeDto_SR.PercentWeight_Name),
            Description = nameof(CountryAttributeDto_SR.PercentWeight_Description),
            ResourceType = typeof(CountryAttributeDto_SR))]
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

        public ModelAttributeMemberDto AttributeMember { get; set; }

    }

}
