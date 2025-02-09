using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Orders.DataStores;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DataStores;

namespace DuxCommerce.OrchardCore.Checkout;

public class OrderVmBuilder(
    ITaxProfileStore taxProfileStore,
    ICurrencyStore currencyStore,
    IOrderStore orderStore,
    OrderProductService orderProductService)
{
    public async Task<OrderVm> BuildCustomerOrder(string orderId)
    {
        var order = await orderStore.Get(orderId);

        return await BuildCustomerOrder(order);
    }

    public async Task<OrderVm> BuildCustomerOrder(OrderRow order)
    {
        return await BuildOrder(order, false);
    }

    public async Task<OrderVm> BuildAdminOrder(OrderRow order)
    {
        return await BuildOrder(order, true);
    }
    
    private async Task<OrderVm> BuildOrder(OrderRow order, bool isAdminOrder)
    {
        var taxProfile = await taxProfileStore.GetProfile();
        var currency = await currencyStore.GetCurrency(order.PaymentCurrency);
        var productMap = await orderProductService.GetProductMap(order);

        var taxes = taxProfile.BreakdownTaxOnFrontEnd
            ? order.Items.SelectMany(x => x.Taxes).Summarize()
            : new List<ItemTaxRow>();

        return new OrderVm
        {
            ProductMap = productMap,
            Taxes = taxes,
            Order = order,
            Currency = currency,
            BreakDownTax = taxProfile.BreakdownTaxOnFrontEnd,
            IsAdminOrder = isAdminOrder
        };
    }
}