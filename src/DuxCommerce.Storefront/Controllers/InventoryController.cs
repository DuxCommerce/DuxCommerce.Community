using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.Storefront.Views.Inventory.ViewModels;
using DuxCommerce.Storefront.Views.Inventory.VmBuilders;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.Navigation;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/Inventory")]
public class InventoryController(
    ProductUseCases productUseCases,
    InventoryVmBuilder inventoryVmBuilder,
    IAuthorizationService authorizationService,
    INotifier notifier,
    IHtmlLocalizer<InventoryController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Index))]
    public async Task<IActionResult> Index(ProductSearchVm searchVm, PagerParameters pagerParameters)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageInventory))
            return Forbid();

        var model = await inventoryVmBuilder.BuildIndexModel(searchVm, pagerParameters);

        return View(model);
    }

    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string productId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageInventory))
            return Forbid();

        var model = await inventoryVmBuilder.BuildEditModel(productId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(EditInventoryVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageInventory))
            return Forbid();

        if (!ModelState.IsValid)
            return RedirectToAction(nameof(Index));

        var request = new AdjustInventoryRequest
        {
            ProductId = model.Inventory.ProductId,
            AdjustBy = model.Inventory.AdjustBy,
            Reason = model.Inventory.Reason
        };

        var result = await productUseCases.AdjustInventory(request);

        if (result.Succeeded)
            await notifier.SuccessAsync(_h["Inventory updated successfully"]);
        else
            await notifier.WarningAsync(_h[result.Error.ToMessage()]);

        return RedirectToAction(nameof(Index));
    }
}