using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Catalog.Products;
using DuxCommerce.OrchardCore.Customers;
using DuxCommerce.StoreBuilder.Catalog.Dto;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.Storefront.Views.Category.ViewModels;
using DuxCommerce.Storefront.Extensions;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Category.VmBuilders;

public class ProductsVmBuilder(
    CurrencyUseCases currencyUseCases,
    CategoryHomeUseCases categoryHomeUseCases,
    IShopperInfoProvider shopperInfoProvider)
{
    public async Task<ProductsVm> BuildViewModel(IEnumerable<ContentItem> contentItems)
    {
        var shopperEmail = shopperInfoProvider.GetUserId();

        var itemMap = contentItems.ToDictionary(x => x.ContentItemId);
        var products = await ToProductSummaries(shopperEmail, itemMap);
        var currency = await currencyUseCases.GetCurrency();

        return new ProductsVm
        {
            ProductMap = itemMap,
            Products = products,
            Currency = currency
        };
    }

    private async Task<List<ProductSummary>> ToProductSummaries(string shopperEmail,
        IDictionary<string, ContentItem> productMap)
    {
        var products = productMap.Values.ToProductRows();
        var summaries = (await categoryHomeUseCases.ListProducts(shopperEmail, products)).ToList();

        foreach (var summary in summaries)
        {
            var image = productMap.GetImage<ProductImagePart>(summary.Id);
            summary.ImagePath = image.Path;
            summary.ImageText = image.Text;
        }

        return summaries;
    }
}