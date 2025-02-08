using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.Coupon.ViewModels;

public class LinkProductsVm
{
    public CouponRow Coupon { get; set; }
    public ProductSearchVm ProductSearch { get; set; }
    public ProductPickerVm ProductPicker { get; set; }
}