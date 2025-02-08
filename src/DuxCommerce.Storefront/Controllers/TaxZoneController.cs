using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Taxes.UseCases;
using DuxCommerce.Storefront.Views.TaxZone.ViewModels;
using DuxCommerce.Storefront.Views.TaxZone.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/TaxZone")]
public class TaxZoneController(
    TaxZoneVmBuilder taxZoneVmBuilder,
    IAuthorizationService authorizationService,
    TaxZoneUseCases taxZoneUseCases,
    INotifier notifier,
    IHtmlLocalizer<TaxZoneController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Index))]
    public async Task<IActionResult> Index()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        var model = await taxZoneVmBuilder.BuildIndexModel();

        return View(model);
    }

    [Route(nameof(CreateZone))]
    public async Task<IActionResult> CreateZone()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        var model = await taxZoneVmBuilder.BuildCreateZoneModel();

        return View(model);
    }

    [HttpPost]
    [Route(nameof(CreateZone))]
    public async Task<IActionResult> CreateZone(TaxZoneVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            var result = await taxZoneUseCases.CreateZone(model.ZoneModel);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Tax zone created successfully"]);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = await taxZoneVmBuilder.BuildCreateZoneModel(model);

        return View(vm);
    }

    [Route(nameof(EditZone))]
    public async Task<IActionResult> EditZone(string zoneId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        var model = await taxZoneVmBuilder.BuildEditZoneModel(zoneId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(EditZone))]
    public async Task<IActionResult> EditZone(TaxZoneVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            var result = await taxZoneUseCases.UpdateZone(model.ZoneModel);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Tax zone updated successfully"]);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = await taxZoneVmBuilder.BuildEditZoneModel(model);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(DeleteZone))]
    public async Task<IActionResult> DeleteZone(string zoneId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        await taxZoneUseCases.DeleteZone(zoneId);

        await notifier.SuccessAsync(_h["Tax zone deleted successfully"]);

        return RedirectToAction(nameof(Index));
    }

    [Route(nameof(TaxRates))]
    public async Task<IActionResult> TaxRates(string zoneId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        var model = await taxZoneVmBuilder.BuildTaxRatesModel(zoneId);

        return View(model);
    }

    [Route(nameof(AddTaxRate))]
    public async Task<IActionResult> AddTaxRate(string zoneId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        var model = await taxZoneVmBuilder.BuildAddTaxRateModel(zoneId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(AddTaxRate))]
    public async Task<IActionResult> AddTaxRate(TaxRateVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await taxZoneUseCases.AddTaxRate(model.ZoneId, model.RateModel);

            await notifier.SuccessAsync(_h["Tax rate created successfully"]);
            return RedirectToAction(nameof(TaxRates), new { model.ZoneId });
        }

        var vm = await taxZoneVmBuilder.BuildAddTaxRateModel(model);

        return View(vm);
    }

    [Route(nameof(EditTaxRate))]
    public async Task<IActionResult> EditTaxRate(string zoneId, string id)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        var model = await taxZoneVmBuilder.BuildEditTaxRateModel(zoneId, id);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(EditTaxRate))]
    public async Task<IActionResult> EditTaxRate(TaxRateVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await taxZoneUseCases.UpdateTaxRate(model.ZoneId, model.RateModel);

            await notifier.SuccessAsync(_h["Tax rate updated successfully"]);
            return RedirectToAction(nameof(TaxRates), new { model.ZoneId });
        }

        var vm = await taxZoneVmBuilder.BuildEditTaxRateModel(model);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(DeleteTaxRate))]
    public async Task<IActionResult> DeleteTaxRate(string zoneId, string id)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        await taxZoneUseCases.DeleteTaxRate(zoneId, id);

        await notifier.SuccessAsync(_h["Tax zone deleted successfully"]);

        return RedirectToAction(nameof(TaxRates), new { zoneId });
    }
}