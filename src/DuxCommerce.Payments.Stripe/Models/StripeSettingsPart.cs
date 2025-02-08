using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Payments.Stripe.Models;

public class StripeSettingsPart : DuxPart<StripeSettingsRow>
{
    public sealed override StripeSettingsRow Row { get; set; } = new StripeSettingsRow();
}