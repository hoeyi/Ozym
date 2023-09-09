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
        Plural = nameof(SecurityAttributeDto_SR.Noun_Plural),
        PluralArticle = nameof(SecurityAttributeDto_SR.Noun_Plural_Article),
        Singular = nameof(SecurityAttributeDto_SR.Noun_Singular),
        SingularArticle = nameof(SecurityAttributeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(SecurityAttributeDto_SR)
        )]
    public class SecurityAttributeDto : DtoBase
    {
        private int _attributeMemberId;
        private int _securityId;
        private DateTime _effectiveDate;
        private decimal _percentWeight;

        [Display(
            Name = nameof(SecurityAttributeDto_SR.AttributeMemberId_Name),
            Description = nameof(SecurityAttributeDto_SR.AttributeMemberId_Description),
            ResourceType = typeof(SecurityAttributeDto_SR))]
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
            Name = nameof(SecurityAttributeDto_SR.SecurityId_Name),
            Description = nameof(SecurityAttributeDto_SR.SecurityId_Description),
            ResourceType = typeof(SecurityAttributeDto_SR))]
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
            Name = nameof(SecurityAttributeDto_SR.EffectiveDate_Name),
            Description = nameof(SecurityAttributeDto_SR.EffectiveDate_Description),
            ResourceType = typeof(SecurityAttributeDto_SR))]
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
            Name = nameof(SecurityAttributeDto_SR.PercentWeight_Name),
            Description = nameof(SecurityAttributeDto_SR.PercentWeight_Description),
            ResourceType = typeof(SecurityAttributeDto_SR))]
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

        public ModelAttributeMemberDto AttributeMember { get; set; } = new();
    }

}
