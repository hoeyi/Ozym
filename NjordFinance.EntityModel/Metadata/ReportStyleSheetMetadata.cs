using NjordFinance.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;

namespace NjordFinance.EntityModel
{
    /// <summary>
    /// Defines the metadata for <see cref="ReportStyleSheet"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.ReportStyleSheet_Plural),
        PluralArticle = nameof(ModelNoun.ReportStyleSheet_PluralArticle),
        Singular = nameof(ModelNoun.ReportStyleSheet_Singular),
        SingularArticle = nameof(ModelNoun.ReportStyleSheet_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class ReportStyleSheetMetadata
    {

        [Display(
            Name = nameof(ModelDisplay.ReportStyleSheet_StyleSheetCode_Name),
            Description = nameof(ModelDisplay.ReportStyleSheet_StyleSheetCode_Description),
            ResourceType = typeof(ModelDisplay))]
        public string StyleSheetCode { get; set; }


        [Display(
            Name = nameof(ModelDisplay.ReportStyleSheet_StyleSheetDescription_Name),
            Description = nameof(ModelDisplay.ReportStyleSheet_StyleSheetDescription_Description),
            ResourceType = typeof(ModelDisplay))]
        public string StyleSheetDescription { get; set; }


        [Display(
            Name = nameof(ModelDisplay.ReportStyleSheet_XmlDefinition_Name),
            Description = nameof(ModelDisplay.ReportStyleSheet_XmlDefinition_Description),
            ResourceType = typeof(ModelDisplay))]
        public string XmlDefinition { get; set; }
    }

    [MetadataType(typeof(ReportStyleSheetMetadata))]
    public partial class ReportStyleSheet
    {
    }
}
