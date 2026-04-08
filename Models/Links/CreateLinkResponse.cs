using System.Text.Json.Serialization;

namespace Linkly.Models.Links;

public class CreateLinkResponse
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("workspace_id")]
    public int WorkspaceId { get; init; }

    /// <summary>The shortened URL.</summary>
    [JsonPropertyName("url")]
    public string Url { get; init; } = string.Empty;

    /// <summary>The original destination URL.</summary>
    [JsonPropertyName("long_url")]
    public string LongUrl { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("domain")]
    public string? Domain { get; init; }

    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    [JsonPropertyName("utm_source")]
    public string? UtmSource { get; init; }

    [JsonPropertyName("utm_medium")]
    public string? UtmMedium { get; init; }

    [JsonPropertyName("utm_campaign")]
    public string? UtmCampaign { get; init; }

    [JsonPropertyName("utm_term")]
    public string? UtmTerm { get; init; }

    [JsonPropertyName("utm_content")]
    public string? UtmContent { get; init; }

    [JsonPropertyName("og_title")]
    public string? OgTitle { get; init; }

    [JsonPropertyName("og_description")]
    public string? OgDescription { get; init; }

    [JsonPropertyName("og_image")]
    public string? OgImage { get; init; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; init; }
}
