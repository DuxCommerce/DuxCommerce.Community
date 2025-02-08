using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Marketing.Requests;
using DuxCommerce.StoreBuilder.Marketing.UseCases;
using DuxCommerce.Storefront.Views.Coupon.ViewModels;
using DuxCommerce.Storefront.Views.Coupon.VmBuilders;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/Coupon")]
public class CouponController(
    CouponUseCases couponUseCases,
    CouponCatalogUseCases couponCatalogUseCases,
    IAuthorizationService authorizationService,
    CouponVmBuilder couponVmBuilder,
    INotifier notifier,
    IHtmlLocalizer<CouponController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Index))]
    public async Task<ActionResult> Index()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var vm = await couponVmBuilder.BuildIndexModel();

        return View(vm);
    }

    [Route(nameof(Create))]
    public async Task<IActionResult> Create()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var vm = await couponVmBuilder.BuildCreateModel();

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<IActionResult> Create(CouponVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            var result = await couponUseCases.CreateCoupon(model.Coupon);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Coupon created successfully"]);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = await couponVmBuilder.BuildCreateModel(model);

        return View(vm);
    }

    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string couponId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var vm = await couponVmBuilder.BuildEditModel(couponId);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string couponId, CouponVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            var result = await couponUseCases.UpdateCoupon(couponId, model.Coupon);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Coupon updated successfully"]);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = await couponVmBuilder.BuildEditModel(model);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Delete))]
    public async Task<IActionResult> Delete(string couponId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        await couponUseCases.DeleteCoupon(couponId);

        await notifier.SuccessAsync(_h["Coupon deleted successfully"]);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet(nameof(Products))]
    public async Task<IActionResult> Products(string couponId, PagerParameters pagerParameter)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var vm = await couponVmBuilder.BuildProductsModel(couponId, pagerParameter);

        return View(vm);
    }

    [HttpGet(nameof(LinkProducts))]
    public async Task<IActionResult> LinkProducts(string couponId, ProductSearchVm searchVm,
        PagerParameters pagerParameters)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var model = await couponVmBuilder.BuildLinkProductsModel(couponId, searchVm, pagerParameters);

        return View(model);
    }

    [HttpPost(nameof(LinkProducts))]
    public async Task<IActionResult> LinkProducts(LinkCouponProducts request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            await couponCatalogUseCases.LinkProducts(request);
            await notifier.SuccessAsync(_h["Products linked successfully"]);
        }

        return RedirectToAction(nameof(LinkProducts), new { request.CouponId });
    }

    [HttpPost(nameof(UnlinkProducts))]
    public async Task<IActionResult> UnlinkProducts(UnlinkCouponProduct request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            await couponCatalogUseCases.UnlinkProduct(request);
            await notifier.SuccessAsync(_h["Product unlinked successfully"]);
        }

        return RedirectToAction(nameof(Products), new { request.CouponId });
    }

    [HttpGet(nameof(Categories))]
    public async Task<IActionResult> Categories(string couponId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var vm = await couponVmBuilder.BuildCategoriesModel(couponId);

        return View(vm);
    }

    [HttpGet(nameof(LinkCategories))]
    public async Task<IActionResult> LinkCategories(string couponId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        var model = await couponVmBuilder.BuildLinkCategoriesModel(couponId);

        return View(model);
    }

    [HttpPost(nameof(LinkCategories))]
    public async Task<IActionResult> LinkCategories(LinkCouponCategories request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            await couponCatalogUseCases.LinkCategories(request);
            await notifier.SuccessAsync(_h["Categories linked successfully"]);
        }

        return RedirectToAction(nameof(LinkCategories), new { request.CouponId });
    }

    [HttpPost(nameof(UnlinkCategories))]
    public async Task<IActionResult> UnlinkCategories(UnlinkCouponCategory request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageMarketing))
            return Forbid();

        if (ModelState.IsValid)
        {
            await couponCatalogUseCases.UnlinkCategory(request);
            await notifier.SuccessAsync(_h["Category unlinked successfully"]);
        }

        return RedirectToAction(nameof(Categories), new { request.CouponId });
    }
}