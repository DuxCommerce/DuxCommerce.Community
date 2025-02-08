using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.Dto;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Category.ViewModels;

public class ProductsVm
{
    public IEnumerable<ProductSummary> Products { get; set; }
    public IDictionary<string, ContentItem> ProductMap { get; set; }
    public CurrencyRow Currency { get; set; }
}