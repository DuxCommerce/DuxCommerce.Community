using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Payments.DataStores;
using DuxCommerce.StoreBuilder.Payments.DataTypes;
using DuxCommerce.Payments.Stripe.DataStores;
using DuxCommerce.Payments.Stripe.Models;
using DuxCommerce.Payments.Stripe.Views.Settings.ViewModels;
using Microsoft.AspNetCore.DataProtection;

namespace DuxCommerce.Payments.Stripe.Services;

public class StripeSettingsUseCases(
    IDataProtectionProvider protectionProvider,
    IPaymentMethodStore paymentMethodStore,
    IStripeSettingsStore stripeSettingsStore)
{
    private const string PurposeName = nameof(StripeSettingsRow);

    public async Task UpdateSettings(StripeSettingsModel request)
    {
        var method = await paymentMethodStore.GetMethod(request.MethodType);
        
        var settings = await stripeSettingsStore.GetSettings();

        await UpdatePaymentMethod(method, request);
        
        await UpdateSettings(settings, request);
    }

    public async Task<StripeSettings> GetSettings()
    {
        var settings = await stripeSettingsStore.GetSettings();
        
        var protector = protectionProvider.CreateProtector(PurposeName);
        var secretKey = protector.Unprotect(settings.SecretKey);
        var webhookSecret = protector.Unprotect(settings.WebhookSecret);

        return new StripeSettings
        {
            IsTestMode = settings.IsTestMode,
            PublishableKey = settings.PublishableKey,
            SecretKey = secretKey,
            WebhookSecret = webhookSecret
        };
    }

    private async Task UpdatePaymentMethod(PaymentMethodRow method, StripeSettingsModel request)
    {
        method.DisplayName = request.DisplayName;
        method.DisplayOrder = request.DisplayOrder;
        method.AvailableCountries = request.AvailableCountries.ToArray();

        await paymentMethodStore.Update(method);
    }

    private async Task UpdateSettings(StripeSettingsRow settings, StripeSettingsModel request)
    {
        var protector = protectionProvider.CreateProtector(PurposeName);
        var secretKey = protector.Protect(request.SecretKey);
        var webhookSecret = protector.Protect(request.WebhookSecret);
        
        settings.IsTestMode = request.IsTestMode;
        settings.PublishableKey = request.PublishableKey;
        settings.SecretKey = secretKey;
        settings.WebhookSecret = webhookSecret;

        await stripeSettingsStore.CreateOrUpdate(settings);
    }
}