using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.ErrorTypes;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.Storefront.Views.TaxProfile.ViewModels;
using DuxCommerce.Storefront.Views.TaxProfile.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/TaxProfile")]
public class TaxProfileController(
    IAuthorizationService authorizationService,
    TaxProfileVmBuilder taxProfileVmBuilder,
    TaxProfileUseCases taxProfileUseCases,
    INotifier notifier,
    IHtmlLocalizer<TaxProfileController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        var model = await taxProfileVmBuilder.BuildEditModel();

        return View(model);
    }

    [HttpPost]
    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(TaxProfileVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();
        
        if (ModelState.IsValid)
        {
            FlexiResult<TaxProfileRow> result;

            if (string.IsNullOrEmpty(model.ProfileModel.Id))
                result = await taxProfileUseCases.CreateProfile(model.ProfileModel);
            else
                result = await taxProfileUseCases.UpdateProfile(model.ProfileModel);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Tax profile updated successfully"]);
                return RedirectToAction(nameof(Edit));
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = await taxProfileVmBuilder.BuildEditModel(model);

        return View(vm);
    }
}