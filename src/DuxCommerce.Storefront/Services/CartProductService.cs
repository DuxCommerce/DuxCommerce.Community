using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.Core;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Services;

public class CartProductService(IProductStore productStore)
{
    public async Task<IDictionary<string, ContentItem>> GetItemMap(CartRow cartRow)
    {
        var productIds = CartCore.getProductIds(cartRow);

        var contentItems = await productStore.GetManyItems<ContentItem>(productIds);

        return contentItems.ToDictionary(x => x.ContentItemId, x => x);
    }
}