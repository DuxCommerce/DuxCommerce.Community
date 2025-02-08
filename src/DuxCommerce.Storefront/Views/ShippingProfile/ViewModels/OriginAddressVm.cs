using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.ShippingProfile.ViewModels;

public class OriginAddressVm
{
    public string OriginId { get; set; }
    public AddressVm AddressVm { get; set; }
}