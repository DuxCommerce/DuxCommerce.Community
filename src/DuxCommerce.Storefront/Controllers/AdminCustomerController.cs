using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Customers.UseCases;
using DuxCommerce.Storefront.Views.AdminCustomer.ViewModels;
using DuxCommerce.Storefront.Views.AdminCustomer.VmBuilders;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.Shared.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Admin]
[Route("Admin/Customer")]
public class AdminCustomerController(
    IAuthorizationService authorizationService,
    CustomerUseCases customerUseCases,
    AdminCustomerVmBuilder adminCustomerVmBuilder,
    CustomerAddressVmBuilder addressVmBuilder,
    INotifier notifier,
    IHtmlLocalizer<AdminCustomerController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;

    [Route(nameof(Index))]
    public async Task<IActionResult> Index()
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCustomers))
            return Forbid();

        var customers = await adminCustomerVmBuilder.BuildIndexModel();

        return View(customers);
    }

    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string customerId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCustomers))
            return Forbid();

        var customer = await adminCustomerVmBuilder.BuildEditModel(customerId);

        return View(customer);
    }

    [HttpPost]
    [Route(nameof(Edit))]
    public async Task<IActionResult> Edit(string customerId, EditCustomerVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCustomers))
            return Forbid();

        if (!ModelState.IsValid)
            return View(adminCustomerVmBuilder.BuildEditModel(model));

        await customerUseCases.UpdateCustomer(model.CustomerModel);

        await notifier.SuccessAsync(_h["Customer updated successfully"]);

        return RedirectToAction(nameof(Edit), new { customerId });
    }

    [Route(nameof(Addresses))]
    public async Task<IActionResult> Addresses(string customerId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCustomers))
            return Forbid();

        var viewModel = await adminCustomerVmBuilder.BuildViewModel(customerId);

        return View(viewModel);
    }

    [Route(nameof(EditAddress))]
    public async Task<IActionResult> EditAddress(string customerId, string addressId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCustomers))
            return Forbid();

        var viewModel = await addressVmBuilder.BuildEditModel(customerId, addressId);

        return View(viewModel);
    }

    [HttpPost]
    [Route(nameof(EditAddress))]
    public async Task<IActionResult> EditAddress(string customerId, CustomerAddressVm model)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCustomers))
            return Forbid();

        if (!ModelState.IsValid)
        {
            var vm = await addressVmBuilder.BuildEditModel(customerId, model);
            return View(vm);
        }

        await customerUseCases.UpdateAddress(customerId, model.AddressVm.Address);

        await notifier.SuccessAsync(_h["Address updated successfully"]);

        return RedirectToAction(nameof(Addresses), new { customerId });
    }

    [HttpPost]
    [Route(nameof(DeleteAddress))]
    public async Task<IActionResult> DeleteAddress(string customerId, string addressId)
    {
        await customerUseCases.DeleteAddress(customerId, addressId);

        return RedirectToAction(nameof(Addresses), new { customerId });
    }

    [Route(nameof(Orders))]
    public async Task<IActionResult> Orders(string customerId)
    {
        if (!await authorizationService.AuthorizeAsync(User, PermissionProvider.ManageCustomers))
            return Forbid();

        var viewModel = await adminCustomerVmBuilder.BuildOrdersModel(customerId);

        return View(viewModel);
    }
}