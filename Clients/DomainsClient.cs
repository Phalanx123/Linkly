using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Linkly.Abstractions;
using Linkly.Configuration;
using Linkly.Exceptions;
using Linkly.Models.Domains;
using Microsoft.Extensions.Options;

namespace Linkly.Clients;

internal sealed class DomainsClient : IDomainsClient
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<LinklyOptions> _options;

    public DomainsClient(HttpClient httpClient, IOptions<LinklyOptions> options)
    {
        _httpClient = httpClient;
        _options = options;
    }

    public async Task<IReadOnlyList<Domain>> ListDomainsAsync(CancellationToken cancellationToken = default)
    {
        var opts = _options.Value;
        var url = $"api/v1/workspace/{opts.WorkspaceId}/domains?api_key={opts.ApiKey}";

        var response = await _httpClient.GetAsync(url, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new LinklyApiException(
                $"Linkly API error {(int)response.StatusCode}: {error}",
                response.StatusCode);
        }
        
        var result = await response.Content.ReadFromJsonAsync<DomainsResponse>(cancellationToken: cancellationToken);
        return result?.Domains ?? [];
    }

    private sealed class DomainsResponse
    {
        [JsonPropertyName("domains")]
        public List<Domain> Domains { get; init; } = [];
    }
}
