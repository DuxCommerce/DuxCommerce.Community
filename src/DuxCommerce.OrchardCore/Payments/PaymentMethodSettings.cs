using System.ComponentModel.DataAnnotations;

namespace DuxCommerce.OrchardCore.Payments;

public class PaymentMethodSettings
{
    [Required] public string MethodType { get; set; }

    [Required] public string DisplayName { get; set; }

    public string Instructions { get; set; }

    [Required] public int DisplayOrder { get; set; }

    [Required] public IEnumerable<string> AvailableCountries { get; set; }
}