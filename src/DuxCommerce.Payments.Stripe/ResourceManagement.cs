using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;
using static DuxCommerce.Payments.Stripe.ResourceNames;

namespace DuxCommerce.Payments.Stripe;

public static class ResourceNames
{
    public const string Payment = nameof(Payment);
    public const string StripeJs = nameof(StripeJs);
}

public class ResourceManagement : IConfigureOptions<ResourceManagementOptions>
{
    private static readonly ResourceManifest Manifest = new();
    
    static ResourceManagement()
    {
        DefineScripts();
    }
    
    private static void DefineScripts()
    {
        Manifest
            .DefineScript(StripeJs)
            .SetCdn("https://js.stripe.com/v3/")
            .SetVersion("3.0.0");
        
        Manifest
            .DefineScript(Payment)
            .SetUrl("~/DuxCommerce.Payments.Stripe/js/payment.js")
            .SetVersion("1.0.0");
        
    }

    public void Configure(ResourceManagementOptions options) => options.ResourceManifests.Add(Manifest);
}