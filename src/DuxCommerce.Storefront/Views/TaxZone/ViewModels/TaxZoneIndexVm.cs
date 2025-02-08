using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;

namespace DuxCommerce.Storefront.Views.TaxZone.ViewModels;

public class TaxZoneIndexVm
{
    public IEnumerable<TaxZoneRow> Zones { get; set; }
}