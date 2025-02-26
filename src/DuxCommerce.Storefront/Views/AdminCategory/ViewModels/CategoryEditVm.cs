using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.AdminCategory.ViewModels;

public class CategoryEditVm
{
    public CategoryModel Category { get; set; } = new();
    public IEnumerable<SelectListItem> CategoryItems { get; set; } = new List<SelectListItem>();
}