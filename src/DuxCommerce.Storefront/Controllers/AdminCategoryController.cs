using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.Storefront.Views.AdminCategory.ViewModels;
using DuxCommerce.Storefront.Views.AdminCategory.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/Category")]
public class AdminCategoryController(
    IAuthorizationService authorizationService,
    CategoryUseCases categoryUseCases,
    CategoryPartVmBuilder categoryPartVmBuilder,
    CategoryIndexVmBuilder categoryIndexVmBuilder,
    INotifier notifier,
    IHtmlLocalizer<AdminCategoryController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Index))]
    public async Task<ActionResult> Index()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCategories))
            return Forbid();

        var model = await categoryIndexVmBuilder.BuildModel();

        return View(model);
    }

    [HttpPost]
    [Route(nameof(Delete))]
    public async Task<IActionResult> Delete(string id)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCategories))
            return Forbid();

        await categoryUseCases.DeleteCategory(id);
        await notifier.SuccessAsync(_h["Category deleted successfully"]);

        return RedirectToAction(nameof(Index));
    }

    [Route(nameof(Products))]
    public async Task<IActionResult> Products(string categoryId, PagerParameters pagerParameter)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCategories))
            return Forbid();

        var model = await categoryPartVmBuilder.BuildProductsModel(categoryId, pagerParameter);

        return View(model);
    }

    [Route(nameof(LinkProducts))]
    public async Task<IActionResult> LinkProducts(CategoryProductSearchVm searchVm, PagerParameters pagerParameters)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCategories))
            return Forbid();

        var model = await categoryPartVmBuilder.BuildLinkProductsModel(searchVm, pagerParameters);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(LinkProducts))]
    public async Task<IActionResult> LinkProducts(LinkProductsRequest request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCategories))
            return Forbid();

        if (ModelState.IsValid)
        {
            await categoryUseCases.LinkProducts(request);
            await notifier.SuccessAsync(_h["Products linked successfully"]);
        }

        return RedirectToAction(nameof(LinkProducts), new { request.CategoryId });
    }

    [HttpPost]
    [Route(nameof(UnlinkProducts))]
    public async Task<IActionResult> UnlinkProducts(UnlinkProductRequest request)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCategories))
            return Forbid();

        await categoryUseCases.UnlinkProduct(request);
        await notifier.SuccessAsync(_h["Product unlinked successfully"]);

        return RedirectToAction(nameof(Products), new { request.CategoryId });
    }
}