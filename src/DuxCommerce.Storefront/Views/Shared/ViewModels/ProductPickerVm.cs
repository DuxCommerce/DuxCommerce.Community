using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Shared.ViewModels;

public class ProductPickerVm
{
    public IEnumerable<ContentItem> Products { get; set; } = new List<ContentItem>();
    public CurrencyRow Currency { get; set; }
    [BindNever] public dynamic Pager { get; set; }
}