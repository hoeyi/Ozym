﻿using NjordFinance.Model.Metadata;
using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="InvestmentStrategy"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.InvestmentStrategyTarget_Plural),
        PluralArticle = nameof(ModelNoun.InvestmentStrategyTarget_PluralArticle),
        Singular = nameof(ModelNoun.InvestmentStrategyTarget_Singular),
        SingularArticle = nameof(ModelNoun.InvestmentStrategyTarget_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class InvestmentStrategyMetadata
    {

        [Display(
            Name = nameof(ModelDisplay.InvestmentStrategy_DisplayName_Name),
            Description = nameof(ModelDisplay.InvestmentStrategy_DisplayName_Description),
            ResourceType = typeof(ModelDisplay))]
        public string DisplayName { get; set; }
    }

    [MetadataType(typeof(InvestmentStrategyMetadata))]
    public partial class InvestmentStrategy
    {
    }
}