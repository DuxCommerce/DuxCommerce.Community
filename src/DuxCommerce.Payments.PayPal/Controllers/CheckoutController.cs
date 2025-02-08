using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Checkout.UseCases;
using DuxCommerce.StoreBuilder.Orders.DataStores;
using DuxCommerce.OrchardCore.Customers;
using DuxCommerce.Payments.PayPal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DuxCommerce.Payments.PayPal.Controllers;

[Authorize]
[Route("PayPal")]
public class CheckoutController(
    ILogger<CheckoutController> logger,
    IShopperInfoProvider shopperInfoProvider,
    PayPalPaymentUseCases paymentUseCases,
    CheckoutUseCases checkoutUseCases,
    IOrderStore orderStore)
    : Controller
{
    [HttpPost]
    [Route(nameof(CreatePayPalOrder))]
    public async Task<IActionResult> CreatePayPalOrder()
    {
        var shopperInfo = shopperInfoProvider.Get();
        var orderResult = await paymentUseCases.CreatePayPalOrder(shopperInfo);

        if (orderResult.Succeeded)
            return Ok(new { orderResult.Result.Id });

        logger.LogWarning(orderResult.Error.ToMessage(), shopperInfo);
        return Problem();
    }

    [HttpPost]
    [Route(nameof(CreateOrder))]
    public async Task<IActionResult> CreateOrder()
    {
        string orderId = null;

        var shopperInfo = shopperInfoProvider.Get();
        var orderResult = await checkoutUseCases.CreateOrderBeforePayment(shopperInfo);

        if (orderResult.Succeeded)
            orderId = orderResult.Result.Id;
        else
            logger.LogWarning(orderResult.Error.ToMessage(), shopperInfo);

        return Ok(new { orderId });
    }

    [HttpPost]
    [Route(nameof(ProcessPayment))]
    public async Task<IActionResult> ProcessPayment(string orderId)
    {
        string paymentId = null;

        var order = await orderStore.Get(orderId);
        var paymentResult = await checkoutUseCases.ProcessOrderPayment(order);

        if (paymentResult.Succeeded)
        {
            await checkoutUseCases.SendOrderEmails(order);
            paymentId = paymentResult.Result.PaymentReference;
        }
        else
            logger.LogWarning(paymentResult.Error.ToMessage());

        return Ok(new { paymentId });
    }
}