using Ichosys.DataModel.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Ozym.DataTransfer.Common
{
    [Noun(
        Plural = nameof(ModelAttributeScopeDto_SR.Noun_Plural),
        PluralArticle = nameof(ModelAttributeScopeDto_SR.Noun_Plural_Article),
        Singular = nameof(ModelAttributeScopeDto_SR.Noun_Singular),
        SingularArticle = nameof(ModelAttributeScopeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(ModelAttributeScopeDto_SR)
        )]
    public class ModelAttributeScopeDto : DtoBase
    {
        private int _attributeId;
        private string _scopeCode;

        [Display(
            Name = nameof(ModelAttributeScopeDto_SR.AttributeId_Name),
            Description = nameof(ModelAttributeScopeDto_SR.AttributeId_Description),
            ResourceType = typeof(ModelAttributeScopeDto_SR))]
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
            Name = nameof(ModelAttributeScopeDto_SR.ScopeCode_Name),
            Description = nameof(ModelAttributeScopeDto_SR.ScopeCode_Description),
            ResourceType = typeof(ModelAttributeScopeDto_SR))]
        public string ScopeCode
        {
            get { return _scopeCode; }
            set
            {
                if (_scopeCode != value)
                {
                    _scopeCode = value;
                    OnPropertyChanged(nameof(ScopeCode));
                }
            }
        }
    }
}
