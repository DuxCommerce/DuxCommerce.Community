using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Orders.DataStores;
using DuxCommerce.StoreBuilder.Orders.Requests;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Shipping.UseCases;
using DuxCommerce.Storefront.Views.AdminOrder.ViewModels;

namespace DuxCommerce.Storefront.Views.AdminOrder.VmBuilders;

public class OrderPaymentsVmBuilder(
    StoreProfileUseCases storeProfileUseCases,
    IOrderStore orderStore,
    ICurrencyStore currencyStore)
{
    public async Task<OrderPaymentsVm> Build(string orderId)
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        var order = await orderStore.Get(orderId);
        var currency = await currencyStore.GetCurrency(order.PaymentCurrency);

        var payment = order.Payments.FirstOrDefault();
        var paymentModel = new ReceivePaymentModel
        {
            PaymentReference = payment?.PaymentReference,
            Note = payment?.Note
        };

        var links = new OrderLinks { OrderId = orderId, PaymentsLink = true };

        return new OrderPaymentsVm
        {
            Order = order,
            PaymentModel = paymentModel,
            Links = links,
            Currency = currency,
            TimeZone = timeZone
        };
    }

    public async Task<OrderPaymentsVm> Build(string orderId, OrderPaymentsVm model)
    {
        var timeZone = await storeProfileUseCases.GetStoreTimeZone();
        model.TimeZone = timeZone;

        var order = await orderStore.Get(orderId);
        model.Order = order;

        var currency = await currencyStore.GetCurrency(order.PaymentCurrency);
        model.Currency = currency;

        return model;
    }
}