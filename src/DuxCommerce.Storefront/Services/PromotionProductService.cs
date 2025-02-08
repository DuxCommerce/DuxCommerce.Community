using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Marketing.DataStores;
using DuxCommerce.Storefront.Views.Promotion.ViewModels;
using DuxCommerce.Storefront.Extensions;
using OrchardCore.ContentManagement;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Services;

public class PromotionProductService(ProductService productService, IPromotionStore promotionStore)
{
    public async Task<PromotionProducts> GetProducts(string promotionId, Pager pager)
    {
        var promotion = await promotionStore.Get(promotionId);
        var productIds = promotion.GetPromotedProducts().ToList();

        var products = await productService.GetMany<ContentItem>(productIds)
            .Skip(pager.GetStartIndex())
            .Take(pager.PageSize)
            .ListAsync();

        var count = await productService.GetMany<ContentItem>(productIds)
            .CountAsync();

        return new PromotionProducts
        {
            Promotion = promotion,
            Products = products,
            Count = count
        };
    }
}