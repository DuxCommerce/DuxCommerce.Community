using System;
using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;

namespace DuxCommerce.Storefront.Views.Coupon.ViewModels;

public class CouponIndexVm
{
    public IEnumerable<CouponRow> Coupons { get; set; }
    public TimeZoneInfo TimeZone { get; set; }
}