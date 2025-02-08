using DuxCommerce.Storefront.Views.Category.ViewModels;

namespace DuxCommerce.Storefront.Views.StoreHome.ViewModels;

public class StoreHome
{
    public CategoryMenuVm MenuVm { get; set; }
    public CategoriesVm CategoriesVm { get; set; }
    public ProductsVm ProductsVm { get; set; }
}