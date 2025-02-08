using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;

namespace DuxCommerce.Storefront.Views.AdminCategory.ViewModels;

public class LinkProductsVm
{
    public CategoryRow Category { get; set; }
    public ProductSearchVm ProductSearch { get; set; }
    public ProductPickerVm ProductPicker { get; set; }
}