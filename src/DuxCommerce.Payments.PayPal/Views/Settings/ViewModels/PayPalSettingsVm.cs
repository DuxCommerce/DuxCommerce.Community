using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Payments.PayPal.Views.Settings.ViewModels;

public class PayPalSettingsVm
{
    public PayPalSettingsModel SettingsModel { get; set; }
    public IEnumerable<CountryRow> Countries { get; set; }
}