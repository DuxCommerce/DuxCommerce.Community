using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Catalog.Products;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.StoreBuilder.Catalog.SimpleTypes;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.Storefront.Services;
using DuxCommerce.Storefront.Views.Inventory.ViewModels;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Extensions;
using Microsoft.AspNetCore.Routing;
using OrchardCore.ContentManagement;
using OrchardCore.DisplayManagement;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Views.Inventory.VmBuilders;

public class InventoryVmBuilder(
    ProductService productService,
    IProductStore productStore,
    CategoryUseCases categoryUseCases,
    IShapeFactory shapeFactory)
{
    private readonly dynamic _new = shapeFactory;

    public async Task<InventoryIndexVm> BuildIndexModel(ProductSearchVm searchVm, PagerParameters pagerParams)
    {
        var options = await CreateSearchOptions(searchVm);
        var pager = new Pager(pagerParams, 10);

        var (contentItems, count) = await productService.SearchInventories(options, pager);

        var trails = await categoryUseCases.GetCategoryTrails();

        var pagerShape = (await _new.Pager(pager)).TotalItemCount(count).RouteData(new RouteData());

        return new InventoryIndexVm
        {
            ProductSearch = new ProductSearchVm { Categories = trails.ToAllListItems() },
            Inventories = ToInventoryModels(contentItems),
            ProductMap = contentItems.ToDictionary(x => x.ContentItemId, x => x),
            Pager = pagerShape
        };
    }

    public async Task<EditInventoryVm> BuildEditModel(string productId)
    {
        var product = await productStore.Get(productId);

        return new EditInventoryVm
        {
            Inventory = ToInventoryModel(product),
            Events = InventoryEventVm.GetAll()
        };
    }

    public async Task<EditInventoryVm> BuildEditModel(EditInventoryVm model)
    {
        var product = await productStore.Get(model.Inventory.ProductId);

        var inventory = ToInventoryModel(product);
        inventory.AdjustBy = model.Inventory.AdjustBy;
        inventory.Reason = model.Inventory.Reason;

        model.Inventory = inventory;
        model.Events = InventoryEventVm.GetAll();

        return model;
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

    private static InventoryModel ToInventoryModel(ProductRow product)
    {
        return new InventoryModel
        {
            ProductId = product.Id,
            Name = product.Name,
            ChoiceNames = product.ChoiceNames,
            StockEnabled = product.StockEnabled,
            Sku = product.Sku,
            LowStockPoint = product.LowStockPoint,
            InStock = product.InStock,
            Reserved = product.Reserved,
            AdjustBy = 0,
            Reason = nameof(InventoryEventType.Received)
        };
    }

    private static List<InventoryModel> ToInventoryModels(List<ContentItem> contentItems)
    {
        return contentItems
            .Select(x => x.As<ProductPart>())
            .Select(x => x.Row)
            .Select(ToInventoryModel)
            .ToList();
    }
}