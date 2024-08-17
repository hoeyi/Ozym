using System;
using System.Text.Json.Serialization;

namespace Ozym.Web.Components.Common;

public class MenuRoot : MenuItem
{
    [JsonConstructor]
    public MenuRoot() : base(isRoot: true)
    {
        MenuGuid = Guid.NewGuid();
    }

    [JsonPropertyName("MenuGuid")]
    public Guid MenuGuid { get; init; }

    [JsonPropertyName("Name")]
    public string Name { get; init; }

    [JsonPropertyName("RootOptions")]
    public DisplayOptions RootOptions { get; set; } = new(initialValue: true);
}
