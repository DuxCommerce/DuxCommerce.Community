using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Orders.Requests;
using DuxCommerce.StoreBuilder.Orders.UseCases;
using DuxCommerce.Storefront.Views.AdminOrder.ViewModels;
using DuxCommerce.Storefront.Views.AdminOrder.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/Order")]
public class AdminOrderController(
    IAuthorizationService authorizationService,
    OrderUseCases orderUseCases,
    AdminOrdersVmBuilder adminOrdersVmBuilder,
    OrderDetailsVmBuilder orderDetailsVmBuilder,
    OrderPaymentsVmBuilder orderPaymentsVmBuilder,
    OrderShipmentsVmBuilder orderShipmentsVmBuilder,
    INotifier notifier,
    IHtmlLocalizer<AdminOrderController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Index))]
    public async Task<ActionResult> Index(OrderSearchOptions options, PagerParameters pagerParameters)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageOrders))
            return Forbid();

        var ordersVm = await adminOrdersVmBuilder.Build(options, pagerParameters);

        return View(ordersVm);
    }

    [Route(nameof(Details))]
    public async Task<IActionResult> Details(string id)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageOrders))
            return Forbid();

        var vm = await orderDetailsVmBuilder.Build(id);

        return View(vm);
    }

    [Route(nameof(Payments))]
    public async Task<IActionResult> Payments(string id)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageOrders))
            return Forbid();

        var vm = await orderPaymentsVmBuilder.Build(id);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Payments))]
    public async Task<IActionResult> Payments(string id, string paymentId, OrderPaymentsVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageOrders))
            return Forbid();

        if (ModelState.IsValid)
        {
            await orderUseCases.ReceivePayment(id, paymentId, model.PaymentModel);

            await notifier.SuccessAsync(_h["Payment updated successfully"]);

            return RedirectToAction(nameof(Payments), new { id });
        }

        var vm = await orderPaymentsVmBuilder.Build(id, model);

        return View(vm);
    }

    [Route(nameof(Shipments))]
    public async Task<IActionResult> Shipments(string id)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageOrders))
            return Forbid();

        var vm = await orderShipmentsVmBuilder.Build(id);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Shipments))]
    public async Task<IActionResult> Shipments(string id, OrderShipmentsVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageOrders))
            return Forbid();

        if (ModelState.IsValid)
        {
            var result = await orderUseCases.CreateShipment(id, model.Shipment);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Shipment created successfully"]);

                return RedirectToAction(nameof(Shipments), new { id });
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = await orderShipmentsVmBuilder.Build(id, model);

        return View(vm);
    }
}