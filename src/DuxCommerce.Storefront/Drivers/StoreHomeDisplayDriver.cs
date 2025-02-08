using DuxCommerce.Storefront.Views.Category.ViewModels;
using DuxCommerce.Storefront.Views.StoreHome.ViewModels;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace DuxCommerce.Storefront.Drivers;

public class StoreHomeDisplayDriver : DisplayDriver<StoreHome>
{
    public override IDisplayResult Display(StoreHome home)
    {
        return Combine(
            Initialize<CategoryMenuVm>("CategoryMenu", model => UpdateMenu(model, home)).Location("Nav:10"),
            Initialize<CategoriesVm>("Categories", model => UpdateCategories(model, home)).Location("Content:10"),
            Initialize<ProductsVm>("Products", model => UpdateProducts(model, home)).Location("Content:20")
        );
    }

    private void UpdateMenu(CategoryMenuVm model, StoreHome home)
    {
        model.Parents = home.MenuVm.Parents;
        model.ChildMap = home.MenuVm.ChildMap;
        model.CategoryMap = home.MenuVm.CategoryMap;
    }

    private void UpdateCategories(CategoriesVm model, StoreHome home)
    {
        model.Categories = home.CategoriesVm.Categories;
        model.CategoryMap = home.CategoriesVm.CategoryMap;
    }

    private void UpdateProducts(ProductsVm model, StoreHome home)
    {
        model.Products = home.ProductsVm.Products;
        model.ProductMap = home.ProductsVm.ProductMap;
        model.Currency = home.ProductsVm.Currency;
    }
}