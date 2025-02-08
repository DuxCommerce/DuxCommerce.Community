using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.TaxProfile.ViewModels;

public class TaxProfileVm
{
    public TaxProfileModel ProfileModel { get; set; }

    public IEnumerable<SelectListItem> TaxCalculationTypes { get; set; }
    public IEnumerable<SelectListItem> Countries { get; set; }
    public IEnumerable<SelectListItem> States { get; set; }
}