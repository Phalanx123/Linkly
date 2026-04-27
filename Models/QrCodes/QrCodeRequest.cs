namespace Linkly.Models.QrCodes;

public class QrCodeRequest
{
    /// <summary>The URL of the link. Required.</summary>
    public required string Url { get; set; }

    /// <summary>Image size in pixels (100–2048).</summary>
    public int? Size { get; set; }

    /// <summary>Foreground (module) colour as a hex string, e.g. "#000000".</summary>
    public string? ForegroundColor { get; set; }

    /// <summary>Background colour as a hex string, e.g. "#ffffff".</summary>
    public string? BackgroundColor { get; set; }

    /// <summary>Module shape style.</summary>
    public QrStyle? QrStyle { get; set; }

    /// <summary>Eye (finder pattern) shape style.</summary>
    public EyeStyle? EyeStyle { get; set; }

    /// <summary>Inner eye colour as a hex string, e.g. "#ff0000".</summary>
    public string? EyeColorInner { get; set; }

    /// <summary>Outer eye colour as a hex string, e.g. "#000000".</summary>
    public string? EyeColorOuter { get; set; }

    /// <summary>URL of the logo image to embed in the centre of the QR code.</summary>
    public string? LogoImage { get; set; }

    /// <summary>Logo width in pixels. Automatically scaled to match requested image size.</summary>
    public int? LogoWidth { get; set; }

    /// <summary>Logo height in pixels. Automatically scaled to match requested image size.</summary>
    public int? LogoHeight { get; set; }

    /// <summary>Padding around the logo in pixels.</summary>
    public int? LogoPadding { get; set; }

    /// <summary>Logo padding shape.</summary>
    public LogoStyle? LogoStyle { get; set; }

    /// <summary>
    /// Whitespace padding around the entire QR code in pixels (0–200), filled with the background colour.
    /// Prevents finder-pattern eyes sitting flush against the edge.
    /// </summary>
    public int? QuietZone { get; set; }
}
