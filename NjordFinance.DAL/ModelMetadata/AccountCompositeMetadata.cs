using NjordFinance.ModelMetadata.Resources;
using System.ComponentModel.DataAnnotations;
using Ichosoft.DataModel.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// <summary>
        /// Gets the short code for this composite.
        /// </summary>
        [NotMapped]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? AccountCompositeCode
        {
            get { return AccountCompositeNavigation?.AccountObjectCode; }
        }

        /// <summary>
        /// Getst the display name for this composite.
        /// </summary>
        [NotMapped]
        public string? AccountCompositeName
        {
            get { return AccountCompositeNavigation?.ObjectDisplayName; }
        }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        public override string ToString()
        {
            return $"{{{nameof(AccountCompositeId)} = {AccountCompositeId};  " +
                $"{nameof(AccountCompositeCode)} = {AccountCompositeCode}}}";
        }
    }


}
