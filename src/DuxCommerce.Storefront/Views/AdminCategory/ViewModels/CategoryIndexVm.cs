using System.Collections.Generic;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.AdminCategory.ViewModels;

public class CategoryIndexVm
{
    public IEnumerable<CategoryTrail> CategoryTrails { get; set; }
    public IDictionary<string, ContentItem> CategoryMap { get; set; }
}