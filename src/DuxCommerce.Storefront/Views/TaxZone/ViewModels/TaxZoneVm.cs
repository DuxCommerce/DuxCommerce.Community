using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Taxes.DomainTypes;
using DuxCommerce.StoreBuilder.Taxes.Requests;

namespace DuxCommerce.Storefront.Views.TaxZone.ViewModels;

public class TaxZoneVm
{
    public TaxZoneModel ZoneModel { get; set; } = new()
    {
        Type = nameof(CountryZone),
        PricesDisplayOption = nameof(PriceDisplayOption.ShowPriceExcTax),
        Countries = new List<string>(),
        States = new List<string>()
    };

    public IEnumerable<TaxZoneTypeVm> ZoneTypes { get; set; }
    public IEnumerable<CountryRow> Countries { get; set; }
    public IDictionary<string, List<StateRow>> States { get; set; }
    public TaxZoneLinks Links { get; set; }
}