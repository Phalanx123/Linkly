using Linkly.Abstractions;
using Linkly.Configuration;
using Linkly.Exceptions;
using Linkly.Models.QrCodes;
using Microsoft.Extensions.Options;

namespace Linkly.Clients;

internal sealed class QrCodeClient : IQrCodeClient
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<LinklyOptions> _options;

    public QrCodeClient(HttpClient httpClient, IOptions<LinklyOptions> options)
    {
        _httpClient = httpClient;
        _options = options;
    }

    public async Task<byte[]> GetQrCodeAsync(QrCodeRequest request, CancellationToken cancellationToken = default)
    {
        var opts = _options.Value;
        var url = BuildUrl(request, opts);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new LinklyApiException(
                $"Linkly API error {(int)response.StatusCode}: {error}",
                response.StatusCode);
        }

        return await response.Content.ReadAsByteArrayAsync(cancellationToken);
    }

    private static string BuildUrl(QrCodeRequest request, LinklyOptions opts)
    {
        var query = new List<string>
        {
            $"api_key={Uri.EscapeDataString(opts.ApiKey)}",
            $"workspace_id={opts.WorkspaceId}"
        };

        if (request.ForegroundColor is not null)
            query.Add($"foreground_color={Uri.EscapeDataString(request.ForegroundColor)}");

        if (request.BackgroundColor is not null)
            query.Add($"background_color={Uri.EscapeDataString(request.BackgroundColor)}");

        if (request.Size is not null)
            query.Add($"size={request.Size}");

        return $"link/{request.LinkId}/qr/png?{string.Join("&", query)}";
    }
}
