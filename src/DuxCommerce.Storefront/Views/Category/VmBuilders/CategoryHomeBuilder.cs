using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DuxCommerce.OrchardCore.Catalog.Categories;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.StoreBuilder.Catalog.SimpleTypes;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.Storefront.Services;
using DuxCommerce.Storefront.Views.Category.ViewModels;
using DuxCommerce.Storefront.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Views.Category.VmBuilders;

public class CategoryHomeBuilder(
    CategoryHomeUseCases categoryHomeUseCases,
    ICategoryStore categoryStore,
    QueryStringParser queryStringParser,
    ProductsVmBuilder productsVmBuilder,
    IShapeFactory shapeFactory)
{
    private readonly dynamic _new = shapeFactory;

    public async Task<CategoryHome> BuildModel(string categoryId)
    {
        var model = new CategoryHome();

        var allCategories = (await categoryStore.GetAllItems<ContentItem>()).ToList();
        model.CategoryMenu = allCategories.ToMenuVm();

        PopulateBreadCrumbs(model, allCategories, categoryId);

        var pagerParameters = await queryStringParser.ToPagerParameters();
        var pager = new Pager(pagerParameters, 12);

        var filterOptions = queryStringParser.GetFilterOptions(categoryId);
        var contentItems = await categoryHomeUseCases.FilterProducts<ContentItem>(filterOptions, pager.ToPagination());

        model.Products = await productsVmBuilder.BuildViewModel(contentItems);

        PopulateSortOption(model, filterOptions, pager);

        await PopulatePager(model, filterOptions, pager);

        return model;
    }

    private void PopulateBreadCrumbs(CategoryHome model, IEnumerable<ContentItem> callCategories, string categoryId)
    {
        var breakCrumbs = new List<ContentItem>();

        var categoryMap = callCategories.ToDictionary(x => x.ContentItemId);
        var currentCategory = categoryMap[categoryId];

        var toContinue = true;
        while (toContinue)
        {
            breakCrumbs.Add(currentCategory);

            var parentId = ((CategoryRow)currentCategory.As<CategoryPart>().Row).ParentId;

            if (parentId != null)
                currentCategory = categoryMap[parentId];
            else
                toContinue = false;
        }

        model.BreadCrumbs = new BreadCrumbsVm { CategoryItems = breakCrumbs, CategoryId = categoryId };
    }

    private void PopulateSortOption(CategoryHome model, ProductFilterOptions filterOptions, Pager pager)
    {
        var sortOption = ((int)filterOptions.SortOption).ToString();

        model.SortOptions = new SortOptionsVm
        {
            ProductExists = model.Products.Products.Any(),
            SortOption = sortOption,
            SortOptions = GetSortOptions(),
            PageLink = GetPageLink(pager)
        };
    }

    private async Task PopulatePager(CategoryHome model, ProductFilterOptions filterOptions, Pager pager)
    {
        var count = await categoryHomeUseCases.CountProducts(filterOptions.CategoryId);
        var pagerShape = (await _new.Pager(pager)).TotalItemCount(count).RouteData(new RouteData());

        model.Pager = pagerShape;
    }

    private string GetPageLink(Pager pager)
    {
        // Todo: reimplement this as we add product filter
        var urlPath = queryStringParser.GetUrlPath();

        var link = HttpUtility.UrlEncode(
            $"{urlPath}?pagenum={pager.Page}&sortoption=");

        if (pager.Page <= 1)
            link = HttpUtility.UrlEncode($"{urlPath}?sortoption=");

        return link;
    }

    private IEnumerable<SelectListItem> GetSortOptions()
    {
        var options = new List<SortOption>
        {
            new() { Option = ((int)ProductSortOption.NameAToZ).ToString(), Name = "Name A to Z" },
            new() { Option = ((int)ProductSortOption.NameZToA).ToString(), Name = "Name Z to A" },
            new() { Option = ((int)ProductSortOption.PriceLowToHigh).ToString(), Name = "Price Low to High" },
            new() { Option = ((int)ProductSortOption.PriceHighToLow).ToString(), Name = "Price High to Low" }
        };

        return options.Select(x => new SelectListItem(x.Name, x.Option));
    }
}