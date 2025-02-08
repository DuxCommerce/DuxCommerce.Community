using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Payments.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.Payments.Stripe.DataStores;

namespace DuxCommerce.Payments.Stripe.Views.Settings.ViewModels;

public class StripeSettingsBuilder(
    IPaymentMethodStore methodStore,
    IStripeSettingsStore stripeSettingsStore,
    ICountryStore countryStore)
{
    public async Task<StripeSettingsVm> BuildModel(string methodType)
    {
        var paymentMethod = await methodStore.GetMethod(methodType);
        var settings = await stripeSettingsStore.GetSettings();

        var model = new StripeSettingsModel
        {
            MethodType = methodType,
            DisplayName = paymentMethod.DisplayName,
            IsTestMode = settings.IsTestMode,
            PublishableKey = settings.PublishableKey,
            SecretKey = null,
            WebhookSecret = null,
            DisplayOrder = paymentMethod.DisplayOrder,
            AvailableCountries = paymentMethod.AvailableCountries
        };
        
        var countries = await countryStore.GetBillingCountries();

        return new StripeSettingsVm { Settings = model, Countries = countries};
    }

    public async Task<StripeSettingsVm> BuildModel(StripeSettingsVm model)
    {
        model.Settings.SecretKey = null;
        model.Settings.WebhookSecret = null;
        
        var countries = await countryStore.GetBillingCountries();
        model.Countries = countries;

        return model;
    }
}