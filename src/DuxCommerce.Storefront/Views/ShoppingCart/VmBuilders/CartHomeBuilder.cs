using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.Storefront.Builders;
using DuxCommerce.Storefront.Services;
using DuxCommerce.Storefront.Views.ShoppingCart.ViewModels;

namespace DuxCommerce.Storefront.Views.ShoppingCart.VmBuilders;

public class CartHomeBuilder(
    CurrencyUseCases currencyUseCases,
    CartUseCases cartUseCases,
    CartProductService cartProductService,
    CategoryMenuBuilder categoryMenuBuilder)
{
    public async Task<ShoppingCartHome> BuildIndexModel(ShopperInfo shopperInfo)
    {
        var cart = await cartUseCases.GetCart(shopperInfo);
        var itemMap = await cartProductService.GetItemMap(cart);

        return new ShoppingCartHome
        {
            MenuVm = await categoryMenuBuilder.Build(),
            CartVm = new ShoppingCartVm
            {
                Currency = await currencyUseCases.GetCurrency(),
                ItemMap = itemMap,
                Cart = cart
            }
        };
    }
}