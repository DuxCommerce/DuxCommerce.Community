using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Shipping.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.ShippingProfile.ViewModels;

public class AddShippingMethodVm
{
    public ShippingMethodModel MethodModel { get; set; } = new();
    public IEnumerable<SelectListItem> MethodTypes { get; set; }

    public ShippingZoneLinks Links { get; set; }
}