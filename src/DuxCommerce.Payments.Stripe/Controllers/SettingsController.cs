using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.Payments.Stripe.Services;
using DuxCommerce.Payments.Stripe.Views.Settings.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Payments.Stripe.Controllers;

[Route("Stripe")]
[Admin]
public class SettingsController(
    IAuthorizationService authorizationService,
    StripeSettingsUseCases stripeSettingsUseCases,
    StripeSettingsBuilder settingsBuilder,
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
    public async Task<IActionResult> Setup(StripeSettingsVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManagePaymentSettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await stripeSettingsUseCases.UpdateSettings(model.Settings);

            await notifier.SuccessAsync(_h["Stripe settings updated successfully"]);

            return RedirectToAction(nameof(Setup), new { model.Settings.MethodType });
        }

        var vm = await settingsBuilder.BuildModel(model);

        return View(vm);
    }
}