using System.Net.Http.Headers;
using System.Net.Http.Json;
using Linkly.Models;

namespace Linkly;

public class DomainsClient
{
    private readonly HttpClient _httpClient;

    public DomainsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public static DomainsClient Create(string apiKey, string baseUrl = "https://app.linklyhq.com")
    {
        var httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", apiKey);
        return new DomainsClient(httpClient);
    }

    public async Task<IReadOnlyList<Domain>> ListDomainsAsync(
        int workspaceId,
        CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(
            $"/api/v1/workspace/{workspaceId}/domains",
            cancellationToken);

        response.EnsureSuccessStatusCode();

        var domains = await response.Content.ReadFromJsonAsync<List<Domain>>(cancellationToken);
        return domains ?? [];
    }
}
