using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.Storefront.Views.LinkedOption.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/LinkedOption")]
public class LinkedOptionController(
    ProductOptionsUseCases productOptionsUseCases,
    LinkedOptionVmBuilder linkedOptionVmBuilder,
    IAuthorizationService authorizationService,
    INotifier notifier,
    IHtmlLocalizer<ProductOptionController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string productId, string optionId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        var model = await linkedOptionVmBuilder.BuildEditModel(productId, optionId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(DefaultChoiceModel model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        if (ModelState.IsValid)
        {
            await productOptionsUseCases.SetDefaultChoice(model);
            
            await notifier.SuccessAsync(_h["Default choice updated successfully"]);
            
            return RedirectToAction(nameof(Edit), new { model.ProductId, model.OptionId });
        }

        var vm = await linkedOptionVmBuilder.BuildEditModel(model.ProductId, model.OptionId);

        return View(vm);
    }
}