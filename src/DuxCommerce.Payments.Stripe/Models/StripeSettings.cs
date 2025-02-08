namespace DuxCommerce.Payments.Stripe.Models;

public class StripeSettings
{
    public bool IsTestMode { get; set; }
    public string PublishableKey { get; set; }
    public string SecretKey { get; set; }
    public string WebhookSecret { get; set; }    
}