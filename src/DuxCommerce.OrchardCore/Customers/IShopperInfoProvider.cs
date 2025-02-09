using DuxCommerce.StoreBuilder.Carts.UseCases;

namespace DuxCommerce.OrchardCore.Customers;

public interface IShopperInfoProvider
{
    string GetUserId();
    ShopperInfo Get();
}