using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Catalog.Products;
using DuxCommerce.StoreBuilder.Catalog.Core;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.StoreBuilder.Taxes.UseCases;
using DuxCommerce.Storefront.Services;
using DuxCommerce.Storefront.Views.AdminProduct.ViewModels;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using OrchardCore.DisplayManagement;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Views.AdminProduct.VmBuilders;

public class ProductPartVmBuilder(
    ProductService productService,
    CurrencyUseCases currencyUseCases,
    TaxCodeUseCases taxCodeUseCases,
    CategoryUseCases categoryUseCases,
    ICategoryStore categoryStore,
    IProductStore productStore,
    IProductOptionsStore productOptionsStore,
    IOptionStore optionStore,
    IShapeFactory shapeFactory)
{
    private readonly dynamic _new = shapeFactory;

    public async Task<ProductIndexVm> BuildIndexModel(ProductSearchVm searchVm, PagerParameters pagerParameters)
    {
        var currency = await currencyUseCases.GetCurrency();

        var options = await CreateSearchOptions(searchVm);
        var pager = new Pager(pagerParameters, 10);
        var (count, products) = await productService.SearchProducts(options, pager);

        var trails = await categoryUseCases.GetCategoryTrails();

        var pagerShape = (await _new.Pager(pager)).TotalItemCount(count).RouteData(new RouteData());

        return new ProductIndexVm
        {
            ProductSearch = new ProductSearchVm { Categories = trails.ToAllListItems() },
            Products = products,
            Currency = currency,
            Pager = pagerShape
        };
    }

    public Task BuildCreateModel(ProductEditVm editVm)
    {
        return FillBasicData(editVm);
    }

    public Task BuildEditModel(ProductPart part, ProductEditVm model)
    {
        var product = (ProductRow)part.Row;

        model.Product = ToProductModel(product);
        model.Links = new ProductLinksVm { ContentItem = part.ContentItem, EditLink = true };

        return FillBasicData(model);
    }

    public async Task<LinkOptionsVm> BuildLinkOptionsVm(string productId)
    {
        var productRow = await productStore.Get(productId);
        var productOptions = await productOptionsStore.GetByProductId(productId);

        var linkedOptionIds = productOptions.SharedOptions.Select(x => x.OptionId);
        var optionRows = await optionStore.GetAll();

        return new LinkOptionsVm
        {
            Product = productRow,
            Options = optionRows.Where(x => !linkedOptionIds.Contains(x.Id))
        };
    }

    private async Task<ProductSearchOptions> CreateSearchOptions(ProductSearchVm searchVm)
    {
        var limitedToProductIds = (List<string>)null;

        if (!string.IsNullOrEmpty(searchVm.SelectedCategoryId))
            limitedToProductIds = (await categoryUseCases.GetProductIds(searchVm.SelectedCategoryId)).ToList();

        return new ProductSearchOptions
        {
            ProductName = searchVm.ProductName,
            LimitedToProductIds = limitedToProductIds
        };
    }

    private async Task FillBasicData(ProductEditVm model)
    {
        var taxCodes = await GetTaxCodes();
        model.TaxCodes = taxCodes;

        model.Categories = await GetCategories();
    }

    private async Task<List<SelectListItem>> GetTaxCodes()
    {
        var taxCodes = await taxCodeUseCases.GetAll();
        return taxCodes.Select(x => new SelectListItem(x.Name, x.Id)).ToList();
    }

    private async Task<AdminCategoriesVm> GetCategories()
    {
        var categories = await categoryStore.GetAll();
        var (parents, childMap) = CategoryCore.splitCategories(categories);

        return new AdminCategoriesVm
        {
            Parents = parents,
            ChildMap = childMap
        };
    }

    private ProductModel ToProductModel(ProductRow product)
    {
        return new ProductModel
        {
            Id = product.Id,
            Name = product.Name,
            Summary = product.Summary,
            Description = product.Description,
            Price = product.Price,
            Retail = product.Retail,
            Cost = product.Cost,
            Length = product.Length,
            Width = product.Width,
            Height = product.Height,
            Weight = product.Weight,
            TaxCodeId = product.TaxCodeId,
            Barcode = product.Barcode,
            StockEnabled = product.StockEnabled,
            Sku = product.Sku,
            LowStockPoint = product.LowStockPoint,
            AllowOutOfStock = product.AllowOutOfStock,
            HasOptions = product.HasOptions,
            HasCustomerFields = product.HasCustomerFields,
            Featured = product.Featured,
            ParentId = product.ParentId,
            CategoryIds = product.CategoryIds
        };
    }
}