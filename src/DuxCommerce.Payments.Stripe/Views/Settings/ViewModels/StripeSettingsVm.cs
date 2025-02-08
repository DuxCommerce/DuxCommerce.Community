using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Payments.Stripe.Views.Settings.ViewModels;

public class StripeSettingsVm
{
    public StripeSettingsModel Settings { get; set; }
    public IEnumerable<CountryRow> Countries { get; set; }
}