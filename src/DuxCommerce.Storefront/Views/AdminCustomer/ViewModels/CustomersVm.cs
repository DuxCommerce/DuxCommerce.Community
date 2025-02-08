using System;
using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Customers.DataTypes;

namespace DuxCommerce.Storefront.Views.AdminCustomer.ViewModels;

public class CustomersVm
{
    public List<CustomerRow> Customers { get; set; }
    public TimeZoneInfo TimeZone { get; set; }
}