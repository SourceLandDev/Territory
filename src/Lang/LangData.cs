using System.Text.Json.Serialization;

namespace Territory.Lang;

internal struct LangData
{
    [JsonPropertyName("territory.command.description")]
    public string CommandDescription { get; set; }
}
