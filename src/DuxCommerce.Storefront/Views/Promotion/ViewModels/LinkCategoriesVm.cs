using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.Promotion.ViewModels;

public class LinkCategoriesVm
{
    public PromotionRow Promotion { get; set; }
    public CategoryPickerVm CategoryPicker { get; set; }
}