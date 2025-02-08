using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Checkout;
using DuxCommerce.StoreBuilder.Orders.Core.Core;
using DuxCommerce.StoreBuilder.Orders.DataStores;
using DuxCommerce.StoreBuilder.Orders.Requests;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Shipping.UseCases;
using DuxCommerce.Storefront.Views.AdminOrder.ViewModels;

namespace DuxCommerce.Storefront.Views.AdminOrder.VmBuilders;

public class OrderShipmentsVmBuilder(
    StoreProfileUseCases storeProfileUseCases,
    OrderProductService orderProductService,
    ICurrencyStore currencyStore,
    IOrderStore orderStore)
{
    public async Task<OrderShipmentsVm> Build(string orderId)
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        var order = await orderStore.Get(orderId);
        var currency = await currencyStore.GetCurrency(order.PaymentCurrency);
        var productMap = await orderProductService.GetProductMap(order);

        var shipment = new ShipmentModel { Items = OrderCore.itemsToShip(order).ToArray() };
        var links = new OrderLinks { OrderId = orderId, ShipmentsLink = true };

        return new OrderShipmentsVm
        {
            Order = order,
            ProductMap = productMap,
            Shipment = shipment,
            Currency = currency,
            Links = links,
            TimeZone = timeZone
        };
    }

    public async Task<OrderShipmentsVm> Build(string orderId, OrderShipmentsVm model)
    {
        var order = await orderStore.Get(orderId);

        model.Order = order;
        model.ProductMap = await orderProductService.GetProductMap(order);
        model.TimeZone = await storeProfileUseCases.GetStoreTimeZone();
        model.Currency = await currencyStore.GetCurrency(order.PaymentCurrency);
        model.Links = new OrderLinks { OrderId = orderId, ShipmentsLink = true };

        return model;
    }
}