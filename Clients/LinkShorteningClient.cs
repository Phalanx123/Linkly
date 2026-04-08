using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Linkly.Abstractions;
using Linkly.Configuration;
using Linkly.Exceptions;
using Linkly.Models.Links;
using Microsoft.Extensions.Options;

namespace Linkly.Clients;

internal sealed class LinkShorteningClient : ILinkShorteningClient
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private readonly HttpClient _httpClient;
    private readonly IOptions<LinklyOptions> _options;

    public LinkShorteningClient(HttpClient httpClient, IOptions<LinklyOptions> options)
    {
        _httpClient = httpClient;
        _options = options;
    }

    public async Task<CreateLinkResponse> CreateLinkAsync(CreateLinkRequest request, CancellationToken cancellationToken = default)
    {
        var opts = _options.Value;

        var body = new LinkRequestBody
        {
            ApiKey = opts.ApiKey,
            WorkspaceId = opts.WorkspaceId,
            Url = request.Url,
            Name = request.Name,
            Domain = request.Domain,
            Slug = request.Slug,
            UtmSource = request.UtmSource,
            UtmMedium = request.UtmMedium,
            UtmCampaign = request.UtmCampaign,
            UtmTerm = request.UtmTerm,
            UtmContent = request.UtmContent,
            OgTitle = request.OgTitle,
            OgDescription = request.OgDescription,
            OgImage = request.OgImage,
        };

        var response = await _httpClient.PostAsJsonAsync("link", body, SerializerOptions, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new LinklyApiException(
                $"Linkly API error {(int)response.StatusCode}: {error}",
                response.StatusCode);
        }

        return await response.Content.ReadFromJsonAsync<CreateLinkResponse>(cancellationToken: cancellationToken)
               ?? throw new LinklyApiException("Received empty response from Linkly API.", response.StatusCode);
    }

    private sealed class LinkRequestBody
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
}
