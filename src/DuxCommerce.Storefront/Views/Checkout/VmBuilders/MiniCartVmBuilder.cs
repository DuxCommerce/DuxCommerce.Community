using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.Storefront.Services;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Extensions;

namespace DuxCommerce.Storefront.Views.Checkout.VmBuilders;

public class MiniCartVmBuilder(
    CurrencyUseCases currencyUseCases,
    ITaxProfileStore taxProfileStore,
    CartProductService cartProductService)
{
    public async Task<MiniCartVm> GetMiniCart(CartRow cart)
    {
        var currency = await currencyUseCases.GetCurrency();
        var taxProfile = await taxProfileStore.GetProfile();
        var itemMap = await cartProductService.GetItemMap(cart);

        return cart.ToMiniCart(taxProfile, currency, itemMap);
    }
}