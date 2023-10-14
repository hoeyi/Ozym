using Ichosys.DataModel.Annotations;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(SecurityTypeGroupDto_SR.Noun_Plural),
        PluralArticle = nameof(SecurityTypeGroupDto_SR.Noun_Plural_Article),
        Singular = nameof(SecurityTypeGroupDto_SR.Noun_Singular),
        SingularArticle = nameof(SecurityTypeGroupDto_SR.Noun_Singular_Article),
        ResourceType = typeof(SecurityTypeGroupDto_SR)
        )]
    public class SecurityTypeGroupDto : DtoBase
    {
        private int _securityTypeGroupId;
        private string _securityTypeGroupName;
        private bool _transactable;
        private bool _depositSource;
        private int _displayOrder;

        [Key]
        public int SecurityTypeGroupId
        {
            get { return _securityTypeGroupId; }
            set
            {
                if (_securityTypeGroupId != value)
                {
                    _securityTypeGroupId = value;
                    OnPropertyChanged(nameof(SecurityTypeGroupId));
                }
            }
        }

        [Display(
            Name = nameof(SecurityTypeGroupDto_SR.SecurityTypeGroupName_Name),
            Description = nameof(SecurityTypeGroupDto_SR.SecurityTypeGroupName_Description),
            ResourceType = typeof(SecurityTypeGroupDto_SR))]
        public string SecurityTypeGroupName
        {
            get { return _securityTypeGroupName; }
            set
            {
                if (_securityTypeGroupName != value)
                {
                    _securityTypeGroupName = value;
                    OnPropertyChanged(nameof(SecurityTypeGroupName));
                }
            }
        }

        [Display(
            Name = nameof(SecurityTypeGroupDto_SR.Transactable_Name),
            Description = nameof(SecurityTypeGroupDto_SR.Transactable_Description),
            ResourceType = typeof(SecurityTypeGroupDto_SR))]
        public bool Transactable
        {
            get { return _transactable; }
            set
            {
                if (_transactable != value)
                {
                    _transactable = value;
                    OnPropertyChanged(nameof(Transactable));
                }
            }
        }

        [Display(
            Name = nameof(SecurityTypeGroupDto_SR.DepositSource_Name),
            Description = nameof(SecurityTypeGroupDto_SR.DepositSource_Description),
            ResourceType = typeof(SecurityTypeGroupDto_SR))]
        public bool DepositSource
        {
            get { return _depositSource; }
            set
            {
                if (_depositSource != value)
                {
                    _depositSource = value;
                    OnPropertyChanged(nameof(DepositSource));
                }
            }
        }

        [Display(
            Name = nameof(SecurityTypeGroupDto_SR.DisplayOrder_Name),
            Description = nameof(SecurityTypeGroupDto_SR.DisplayOrder_Description),
            ResourceType = typeof(SecurityTypeGroupDto_SR))]
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