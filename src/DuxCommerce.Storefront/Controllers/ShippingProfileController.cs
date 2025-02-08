using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Shipping.Requests;
using DuxCommerce.StoreBuilder.Shipping.UseCases;
using DuxCommerce.Storefront.Views.ShippingProfile.ViewModels;
using DuxCommerce.Storefront.Views.ShippingProfile.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/ShippingProfile")]
public class ShippingProfileController(
    IAuthorizationService authorizationService,
    ShippingOriginUseCases originUseCases,
    ShippingProfileUseCases profileUseCases,
    ShippingProfileVmBuilder profileVmBuilder,
    INotifier notifier,
    IHtmlLocalizer<ShippingProfileController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [HttpGet]
    [Route(nameof(Index))]
    public async Task<IActionResult> Index()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        var model = await profileVmBuilder.BuildIndexModel();

        return View(model);
    }

    [HttpGet]
    [Route(nameof(CreateZone))]
    public async Task<IActionResult> CreateZone(string groupId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        var model = await profileVmBuilder.BuildCreateZoneModel(groupId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(CreateZone))]
    public async Task<IActionResult> CreateZone(ShippingZoneVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await profileUseCases.CreateZone(model.ZoneModel);

            await notifier.SuccessAsync(_h["Shipping zone created successfully"]);

            return RedirectToAction(nameof(Index));
        }

        var vm = await profileVmBuilder.BuildCreateZoneModel(model);

        return View(vm);
    }

    [HttpGet]
    [Route(nameof(EditZone))]
    public async Task<IActionResult> EditZone(string groupId, string zoneId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        var model = await profileVmBuilder.BuildEditZoneModel(groupId, zoneId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(EditZone))]
    public async Task<IActionResult> EditZone(ShippingZoneVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await profileUseCases.UpdateZone(model.ZoneModel);

            await notifier.SuccessAsync(_h["Shipping zone updated successfully"]);

            return RedirectToAction(nameof(Index));
        }

        var vm = await profileVmBuilder.BuildEditZoneModel(model);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(DeleteZone))]
    public async Task<IActionResult> DeleteZone(string groupId, string zoneId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        await profileUseCases.DeleteZone(groupId, zoneId);

        await notifier.SuccessAsync(_h["Shipping zone deleted successfully"]);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Route(nameof(Methods))]
    public async Task<IActionResult> Methods(string groupId, string zoneId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        var model = await profileVmBuilder.BuildMethodsModel(groupId, zoneId);

        return View(model);
    }

    [HttpGet]
    [Route(nameof(AddMethod))]
    public async Task<IActionResult> AddMethod(string groupId, string zoneId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        var model = profileVmBuilder.BuildAddMethodModel(groupId, zoneId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(AddMethod))]
    public async Task<IActionResult> AddMethod(AddShippingMethodVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await profileUseCases.AddMethod(model.MethodModel);

            await notifier.SuccessAsync(_h["Shipping method added successfully"]);

            return RedirectToAction(nameof(Methods), new { model.MethodModel.GroupId, model.MethodModel.ZoneId });
        }

        var vm = profileVmBuilder.BuildAddMethodModel(model);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(DeleteMethod))]
    public async Task<IActionResult> DeleteMethod(string groupId, string zoneId, string methodId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        await profileUseCases.DeleteMethod(groupId, zoneId, methodId);

        await notifier.SuccessAsync(_h["Shipping method deleted successfully"]);

        return RedirectToAction(nameof(Methods), new { groupId, zoneId });
    }

    [HttpGet]
    [Route(nameof(EditMethod))]
    public async Task<IActionResult> EditMethod(string groupId, string zoneId, string methodId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        var model = await profileVmBuilder.BuildEditMethodModel(groupId, zoneId, methodId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(RenameMethod))]
    public async Task<IActionResult> RenameMethod(RenameMethodRequest request)
    {
        await profileUseCases.RenameMethod(request);

        return Json(new { Code = 0 });
    }

    [HttpGet]
    [Route(nameof(AddRate))]
    public async Task<IActionResult> AddRate(string groupId, string zoneId, string methodId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        var vm = profileVmBuilder.BuildAddRateModel(groupId, zoneId, methodId);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(AddRate))]
    public async Task<IActionResult> AddRate(ShippingRateModel model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        await profileUseCases.AddRate(model);

        await notifier.SuccessAsync(_h["Shipping rate added successfully"]);

        return RedirectToAction(nameof(EditMethod), new { model.GroupId, model.ZoneId, model.MethodId });
    }

    [HttpGet]
    [Route(nameof(EditRate))]
    public async Task<IActionResult> EditRate(string groupId, string zoneId, string methodId, string rateId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        var vm = await profileVmBuilder.BuildEditRateModel(groupId, zoneId, methodId, rateId);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(EditRate))]
    public async Task<IActionResult> EditRate(ShippingRateModel model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        await profileUseCases.UpdateRate(model);

        await notifier.SuccessAsync(_h["Shipping rate updated successfully"]);

        return RedirectToAction(nameof(EditMethod), new { model.GroupId, model.ZoneId, model.MethodId });
    }

    [HttpDelete]
    [Route(nameof(DeleteRate))]
    public async Task<JsonResult> DeleteRate(DeleteRateRequest request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
        {
            var response = new { Code = 1, Message = "Access Denied" };
            return Json(response);
        }

        await profileUseCases.DeleteRate(request);

        return Json(new { Code = 0 });
    }

    [Route(nameof(EditAddress))]
    public async Task<IActionResult> EditAddress(string originId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        var viewModel = await profileVmBuilder.BuildEditAddressModel(originId);

        return View(viewModel);
    }

    [HttpPost]
    [Route(nameof(EditAddress))]
    public async Task<IActionResult> EditAddress(string originId, OriginAddressVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageShippingSettings))
            return Forbid();

        if (!ModelState.IsValid)
        {
            var vm = await profileVmBuilder.BuildEditAddressModel(originId, model);
            return View(vm);
        }

        await originUseCases.UpdateAddress(originId, model.AddressVm.Address);

        await notifier.SuccessAsync(_h["Shipping origin updated successfully"]);

        return RedirectToAction(nameof(Index));
    }
}