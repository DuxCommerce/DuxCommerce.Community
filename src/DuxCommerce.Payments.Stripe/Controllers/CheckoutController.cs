using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Checkout.UseCases;
using DuxCommerce.OrchardCore.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DuxCommerce.Payments.Stripe.Controllers;

[Authorize]
[Route("Stripe")]
public class CheckoutController(
    ILogger<CheckoutController> logger,
    IShopperInfoProvider shopperInfoProvider,
    CheckoutUseCases checkoutUseCases)
    : Controller
{
    [HttpPost]
    [Route(nameof(CreateOrder))]
    public async Task<IActionResult> CreateOrder()
    {
        // Note: we use orderId to communicate to client if the order has been created successfully
        string orderId = null;

        var shopperInfo = shopperInfoProvider.Get();
        var orderResult = await checkoutUseCases.CreateOrderBeforePayment(shopperInfo);

        if (orderResult.Succeeded)
        {
            orderId = orderResult.Result.Id;
            await checkoutUseCases.SendOrderEmails(orderResult.Result);
        }
        else
            logger.LogWarning(orderResult.Error.ToMessage());

        return Ok(new { orderId });
    }
}