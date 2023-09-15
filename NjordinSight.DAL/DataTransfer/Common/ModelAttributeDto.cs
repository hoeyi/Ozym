using Ichosys.DataModel.Annotations;
using NjordinSight.EntityModel.Metadata;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NjordinSight.DataTransfer.Common
{
    [Noun(
        Plural = nameof(ModelAttributeDto_SR.Noun_Plural),
        PluralArticle = nameof(ModelAttributeDto_SR.Noun_Plural_Article),
        Singular = nameof(ModelAttributeDto_SR.Noun_Singular),
        SingularArticle = nameof(ModelAttributeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(ModelAttributeDto_SR)
        )]
    public class ModelAttributeDtoBase : DtoBase
    {
        private int _attributeId;
        private string _displayName;

        [Key]
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
            Name = nameof(ModelAttributeDto_SR.DisplayName_Name),
            Description = nameof(ModelAttributeDto_SR.DisplayName_Description),
            ResourceType = typeof(ModelAttributeDto_SR))]
        [Required(
            ErrorMessageResourceName = nameof(ModelValidation.RequiredAttribute_ValidationError),
            ErrorMessageResourceType = typeof(ModelValidation))]
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
    }

    [Noun(
        Plural = nameof(ModelAttributeDto_SR.Noun_Plural),
        PluralArticle = nameof(ModelAttributeDto_SR.Noun_Plural_Article),
        Singular = nameof(ModelAttributeDto_SR.Noun_Singular),
        SingularArticle = nameof(ModelAttributeDto_SR.Noun_Singular_Article),
        ResourceType = typeof(ModelAttributeDto_SR)
        )]
    public class ModelAttributeDto : ModelAttributeDtoBase
    {
        public ModelAttributeDto()
        {
            AttributeValues = new HashSet<ModelAttributeMemberDto>();
            AttributeScopes = new HashSet<ModelAttributeScopeDto>();
        }
        
        public ICollection<ModelAttributeMemberDto> AttributeValues { get; set; }

        public ICollection<ModelAttributeScopeDto> AttributeScopes { get; set; }
    }
}
