using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.Checkout.ViewModels;

public class BillingAddressVm
{
    public CheckoutAddressVm BillingAddress { get; set; }
    public MiniCartVm MiniCart { get; set; }
}