using DuxCommerce.Storefront.Views.Category.ViewModels;
using DuxCommerce.Storefront.Views.StoreHome.ViewModels;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace DuxCommerce.Storefront.Drivers;

public class CategoryHomeDisplayDriver : DisplayDriver<CategoryHome>
{
    public override IDisplayResult Display(CategoryHome home, BuildDisplayContext context)
    {
        return Combine(
            Initialize<CategoryMenuVm>("CategoryMenu", model => UpdateMenuModel(model, home)).Location("Nav:5"),
            Initialize<BreadCrumbsVm>("BreadCrumbs", model => UpdateBreadCrumbsModel(model, home))
                .Location("Content:5"),
            Initialize<SortOptionsVm>("SortOptions", model => UpdateSortOptionsModel(model, home))
                .Location("Content:10"),
            Initialize<ProductsVm>("Products", model => UpdateProductsModel(model, home)).Location("Content:15"),
            Initialize<CategoryPagerVm>("CategoryPager", model => UpdatePagerModel(model, home)).Location("Content:20")
        );
    }

    private void UpdateMenuModel(CategoryMenuVm model, CategoryHome home)
    {
        model.Parents = home.CategoryMenu.Parents;
        model.ChildMap = home.CategoryMenu.ChildMap;
        model.CategoryMap = home.CategoryMenu.CategoryMap;
    }

    private void UpdateBreadCrumbsModel(BreadCrumbsVm model, CategoryHome home)
    {
        model.CategoryId = home.BreadCrumbs.CategoryId;
        model.CategoryItems = home.BreadCrumbs.CategoryItems;
    }

    private void UpdateSortOptionsModel(SortOptionsVm model, CategoryHome home)
    {
        model.ProductExists = home.SortOptions.ProductExists;
        model.SortOption = home.SortOptions.SortOption;
        model.SortOptions = home.SortOptions.SortOptions;
        model.PageLink = home.SortOptions.PageLink;
    }

    private void UpdateProductsModel(ProductsVm model, CategoryHome home)
    {
        model.Products = home.Products.Products;
        model.ProductMap = home.Products.ProductMap;
        model.Currency = home.Products.Currency;
    }

    private void UpdatePagerModel(CategoryPagerVm model, CategoryHome home)
    {
        model.Pager = home.Pager;
    }
}