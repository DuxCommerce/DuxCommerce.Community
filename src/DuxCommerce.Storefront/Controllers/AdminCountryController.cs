using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Settings.Requests;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.Storefront.Views.AdminCountry.ViewModels;
using DuxCommerce.Storefront.Views.AdminCountry.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/Country")]
public class AdminCountryController(
    IAuthorizationService authorizationService,
    CountryUseCases countryUseCases,
    StateUseCases stateUseCases,
    CountryVmBuilder vmVmBuilder,
    INotifier notifier,
    IHtmlLocalizer<AdminCountryController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Index))]
    public async Task<ActionResult> Index()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        var vm = await vmVmBuilder.BuildIndexModel();

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Index))]
    public async Task<IActionResult> Index(UpdateCountriesRequest request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await countryUseCases.UpdateCountries(request);

            await notifier.SuccessAsync(_h["Countries updated successfully"]);
        }

        return RedirectToAction(nameof(Index));
    }

    [Route(nameof(Create))]
    public async Task<IActionResult> Create()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        return View(new CountryVm());
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<IActionResult> Create(CountryVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await countryUseCases.CreateCountry(model.CountryModel);

            await notifier.SuccessAsync(_h["Country created successfully"]);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string countryId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        var vm = await vmVmBuilder.BuildEditModel(countryId);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string countryId, CountryVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await countryUseCases.UpdateCountry(countryId, model.CountryModel);

            await notifier.SuccessAsync(_h["Country updated successfully"]);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    [HttpPost]
    [Route(nameof(Delete))]
    public async Task<IActionResult> Delete(string countryId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        await countryUseCases.DeleteCountry(countryId);

        await notifier.SuccessAsync(_h["Country deleted successfully"]);

        return RedirectToAction(nameof(Index));
    }

    [Route(nameof(CreateState))]
    public async Task<IActionResult> CreateState(string countryId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        var vm = await vmVmBuilder.BuildCreateStateModel(countryId);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(CreateState))]
    public async Task<IActionResult> CreateState(string countryId, StateVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await stateUseCases.CreateState(model.StateModel);

            await notifier.SuccessAsync(_h["State created successfully"]);

            return RedirectToAction(nameof(Edit), new { countryId });
        }

        return View(model);
    }

    [Route(nameof(EditState))]
    public async Task<IActionResult> EditState(string countryId, string stateId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        var vm = await vmVmBuilder.BuildEditStateModel(countryId, stateId);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(EditState))]
    public async Task<IActionResult> EditState(string countryId, StateVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        if (ModelState.IsValid)
        {
            await stateUseCases.UpdateState(model.StateModel);

            await notifier.SuccessAsync(_h["State updated successfully"]);

            return RedirectToAction(nameof(Edit), new { countryId });
        }

        return View(model);
    }

    [Route(nameof(DeleteState))]
    public async Task<IActionResult> DeleteState(string countryId, string stateId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCountrySettings))
            return Forbid();

        await stateUseCases.DeleteState(stateId);

        await notifier.SuccessAsync(_h["State deleted successfully"]);

        return RedirectToAction(nameof(Edit), new { countryId });
    }
}