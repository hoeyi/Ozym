using Ichosys.DataModel.Annotations;
using NjordFinance.Model.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="InvestmentStrategyTarget"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.InvestmentStrategyTarget_Plural),
        PluralArticle = nameof(ModelNoun.InvestmentStrategyTarget_PluralArticle),
        Singular = nameof(ModelNoun.InvestmentStrategyTarget_Singular),
        SingularArticle = nameof(ModelNoun.InvestmentStrategyTarget_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    internal class InvestmentStrategyTargetMetadata
    {
    }

    [MetadataType(typeof(InvestmentStrategyTargetMetadata))]
    public partial class InvestmentStrategyTarget
    {
    }
}
