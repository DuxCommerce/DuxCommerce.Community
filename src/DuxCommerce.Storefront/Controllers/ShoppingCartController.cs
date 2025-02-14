using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.OrchardCore.Customers;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Carts.Requests;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.StoreBuilder.ErrorTypes;
using DuxCommerce.Storefront.Views.ShoppingCart.ViewModels;
using DuxCommerce.Storefront.Views.ShoppingCart.VmBuilders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Route("Cart")]
public class ShoppingCartController(
    IShopperInfoProvider shopperInfoProvider,
    IDisplayManager<ShoppingCartHome> cartHomeDisplayManager,
    IUpdateModelAccessor updateModelAccessor,
    CartUseCases cartUseCases,
    CartHomeBuilder cartHomeBuilder,
    INotifier notifier,
    IHtmlLocalizer<ShoppingCartController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    public async Task<IActionResult> Index()
    {
        var shopperInfo = shopperInfoProvider.Get();

        var cartHome = await cartHomeBuilder.BuildIndexModel(shopperInfo);

        var shape = await cartHomeDisplayManager.BuildDisplayAsync(cartHome, updateModelAccessor.ModelUpdater);

        return View(shape);
    }

    [HttpPost]
    [Route(nameof(AddItem))]
    public async Task<IActionResult> AddItem(AddCartItemRequest request)
    {
        var shopperInfo = shopperInfoProvider.Get();

        request.Quantity = 1;
        var result = await cartUseCases.AddCartItem(shopperInfo, request);

        return await ProcessResult(result);
    }

    [HttpPost]
    [Route(nameof(Update))]
    public async Task<IActionResult> Update(UpdateCartRequest request)
    {
        var shopperInfo = shopperInfoProvider.Get();

        var result = await cartUseCases.UpdateCart(shopperInfo, request);

        return await ProcessResult(result);
    }

    [HttpPost]
    [Route(nameof(DeleteItem))]
    public async Task<IActionResult> DeleteItem(DeleteCartItemRequest request)
    {
        var shopperInfo = shopperInfoProvider.Get();

        var result = await cartUseCases.DeleteCartItem(shopperInfo, request);

        return await ProcessResult(result);
    }

    [HttpPost]
    [Route(nameof(AddCoupon))]
    public async Task<IActionResult> AddCoupon(AddCouponRequest request)
    {
        var shopperInfo = shopperInfoProvider.Get();

        var result = await cartUseCases.AddCoupon(shopperInfo, request);

        return await ProcessResult(result);
    }

    [HttpPost]
    [Route(nameof(RemoveCoupon))]
    public async Task<IActionResult> RemoveCoupon()
    {
        var shopperInfo = shopperInfoProvider.Get();

        await cartUseCases.RemoveCoupon(shopperInfo);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route(nameof(StartCheckout))]
    public async Task<IActionResult> StartCheckout()
    {
        var shopperInfo = shopperInfoProvider.Get();

        var result = await cartUseCases.StartCheckout(shopperInfo);

        if (result.Succeeded)
            return RedirectToAction("CheckoutAddresses", "Checkout");

        return await Redirect(_h[result.Error.ToMessage()]);
    }

    private async Task<IActionResult> ProcessResult(DuxResult<CartRow> result)
    {
        if (result.Succeeded)
            return RedirectToAction(nameof(Index));

        return await Redirect(_h[result.Error.ToMessage()]);
    }

    private async Task<IActionResult> Redirect(LocalizedHtmlString message)
    {
        await notifier.ErrorAsync(message);

        return RedirectToAction(nameof(Index));
    }
}