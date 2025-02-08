using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Checkout;
using DuxCommerce.OrchardCore.Customers;
using DuxCommerce.StoreBuilder.Orders.DataStores;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.YourOrders.ViewModels;
using DuxCommerce.Storefront.Views.YourOrders.VmBuilders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DuxCommerce.Storefront.Controllers;

[Authorize]
[Route("YourOrders")]
public class YourOrdersController(
    YourOrdersVmBuilder yourOrdersVmBuilder,
    OrderVmBuilder orderVmBuilder,
    IOrderStore orderStore,
    IShopperInfoProvider shopperInfoProvider)
    : Controller
{
    [Route(nameof(Index))]
    public async Task<IActionResult> Index()
    {
        var shopperInfo = shopperInfoProvider.Get();

        var model = await yourOrdersVmBuilder.BuildIndexModel(shopperInfo);

        return View(model);
    }

    [Route(nameof(Details))]
    public async Task<IActionResult> Details(string orderId)
    {
        var order = await orderStore.Get(orderId);
        var shopperInfo = shopperInfoProvider.Get();

        if (order.UserId != shopperInfo.UserId)
            return Unauthorized();

        var orderVm = await orderVmBuilder.BuildCustomerOrder(order);

        var vm = new YourOrderVm { OrderVm = orderVm, AccountLinks = new AccountLinksVm { Orders = true } };

        return View(vm);
    }
}