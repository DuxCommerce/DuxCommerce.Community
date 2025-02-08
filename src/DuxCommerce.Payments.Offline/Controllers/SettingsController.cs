using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.OrchardCore.Payments;
using DuxCommerce.Payments.Offline.Views.Settings.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Payments.Offline.Controllers;

[Route("PaymentMethod")]
[Admin]
public class SettingsController(
    IAuthorizationService authorizationService,
    OfflineSettingsBuilder offlineSettingsBuilder,
    SettingsUseCases settingsUseCases,
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

        var vm = await offlineSettingsBuilder.BuildEditModel(methodType);

        return View(vm);
    }

    [HttpPost(nameof(Setup))]
    public async Task<IActionResult> Setup(OfflineSettingsVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManagePaymentSettings))
            return Forbid();
    
        if (ModelState.IsValid)
        {
            await settingsUseCases.UpdateMethod(model.Settings);
    
            await notifier.SuccessAsync(_h["Payment method updated successfully"]);
    
            return RedirectToAction(nameof(Setup), new {model.Settings.MethodType});
        }

        var vm = await offlineSettingsBuilder.BuildEditModel(model);
    
        return View(vm);
    }    
}