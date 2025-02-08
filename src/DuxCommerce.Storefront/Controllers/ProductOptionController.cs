using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.StoreBuilder.Catalog.UseCases;
using DuxCommerce.StoreBuilder.Workflows;
using DuxCommerce.Storefront.Views.ProductOption.ViewModels;
using DuxCommerce.Storefront.Views.ProductOption.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/ProductOption")]
public class ProductOptionController(
    ProductOptionsUseCases productOptionsUseCases,
    ProductOptionWorkflow productOptionWorkflow,
    ProductOptionsVmBuilder productOptionsVmBuilder,
    IAuthorizationService authorizationService,
    INotifier notifier,
    IHtmlLocalizer<ProductOptionController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Index))]
    public async Task<IActionResult> Index(string productId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        var model = await productOptionsVmBuilder.BuildIndexModel(productId);

        return View(model);
    }

    [Route(nameof(Create))]
    public async Task<IActionResult> Create(string productId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        var model = productOptionsVmBuilder.BuildCreateModel(productId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<IActionResult> Create(string productId, PrivateOptionVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        if (ModelState.IsValid)
        {
            var result = await productOptionsUseCases.AddPrivateOption(productId, model.Option);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Product option created successfully"]);
                return RedirectToAction(nameof(Edit), new { productId, OptionId = result.Result.Id });
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = productOptionsVmBuilder.BuildCreateModel(model);

        return View(vm);
    }

    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string productId, string optionId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        var model = await productOptionsVmBuilder.BuildEditModel(productId, optionId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string productId, PrivateOptionVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        if (ModelState.IsValid)
        {
            var result = await productOptionsUseCases.UpdatePrivateOption(productId, model.Option);

            if (result.Succeeded)
            {
                await notifier.SuccessAsync(_h["Product option updated successfully"]);
                return RedirectToAction(nameof(Index), new { productId });
            }

            ModelState.AddModelError(string.Empty, result.Error.ToMessage());
        }

        var vm = await productOptionsVmBuilder.BuildEditModel(productId, model);

        return View(vm);
    }

    [HttpPost]
    [Route(nameof(Delete))]
    public async Task<IActionResult> Delete(string productId, string optionId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        await productOptionWorkflow.DeletePrivateOption(productId, optionId);

        await notifier.SuccessAsync(_h["Product option deleted successfully"]);

        return RedirectToAction(nameof(Index), new { productId });
    }

    [HttpPost]
    [Route(nameof(UnlinkOption))]
    public async Task<IActionResult> UnlinkOption(string productId, string optionId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        await productOptionWorkflow.UnlinkSharedOption(productId, optionId);

        await notifier.SuccessAsync(_h["Product option deleted successfully"]);

        return RedirectToAction(nameof(Index), new { productId });
    }

    [Route(nameof(CreateChoice))]
    public async Task<IActionResult> CreateChoice(string productId, string optionId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();
        
        var model = new PrivateOptionChoiceVm
        {
            ProductId = productId,
            Choice = new OptionChoiceModel { OptionId = optionId }
        };

        return View(model);
    }

    [HttpPost]
    [Route(nameof(CreateChoice))]
    public async Task<IActionResult> CreateChoice(PrivateOptionChoiceVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();
        
        if (ModelState.IsValid)
        {
            await productOptionsUseCases.CreatePrivateChoice(model.ProductId, model.Choice);

            await notifier.SuccessAsync(_h["Option choice created successfully"]);

            return RedirectToAction(nameof(Edit), new { model.ProductId, model.Choice.OptionId });
        }

        return View(model);
    }

    [Route(nameof(EditChoice))]
    public async Task<IActionResult> EditChoice(string productId, string optionId, string choiceId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        var model = await productOptionsVmBuilder.BuildEditChoiceModel(productId, optionId, choiceId);

        return View(model);
    }

    [HttpPost]
    [Route(nameof(EditChoice))]
    public async Task<IActionResult> EditChoice(PrivateOptionChoiceVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();
        
        if (ModelState.IsValid)
        {
            await productOptionsUseCases.UpdatePrivateChoice(model.ProductId, model.Choice);

            await notifier.SuccessAsync(_h["Option choice updated successfully"]);

            return RedirectToAction(nameof(Edit), new { model.ProductId, model.Choice.OptionId });
        }

        return View(model);
    }

    [HttpPost]
    [Route(nameof(DeleteChoice))]
    public async Task<IActionResult> DeleteChoice(string productId, string optionId, string choiceId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageProducts))
            return Forbid();

        await productOptionWorkflow.DeletePrivateChoice(productId, optionId, choiceId);

        await notifier.SuccessAsync(_h["Option choice deleted successfully"]);

        return RedirectToAction(nameof(Edit), new { productId, optionId });
    }
}