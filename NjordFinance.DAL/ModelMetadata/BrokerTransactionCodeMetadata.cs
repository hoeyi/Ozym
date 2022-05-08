using NjordFinance.ModelMetadata.Resources;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="BrokerTransactionCode"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.BrokerTransactionCode_Plural),
        PluralArticle = nameof(ModelNoun.BrokerTransactionCode_PluralArticle),
        Singular = nameof(ModelNoun.BrokerTransactionCode_Singular),
        SingularArticle = nameof(ModelNoun.BrokerTransactionCode_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class BrokerTransactionCodeMetadata
    {

        [Display(
            Name = nameof(ModelDisplay.BrokerTransactionCode_TransactionCode_Name),
            Description = nameof(ModelDisplay.BrokerTransactionCode_TransactionCode_Description),
            ResourceType = typeof(ModelDisplay))]
        public string TransactionCode { get; set; }


        [Display(
            Name = nameof(ModelDisplay.BrokerTransactionCode_DisplayName_Name),
            Description = nameof(ModelDisplay.BrokerTransactionCode_DisplayName_Description),
            ResourceType = typeof(ModelDisplay))]
        public string DisplayName { get; set; }


        [Display(
            Name = nameof(ModelDisplay.BrokerTransactionCode_CashEffect_Name),
            Description = nameof(ModelDisplay.BrokerTransactionCode_CashEffect_Description),
            ResourceType = typeof(ModelDisplay))]
        public byte CashEffect { get; set; }


        [Display(
            Name = nameof(ModelDisplay.BrokerTransactionCode_ContributionWithdrawalEffect_Name),
            Description = nameof(ModelDisplay.BrokerTransactionCode_ContributionWithdrawalEffect_Description),
            ResourceType = typeof(ModelDisplay))]
        public byte ContributionWithdrawalEffect { get; set; }


        [Display(
            Name = nameof(ModelDisplay.BrokerTransactionCode_QuantityEffect_Name),
            Description = nameof(ModelDisplay.BrokerTransactionCode_QuantityEffect_Description),
            ResourceType = typeof(ModelDisplay))]
        public byte QuantityEffect { get; set; }
    }

    [MetadataType(typeof(BrokerTransactionCodeMetadata))]
    public partial class BrokerTransactionCode
    {
    }
}
