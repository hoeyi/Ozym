using System.Text.Json.Serialization;

namespace Ozym.Web.Components.Common;

public class MenuRoot : MenuItem
{
    [JsonConstructor]
    public MenuRoot() : base(isRoot: true)
    {
        MenuGuid = Guid.NewGuid();
    }

    /// <summary>
    /// Gets or sets the unique identifier for this menu.
    /// </summary>
    [JsonPropertyName("MenuGuid")]
    public Guid MenuGuid { get; init; }

    /// <summary>
    /// Gets or sets the display name of this menu.
    /// </summary>
    [JsonPropertyName("Name")]
    public string Name { get; init; }

    /// <summary>
    /// Gets or sets the display options for the root of this menu.
    /// </summary>
    [JsonPropertyName("RootOptions")]
    public DisplayOptions RootOptions { get; set; }
}
