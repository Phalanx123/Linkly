using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Linkly.Abstractions;
using Linkly.Configuration;
using Linkly.Exceptions;
using Linkly.Models.Links;
using Microsoft.Extensions.Logging;
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
    private readonly ILogger<LinkShorteningClient> _logger;

    public LinkShorteningClient(HttpClient httpClient, IOptions<LinklyOptions> options, ILogger<LinkShorteningClient> logger)
    {
        _httpClient = httpClient;
        _options = options;
        _logger = logger;
    }

    public async Task<CreateLinkResponse> CreateLinkAsync(CreateLinkRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("BaseUrl {Url}",  _options.Value.BaseUrl);
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

        var response = await _httpClient.PostAsJsonAsync("api/v1/link", body, SerializerOptions, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new LinklyApiException(
                $"Linkly API error {(int)response.StatusCode}: {error}",
                response.StatusCode);
        }

        var linkResponse = await response.Content.ReadFromJsonAsync<CreateLinkResponse>(cancellationToken: cancellationToken)
               ?? throw new LinklyApiException("Received empty response from Linkly API.", response.StatusCode);
        return linkResponse;
    }
}
