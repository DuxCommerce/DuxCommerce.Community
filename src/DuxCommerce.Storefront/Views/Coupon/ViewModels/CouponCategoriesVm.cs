using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Coupon.ViewModels;

public class CouponCategoriesVm
{
    public CouponRow Coupon { get; set; }
    public IEnumerable<CategoryTrail> CategoryTrails { get; set; }
    public IDictionary<string, ContentItem> CategoryMap { get; set; }
    public CouponLinks Links { get; set; }
}