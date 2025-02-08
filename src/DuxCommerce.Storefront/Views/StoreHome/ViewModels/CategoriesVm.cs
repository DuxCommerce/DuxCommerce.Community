using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.StoreHome.ViewModels;

public class CategoriesVm
{
    public IEnumerable<CategoryRow> Categories { get; set; }
    public IDictionary<string, ContentItem> CategoryMap { get; set; }
}