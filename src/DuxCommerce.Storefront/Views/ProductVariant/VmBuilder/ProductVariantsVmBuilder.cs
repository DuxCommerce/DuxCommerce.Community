using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Catalog.Products;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.Storefront.Views.AdminProduct.ViewModels;
using DuxCommerce.Storefront.Views.ProductVariant.ViewModels;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.ProductVariant.VmBuilder;

public class ProductVariantsVmBuilder(IProductStore productStore)
{
    public async Task<ProductVariantsVm> BuildIndexModel(string productId)
    {
        var variants = await productStore.GetVariants(productId);

        var productItem = await productStore.GetItem<ContentItem>(productId);
        var productRow = (ProductRow)productItem.As<ProductPart>().Row;

        return new ProductVariantsVm
        {
            Product = productRow,
            Variants = ToVariantModels(variants).ToList(),
            Links = new ProductLinksVm { ContentItem = productItem, OptionsLink = true }
        };
    }

    public async Task<ProductVariantsVm> BuildIndexModel(string productId, ProductVariantsVm model)
    {
        var productItem = await productStore.GetItem<ContentItem>(productId);
        var productRow = (ProductRow)productItem.As<ProductPart>().Row;

        model.Product = productRow;

        model.Links = new ProductLinksVm { ContentItem = productItem, OptionsLink = true };

        return model;
    }

    private IEnumerable<VariantModel> ToVariantModels(IEnumerable<ProductRow> variants)
    {
        return variants.Select(x => new VariantModel
        {
            VariantId = x.Id,
            ChoiceName = x.ChoiceNames,
            Price = x.Price,
            Retail = x.Retail,
            Cost = x.Cost,
            Weight = x.Weight,
            Barcode = x.Barcode,
            StockEnabled = x.StockEnabled,
            Sku = x.Sku,
            LowStockPoint = x.LowStockPoint,
            InStock = x.InStock,
            Reserved = x.Reserved,
            AllowOutOfStock = x.AllowOutOfStock
        });
    }
}