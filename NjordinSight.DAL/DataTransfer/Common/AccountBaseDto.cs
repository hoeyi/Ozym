using NjordinSight.DataTransfer.Common.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NjordinSight.DataTransfer.Common
{
    public abstract class AccountBaseDto : DtoBase
    {
        private int _id;
        private string _shortCode;
        private DateTime _startDate;
        private DateTime? _closeDate;
        private string _displayName;
        private string _description;

        public AccountBaseDto()
        {
            Attributes = new List<AccountBaseAttributeDto>();
            AttributeCollection = new(this);
        }

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

        public abstract string ObjectType { get; }

        public ICollection<AccountBaseAttributeDto> Attributes { get; set; } 
            = new List<AccountBaseAttributeDto>();

        [JsonIgnore]
        public AccountAttributeDtoCollection AttributeCollection { get; set; }
    }
}
