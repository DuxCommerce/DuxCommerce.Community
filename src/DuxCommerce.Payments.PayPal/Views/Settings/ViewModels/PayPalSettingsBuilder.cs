using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.StoreBuilder.Payments.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.Payments.PayPal.DataStores;

namespace DuxCommerce.Payments.PayPal.Views.Settings.ViewModels;

public class PayPalSettingsBuilder(
    IPaymentMethodStore methodStore,
    IPayPalSettingsStore payPalSettingsStore,
    ICountryStore countryStore)
{
    public async Task<PayPalSettingsVm> BuildModel(string methodType)
    {
        var paymentMethod = await methodStore.GetMethod(methodType);
        var settings = await payPalSettingsStore.GetSettings();

        var model = new PayPalSettingsModel
        {
            MethodType = methodType,
            DisplayName = paymentMethod.DisplayName,
            IsTestMode = settings.IsTestMode,
            ClientId = settings.ClientId,
            Secret = null,
            DisplayOrder = paymentMethod.DisplayOrder,
            AvailableCountries = paymentMethod.AvailableCountries
        };
        
        var countries = await countryStore.GetBillingCountries();

        return new PayPalSettingsVm { SettingsModel = model, Countries = countries};
    }

    public async Task<PayPalSettingsVm> BuildModel(PayPalSettingsVm model)
    {
        var countries = await countryStore.GetBillingCountries();
        model.Countries = countries;

        return model;
    }
}