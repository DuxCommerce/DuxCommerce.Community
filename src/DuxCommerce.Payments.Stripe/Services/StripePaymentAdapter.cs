using System;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.StoreBuilder.ErrorCodes;
using DuxCommerce.StoreBuilder.ErrorTypes;
using Microsoft.Extensions.Logging;
using Stripe;

namespace DuxCommerce.Payments.Stripe.Services;

public class StripePaymentIntent(string clientSecret, string paymentIntentId)
{
    public string ClientSecret { get; } = clientSecret;
    public string PaymentIntentId { get; } = paymentIntentId;
}

public class StripePaymentAdapter(
    ILogger<StripePaymentAdapter> logger,
    CartUseCases cartUseCases,
    PaymentIntentService intentService,
    StripeSettingsUseCases settingsUseCases)
{
    public async Task<FlexiResult<StripePaymentIntent>> InitPayment(ShopperInfo shopperInfo)
    {
        try
        {
            var cart = await cartUseCases.GetCart(shopperInfo);
            var amount = StripeAmount.Convert(cart.CartTotal, cart.PaymentCurrency);

            PaymentIntent paymentIntent;

            if (string.IsNullOrEmpty(cart.PaymentReference))
                paymentIntent = await CreatePaymentIntent(amount, cart.PaymentCurrency);
            else
                paymentIntent = await UpdatePaymentIntent(cart.PaymentReference, amount, cart.PaymentCurrency);

            var intent = new StripePaymentIntent(paymentIntent.ClientSecret, paymentIntent.Id);

            return new FlexiResult<StripePaymentIntent>(intent);
        }
        catch (Exception ex)
        {
            var message = $"An error occurred when trying to create or update payment intent for shopper '{shopperInfo.UserId}'";

            logger.LogError(ex, message);

            var error = new FlexiError(ErrorCode.ErrorOccurredCallingExternalService, Fields.CustomMessage, message);

            return new FlexiResult<StripePaymentIntent>(error);
        }
    }

    private async Task<PaymentIntent> CreatePaymentIntent(long amount, string currency)
    {
        var settings = await settingsUseCases.GetSettings();

        var requestOptions = new RequestOptions { ApiKey = settings.SecretKey };

        var createOptions = new PaymentIntentCreateOptions
        {
            Amount = amount,
            Currency = currency,
            AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
            {
                Enabled = true
            }
        };

        return await intentService.CreateAsync(createOptions, requestOptions);
    }

    private async Task<PaymentIntent> UpdatePaymentIntent(string intentId, long amount, string currency)
    {
        var settings = await settingsUseCases.GetSettings();

        var requestOptions = new RequestOptions { ApiKey = settings.SecretKey };

        var updateOption = new PaymentIntentUpdateOptions
        {
            Amount = amount,
            Currency = currency
        };

        return await intentService.UpdateAsync(intentId, updateOption, requestOptions);
    }
}