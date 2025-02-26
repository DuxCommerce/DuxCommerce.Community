using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Catalog.Categories;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.Storefront.Services;
using DuxCommerce.Storefront.Views.AdminCategory.ViewModels;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Views.AdminCategory.VmBuilders;

public class CategoryPartVmBuilder(
    ProductService productService,
    CategoryProductService categoryProductService,
    CurrencyUseCases currencyUseCases,
    CategoryUseCases categoryUseCases,
    ICategoryStore categoryStore,
    IStringLocalizer<CategoryPartVmBuilder> h,
    IShapeFactory shapeFactory)
{
    private readonly IStringLocalizer _h = h;
    private readonly dynamic _new = shapeFactory;

    public async Task<CategoryEditVm> BuildCreateModel(CategoryEditVm editVm)
    {
        var model = editVm ?? new CategoryEditVm();
        model.CategoryItems = await GetParentCategories();

        return model;
    }

    public async Task<CategoryEditVm> BuildEditModel(CategoryPart part, CategoryEditVm model)
    {
        var categoryRow = part.Row;

        model.Category = ToCategoryModel(categoryRow);
        model.CategoryItems = await GetParentCategories(categoryRow.Id);

        return model;
    }

    public async Task<CategoryProductsVm> BuildProductsModel(string categoryId, PagerParameters pagerParameters)
    {
        var currency = await currencyUseCases.GetCurrency();

        var pager = new Pager(pagerParameters, 10);
        var (count, products) = await categoryProductService.GetProducts(categoryId, pager);
        var pagerShape = (await _new.Pager(pager)).TotalItemCount(count).RouteData(new RouteData());

        var categoryItem = await categoryStore.GetItem<ContentItem>(categoryId);
        var links = new CategoryLinksVm { ContentItem = categoryItem, ProductsLink = true };

        return new CategoryProductsVm
        {
            Category = categoryItem.As<CategoryPart>().Row,
            Products = products,
            Currency = currency,
            Links = links,
            Pager = pagerShape
        };
    }

    public async Task<LinkProductsVm> BuildLinkProductsModel(CategoryProductSearchVm searchVm,
        PagerParameters pagerParams)
    {
        var currency = await currencyUseCases.GetCurrency();

        var searchOptions = await CreateSearchOptions(searchVm);
        var pager = new Pager(pagerParams, 10);
        var (count, products) = await productService.SearchProducts(searchOptions, pager);
        var pagerShape = (await _new.Pager(pager)).TotalItemCount(count).RouteData(new RouteData());

        var category = await categoryUseCases.GetCategory(searchVm.CategoryId);
        var trails = await categoryUseCases.GetCategoryTrails();

        return new LinkProductsVm
        {
            Category = category,
            ProductSearch = new ProductSearchVm { Categories = trails.ToAllListItems() },
            ProductPicker = new ProductPickerVm { Products = products, Currency = currency, Pager = pagerShape }
        };
    }

    private async Task<List<SelectListItem>> GetParentCategories(string selectedId = null)
    {
        var candidates = new List<SelectListItem>();

        var root = _h["--No Parent--"];
        candidates.Add(new SelectListItem(root, string.Empty));

        var trails = await categoryUseCases.GetCategoryTrails();

        candidates.AddRange(trails.ToListItems(selectedId));

        return candidates;
    }

    private async Task<ProductSearchOptions> CreateSearchOptions(CategoryProductSearchVm searchVm)
    {
        var excludedProductIds = (await categoryUseCases.GetProductIds(searchVm.CategoryId)).ToList();

        var limitedToProductIds = (List<string>)null;

        if (!string.IsNullOrEmpty(searchVm.SelectedCategoryId))
            limitedToProductIds = (await categoryUseCases.GetProductIds(searchVm.SelectedCategoryId)).ToList();

        return new ProductSearchOptions
        {
            ProductName = searchVm.ProductName,
            ExcludedProductIds = excludedProductIds,
            LimitedToProductIds = limitedToProductIds
        };
    }

    private static CategoryModel ToCategoryModel(CategoryRow row)
    {
        return new CategoryModel
        {
            Id = row.Id,
            Name = row.Name,
            Description = row.Description,
            SortOrder = row.SortOrder,
            ParentId = row.ParentId,
            Featured = row.Featured
        };
    }
}