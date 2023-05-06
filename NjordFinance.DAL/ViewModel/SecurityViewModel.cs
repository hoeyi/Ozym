using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.Model;
using NjordFinance.Model.Metadata;

namespace NjordFinance.ViewModel
{
    public class SecurityViewModel
    {
        private readonly Security _security;
        private readonly SecurityAttributeViewModel _attributeViewModel;

        public SecurityViewModel(Security sourceModel)
        {
            _security = sourceModel;
            _attributeViewModel = new(sourceModel);
        }

        public SecurityAttributeViewModel AttributeViewModel => _attributeViewModel;

        public int SecurityId
        {
            get { return _security.SecurityId; }
            set
            {
                if (_security.SecurityId != value)
                    _security.SecurityId = value;
            }
        }

        [Display(
            Name = nameof(ModelDisplay.Security_SecurityTypeID_Name),
            Description = nameof(ModelDisplay.Security_SecurityTypeID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int SecurityTypeId
        {
            get { return _security.SecurityTypeId; }
            set
            {
                if (_security.SecurityTypeId != value)
                    _security.SecurityTypeId = value;
            }
        }
        
        [Display(
            Name = nameof(ModelDisplay.Security_SecurityExchangeID_Name),
            Description = nameof(ModelDisplay.Security_SecurityExchangeID_Description),
            ResourceType = typeof(ModelDisplay))]
        public int? SecurityExchangeId
        {
            get { return _security.SecurityExchangeId; }
            set
            {
                if (_security.SecurityExchangeId != value)
                    _security.SecurityExchangeId = value;
            }
        }

        [Display(
            Name = nameof(ModelDisplay.Security_SecurityDescription_Name),
            Description = nameof(ModelDisplay.Security_SecurityDescription_Description),
            ResourceType = typeof(ModelDisplay))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        [StringLength(72,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string SecurityDescription
        {
            get { return _security.SecurityDescription; }
            set
            {
                if (_security.SecurityDescription != value)
                    _security.SecurityDescription = value;
            }
        }
        
        [Display(
            Name = nameof(ModelDisplay.Security_Issuer_Name),
            Description = nameof(ModelDisplay.Security_Issuer_Description),
            ResourceType = typeof(ModelDisplay))]
        [StringLength(96,
            ErrorMessageResourceName = nameof(ModelValidation.StringLengthAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
        public string Issuer
        {
            get { return _security.Issuer; }
            set
            {
                if (_security.Issuer != value)
                    _security.Issuer = value;
            }
        }

        [Display(
            Name = nameof(ModelDisplay.Security_HasPerpetualMarket_Name),
            Description = nameof(ModelDisplay.Security_HasPerpetualMarket_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasPerpetualMarket
        {
            get { return _security.HasPerpetualMarket; }
            set
            {
                if (_security.HasPerpetualMarket != value)
                    _security.HasPerpetualMarket = value;
            }
        }

        [Display(
            Name = nameof(ModelDisplay.Security_HasPerpetualPrice_Name),
            Description = nameof(ModelDisplay.Security_HasPerpetualPrice_Description),
            ResourceType = typeof(ModelDisplay))]
        public bool HasPerpetualPrice
        {
            get { return _security.HasPerpetualPrice; }
            set
            {
                if (_security.HasPerpetualPrice != value)
                    _security.HasPerpetualPrice = value;
            }
        }

        public IReadOnlyCollection<SecuritySymbol> SecuritySymbols => _security.SecuritySymbols.ToList();

        public void AddNewSecuritySymbol() => _security.SecuritySymbols.Add(new()
        {
            SecurityId = _security.SecurityId,
            EffectiveDate = DateTime.UtcNow.Date
        });

        public void RemoveSecuritySymbol(SecuritySymbol securitySymbol) =>
            _security.SecuritySymbols.Remove(securitySymbol);
        
        public Security ToEntity() => _security;
    }
}
