using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Inventory.ViewModels;

public class EditInventoryVm
{
    public InventoryModel Inventory { get; set; }
    public IEnumerable<SelectListItem> Events { get; set; }
}