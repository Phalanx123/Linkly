using System.Text.Json.Serialization;

namespace Linkly.Models;

public class Domain
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("workspace_id")]
    public int WorkspaceId { get; set; }

    [JsonPropertyName("https")]
    public bool Https { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
