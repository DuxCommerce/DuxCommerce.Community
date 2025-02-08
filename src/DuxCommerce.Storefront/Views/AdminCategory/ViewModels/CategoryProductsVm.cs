using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.AdminCategory.ViewModels;

public class CategoryProductsVm
{
    public CategoryRow Category { get; set; }
    public IEnumerable<ContentItem> Products { get; set; } = new List<ContentItem>();
    public CurrencyRow Currency { get; set; }

    [BindNever] public dynamic Pager { get; set; }
    public CategoryLinksVm Links { get; set; }
}