using System.Collections.Generic;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Category.ViewModels;

public class BreadCrumbsVm
{
    public string CategoryId { get; set; }
    public IEnumerable<ContentItem> CategoryItems { get; set; }
}