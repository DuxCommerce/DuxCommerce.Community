using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.OrchardCore.Checkout;
using DuxCommerce.OrchardCore.Customers;
using DuxCommerce.StoreBuilder.Carts.DataStores;
using DuxCommerce.StoreBuilder.Checkout.Requests;
using DuxCommerce.StoreBuilder.Checkout.UseCases;
using DuxCommerce.Storefront.Views.Checkout.ViewModels;
using DuxCommerce.Storefront.Views.Checkout.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Authorize]
[Route("Checkout")]
public class CheckoutController(
    IShopperInfoProvider shopperInfoProvider,
    ICartStore cartStore,
    CheckoutUseCases checkoutUseCases,
    CheckoutAddressesVmBuilder checkoutAddressesVmBuilder,
    CheckoutOptionsVmBuilder checkoutOptionsVmBuilder,
    ConfirmPaymentVmBuilder confirmPaymentVmBuilder,
    OrderVmBuilder orderVmBuilder,
    INotifier notifier,
    IHtmlLocalizer<CheckoutController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [HttpGet]
    [Route(nameof(CheckoutAddresses))]
    public async Task<IActionResult> CheckoutAddresses()
    {
        var shopperInfo = shopperInfoProvider.Get();

        if (!await cartStore.CartExists(shopperInfo.CartId))
            return RedirectToAction("Index", "ShoppingCart");

        var model = await checkoutAddressesVmBuilder.BuildEditModel(shopperInfo);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(CheckoutAddresses))]
    public async Task<IActionResult> CheckoutAddresses(CheckoutAddressesVm model)
    {
        var shopperInfo = shopperInfoProvider.Get();

        if (!await cartStore.CartExists(shopperInfo.CartId))
            return RedirectToAction("Index", "ShoppingCart");

        var validationResults = new List<ValidationResult>();

        if (model.Validate(validationResults))
        {
            var addressesModel = new CheckoutAddressesModel
            {
                BillingAddressId = model.BillingAddress.AddressId,
                BillingAddress = model.BillingAddress.AddressVm?.Address,
                SameAsBillingAddress = model.SameAsBillingAddress,
                ShippingAddressId = model.ShippingAddress.AddressId,
                ShippingAddress = model.ShippingAddress.AddressVm?.Address
            };

            await checkoutUseCases.AddCheckoutAddresses(shopperInfo, addressesModel);

            return RedirectToAction(nameof(CheckoutOptions));
        }

        var vm = await checkoutAddressesVmBuilder.BuildEditModel(shopperInfo, model);

        return View(vm);
    }

    [HttpGet]
    [Route(nameof(CheckoutOptions))]
    public async Task<IActionResult> CheckoutOptions()
    {
        var shopperInfo = shopperInfoProvider.Get();

        if (!await cartStore.CartExists(shopperInfo.CartId))
            return RedirectToAction("Index", "ShoppingCart");

        var model = await checkoutOptionsVmBuilder.BuildViewModel(shopperInfo);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(CheckoutOptions))]
    public async Task<IActionResult> CheckoutOptions(CheckoutOptionsVm model)
    {
        var shopperInfo = shopperInfoProvider.Get();

        if (!await cartStore.CartExists(shopperInfo.CartId))
            return RedirectToAction("Index", "ShoppingCart");

        if (ModelState.IsValid)
        {
            var shippingPaymentModel = new CheckoutOptionsModel
            {
                ShippingOption = model.ShippingModel,
                PaymentMethod = model.MethodModel
            };

            var result = await checkoutUseCases.AddCheckoutOptions(shopperInfo, shippingPaymentModel);

            if (result.Succeeded)
                return RedirectToAction(nameof(ConfirmPayment));

            await notifier.ErrorAsync(_h[result.Error.ToMessage()]);
        }

        var vm = await checkoutOptionsVmBuilder.BuildViewModel(shopperInfo, model);

        return View(vm);
    }

    [HttpGet]
    [Route(nameof(ConfirmPayment))]
    public async Task<IActionResult> ConfirmPayment()
    {
        var shopperInfo = shopperInfoProvider.Get();

        if (!await cartStore.CartExists(shopperInfo.CartId))
            return RedirectToAction("Index", "ShoppingCart");

        var model = await confirmPaymentVmBuilder.BuildViewModel(shopperInfo);

        return View(model);
    }

    [HttpGet]
    [Route(nameof(Confirmation))]
    public async Task<IActionResult> Confirmation(string orderId)
    {
        var model = await orderVmBuilder.BuildCustomerOrder(orderId);

        return View(model);
    }
}