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
    /// Defines the metadata for <see cref="Country"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.Country_Plural),
        PluralArticle = nameof(ModelNoun.Country_PluralArticle),
        Singular = nameof(ModelNoun.Country_Singular),
        SingularArticle = nameof(ModelNoun.Country_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class CountryMetadata
    {
        [Display(
            Name = nameof(ModelDisplay.Country_DisplayName_Name),
            Description = nameof(ModelDisplay.Country_DisplayName_Description),
            ResourceType = typeof(ModelDisplay))]
        public string DisplayName { get; set; }


        [Display(
            Name = nameof(ModelDisplay.Country_IsoCode3_Name),
            Description = nameof(ModelDisplay.Country_IsoCode3_Description),
            ResourceType = typeof(ModelDisplay))]
        public string IsoCode3 { get; set; }
    }

    [MetadataType(typeof(CountryMetadata))]
    public partial class Country
    {
    }
}
