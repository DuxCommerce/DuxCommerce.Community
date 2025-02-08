namespace DuxCommerce.Payments.PayPal.Models;

public class PayPalSettings
{
    public bool IsTestMode { get; set; }
    public string ClientId { get; set; }
    public string Secret { get; set; }    
}