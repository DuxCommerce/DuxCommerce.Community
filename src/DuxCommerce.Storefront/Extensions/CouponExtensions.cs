using System;
using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;

namespace DuxCommerce.Storefront.Extensions;

public static class CouponExtensions
{
    public static IEnumerable<string> GetPromotedProducts(this CouponRow coupon)
    {
        return coupon.Rule?.Product?.Products ?? Array.Empty<string>();
    }

    public static IEnumerable<string> GetPromotedCategories(this CouponRow coupon)
    {
        return coupon.Rule?.Product?.Categories ?? Array.Empty<string>();
    }
}