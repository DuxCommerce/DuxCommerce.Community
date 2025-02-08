using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Coupon.ViewModels;

public class CouponProducts
{
    public CouponRow Coupon { get; set; }
    public IEnumerable<ContentItem> Products { get; set; }
    public int Count { get; set; }
}