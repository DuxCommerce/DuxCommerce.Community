using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.StoreHome.ViewModels;

public class CategoryMenuVm
{
    public IEnumerable<CategoryRow> Parents { get; set; }
    public IDictionary<string, IEnumerable<CategoryRow>> ChildMap { get; set; }
    public IDictionary<string, ContentItem> CategoryMap { get; set; }
}