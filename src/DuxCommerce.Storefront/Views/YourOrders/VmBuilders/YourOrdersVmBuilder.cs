using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Checkout;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.StoreBuilder.Customers.DataStores;
using DuxCommerce.StoreBuilder.Orders.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Shipping.UseCases;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.YourOrders.ViewModels;

namespace DuxCommerce.Storefront.Views.YourOrders.VmBuilders;

public class YourOrdersVmBuilder(
    ICustomerStore customerStore,
    IOrderStore orderStore,
    StoreProfileUseCases storeProfileUseCases,
    ICurrencyStore currencyStore)
{
    public async Task<YourOrdersVm> BuildIndexModel(ShopperInfo shopperInfo)
    {
        var customer = await customerStore.GetByUserId(shopperInfo.UserId);

        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        var orders = (await orderStore.GetCustomerOrders(shopperInfo.UserId)).ToList();

        var currencyCodes = orders.Select(x => x.PaymentCurrency).Distinct();
        var currencies = await currencyStore.GetCurrencies(currencyCodes);

        var orderVms = orders.Select(x =>
            new OrderVm
            {
                Order = x,
                Currency = currencies.Single(c => c.Code == x.PaymentCurrency)
            });

        return new YourOrdersVm
        {
            AccountLinks = new AccountLinksVm { Orders = true },
            Customer = customer,
            Orders = orderVms,
            TimeZone = timeZone
        };
    }
}