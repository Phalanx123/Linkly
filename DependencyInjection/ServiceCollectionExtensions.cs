using Linkly.Abstractions;
using Linkly.Clients;
using Linkly.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Linkly.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers Linkly API clients. Binds options from the "Linkly" configuration section,
    /// which can be populated via user secrets:
    ///   dotnet user-secrets set "Linkly:ApiKey" "your-api-key"
    ///   dotnet user-secrets set "Linkly:WorkspaceId" "12345"
    /// </summary>
    public static IServiceCollection AddLinkly(this IServiceCollection services)
    {
        services.AddOptions<LinklyOptions>().BindConfiguration(LinklyOptions.SectionName);
        return services.RegisterHttpClients();
    }

    /// <summary>
    /// Registers Linkly API clients with inline configuration.
    /// </summary>
    public static IServiceCollection AddLinkly(this IServiceCollection services, Action<LinklyOptions> configure)
    {
        services.Configure(configure);
        return services.RegisterHttpClients();
    }

    private static IServiceCollection RegisterHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<ILinkShorteningClient, LinkShorteningClient>((sp, client) =>
        {
            var opts = sp.GetRequiredService<IOptions<LinklyOptions>>().Value;
            client.BaseAddress = new Uri(opts.BaseUrl.TrimEnd('/') + "/");
        });

        services.AddHttpClient<IQrCodeClient, QrCodeClient>((sp, client) =>
        {
            var opts = sp.GetRequiredService<IOptions<LinklyOptions>>().Value;
            client.BaseAddress = new Uri(opts.BaseUrl.TrimEnd('/') + "/");
        });

        return services;
    }
}
