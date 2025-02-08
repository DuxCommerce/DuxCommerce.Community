using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Shared.ViewModels;

public class ProductSearchVm
{
    public string ProductName { get; set; }
    public string SelectedCategoryId { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; }
}