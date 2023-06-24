using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NjordinSight.DataTransfer.Common
{
    public class AccountBaseAttributeDto : DtoBase
    {
        private int _accountObjectId;
        private DateTime _effectiveDate;
        private decimal _percentWeight;

        public AccountBaseAttributeDto()
        {
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
