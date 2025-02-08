using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.Storefront.Views.ProductVariant.ViewModels;
using DuxCommerce.Storefront.Views.ProductVariant.VmBuilder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/ProductVariant")]
public class ProductVariantController(
    ProductUseCases productUseCases,
    ProductVariantsVmBuilder productVariantsVmBuilder,
    IAuthorizationService authorizationService,
    INotifier notifier,
    IHtmlLocalizer<ProductVariantController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Index))]
    public async Task<IActionResult> Index(string productId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        var model = await productVariantsVmBuilder.BuildIndexModel(productId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(Index))]
    public async Task<IActionResult> Index(string productId, ProductVariantsVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();
        
        if (ModelState.IsValid)
        {
            var result = await productUseCases.UpdateVariants(productId, model.Variants);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Product variants updated successfully"]);
                return RedirectToAction(nameof(Index), new { productId });
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = await productVariantsVmBuilder.BuildIndexModel(productId, model);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(GenerateVariants))]
    public async Task<IActionResult> GenerateVariants(string productId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();
        
        await productUseCases.CreateAllVariants(productId);

        await notifier.SuccessAsync(_h["Product variants generated successfully"]);

        return RedirectToAction(nameof(Index), new { productId });
    }
}