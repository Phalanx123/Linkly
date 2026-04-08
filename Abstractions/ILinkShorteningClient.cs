using Linkly.Models.Links;

namespace Linkly.Abstractions;

public interface ILinkShorteningClient
{
    Task<CreateLinkResponse> CreateLinkAsync(CreateLinkRequest request, CancellationToken cancellationToken = default);
}
