using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Payments.PayPal.Models;

public class PayPalSettingsPart : DuxPart<PayPalSettingsRow>
{
    public sealed override PayPalSettingsRow Row { get; set; } = new PayPalSettingsRow();
}