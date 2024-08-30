using Ozym.Web.Components.Common;
using Ozym.UserInterface;

namespace Ozym.Web.Components.Generic
{
    /// <summary>
    /// A component for interacting with a model index.
    /// </summary>
    public partial class ModelIndex<TModelDto> : ModelPagedIndex<TModelDto>
        where TModelDto : class, new()
    {
        /// <inheritdoc/>
        protected override MenuRoot CreateSectionNavigationMenu() => new()
        {
            Children = new()
            {
                new MenuItem()
                {
                    IconKey = "create",
                    Caption = Strings.Caption_CreateNew.Format(ModelNoun?.GetSingular() ?? typeof(TModelDto).Name),
                    UriRelativePath = FormatCreateUri(Guid.NewGuid())
                }
            }
        };
    }
}
