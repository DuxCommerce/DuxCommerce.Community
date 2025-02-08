using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Carts.DataTypes;
using DuxCommerce.StoreBuilder.Carts.UseCases;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.ErrorCodes;
using DuxCommerce.StoreBuilder.ErrorTypes;
using DuxCommerce.Payments.PayPal.Models;
using Microsoft.Extensions.Logging;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;

namespace DuxCommerce.Payments.PayPal.Services;

public class PayPalPaymentAdapter(
    PayPalSettingsUseCases settingsUseCases,
    IStateStore stateStore,
    CartUseCases cartUseCases,
    ILogger<PayPalPaymentAdapter> logger)
{
    private static readonly List<string> ZeroDecimalCurrencies = new() { "HUF", "JPY", "TWD" };

    public async Task<FlexiResult<Order>> CreateOrder(ShopperInfo shopperInfo)
    {
        try
        {
            var cart = await cartUseCases.GetCart(shopperInfo);
            var request = await ToOrdersCreateRequest(shopperInfo.Email, cart);

            var settings = await settingsUseCases.GetSettings();
            var httpClient = new PayPalHttpClient(ToEnvironment(settings));

            var response = await httpClient.Execute(request);
            var order = response.Result<Order>();

            return new FlexiResult<Order>(order);
        }
        catch (Exception ex)
        {
            var message = $"An error occurred when trying to create a PayPal order for shopper '{shopperInfo.UserId}'";

            logger.LogError(ex, message);

            var error = new FlexiError(ErrorCode.ErrorOccurredCallingExternalService, Fields.CustomMessage, message);

            return new FlexiResult<Order>(error);
        }
    }

    public async Task<FlexiResult<Order>> CaptureOrder(string orderId)
    {
        try
        {
            var request = new OrdersCaptureRequest(orderId);
            request.Prefer("return=representation");
            request.RequestBody(new OrderActionRequest());

            var settings = await settingsUseCases.GetSettings();
            var httpClient = new PayPalHttpClient(ToEnvironment(settings));

            var response = await httpClient.Execute(request);
            var order = response.Result<Order>();

            return new FlexiResult<Order>(order);
        }
        catch (Exception ex)
        {
            var message = $"An error occurred when trying to capture a PayPal order '{orderId}'";

            logger.LogError(ex, message);

            var error = new FlexiError(ErrorCode.ErrorOccurredCallingExternalService, Fields.CustomMessage, message);

            return new FlexiResult<Order>(error);
        }
    }

    private async Task<OrdersCreateRequest> ToOrdersCreateRequest(string shopperEmail, CartRow cart)
    {
        var request = new OrdersCreateRequest();

        request.Headers.Add("prefer", "return=representation");

        var orderRequest = await CreateOrderRequest(shopperEmail, cart);

        request.RequestBody(orderRequest);

        return request;
    }

    private async Task<OrderRequest> CreateOrderRequest(string shopperEmail, CartRow cart)
    {
        var billingState = await stateStore.Get(cart.BillingAddress.StateId);
        var shippingState = billingState;

        if (!cart.SameAsBillingAddress)
            shippingState = await stateStore.Get(cart.ShippingAddress.StateId);

        return ToOrderRequest(shopperEmail, cart, billingState, shippingState);
    }

    private static OrderRequest ToOrderRequest(string shopperEmail, CartRow cart, StateRow billingState, StateRow shippingState)
    {
        var cartTotal = Math.Round(cart.CartTotal, 2);

        // Note: some currencies don't support decimals: https://developer.paypal.com/reference/currency-codes
        var format = ZeroDecimalCurrencies.Contains(cart.PaymentCurrency) ? "0" : "0.00";

        var purchaseUnit = new PurchaseUnitRequest
        {
            AmountWithBreakdown = new AmountWithBreakdown
            {
                CurrencyCode = cart.PaymentCurrency,
                Value = cartTotal.ToString(format, CultureInfo.InvariantCulture)
            },
            ShippingDetail = CreateShippingDetails(cart, shippingState)
        };

        return new OrderRequest
        {
            ApplicationContext = new ApplicationContext
            {
                ShippingPreference = "SET_PROVIDED_ADDRESS"
            },
            CheckoutPaymentIntent = "CAPTURE",
            Payer = CreatePayer(shopperEmail, cart, billingState),
            PurchaseUnits = new List<PurchaseUnitRequest>
            {
                purchaseUnit
            }
        };
    }

    private static Payer CreatePayer(string shopperEmail, CartRow cart, StateRow billingState)
    {
        // Todo: check the length of different fields

        var billingAddress = cart.BillingAddress;

        return new Payer
        {
            Name = new Name { GivenName = billingAddress.FirstName, Surname = billingAddress.LastName },
            Email = shopperEmail,
            AddressPortable = new AddressPortable
            {
                AddressLine1 = billingAddress.AddressLine1,
                AddressLine2 = billingAddress.AddressLine2,
                AdminArea2 = billingAddress.City,
                AdminArea1 = billingState.Code,
                CountryCode = billingAddress.CountryCode,
                PostalCode = billingAddress.PostalCode
            }
        };
    }

    private static ShippingDetail CreateShippingDetails(CartRow cart, StateRow shippingState)
    {
        // Todo: check the length of different fields

        var shippingAddress = cart.ShippingAddress;

        return new ShippingDetail
        {
            AddressPortable = new AddressPortable
            {
                AddressLine1 = shippingAddress.AddressLine1,
                AddressLine2 = shippingAddress.AddressLine2,
                AdminArea2 = shippingAddress.City,
                AdminArea1 = shippingState.Code,
                CountryCode = shippingAddress.CountryCode,
                PostalCode = shippingAddress.PostalCode
            }
        };
    }

    private static PayPalEnvironment ToEnvironment(PayPalSettings settings)
    {
        return settings.IsTestMode
            ? new SandboxEnvironment(settings.ClientId, settings.Secret)
            : new LiveEnvironment(settings.ClientId, settings.Secret);
    }
}