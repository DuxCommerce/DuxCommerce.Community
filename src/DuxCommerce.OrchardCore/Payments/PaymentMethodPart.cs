using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Payments.DataTypes;

namespace DuxCommerce.OrchardCore.Payments;

public class PaymentMethodPart : DuxPart<PaymentMethodRow>
{
    public sealed override PaymentMethodRow Row { get; set; } = new();
}