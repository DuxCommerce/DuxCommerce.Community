using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Storefront.Views.AdminCountry.ViewModels;

public class CountryIndexVm
{
    public IEnumerable<CountryRow> Countries { get; set; }
}