using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class ModelAttributeValueDto : DtoBase
    {
        private int _attributeMemberId;
        private int _attributeId;
        private string _displayName;
        private int _displayOrder;

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
            Name = nameof(ModelAttributeValueDto_SR.AttributeId_Name),
            Description = nameof(ModelAttributeValueDto_SR.AttributeId_Description),
            ResourceType = typeof(ModelAttributeValueDto_SR))]
        public int AttributeId
        {
            get { return _attributeId; }
            set
            {
                if (_attributeId != value)
                {
                    _attributeId = value;
                    OnPropertyChanged(nameof(AttributeId));
                }
            }
        }

        [Display(
            Name = nameof(ModelAttributeValueDto_SR.DisplayName_Name),
            Description = nameof(ModelAttributeValueDto_SR.DisplayName_Description),
            ResourceType = typeof(ModelAttributeValueDto_SR))]
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
            Name = nameof(ModelAttributeValueDto_SR.DisplayOrder_Name),
            Description = nameof(ModelAttributeValueDto_SR.DisplayOrder_Description),
            ResourceType = typeof(ModelAttributeValueDto_SR))]
        public int DisplayOrder
        {
            get { return _displayOrder; }
            set
            {
                if (_displayOrder != value)
                {
                    _displayOrder = value;
                    OnPropertyChanged(nameof(DisplayOrder));
                }
            }
        }
    }


    

    

    

}


