using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Shipping.DataTypes;

namespace DuxCommerce.Storefront.Views.ShippingProfile.ViewModels;

public class ShippingProfileVm
{
    public ShippingProfileRow Profile { get; set; }
    public IDictionary<string, ShippingOriginRow> Origins { get; set; }
    public IDictionary<string, CountryRow> Countries { get; set; }
}