using DuxCommerce.OrchardCore.Checkout;
using DuxCommerce.StoreBuilder.Customers.DataTypes;

namespace DuxCommerce.Storefront.Views.AdminOrder.ViewModels;

public class OrderDetailsVm
{
    public OrderVm OrderModel { get; set; }
    public CustomerRow Customer { get; set; }
    public OrderLinks Links { get; set; }
}