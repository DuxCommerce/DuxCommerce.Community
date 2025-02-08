using System;
using System.Collections.Generic;
using DuxCommerce.OrchardCore.Checkout;
using DuxCommerce.StoreBuilder.Customers.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.YourOrders.ViewModels;

public class YourOrdersVm
{
    public AccountLinksVm AccountLinks { get; set; }
    public CustomerRow Customer { get; set; }
    public IEnumerable<OrderVm> Orders { get; set; }
    public TimeZoneInfo TimeZone { get; set; }
}