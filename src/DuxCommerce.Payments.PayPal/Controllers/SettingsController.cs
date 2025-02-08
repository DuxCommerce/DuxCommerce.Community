using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.Payments.PayPal.Services;
using DuxCommerce.Payments.PayPal.Views.Settings.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Payments.PayPal.Controllers;

[Route("PayPal")]
[Admin]
public class SettingsController(
    IAuthorizationService authorizationService,
    PayPalSettingsUseCases payPalSettingsUseCases,
    PayPalSettingsBuilder settingsBuilder,
    INotifier notifier,
    IHtmlLocalizer<SettingsController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [HttpGet(nameof(Setup))]
    public async Task<IActionResult> Setup(string methodType)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManagePaymentSettings))
            return Forbid();

        var vm = await settingsBuilder.BuildModel(methodType);

        return View(vm);
    }

    [HttpPost(nameof(Setup))]
    public async Task<IActionResult> Setup(PayPalSettingsVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManagePaymentSettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await payPalSettingsUseCases.UpdateSettings(model.SettingsModel);

            await notifier.SuccessAsync(_h["PayPal settings updated successfully"]);

            return RedirectToAction(nameof(Setup), new { model.SettingsModel.MethodType });
        }

        var vm = await settingsBuilder.BuildModel(model);

        return View(vm);
    }
}