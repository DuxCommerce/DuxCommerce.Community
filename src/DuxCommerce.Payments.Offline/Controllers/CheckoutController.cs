using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Checkout.UseCases;
using DuxCommerce.OrchardCore.Customers;
using DuxCommerce.StoreBuilder.Carts.DataStores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DuxCommerce.Payments.Offline.Controllers;

[Authorize]
public class CheckoutController(
    IShopperInfoProvider shopperInfoProvider,
    CheckoutUseCases checkoutUseCases,
    ICartStore cartStore)
    : Controller
{
    [HttpPost]
    public async Task<IActionResult> ConfirmPayment()
    {
        var shopperInfo = shopperInfoProvider.Get();

        if (!await cartStore.CartExists(shopperInfo.CartId))
            return RedirectToAction("Index", "ShoppingCart");
        
        var orderResult = await checkoutUseCases.SubmitOrder(shopperInfo);

        // Todo: handle order submission failure
        return Redirect($"/Checkout/Confirmation?OrderId={orderResult.Result.Id}");
    }
}