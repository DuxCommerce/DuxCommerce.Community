using System;
using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.AdminProduct.ViewModels;

public class ProductEditVm
{
    public ProductModel Product { get; set; } = new() { CategoryIds = [] };
    public IEnumerable<SelectListItem> TaxCodes { get; set; }
    public IEnumerable<SelectListItem> CategoryItems { get; set; }
    public ProductLinksVm Links { get; set; }
}