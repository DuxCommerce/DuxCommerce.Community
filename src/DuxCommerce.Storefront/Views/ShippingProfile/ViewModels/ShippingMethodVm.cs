using DuxCommerce.StoreBuilder.Shipping.DataTypes;

namespace DuxCommerce.Storefront.Views.ShippingProfile.ViewModels;

public class ShippingMethodVm
{
    public string GroupId { get; set; }
    public string ZoneId { get; set; }
    public ShippingMethodRow Method { get; set; }
    public BreadCrumbs BreadCrumbs { get; set; }
}