using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Currency.ViewModels;

public class CurrencyVm
{
    public CurrencyModel CurrencyModel { get; set; }
    public IEnumerable<SelectListItem> Locales { get; set; }
}