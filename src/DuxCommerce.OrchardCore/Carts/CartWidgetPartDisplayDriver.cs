using DuxCommerce.OrchardCore.Customers;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;

namespace DuxCommerce.OrchardCore.Carts;

public class CartWidgetPartDisplayDriver(IShopperInfoProvider shopperInfoProvider, CartUseCases cartUseCases)
    : ContentPartDisplayDriver<CartWidgetPart>
{
    public override IDisplayResult Display(CartWidgetPart part, BuildPartDisplayContext context)
    {
        return Initialize<CartWidgetVm>(GetDisplayShapeType(context), PopulateViewModelAsync)
            .Location("Detail", "Content:20")
            .Location("Summary", "Meta:10");
    }

    private async ValueTask PopulateViewModelAsync(CartWidgetVm vm)
    {
        var shopperInfo = shopperInfoProvider.Get();

        var cart = await cartUseCases.GetCart(shopperInfo);

        vm.ItemCount = cart?.Items?.Sum(x => x.Quantity) ?? 0;
    }
}