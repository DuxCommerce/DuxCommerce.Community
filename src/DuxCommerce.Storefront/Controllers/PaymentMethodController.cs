using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Payments.UseCases;
using DuxCommerce.Storefront.Views.PaymentMethod.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/PaymentMethod")]
public class PaymentMethodController(
    IAuthorizationService authorizationService,
    PaymentMethodVmBuilder paymentMethodVmBuilder,
    PaymentMethodUseCases paymentMethodUseCases,
    INotifier notifier,
    IHtmlLocalizer<PaymentMethodController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;
    private readonly INotifier _notifier = notifier;

    [HttpGet]
    [Route(nameof(Index))]
    public async Task<IActionResult> Index()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManagePaymentSettings))
            return Forbid();

        var vm = await paymentMethodVmBuilder.BuildIndexModel();

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Enable))]
    public async Task<JsonResult> Enable(string methodType)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManagePaymentSettings))
        {
            var response = new { Code = 1, Message = "Access Denied" };
            return Json(response);
        }

        await paymentMethodUseCases.EnableMethod(methodType);

        return Json(new { Code = 0 });
    }

    [HttpPost]
    [Route(nameof(Disable))]
    public async Task<JsonResult> Disable(string methodType)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManagePaymentSettings))
        {
            var response = new { Code = 1, Message = "Access Denied" };
            return Json(response);
        }

        await paymentMethodUseCases.DisableMethod(methodType);

        return Json(new { Code = 0 });
    }
}