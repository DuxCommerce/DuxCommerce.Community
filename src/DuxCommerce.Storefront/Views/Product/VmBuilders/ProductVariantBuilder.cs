using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Catalog.Products;
using DuxCommerce.StoreBuilder.Catalog.Core;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.Storefront.Views.Product.ViewModels;
using DuxCommerce.Storefront.Extensions;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Product.VmBuilders;

public class ProductVariantBuilder(
    ProductHomeUseCases productHomeUseCases,
    ProductUseCases productUseCases,
    IProductStore productStore)
{
    public async Task<ProductVariantVm> BuildVariantModel(string userId, string prototypeId,
        IEnumerable<string> choiceIds)
    {
        var variantId = await productUseCases.GetVariantId(prototypeId, choiceIds.ToList());

        return await CreateVariantModel(userId, variantId);
    }

    private async Task<ProductVariantVm> CreateVariantModel(string shopperEmail, string productId)
    {
        var productItem = await productStore.GetItem<ContentItem>(productId);
        var product = productItem.As<ProductPart>().Row;
        var details = await productHomeUseCases.GetProductDetails(shopperEmail, product);

        return new ProductVariantVm
        {
            Id = details.Product.Id,
            Name = details.Product.Name,
            Sku = details.Product.Sku,
            PriceIncTax = details.Prices.PriceIncTax.ToCurrency(details.Currency),
            PriceExcTax = details.Prices.PriceExcTax.ToCurrency(details.Currency),
            Summary = details.Product.Summary,
            Description = details.Product.Description,
            IsPurchasable = details.IsPurchasable
        };
    }
}