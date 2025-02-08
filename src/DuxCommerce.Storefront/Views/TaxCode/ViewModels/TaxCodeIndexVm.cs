using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;

namespace DuxCommerce.Storefront.Views.TaxCode.ViewModels;

public class TaxCodeIndexVm
{
    public IEnumerable<TaxCodeRow> TaxCodes { get; set; }
    public IEnumerable<string> UsedTaxCodeIds { get; set; }
}