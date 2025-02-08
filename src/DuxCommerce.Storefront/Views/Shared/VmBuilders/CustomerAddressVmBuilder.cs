using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Customers.UseCases;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.Shared.VmBuilders;

public class CustomerAddressVmBuilder(
    ICountryStore countryStore,
    CustomerUseCases customerUseCases,
    AddressVmBuilder addressVmBuilder)
{
    public async Task<CustomerAddressVm> BuildEditModel(string customerId, string addressId)
    {
        var address = await customerUseCases.GetAddress(customerId, addressId);
        var addressVm = new AddressVm { Address = address };

        var countries = await countryStore.GetEnabledCountries();
        await addressVmBuilder.PopulateCountries(addressVm, countries.ToList());

        return new CustomerAddressVm
        {
            CustomerId = customerId,
            AddressVm = addressVm
        };
    }

    public async Task<CustomerAddressVm> BuildEditModel(string customerId, CustomerAddressVm model)
    {
        var countries = await countryStore.GetEnabledCountries();
        await addressVmBuilder.PopulateCountries(model.AddressVm, countries.ToList());

        model.CustomerId = customerId;

        return model;
    }
}