using System;
using System.Collections.Generic;
using DuxCommerce.OrchardCore.Checkout;

namespace DuxCommerce.Storefront.Views.Shared.ViewModels;

public class OrdersVm
{
    public IEnumerable<OrderVm> Orders { get; set; }
    public TimeZoneInfo TimeZone { get; set; }
}