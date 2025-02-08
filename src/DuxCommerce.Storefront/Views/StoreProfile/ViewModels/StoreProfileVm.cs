using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.StoreProfile.ViewModels;

public class StoreProfileVm
{
    public StoreProfileRow Profile { get; set; }
    public AddressVm AddressVm { get; set; }
    public IEnumerable<SelectListItem> UnitSystems { get; set; }
    public IEnumerable<SelectListItem> WeightUnits { get; set; }
    public IEnumerable<SelectListItem> LengthUnits { get; set; }
    public IEnumerable<SelectListItem> TimeZones { get; set; }
    public IEnumerable<SelectListItem> Currencies { get; set; }
}