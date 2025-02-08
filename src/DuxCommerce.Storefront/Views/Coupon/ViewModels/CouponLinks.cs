using DuxCommerce.StoreBuilder.Marketing.DataTypes;

namespace DuxCommerce.Storefront.Views.Coupon.ViewModels;

public class CouponLinks
{
    public CouponRow Coupon { get; set; }
    public bool General { get; set; }
    public bool Products { get; set; }
    public bool Categories { get; set; }
}