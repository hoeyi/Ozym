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
    /// Defines the metadata for <see cref="MarketHoliday"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.MarketHoliday_Plural),
        PluralArticle = nameof(ModelNoun.MarketHoliday_PluralArticle),
        Singular = nameof(ModelNoun.MarketHoliday_Singular),
        SingularArticle = nameof(ModelNoun.MarketHoliday_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class MarketHolidayMetadata
    {

        [Display(
            Name = nameof(ModelDisplay.MarketHoliday_MarketHolidayName_Name),
            Description = nameof(ModelDisplay.MarketHoliday_MarketHolidayName_Description),
            ResourceType = typeof(ModelDisplay))]
        public string MarketHolidayName { get; set; }
    }

    [MetadataType(typeof(MarketHolidayMetadata))]
    public partial class MarketHoliday
    {
    }
}
