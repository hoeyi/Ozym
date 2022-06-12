using System.ComponentModel.DataAnnotations;
using NjordFinance.ModelMetadata.Resources;
using Ichosoft.DataModel.Annotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="ModelAttributeScope"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.ModelAttributeScope_Plural),
        PluralArticle = nameof(ModelNoun.ModelAttributeScope_PluralArticle),
        Singular = nameof(ModelNoun.ModelAttributeScope_Singular),
        SingularArticle = nameof(ModelNoun.ModelAttributeScope_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class ModelAttributeScopeMetadata
    {

        [Display(
            Name = nameof(ModelDisplay.ModelAttributeScope_ScopeCode_Name),
            Description = nameof(ModelDisplay.ModelAttributeScope_ScopeCode_Description),
            ResourceType = typeof(ModelDisplay))]
        public string ScopeCode { get; set; }
    }

    [MetadataType(typeof(ModelAttributeScopeMetadata))]
    public partial class ModelAttributeScope
    {
    }
}
