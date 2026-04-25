namespace Linkly.Configuration;

public class LinklyOptions
{
    public const string SectionName = "Linkly";

    public string ApiKey { get; set; } = string.Empty;
    public int WorkspaceId { get; set; }
    public string BaseUrl { get; set; } = "https://app.linklyhq.com/api/v1";
    public string? OverrideHostHeader { get; set; }
}
