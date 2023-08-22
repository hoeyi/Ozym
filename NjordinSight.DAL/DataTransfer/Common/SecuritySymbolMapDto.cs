using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    public class SecuritySymbolMapDto : DtoBase
    {
        private int _symbolMapId;
        private int _accountCustodianId;
        private string _custodianSymbol;
        private int _securitySymbolId;

        [Display(
            Name = nameof(SecuritySymbolMapDto_SR.SymbolMapId_Name),
            Description = nameof(SecuritySymbolMapDto_SR.SymbolMapId_Description),
            ResourceType = typeof(SecuritySymbolMapDto_SR))]
        public int SymbolMapId
        {
            get { return _symbolMapId; }
            set
            {
                if (_symbolMapId != value)
                {
                    _symbolMapId = value;
                    OnPropertyChanged(nameof(SymbolMapId));
                }
            }
        }

        [Display(
            Name = nameof(SecuritySymbolMapDto_SR.AccountCustodianId_Name),
            Description = nameof(SecuritySymbolMapDto_SR.AccountCustodianId_Description),
            ResourceType = typeof(SecuritySymbolMapDto_SR))]
        public int AccountCustodianId
        {
            get { return _accountCustodianId; }
            set
            {
                if (_accountCustodianId != value)
                {
                    _accountCustodianId = value;
                    OnPropertyChanged(nameof(AccountCustodianId));
                }
            }
        }

        [Display(
            Name = nameof(SecuritySymbolMapDto_SR.CustodianSymbol_Name),
            Description = nameof(SecuritySymbolMapDto_SR.CustodianSymbol_Description),
            ResourceType = typeof(SecuritySymbolMapDto_SR))]
        public string CustodianSymbol
        {
            get { return _custodianSymbol; }
            set
            {
                if (_custodianSymbol != value)
                {
                    _custodianSymbol = value;
                    OnPropertyChanged(nameof(CustodianSymbol));
                }
            }
        }

        [Display(
            Name = nameof(SecuritySymbolMapDto_SR.SecuritySymbolId_Name),
            Description = nameof(SecuritySymbolMapDto_SR.SecuritySymbolId_Description),
            ResourceType = typeof(SecuritySymbolMapDto_SR))]
        public int SecuritySymbolId
        {
            get { return _securitySymbolId; }
            set
            {
                if (_securitySymbolId != value)
                {
                    _securitySymbolId = value;
                    OnPropertyChanged(nameof(SecuritySymbolId));
                }
            }
        }
    }

}