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

        if (request.Size is not null)
            query.Add($"size={request.Size}");

        // Hex colours must be URL-encoded: # → %23
        if (request.ForegroundColor is not null)
            query.Add($"fgColor={EncodeColor(request.ForegroundColor)}");

        if (request.BackgroundColor is not null)
            query.Add($"bgColor={EncodeColor(request.BackgroundColor)}");

        if (request.QrStyle is not null)
            query.Add($"qrStyle={request.QrStyle.Value.ToString().ToLowerInvariant()}");

        if (request.EyeStyle is not null)
            query.Add($"eyeStyle={request.EyeStyle.Value.ToString().ToLowerInvariant()}");

        if (request.EyeColorInner is not null)
            query.Add($"eyeColorInner={EncodeColor(request.EyeColorInner)}");

        if (request.EyeColorOuter is not null)
            query.Add($"eyeColorOuter={EncodeColor(request.EyeColorOuter)}");

        if (request.LogoImage is not null)
            query.Add($"logoImage={Uri.EscapeDataString(request.LogoImage)}");

        if (request.LogoWidth is not null)
            query.Add($"logoWidth={request.LogoWidth}");

        if (request.LogoHeight is not null)
            query.Add($"logoHeight={request.LogoHeight}");

        if (request.LogoPadding is not null)
            query.Add($"logoPadding={request.LogoPadding}");

        if (request.LogoStyle is not null)
            query.Add($"logoStyle={request.LogoStyle.Value.ToString().ToLowerInvariant()}");

        if (request.QuietZone is not null)
            query.Add($"quietZone={request.QuietZone}");

        return $"link/{request.LinkId}/qr/png?{string.Join("&", query)}";
    }

    // The API expects hex colours URL-encoded with %23 instead of #.
    // Accepts "#ff0000" or "ff0000" — always ensures the hash is encoded.
    private static string EncodeColor(string hex)
    {
        var normalised = hex.StartsWith('#') ? hex : "#" + hex;
        return Uri.EscapeDataString(normalised);
    }
}
