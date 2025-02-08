using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Settings.Requests;

namespace DuxCommerce.Storefront.Views.AdminCountry.ViewModels;

public class CountryVm
{
    public CountryModel CountryModel { get; set; } = new();
    public IEnumerable<StateRow> States { get; set; } = new List<StateRow>();
}