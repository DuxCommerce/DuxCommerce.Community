using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Orders.Core.Core;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using OrchardCore.ContentManagement;

namespace DuxCommerce.OrchardCore.Checkout;

public class OrderProductService(IProductStore productStore)
{
    public async Task<IDictionary<string, ContentItem>> GetProductMap(OrderRow orderRow)
    {
        var productIds = OrderCore.getProductIds(orderRow);
        
        var contentItems = await productStore.GetManyItems<ContentItem>(productIds);

        return contentItems.ToDictionary(x => x.ContentItemId, x => x);
    } 
}