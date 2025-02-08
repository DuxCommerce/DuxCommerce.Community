using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Marketing.Requests;
using DuxCommerce.StoreBuilder.Marketing.UseCases;
using DuxCommerce.Storefront.Views.Promotion.ViewModels;
using DuxCommerce.Storefront.Views.Promotion.VmBuilders;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/Promotion")]
public class PromotionController(
    PromotionUseCases promotionUseCases,
    PromotionCatalogUseCases promotionCatalogUseCases,
    IAuthorizationService authorizationService,
    PromotionVmBuilder promotionVmBuilder,
    INotifier notifier,
    IHtmlLocalizer<PromotionController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [HttpGet(nameof(Index))]
    public async Task<ActionResult> Index()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var vm = await promotionVmBuilder.BuildIndexModel();

        return View(vm);
    }

    [HttpGet(nameof(Create))]
    public async Task<IActionResult> Create()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var vm = await promotionVmBuilder.BuildCreateModel();

        return View(vm);
    }

    [HttpPost(nameof(Create))]
    public async Task<IActionResult> Create(PromotionVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            var result = await promotionUseCases.CreatePromotion(model.Promotion);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Promotion created successfully"]);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = await promotionVmBuilder.BuildCreateModel(model);

        return View(vm);
    }

    [HttpGet(nameof(Edit))]
    public async Task<IActionResult> Edit(string promotionId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var vm = await promotionVmBuilder.BuildEditModel(promotionId);

        return View(vm);
    }

    [HttpPost(nameof(Edit))]
    public async Task<IActionResult> Edit(string promotionId, PromotionVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            var result = await promotionUseCases.UpdatePromotion(promotionId, model.Promotion);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Promotion updated successfully"]);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = await promotionVmBuilder.BuildEditModel(model);

        return View(vm);
    }

    [HttpPost(nameof(Delete))]
    public async Task<IActionResult> Delete(string promotionId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        await promotionUseCases.DeletePromotion(promotionId);

        await notifier.SuccessAsync(_h["Promotion deleted successfully"]);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet(nameof(Products))]
    public async Task<IActionResult> Products(string promotionId, PagerParameters pagerParameter)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var vm = await promotionVmBuilder.BuildProductsModel(promotionId, pagerParameter);

        return View(vm);
    }

    [HttpGet(nameof(LinkProducts))]
    public async Task<IActionResult> LinkProducts(string promotionId, ProductSearchVm searchVm,
        PagerParameters pagerParameters)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var model = await promotionVmBuilder.BuildLinkProductsModel(promotionId, searchVm, pagerParameters);

        return View(model);
    }

    [HttpPost(nameof(LinkProducts))]
    public async Task<IActionResult> LinkProducts(LinkPromotionProducts request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            await promotionCatalogUseCases.LinkProducts(request);
            await notifier.SuccessAsync(_h["Products linked successfully"]);
        }

        return RedirectToAction(nameof(LinkProducts), new { request.PromotionId });
    }

    [HttpPost(nameof(UnlinkProducts))]
    public async Task<IActionResult> UnlinkProducts(UnlinkPromotionProduct request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            await promotionCatalogUseCases.UnlinkProduct(request);
            await notifier.SuccessAsync(_h["Product unlinked successfully"]);
        }

        return RedirectToAction(nameof(Products), new { request.PromotionId });
    }

    [HttpGet(nameof(Categories))]
    public async Task<IActionResult> Categories(string promotionId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var vm = await promotionVmBuilder.BuildCategoriesModel(promotionId);

        return View(vm);
    }

    [HttpGet(nameof(LinkCategories))]
    public async Task<IActionResult> LinkCategories(string promotionId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var model = await promotionVmBuilder.BuildLinkCategoriesModel(promotionId);

        return View(model);
    }

    [HttpPost(nameof(LinkCategories))]
    public async Task<IActionResult> LinkCategories(LinkPromotionCategories request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            await promotionCatalogUseCases.LinkCategories(request);
            await notifier.SuccessAsync(_h["Categories linked successfully"]);
        }

        return RedirectToAction(nameof(LinkCategories), new { request.PromotionId });
    }

    [HttpPost(nameof(UnlinkCategories))]
    public async Task<IActionResult> UnlinkCategories(UnlinkPromotionCategory request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            await promotionCatalogUseCases.UnlinkCategory(request);
            await notifier.SuccessAsync(_h["Category unlinked successfully"]);
        }

        return RedirectToAction(nameof(Categories), new { request.PromotionId });
    }
}