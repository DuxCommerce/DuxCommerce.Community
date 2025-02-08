using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.AdminProduct.ViewModels;

public class ProductIndexVm
{
    public ProductSearchVm ProductSearch { get; set; }
    public IEnumerable<ContentItem> Products { get; set; } = new List<ContentItem>();
    public CurrencyRow Currency { get; set; }
    [BindNever] public dynamic Pager { get; set; }
}