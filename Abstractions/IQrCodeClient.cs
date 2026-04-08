using Linkly.Models.QrCodes;

namespace Linkly.Abstractions;

public interface IQrCodeClient
{
    /// <summary>
    /// Returns the QR code image as a PNG byte array.
    /// </summary>
    Task<byte[]> GetQrCodeAsync(QrCodeRequest request, CancellationToken cancellationToken = default);
}
