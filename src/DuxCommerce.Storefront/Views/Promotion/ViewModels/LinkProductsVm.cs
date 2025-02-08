using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.Promotion.ViewModels;

public class LinkProductsVm
{
    public PromotionRow Promotion { get; set; }
    public ProductSearchVm ProductSearch { get; set; }
    public ProductPickerVm ProductPicker { get; set; }
}