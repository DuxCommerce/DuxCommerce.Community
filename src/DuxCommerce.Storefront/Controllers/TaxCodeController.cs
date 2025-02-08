using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Taxes.Requests;
using DuxCommerce.StoreBuilder.Taxes.UseCases;
using DuxCommerce.Storefront.Views.TaxCode.ViewModels;
using DuxCommerce.Storefront.Views.TaxCode.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/TaxCode")]
public class TaxCodeController(
    IAuthorizationService authorizationService,
    TaxCodeVmBuilder vmVmBuilder,
    TaxCodeUseCases taxCodeUseCases,
    INotifier notifier,
    IHtmlLocalizer<TaxCodeController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Index))]
    public async Task<IActionResult> Index()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        var taxCodes = await vmVmBuilder.BuildIndexModel();

        return View(taxCodes);
    }

    [Route(nameof(Create))]
    public async Task<IActionResult> Create()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        var vm = new TaxCodeVm { CodeModel = new TaxCodeModel() };

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<IActionResult> Create(TaxCodeVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await taxCodeUseCases.CreateCode(model.CodeModel);

            await notifier.SuccessAsync(_h["Tax code created successfully"]);
        }

        return RedirectToAction(nameof(Index));
    }

    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string taxCodeId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        var vm = await vmVmBuilder.BuildEditCodeModel(taxCodeId);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(TaxCodeVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await taxCodeUseCases.UpdateCode(model.CodeModel);

            await notifier.SuccessAsync(_h["Tax code updated successfully"]);
        }

        return RedirectToAction(nameof(Index));
    }

    [Route(nameof(Delete))]
    public async Task<IActionResult> Delete(string taxCodeId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageTaxSettings))
            return Forbid();

        await taxCodeUseCases.DeleteCode(taxCodeId);

        await notifier.SuccessAsync(_h["Tax code deleted successfully"]);

        return RedirectToAction(nameof(Index));
    }
}