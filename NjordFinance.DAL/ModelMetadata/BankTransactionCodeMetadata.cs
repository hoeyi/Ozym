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
    /// Defines the metadata for <see cref="BankTransactionCode"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.BankTransactionCode_Plural),
        PluralArticle = nameof(ModelNoun.BankTransactionCode_PluralArticle),
        Singular = nameof(ModelNoun.BankTransactionCode_Singular),
        SingularArticle = nameof(ModelNoun.BankTransactionCode_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class BankTransactionCodeMetadata
    {

        [Display(
            Name = nameof(ModelDisplay.BankTransactionCode_TransactionCode_Name),
            Description = nameof(ModelDisplay.BankTransactionCode_TransactionCode_Description),
            ResourceType = typeof(ModelDisplay))]
        public string TransactionCode { get; set; }


        [Display(
            Name = nameof(ModelDisplay.BankTransactionCode_DisplayName_Name),
            Description = nameof(ModelDisplay.BankTransactionCode_DisplayName_Description),
            ResourceType = typeof(ModelDisplay))]
        public string DisplayName { get; set; }
    }

    [MetadataType(typeof(BankTransactionCodeMetadata))]
    public partial class BankTransactionCode
    {
    }
}
