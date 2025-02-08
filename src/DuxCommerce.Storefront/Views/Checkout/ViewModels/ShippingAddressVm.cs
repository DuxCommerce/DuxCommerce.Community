using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.Checkout.ViewModels;

public class ShippingAddressVm
{
    public bool SameAsBillingAddress { get; set; }
    public CheckoutAddressVm ShippingAddress { get; set; }
    public MiniCartVm MiniCart { get; set; }
}