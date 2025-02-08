using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.AdminCustomer.ViewModels;

public class CustomerOrdersVm
{
    public CustomerLinks Links { get; set; }
    public OrdersVm OrdersVm { get; set; }
}