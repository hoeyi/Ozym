using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NjordFinance.ModelMetadata.Resources;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="ReportConfiguration"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.ReportConfiguration_Plural),
        PluralArticle = nameof(ModelNoun.ReportConfiguration_PluralArticle),
        Singular = nameof(ModelNoun.ReportConfiguration_Singular),
        SingularArticle = nameof(ModelNoun.ReportConfiguration_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class ReportConfigurationMetadata
    {

        [Display(
            Name = nameof(ModelDisplay.ReportConfiguration_ConfigurationCode_Name),
            Description = nameof(ModelDisplay.ReportConfiguration_ConfigurationCode_Description),
            ResourceType = typeof(ModelDisplay))]
        public string ConfigurationCode { get; set; }


        [Display(
            Name = nameof(ModelDisplay.ReportConfiguration_ConfigurationDescription_Name),
            Description = nameof(ModelDisplay.ReportConfiguration_ConfigurationDescription_Description),
            ResourceType = typeof(ModelDisplay))]
        public string ConfigurationDescription { get; set; }


        [Display(
            Name = nameof(ModelDisplay.ReportConfiguration_XmlDefinition_Name),
            Description = nameof(ModelDisplay.ReportConfiguration_XmlDefinition_Description),
            ResourceType = typeof(ModelDisplay))]
        public string XmlDefinition { get; set; }
    }

    [MetadataType(typeof(ReportConfigurationMetadata))]
    public partial class ReportConfiguration
    {
    }
}
