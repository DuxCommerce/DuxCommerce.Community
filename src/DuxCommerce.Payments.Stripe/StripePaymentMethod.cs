using System;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Plugins;
using DuxCommerce.StoreBuilder.ErrorTypes;
using DuxCommerce.Payments.Stripe.Components;

namespace DuxCommerce.Payments.Stripe;

public class StripePaymentMethod : IPaymentMethod
{
    public string MethodType => nameof(StripePaymentMethod);
    public Type CheckoutViewComponent => typeof(StripePaymentViewComponent);
    public async Task<DuxResult<PaymentResult>> ChargeAsync(IPaymentRequest request)
    {
        return new DuxResult<PaymentResult>(new PaymentResult());
    }
}