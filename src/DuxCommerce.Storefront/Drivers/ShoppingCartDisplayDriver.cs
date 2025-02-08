using DuxCommerce.Storefront.Views.ShoppingCart.ViewModels;
using DuxCommerce.Storefront.Views.StoreHome.ViewModels;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;

namespace DuxCommerce.Storefront.Drivers;

public class ShoppingCartDisplayDriver : DisplayDriver<ShoppingCartHome>
{
    public override IDisplayResult Display(ShoppingCartHome cartHome)
    {
        return Combine(
            Initialize<CategoryMenuVm>("CategoryMenu", model => UpdateMenuModel(model, cartHome)).Location("Nav:10"),
            Initialize<ShoppingCartVm>("ShoppingCart", model => UpdateCartModel(model, cartHome)).Location("Content:10")
        );
    }

    private void UpdateMenuModel(CategoryMenuVm model, ShoppingCartHome cartHome)
    {
        model.Parents = cartHome.MenuVm.Parents;
        model.ChildMap = cartHome.MenuVm.ChildMap;
        model.CategoryMap = cartHome.MenuVm.CategoryMap;
    }

    private void UpdateCartModel(ShoppingCartVm model, ShoppingCartHome cartHome)
    {
        model.Currency = cartHome.CartVm.Currency;
        model.Cart = cartHome.CartVm.Cart;
        model.ItemMap = cartHome.CartVm.ItemMap;
    }
}