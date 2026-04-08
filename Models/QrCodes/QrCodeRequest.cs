namespace Linkly.Models.QrCodes;

public class QrCodeRequest
{
    /// <summary>The ID of the link to generate a QR code for. Required.</summary>
    public required int LinkId { get; set; }

    /// <summary>Foreground colour as a hex string, e.g. "#000000".</summary>
    public string? ForegroundColor { get; set; }

    /// <summary>Background colour as a hex string, e.g. "#ffffff".</summary>
    public string? BackgroundColor { get; set; }

    /// <summary>Image size in pixels (width and height).</summary>
    public int? Size { get; set; }
}
