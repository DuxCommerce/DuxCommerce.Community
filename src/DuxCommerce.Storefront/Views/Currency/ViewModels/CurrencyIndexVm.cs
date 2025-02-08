using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Storefront.Views.Currency.ViewModels;

public class CurrencyIndexVm
{
    public IEnumerable<CurrencyRow> Currencies { get; set; }
}