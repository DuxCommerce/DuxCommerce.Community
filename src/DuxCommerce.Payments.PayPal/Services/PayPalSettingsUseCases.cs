using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Payments.DataStores;
using DuxCommerce.StoreBuilder.Payments.DataTypes;
using DuxCommerce.Payments.PayPal.DataStores;
using DuxCommerce.Payments.PayPal.Models;
using DuxCommerce.Payments.PayPal.Views.Settings.ViewModels;
using Microsoft.AspNetCore.DataProtection;

namespace DuxCommerce.Payments.PayPal.Services;

public class PayPalSettingsUseCases(
    IDataProtectionProvider protectionProvider,
    IPaymentMethodStore paymentMethodStore,
    IPayPalSettingsStore payPalSettingsStore)
{
    private const string PurposeName = nameof(PayPalSettingsRow);

    public async Task<PayPalSettings> GetSettings()
    {
        var settings = await payPalSettingsStore.GetSettings();

        var protector = protectionProvider.CreateProtector(PurposeName);
        var secret = protector.Unprotect(settings.Secret);

        return new PayPalSettings
        {
            IsTestMode = settings.IsTestMode,
            ClientId = settings.ClientId,
            Secret = secret
        };
    }

    public async Task UpdateSettings(PayPalSettingsModel request)
    {
        var method = await paymentMethodStore.GetMethod(request.MethodType);

        var settings = await payPalSettingsStore.GetSettings();

        await UpdateMethod(method, request);

        await UpdateSettings(settings, request);
    }

    private async Task UpdateMethod(PaymentMethodRow method, PayPalSettingsModel request)
    {
        method.DisplayName = request.DisplayName;
        method.DisplayOrder = request.DisplayOrder;
        method.AvailableCountries = request.AvailableCountries.ToArray();

        await paymentMethodStore.Update(method);
    }

    private async Task UpdateSettings(PayPalSettingsRow settings, PayPalSettingsModel request)
    {
        var protector = protectionProvider.CreateProtector(PurposeName);
        var secret = protector.Protect(request.Secret);
        
        settings.IsTestMode = request.IsTestMode;
        settings.ClientId = request.ClientId;
        settings.Secret = secret;

        await payPalSettingsStore.CreateOrUpdate(settings);
    }
}