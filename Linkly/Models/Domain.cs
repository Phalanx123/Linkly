using System.Text.Json.Serialization;

namespace Linkly.Models;

public class Domain
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("inserted_at")]
    public DateTime? InsertedAt { get; set; }

    [JsonPropertyName("stripe_subscription_id")]
    public string? StripeSubscriptionId { get; set; }

    [JsonPropertyName("stripe_cancel_at")]
    public DateTime? StripeCancelAt { get; set; }

    [JsonPropertyName("paid_up")]
    public bool? PaidUp { get; set; }

    [JsonPropertyName("stripe_current_period_end")]
    public DateTime? StripeCurrentPeriodEnd { get; set; }

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("favicon_url")]
    public string? FaviconUrl { get; set; }

    [JsonPropertyName("purchase_domain_id")]
    public int? PurchaseDomainId { get; set; }

    [JsonPropertyName("purchase_deleted")]
    public bool? PurchaseDeleted { get; set; }
}
