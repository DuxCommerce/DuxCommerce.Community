using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Shared.ViewModels;

public class AddressVm
{
    public AddressRow Address { get; set; }
    public IEnumerable<SelectListItem> Countries { get; set; }
    public IEnumerable<SelectListItem> States { get; set; }
    public string Suffix { get; set; }
}