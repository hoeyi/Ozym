using NjordFinance.ModelMetadata.Resources;
using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="ResourceImage"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.ResourceImage_Plural),
        PluralArticle = nameof(ModelNoun.ResourceImage_PluralArticle),
        Singular = nameof(ModelNoun.ResourceImage_Singular),
        SingularArticle = nameof(ModelNoun.ResourceImage_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class ResourceImageMetadata
    {
        [Display(
            Name = nameof(ModelDisplay.ResourceImage_ImageDescription_Name),
            Description = nameof(ModelDisplay.ResourceImage_ImageDescription_Description),
            ResourceType = typeof(ModelDisplay))]
        public string ImageDescription { get; set; }

        [Display(
            Name = nameof(ModelDisplay.ResourceImage_ImageDescription_Name),
            Description = nameof(ModelDisplay.ResourceImage_ImageDescription_Description),
            ResourceType = typeof(ModelDisplay))]
        public string FileExtension { get; set; }
    }

    [MetadataType(typeof(ResourceImageMetadata))]
    public partial class ResourceImage
    {
    }
}
