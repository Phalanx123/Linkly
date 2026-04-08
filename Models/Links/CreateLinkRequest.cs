namespace Linkly.Models.Links;

public class CreateLinkRequest
{
    /// <summary>The destination URL to shorten. Required.</summary>
    public required string Url { get; set; }

    /// <summary>A display name for the link.</summary>
    public string? Name { get; set; }

    /// <summary>Custom domain to use for the short link.</summary>
    public string? Domain { get; set; }

    /// <summary>Custom slug/alias for the short link.</summary>
    public string? Slug { get; set; }

    public string? UtmSource { get; set; }
    public string? UtmMedium { get; set; }
    public string? UtmCampaign { get; set; }
    public string? UtmTerm { get; set; }
    public string? UtmContent { get; set; }

    public string? OgTitle { get; set; }
    public string? OgDescription { get; set; }
    public string? OgImage { get; set; }
}
