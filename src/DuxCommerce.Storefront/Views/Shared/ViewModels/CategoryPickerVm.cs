using System.Collections.Generic;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Shared.ViewModels;

public class CategoryTrail
{
    public string CategoryId { get; set; }
    public string FriendlyName { get; set; }
    public int SortOrder { get; set; }
}

public class CategoryPickerVm
{
    public IEnumerable<CategoryTrail> CategoryTrails { get; set; }
    public IDictionary<string, ContentItem> CategoryMap { get; set; }
    public List<string> IdsExcluded { get; set; }
}