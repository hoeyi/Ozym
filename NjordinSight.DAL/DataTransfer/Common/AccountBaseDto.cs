using Ichosys.DataModel.Annotations;
using NjordinSight.DataTransfer.Common.Collections;
using NjordinSight.EntityModel.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NjordinSight.DataTransfer.Common
{
    public class AccountBaseSimpleDto : DtoBase
    {
        private int _id;
        private string _shortCode;
        private DateTime _startDate;
        private DateTime? _closeDate;
        private string _displayName;
        private string _description;

        [Key]
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        [Display(
            Name = nameof(AccountCompositeDto_SR.ShortCode_Name),
            Description = nameof(AccountCompositeDto_SR.ShortCode_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(12,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [Searchable]
        public virtual string ShortCode
        {
            get { return _shortCode; }
            set
            {
                if (_shortCode != value)
                {
                    _shortCode = value;
                    OnPropertyChanged(nameof(ShortCode));
                }
            }
        }

        [Display(
            Name = nameof(AccountCompositeDto_SR.StartDate_Name),
            Description = nameof(AccountCompositeDto_SR.StartDate_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        [Searchable]
        public virtual DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        [Display(
            Name = nameof(AccountCompositeDto_SR.CloseDate_Name),
            Description = nameof(AccountCompositeDto_SR.CloseDate_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        [Searchable]
        public virtual DateTime? CloseDate
        {
            get { return _closeDate; }
            set
            {
                if (_closeDate != value)
                {
                    _closeDate = value;
                    OnPropertyChanged(nameof(CloseDate));
                }
            }
        }

        [Display(
            Name = nameof(AccountCompositeDto_SR.DisplayName_Name),
            Description = nameof(AccountCompositeDto_SR.DisplayName_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [Searchable]
        public virtual string DisplayName

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
            Name = nameof(AccountCompositeDto_SR.Description_Name),
            Description = nameof(AccountCompositeDto_SR.Description_Description),
            ResourceType = typeof(AccountCompositeDto_SR))]
        [StringLength(128,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [Searchable]
        public virtual string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public virtual string ObjectType { get; } = string.Empty;
    }

    public class AccountBaseDto : AccountBaseSimpleDto
    {
        private ICollection<AccountBaseAttributeDto> _attributes;

        public AccountBaseDto()
        {
            Attributes = new HashSet<AccountBaseAttributeDto>();
        }

        public ICollection<AccountBaseAttributeDto> Attributes
        {
            get { return _attributes; }
            set
            {
                if(_attributes != value)
                {
                    _attributes = value;
                    AttributeCollection = new(this);
                }
            }
        }

        [JsonIgnore]
        public AccountAttributeDtoCollection AttributeCollection { get; private set; }
    }
}
