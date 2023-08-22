using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NjordinSight.DataTransfer.Common
{
    public class SecuritySymbolTypeDto : DtoBase
    {
        private int _symbolTypeId;
        private string _symbolTypeName;

        [Display(
            Name = nameof(SecuritySymbolTypeDto_SR.SymbolTypeId_Name),
            Description = nameof(SecuritySymbolTypeDto_SR.SymbolTypeId_Description),
            ResourceType = typeof(SecuritySymbolTypeDto_SR))]
        public int SymbolTypeId
        {
            get { return _symbolTypeId; }
            set
            {
                if (_symbolTypeId != value)
                {
                    _symbolTypeId = value;
                    OnPropertyChanged(nameof(SymbolTypeId));
                }
            }
        }

        [Display(
            Name = nameof(SecuritySymbolTypeDto_SR.SymbolTypeName_Name),
            Description = nameof(SecuritySymbolTypeDto_SR.SymbolTypeName_Description),
            ResourceType = typeof(SecuritySymbolTypeDto_SR))]
        public string SymbolTypeName
        {
            get { return _symbolTypeName; }
            set
            {
                if (_symbolTypeName != value)
                {
                    _symbolTypeName = value;
                    OnPropertyChanged(nameof(SymbolTypeName));
                }
            }
        }
    }

}
