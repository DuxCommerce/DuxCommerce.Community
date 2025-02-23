using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using OrchardCore.ContentManagement;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Services;

public class ProductOptionsService(IProductOptionsStore productOptionsStore, ProductService productService)
{
    public async Task<(int, List<ContentItem>)> GetProducts(string optionId, Pager pager)
    {
        var productIds = (await productOptionsStore.GetLinkedProductIds(optionId)).ToList();

        var products = await productService.GetMany<ContentItem>(productIds)
            .Skip(pager.GetStartIndex())
            .Take(pager.PageSize)
            .ListAsync();

        return (productIds.Count, products.ToList());
    }
}