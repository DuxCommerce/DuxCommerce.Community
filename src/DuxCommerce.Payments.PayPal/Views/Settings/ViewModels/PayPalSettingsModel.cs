using System.ComponentModel.DataAnnotations;
using DuxCommerce.OrchardCore.Payments;

namespace DuxCommerce.Payments.PayPal.Views.Settings.ViewModels;

public class PayPalSettingsModel : PaymentMethodSettings
{
    [Required] public bool IsTestMode { get; set; }

    [Required] public string ClientId { get; set; }

    [Required] public string Secret { get; set; }
}