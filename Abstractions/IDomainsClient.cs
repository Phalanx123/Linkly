using Linkly.Models.Domains;

namespace Linkly.Abstractions;

public interface IDomainsClient
{
    Task<IReadOnlyList<Domain>> ListDomainsAsync(CancellationToken cancellationToken = default);
}
