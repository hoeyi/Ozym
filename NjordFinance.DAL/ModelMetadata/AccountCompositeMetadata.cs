using NjordFinance.ModelMetadata.Resources;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;

namespace NjordFinance.Model
{
    /// <summary>
    /// Defines the metadata for <see cref="AccountComposite"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.AccountCompositeMember_Plural),
        PluralArticle = nameof(ModelNoun.AccountCompositeMember_PluralArticle),
        Singular = nameof(ModelNoun.AccountCompositeMember_Singular),
        SingularArticle = nameof(ModelNoun.AccountCompositeMember_SingularArticle),
        ResourceType = typeof(ModelNoun)
        )]
    public class AccountCompositeMetadata
    {
    }

    [MetadataType(typeof(AccountCompositeMetadata))]
    public partial class AccountComposite
    {
    }
}
