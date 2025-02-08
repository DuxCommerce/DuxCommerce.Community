using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.AdminCategory.ViewModels;

public class CategoryLinksVm
{
    public ContentItem ContentItem { get; set; }
    public bool EditLink { get; set; }
    public bool ProductsLink { get; set; }
}