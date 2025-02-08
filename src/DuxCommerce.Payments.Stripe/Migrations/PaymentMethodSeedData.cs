using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Payments.DataTypes;

namespace DuxCommerce.Payments.Stripe.Migrations;
public static class PaymentMethodSeedData
{
    public static IEnumerable<PaymentMethodRow> GetMethods()
    {
        return new List<PaymentMethodRow>
        {
            new()
            {
                DisplayName = "Stripe", 
                MethodType = nameof(StripePaymentMethod),
                SetupController = "Stripe",
                SetupAction = "Setup"
            }
        };
    }
}