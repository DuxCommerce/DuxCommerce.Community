using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.SharedOption.ViewModels;

public class LinkedProductsVm
{
    public IEnumerable<ContentItem> Products { get; set; } = new List<ContentItem>();
    [BindNever] public dynamic Pager { get; set; }
}