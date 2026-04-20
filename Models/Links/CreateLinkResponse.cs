using System.Text.Json.Serialization;

namespace Linkly.Models.Links;

public class CreateLinkResponse
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("workspace_id")]
    public int WorkspaceId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("domain")]
    public string Domain { get; init; } = string.Empty;

    [JsonPropertyName("slug")]
    public string Slug { get; init; } = string.Empty;

    /// <summary>Destination URL</summary>
    [JsonPropertyName("url")]
    public string Url { get; init; } = string.Empty;

    /// <summary>Shortened full URL</summary>
    [JsonPropertyName("full_url")]
    public string FullUrl { get; init; } = string.Empty;

    [JsonPropertyName("inserted_at")]
    public DateTime InsertedAt { get; init; }

    // UTM Parameters
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

    // Optional metadata
    [JsonPropertyName("note")]
    public string? Note { get; init; }

    [JsonPropertyName("linkify_words")]
    public string? LinkifyWords { get; init; }

    [JsonPropertyName("spam")]
    public string? Spam { get; init; }

    [JsonPropertyName("public_analytics")]
    public bool? PublicAnalytics { get; init; }

    [JsonPropertyName("replacements")]
    public string? Replacements { get; init; }

    [JsonPropertyName("expiry_clicks")]
    public int? ExpiryClicks { get; init; }

    [JsonPropertyName("expiry_destination")]
    public string? ExpiryDestination { get; init; }

    [JsonPropertyName("expiry_datetime")]
    public DateTime? ExpiryDateTime { get; init; }

    [JsonPropertyName("password")]
    public string? Password { get; init; }

    [JsonPropertyName("hide_referrer")]
    public bool? HideReferrer { get; init; }

    [JsonPropertyName("cloaking")]
    public bool? Cloaking { get; init; }

    [JsonPropertyName("block_bots")]
    public bool? BlockBots { get; init; }

    [JsonPropertyName("forward_params")]
    public bool? ForwardParams { get; init; }

    [JsonPropertyName("skip_social_crawler_tracking")]
    public bool? SkipSocialCrawlerTracking { get; init; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; init; }

    [JsonPropertyName("deleted")]
    public bool? Deleted { get; init; }

    // Open Graph
    [JsonPropertyName("og_title")]
    public string? OgTitle { get; init; }

    [JsonPropertyName("og_description")]
    public string? OgDescription { get; init; }

    [JsonPropertyName("og_image")]
    public string? OgImage { get; init; }

    // Tracking / integrations
    [JsonPropertyName("fb_pixel_id")]
    public string? FbPixelId { get; init; }

    [JsonPropertyName("tiktok_pixel_id")]
    public string? TiktokPixelId { get; init; }

    [JsonPropertyName("gtm_id")]
    public string? GtmId { get; init; }

    [JsonPropertyName("ga4_tag_id")]
    public string? Ga4TagId { get; init; }

    // Collections (left as raw for now since structure unknown)
    [JsonPropertyName("rules")]
    public List<object> Rules { get; init; } = new();

    [JsonPropertyName("webhooks")]
    public List<object> Webhooks { get; init; } = new();

    [JsonPropertyName("notify_user_ids")]
    public List<int> NotifyUserIds { get; init; } = new();

    // Tags / styling
    [JsonPropertyName("head_tags")]
    public string? HeadTags { get; init; }

    [JsonPropertyName("body_tags")]
    public string? BodyTags { get; init; }

    [JsonPropertyName("qr_styles")]
    public string? QrStyles { get; init; }
}