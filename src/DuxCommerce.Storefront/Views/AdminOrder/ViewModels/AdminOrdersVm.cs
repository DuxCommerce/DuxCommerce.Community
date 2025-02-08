using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Orders.Requests;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.AdminOrder.ViewModels;

public class AdminOrdersVm
{
    public OrdersVm OrdersVm { get; set; }
    [BindNever] public dynamic Pager { get; set; }
    public OrderSearchOptions Options { get; set; }
    public IEnumerable<SelectListItem> OrderStatuses { get; set; }
    public IEnumerable<SelectListItem> PaymentStatuses { get; set; }
    public IEnumerable<SelectListItem> ShippingStatuses { get; set; }
}