using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Payments;
using DuxCommerce.StoreBuilder.Payments.DataStores;
using DuxCommerce.StoreBuilder.Payments.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DataStores;

namespace DuxCommerce.Payments.Offline.Views.Settings.ViewModels;

public class OfflineSettingsBuilder(
    IPaymentMethodStore methodStore,
    ICountryStore countryStore)
{
    public async Task<OfflineSettingsVm> BuildEditModel(string methodType)
    {
        var countries = await countryStore.GetBillingCountries();

        var paymentMethod = await methodStore.GetMethod(methodType);
        var model = ToEditModel(paymentMethod);

        return new OfflineSettingsVm { Settings = model, Countries = countries};
    }

    public async Task<OfflineSettingsVm> BuildEditModel(OfflineSettingsVm model)
    {
        var countries = await countryStore.GetBillingCountries();
        model.Countries = countries;

        return model;
    }

    private PaymentMethodSettings ToEditModel(PaymentMethodRow method)
    {
        return new PaymentMethodSettings
        {
            MethodType = method.MethodType,
            DisplayName = method.DisplayName,
            Instructions = method.Instructions,
            DisplayOrder = method.DisplayOrder,
            AvailableCountries = method.AvailableCountries
        };
    }
}