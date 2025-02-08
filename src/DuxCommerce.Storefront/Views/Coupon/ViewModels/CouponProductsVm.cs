using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Coupon.ViewModels;

public class CouponProductsVm
{
    public CouponRow Coupon { get; set; }
    public IEnumerable<ContentItem> Products { get; set; } = new List<ContentItem>();
    public CurrencyRow Currency { get; set; }
    [BindNever] public dynamic Pager { get; set; }
    public CouponLinks Links { get; set; }
}