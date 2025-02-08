using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Checkout;
using DuxCommerce.StoreBuilder.Customers.DataStores;
using DuxCommerce.StoreBuilder.Orders.DataStores;
using DuxCommerce.Storefront.Views.AdminOrder.ViewModels;

namespace DuxCommerce.Storefront.Views.AdminOrder.VmBuilders;

public class OrderDetailsVmBuilder(
    IOrderStore orderStore,
    ICustomerStore customerStore,
    OrderVmBuilder orderVmBuilder)
{
    public async Task<OrderDetailsVm> Build(string orderId)
    {
        var order = await orderStore.Get(orderId);
        var orderDetails = await orderVmBuilder.BuildAdminOrder(order);

        var customer = await customerStore.GetByUserId(order.UserId);
        var links = new OrderLinks { OrderId = orderId, SummaryLink = true };

        return new OrderDetailsVm
        {
            OrderModel = orderDetails,
            Customer = customer,
            Links = links
        };
    }
}