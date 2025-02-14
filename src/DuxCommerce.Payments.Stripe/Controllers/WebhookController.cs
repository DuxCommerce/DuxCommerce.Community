using System.IO;
using System.Threading.Tasks;
using DuxCommerce.OrchardCore;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using DuxCommerce.StoreBuilder.Orders.Requests;
using DuxCommerce.StoreBuilder.Orders.SimpleTypes;
using DuxCommerce.StoreBuilder.Orders.UseCases;
using DuxCommerce.StoreBuilder.ErrorTypes;
using DuxCommerce.Payments.Stripe.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stripe;

namespace DuxCommerce.Payments.Stripe.Controllers;

[Route("Stripe")]
[ApiController]
[Authorize(AuthenticationSchemes = "Api"), IgnoreAntiforgeryToken, AllowAnonymous]
public class WebhookController(
    ILogger<WebhookController> logger,
    StripeSettingsUseCases settingsUseCases,
    OrderUseCases orderUseCases)
    : Controller
{
    [HttpPost(nameof(Webhook))]
    public async Task<IActionResult> Webhook()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
        var settings = await settingsUseCases.GetSettings();

        var stripeEvent =
            EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], settings.WebhookSecret);

        if (stripeEvent.Type is not (Events.PaymentIntentSucceeded or Events.PaymentIntentPaymentFailed))
            return Ok();

        var updateResult = await UpdatePaymentStatus(stripeEvent);

        if (updateResult.Succeeded)
            return Ok();

        logger.LogWarning(updateResult.Error.ToMessage());


        return Problem();
    }

    private async Task<DuxResult<OrderRow>> UpdatePaymentStatus(Event stripeEvent)
    {
        var intent = stripeEvent.Data.Object as PaymentIntent;

        var status = stripeEvent.Type == Events.PaymentIntentSucceeded
            ? PaymentStatus.Paid
            : PaymentStatus.Failed;

        var request = new PaymentStatusModel
        {
            PaymentReference = intent?.Id,
            PaymentStatus = status
        };

        return await orderUseCases.UpdatePayment(request);
    }
}