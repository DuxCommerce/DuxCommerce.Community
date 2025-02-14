using System;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Orders.DataTypes;
using DuxCommerce.StoreBuilder.Orders.Requests;
using DuxCommerce.StoreBuilder.Orders.SimpleTypes;
using DuxCommerce.StoreBuilder.Orders.UseCases;
using DuxCommerce.StoreBuilder.Plugins;
using DuxCommerce.StoreBuilder.ErrorTypes;
using DuxCommerce.Payments.PayPal.Components;
using DuxCommerce.Payments.PayPal.Services;

namespace DuxCommerce.Payments.PayPal;

public class PayPalPaymentMethod(
    PayPalPaymentAdapter paymentAdapter,
    OrderUseCases orderUseCases)
    : IPaymentMethod
{
    public string MethodType => nameof(PayPalPaymentMethod);

    public Type CheckoutViewComponent => typeof(PayPalPaymentViewComponent);

    public async Task<DuxResult<PaymentResult>> ChargeAsync(IPaymentRequest request)
    {
        var order = await orderUseCases.GetOrder(request.OrderId);
        var paypalPayment = order.Payments.Single(x => x.PaymentMethodType == MethodType);

        // Capture PayPal order
        var captureResult = await paymentAdapter.CaptureOrder(paypalPayment.PaymentReference);
        
        if (!captureResult.Succeeded)
            return new DuxResult<PaymentResult>(captureResult.Error);

        // Update payment status
        var updateResult = await UpdatePaymentStatus(paypalPayment.PaymentReference);
        
        if (!updateResult.Succeeded)
            return new DuxResult<PaymentResult>(updateResult.Error);

        return new DuxResult<PaymentResult>(new PaymentResult(paypalPayment.PaymentReference));
    }

    private async Task<DuxResult<OrderRow>> UpdatePaymentStatus(string paymentReference)
    {
        var request = new PaymentStatusModel
        {
            PaymentReference = paymentReference,
            PaymentStatus = PaymentStatus.Paid
        };

        return await orderUseCases.UpdatePayment(request);
    }
}