using System.Text.Json.Serialization;

namespace Linkly.Models.Domains;

public class Domain
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    [JsonPropertyName("inserted_at")]
    public DateTime? InsertedAt { get; init; }

    [JsonPropertyName("stripe_subscription_id")]
    public string? StripeSubscriptionId { get; init; }

    [JsonPropertyName("stripe_cancel_at")]
    public DateTime? StripeCancelAt { get; init; }

    [JsonPropertyName("paid_up")]
    public bool? PaidUp { get; init; }

    [JsonPropertyName("stripe_current_period_end")]
    public DateTime? StripeCurrentPeriodEnd { get; init; }

    [JsonPropertyName("price")]
    public decimal? Price { get; init; }

    [JsonPropertyName("favicon_url")]
    public string? FaviconUrl { get; init; }

    [JsonPropertyName("purchase_domain_id")]
    public int? PurchaseDomainId { get; init; }

    [JsonPropertyName("purchase_deleted")]
    public bool? PurchaseDeleted { get; init; }
}
