using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class SecurityTypeGroupDto : DtoBase
    {
        private int _securityTypeGroupId;
        private string _securityTypeGroupName;
        private bool _transactable;
        private bool _depositSource;

        [Display(
            Name = nameof(SecurityTypeGroupDto_SR.SecurityTypeGroupId_Name),
            Description = nameof(SecurityTypeGroupDto_SR.SecurityTypeGroupId_Description),
            ResourceType = typeof(SecurityTypeGroupDto_SR))]
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
    }

}