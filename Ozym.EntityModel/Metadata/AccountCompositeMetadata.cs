using Ozym.EntityModel.Metadata;
using System.ComponentModel.DataAnnotations;
using Ichosys.DataModel.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozym.EntityModel
{
    /// <summary>
    /// Defines the metadata for <see cref="AccountComposite"/>.
    /// </summary>
    [Noun(
        Plural = nameof(ModelNoun.AccountComposite_Plural),
        PluralArticle = nameof(ModelNoun.AccountComposite_PluralArticle),
        Singular = nameof(ModelNoun.AccountComposite_Singular),
        SingularArticle = nameof(ModelNoun.AccountComposite_SingularArticle),
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
