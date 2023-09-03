using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class ModelAttributeMemberDtoBase : DtoBase
    {
        private int _attributeMemberId;
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
            Name = nameof(ModelAttributeMemberDto_SR.DisplayName_Name),
            Description = nameof(ModelAttributeMemberDto_SR.DisplayName_Description),
            ResourceType = typeof(ModelAttributeMemberDto_SR))]
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
            Name = nameof(ModelAttributeMemberDto_SR.DisplayOrder_Name),
            Description = nameof(ModelAttributeMemberDto_SR.DisplayOrder_Description),
            ResourceType = typeof(ModelAttributeMemberDto_SR))]
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

    public class ModelAttributeMemberDto : ModelAttributeMemberDtoBase
    {
        [Display(
            Name = nameof(ModelAttributeMemberDto_SR.AttributeId_Name),
            Description = nameof(ModelAttributeMemberDto_SR.AttributeId_Description),
            ResourceType = typeof(ModelAttributeMemberDto_SR))]
        public ModelAttributeDtoBase Attribute { get; set; } = new();
    }
}


