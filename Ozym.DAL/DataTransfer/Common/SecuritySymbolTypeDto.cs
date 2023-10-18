using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(SecuritySymbolTypeDto_SR.Noun_Plural),
        PluralArticle = nameof(SecuritySymbolTypeDto_SR.Noun_Plural_Article),
        Singular = nameof(SecuritySymbolTypeDto_SR.Noun_Singular),
        SingularArticle = nameof(SecuritySymbolTypeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(SecuritySymbolTypeDto_SR)
        )]
    public class SecuritySymbolTypeDto : DtoBase
    {
        private int _symbolTypeId;
        private string _symbolTypeName;

        [Key]
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
