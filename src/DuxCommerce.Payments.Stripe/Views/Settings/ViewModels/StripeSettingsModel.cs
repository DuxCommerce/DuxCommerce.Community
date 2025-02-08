using System.ComponentModel.DataAnnotations;
using DuxCommerce.OrchardCore.Payments;

namespace DuxCommerce.Payments.Stripe.Views.Settings.ViewModels;

public class StripeSettingsModel:PaymentMethodSettings
{
    [Required]
    public bool IsTestMode { get; set; }

    [Required]
    public string PublishableKey { get; set; }

    [Required]
    public string SecretKey { get; set; }

    [Required]
    public string WebhookSecret { get; set; }
}