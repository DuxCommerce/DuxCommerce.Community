using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Payments.DataTypes;

namespace DuxCommerce.Payments.Stripe.Migrations;
public static class PaymentMethodSeedData
{
    private const string ModuleName = "DuxCommerce.Payments.Stripe";
    public static IEnumerable<PaymentMethodRow> GetMethods()
    {
        return new List<PaymentMethodRow>
        {
            new()
            {
                DisplayName = "Stripe", 
                MethodType = nameof(StripePaymentMethod),
                ModuleName = ModuleName
            }
        };
    }
}