using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Shipping.DataTypes;

namespace DuxCommerce.Storefront.Views.ShippingProfile.ViewModels;

public class ShippingMethodsVm
{
    public string GroupId { get; set; }
    public string ZoneId { get; set; }
    public IEnumerable<ShippingMethodRow> Methods { get; set; }
    public ShippingZoneLinks Links { get; set; }
}