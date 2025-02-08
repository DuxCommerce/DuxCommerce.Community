using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Customers;
using DuxCommerce.StoreBuilder.Customers.DataStores;
using DuxCommerce.StoreBuilder.Customers.UseCases;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.Shared.VmBuilders;
using DuxCommerce.Storefront.Views.YourAddresses.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.DisplayManagement.Notify;

namespace DuxCommerce.Storefront.Controllers;

[Authorize]
[Route("YourAddresses")]
public class YourAddressesController(
    IShopperInfoProvider shopperInfoProvider,
    CustomerAddressVmBuilder addressVmBuilder,
    CustomerVmBuilder customerVmBuilder,
    CustomerUseCases customerUseCases,
    ICustomerStore customerStore,
    INotifier notifier,
    IHtmlLocalizer<YourAddressesController> h)
    : Controller
{
    private readonly IHtmlLocalizer _h = h;


    [Route(nameof(Index))]
    public async Task<IActionResult> Index()
    {
        var shopperInfo = shopperInfoProvider.Get();

        var model = await customerVmBuilder.BuildModel(shopperInfo);

        return View(model);
    }

    [Route(nameof(EditAddress))]
    public async Task<IActionResult> EditAddress(string customerId, string addressId)
    {
        if (!await VerifyUserIdentity(customerId))
            return Unauthorized();

        var viewModel = await addressVmBuilder.BuildEditModel(customerId, addressId);

        return View(viewModel);
    }

    [HttpPost]
    [Route(nameof(EditAddress))]
    public async Task<IActionResult> EditAddress(string customerId, CustomerAddressVm model)
    {
        if (!await VerifyUserIdentity(customerId))
            return Unauthorized();

        if (!ModelState.IsValid)
        {
            var vm = await addressVmBuilder.BuildEditModel(customerId, model);
            return View(vm);
        }

        await customerUseCases.UpdateAddress(customerId, model.AddressVm.Address);

        await notifier.SuccessAsync(_h["Address updated successfully"]);

        return RedirectToAction(nameof(Index), new { customerId });
    }

    [HttpPost]
    [Route(nameof(DeleteAddress))]
    public async Task<IActionResult> DeleteAddress(string customerId, string addressId)
    {
        var shopperInfo = shopperInfoProvider.Get();
        var customer = await customerStore.GetByUserId(shopperInfo.UserId);

        if (customer.Id != customerId)
            return Unauthorized();

        await customerUseCases.DeleteAddress(customer, addressId);

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> VerifyUserIdentity(string customerId)
    {
        var shopperInfo = shopperInfoProvider.Get();
        var customer = await customerStore.GetByUserId(shopperInfo.UserId);

        return customer.Id == customerId;
    }
}