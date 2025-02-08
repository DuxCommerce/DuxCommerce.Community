using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Shared.ViewModels;

public class CheckoutAddressVm
{
    public IEnumerable<SelectListItem> Addresses { get; set; }
    public string AddressId { get; set; }
    public AddressVm AddressVm { get; set; }
}