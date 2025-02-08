using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Payments.Stripe.Models;

public class StripeSettingsRow : IRow
{
    public string Id { get; set; }
    public bool IsTestMode { get; set; }
    public string PublishableKey { get; set; }
    public string SecretKey { get; set; }
    public string WebhookSecret { get; set; }
}