using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Category.ViewModels;

public class SortOptionsVm
{
    public bool ProductExists { get; set; }
    public string SortOption { get; set; }
    public IEnumerable<SelectListItem> SortOptions { get; set; }
    public string PageLink { get; set; }
}

public class SortOption
{
    public string Option { get; set; }
    public string Name { get; set; }
}