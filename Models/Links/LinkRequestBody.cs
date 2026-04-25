using System.Text.Json.Serialization;

namespace Linkly.Models.Links;

public sealed class LinkRequestBody
{
    [JsonPropertyName("api_key")]
    public required string ApiKey { get; init; }

    [JsonPropertyName("workspace_id")]
    public required int WorkspaceId { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

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
}