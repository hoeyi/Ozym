using Ichosys.DataModel.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(SecurityTypeDto_SR.Noun_Plural),
        PluralArticle = nameof(SecurityTypeDto_SR.Noun_Plural_Article),
        Singular = nameof(SecurityTypeDto_SR.Noun_Singular),
        SingularArticle = nameof(SecurityTypeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(SecurityTypeDto_SR)
        )]
    public class SecurityTypeDto : DtoBase
    {
        private int _securityTypeId;
        private int _securityTypeGroupId;
        private string _securityTypeName;
        private decimal _valuationFactor;
        private bool _canHaveDerivative;
        private bool _canHavePosition;
        private bool _heldInWallet;

        [Key]
        public int SecurityTypeId
        {
            get { return _securityTypeId; }
            set
            {
                if (_securityTypeId != value)
                {
                    _securityTypeId = value;
                    OnPropertyChanged(nameof(SecurityTypeId));
                }
            }
        }

        [Display(
            Name = nameof(SecurityTypeDto_SR.SecurityTypeGroupId_Name),
            Description = nameof(SecurityTypeDto_SR.SecurityTypeGroupId_Description),
            ResourceType = typeof(SecurityTypeDto_SR))]
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
            Name = nameof(SecurityTypeDto_SR.SecurityTypeName_Name),
            Description = nameof(SecurityTypeDto_SR.SecurityTypeName_Description),
            ResourceType = typeof(SecurityTypeDto_SR))]
        public string SecurityTypeName
        {
            get { return _securityTypeName; }
            set
            {
                if (_securityTypeName != value)
                {
                    _securityTypeName = value;
                    OnPropertyChanged(nameof(SecurityTypeName));
                }
            }
        }

        [Display(
            Name = nameof(SecurityTypeDto_SR.ValuationFactor_Name),
            Description = nameof(SecurityTypeDto_SR.ValuationFactor_Description),
            ResourceType = typeof(SecurityTypeDto_SR))]
        public decimal ValuationFactor
        {
            get { return _valuationFactor; }
            set
            {
                if (_valuationFactor != value)
                {
                    _valuationFactor = value;
                    OnPropertyChanged(nameof(ValuationFactor));
                }
            }
        }

        [Display(
            Name = nameof(SecurityTypeDto_SR.CanHaveDerivative_Name),
            Description = nameof(SecurityTypeDto_SR.CanHaveDerivative_Description),
            ResourceType = typeof(SecurityTypeDto_SR))]
        public bool CanHaveDerivative
        {
            get { return _canHaveDerivative; }
            set
            {
                if (_canHaveDerivative != value)
                {
                    _canHaveDerivative = value;
                    OnPropertyChanged(nameof(CanHaveDerivative));
                }
            }
        }

        [Display(
            Name = nameof(SecurityTypeDto_SR.CanHavePosition_Name),
            Description = nameof(SecurityTypeDto_SR.CanHavePosition_Description),
            ResourceType = typeof(SecurityTypeDto_SR))]
        public bool CanHavePosition
        {
            get { return _canHavePosition; }
            set
            {
                if (_canHavePosition != value)
                {
                    _canHavePosition = value;
                    OnPropertyChanged(nameof(CanHavePosition));
                }
            }
        }

        [Display(
            Name = nameof(SecurityTypeDto_SR.HeldInWallet_Name),
            Description = nameof(SecurityTypeDto_SR.HeldInWallet_Description),
            ResourceType = typeof(SecurityTypeDto_SR))]
        public bool HeldInWallet
        {
            get { return _heldInWallet; }
            set
            {
                if (_heldInWallet != value)
                {
                    _heldInWallet = value;
                    OnPropertyChanged(nameof(HeldInWallet));
                }
            }
        }

        [Display(
            Name = nameof(SecurityTypeDto_SR.DisplayOrder_Name),
            Description = nameof(SecurityTypeDto_SR.DisplayOrder_Description),
            ResourceType = typeof(SecurityTypeDto_SR))]
        public int DisplayOrder { get; set; }
    }

}