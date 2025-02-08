using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.StoreBuilder.Customers.DataStores;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.YourAddresses.ViewModels;

namespace DuxCommerce.Storefront.Views.YourAddresses.VmBuilders;

public class CustomerVmBuilder(ICustomerStore customerStore)
{
    public async Task<CustomerVm> BuildModel(ShopperInfo shopperInfo)
    {
        var customer = await customerStore.GetByUserId(shopperInfo.UserId);

        return new CustomerVm
        {
            AccountLinks = new AccountLinksVm { Addresses = true },
            Customer = customer
        };
    }
}