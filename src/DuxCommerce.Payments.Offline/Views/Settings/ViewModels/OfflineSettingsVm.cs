using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DuxCommerce.OrchardCore.Payments;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Payments.Offline.Views.Settings.ViewModels;

public class OfflineSettingsVm
{
    [Required]
    public PaymentMethodSettings Settings { get; set; }
    public IEnumerable<CountryRow> Countries { get; set; }
}