using System;
using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(AccountBaseAttributeDto_SR.Noun_Plural),
        PluralArticle = nameof(AccountBaseAttributeDto_SR.Noun_Plural_Article),
        Singular = nameof(AccountBaseAttributeDto_SR.Noun_Singular),
        SingularArticle = nameof(AccountBaseAttributeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(AccountBaseAttributeDto_SR)
        )]
    public class AccountBaseAttributeDto : DtoBase
    {
        private int _attributeMemberId;
        private int _accountObjectId;
        private DateTime _effectiveDate;
        private decimal _percentWeight;

        [Display(
            Name = nameof(AccountBaseAttributeDto_SR.AttributeMemberId_Name),
            Description = nameof(AccountBaseAttributeDto_SR.AttributeMemberId_Description),
            ResourceType = typeof(AccountBaseAttributeDto_SR))]
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
            Name = nameof(AccountBaseAttributeDto_SR.AccountObjectId_Name),
            Description = nameof(AccountBaseAttributeDto_SR.AccountObjectId_Description),
            ResourceType = typeof(AccountBaseAttributeDto_SR))]
        public int AccountObjectId
        {
            get { return _accountObjectId; }
            set
            {
                if (_accountObjectId != value)
                {
                    _accountObjectId = value;
                    OnPropertyChanged(nameof(AccountObjectId));
                }
            }
        }

        [Display(
            Name = nameof(AccountBaseAttributeDto_SR.EffectiveDate_Name),
            Description = nameof(AccountBaseAttributeDto_SR.EffectiveDate_Description),
            ResourceType = typeof(AccountBaseAttributeDto_SR))]
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
            Name = nameof(AccountBaseAttributeDto_SR.PercentWeight_Name),
            Description = nameof(AccountBaseAttributeDto_SR.PercentWeight_Description),
            ResourceType = typeof(AccountBaseAttributeDto_SR))]
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

        [Display(
            Name = nameof(AccountBaseAttributeDto_SR.AttributeMemberId_Name),
            Description = nameof(AccountBaseAttributeDto_SR.AttributeMemberId_Description),
            ResourceType = typeof(AccountBaseAttributeDto_SR))]
        public ModelAttributeMemberDto AttributeMember { get; set; } = new();
    }

}
