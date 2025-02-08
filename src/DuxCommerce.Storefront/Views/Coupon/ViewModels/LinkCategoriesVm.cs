using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.Coupon.ViewModels;

public class LinkCategoriesVm
{
    public CouponRow Coupon { get; set; }
    public CategoryPickerVm CategoryPicker { get; set; }
}