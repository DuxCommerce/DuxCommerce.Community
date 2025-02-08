using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;

namespace DuxCommerce.Storefront.Views.Inventory.ViewModels;

public class InventoryIndexVm
{
    public ProductSearchVm ProductSearch { get; set; }
    public List<InventoryModel> Inventories { get; set; }
    public IDictionary<string, ContentItem> ProductMap { get; set; }
    [BindNever] public dynamic Pager { get; set; }
}