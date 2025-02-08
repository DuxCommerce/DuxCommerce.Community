using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;

namespace DuxCommerce.Storefront.Views.TaxZone.ViewModels;

public class TaxRatesVm
{
    public string ZoneId { get; set; }
    public IEnumerable<TaxRateRow> TaxRates { get; set; }
    public IEnumerable<TaxCodeRow> TaxCodes { get; set; }
    public TaxZoneLinks Links { get; set; }
}