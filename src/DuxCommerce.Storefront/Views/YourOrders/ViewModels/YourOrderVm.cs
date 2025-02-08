using DuxCommerce.OrchardCore.Checkout;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.YourOrders.ViewModels;

public class YourOrderVm
{
    public AccountLinksVm AccountLinks { get; set; }
    public OrderVm OrderVm { get; set; }
}