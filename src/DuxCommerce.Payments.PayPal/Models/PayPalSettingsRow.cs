using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Payments.PayPal.Models;

public class PayPalSettingsRow : IRow
{
    public string Id { get; set; }
    public bool IsTestMode { get; set; }
    public string ClientId { get; set; }
    public string Secret { get; set; }
}