using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;
using DuxCommerce.StoreBuilder.Taxes.Requests;

namespace DuxCommerce.Storefront.Views.TaxZone.ViewModels;

public class TaxRateVm
{
    public string ZoneId { get; set; }
    public TaxRateModel RateModel { get; set; }
    public IEnumerable<TaxCodeRow> TaxCodes { get; set; }
    public BreadCrumbs BreadCrumbs { get; set; }
}