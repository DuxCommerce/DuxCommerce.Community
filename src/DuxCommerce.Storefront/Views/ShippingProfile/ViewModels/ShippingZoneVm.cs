using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Shipping.Requests;

namespace DuxCommerce.Storefront.Views.ShippingProfile.ViewModels;

public class ShippingZoneVm
{
    public ShippingZoneModel ZoneModel { get; set; }

    public List<CountryRow> Countries { get; set; }
    public Dictionary<string, List<StateRow>> AllStates { get; set; }
    public ShippingZoneLinks Links { get; set; }
}