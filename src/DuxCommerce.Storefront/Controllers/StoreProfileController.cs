using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.ErrorTypes;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Shipping.UseCases;
using DuxCommerce.Storefront.Views.StoreProfile.ViewModels;
using DuxCommerce.Storefront.Views.StoreProfile.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/StoreProfile")]
public class StoreProfileController(
    IAuthorizationService authorizationService,
    StoreProfileVmBuilder storeProfileVmBuilder,
    StoreProfileUseCases storeProfileUseCases,
    INotifier notifier,
    IHtmlLocalizer<StoreProfileController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageStoreProfile))
            return Forbid();

        var model = await storeProfileVmBuilder.BuildEditModel();

        return View(model);
    }

    [HttpPost]
    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(StoreProfileVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageStoreProfile))
            return Forbid();
        
        if (ModelState.IsValid)
        {
            DuxResult<StoreProfileRow> result;

            model.Profile.Address = model.AddressVm.Address;

            if (string.IsNullOrEmpty(model.Profile.Id))
                result = await storeProfileUseCases.CreateProfile(model.Profile);
            else
                result = await storeProfileUseCases.UpdateProfile(model.Profile);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Store profile updated successfully"]);
                return RedirectToAction(nameof(Edit));
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = await storeProfileVmBuilder.BuildEditModel(model);

        return View(vm);
    }
}