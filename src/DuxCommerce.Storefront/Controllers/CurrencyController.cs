using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.Storefront.Views.Currency.ViewModels;
using DuxCommerce.Storefront.Views.Currency.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/Currency")]
public class CurrencyController(
    CurrencyUseCases currencyUseCases,
    IAuthorizationService authorizationService,
    CurrencyVmBuilder vmVmBuilder,
    INotifier notifier,
    IHtmlLocalizer<CurrencyController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Index))]
    public async Task<ActionResult> Index()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCurrencySettings))
            return Forbid();

        var vm = await vmVmBuilder.BuildIndexModel();

        return View(vm);
    }

    [Route(nameof(Create))]
    public async Task<IActionResult> Create()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCurrencySettings))
            return Forbid();

        return View(vmVmBuilder.BuildCreateModel());
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<IActionResult> Create(CurrencyVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCurrencySettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await currencyUseCases.CreateCurrency(model.CurrencyModel);
            await notifier.SuccessAsync(_h["Currency created successfully"]);

            return RedirectToAction(nameof(Index));
        }

        return View(vmVmBuilder.BuildCreateModel(model));
    }

    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string currencyId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCurrencySettings))
            return Forbid();

        var vm = await vmVmBuilder.BuildEditModel(currencyId);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string currencyId, CurrencyVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCurrencySettings))
            return Forbid();

        // Todo: add custom validator to make sure either display locale or custom formatting is set but not bth
        if (ModelState.IsValid)
        {
            await currencyUseCases.UpdateCurrency(currencyId, model.CurrencyModel);
            await notifier.SuccessAsync(_h["Currency updated successfully"]);

            return RedirectToAction(nameof(Index));
        }

        return View(vmVmBuilder.BuildEditModel(model));
    }

    [HttpPost]
    [Route(nameof(Delete))]
    public async Task<IActionResult> Delete(string currencyId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCurrencySettings))
            return Forbid();

        await currencyUseCases.DeleteCurrency(currencyId);
        await notifier.SuccessAsync(_h["Currency deleted successfully"]);

        return RedirectToAction(nameof(Index));
    }
}