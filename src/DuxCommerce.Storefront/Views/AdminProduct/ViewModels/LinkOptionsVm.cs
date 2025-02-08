using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.Storefront.Views.AdminProduct.ViewModels;

public class LinkOptionsVm
{
    public ProductRow Product { get; set; }
    public IEnumerable<OptionRow> Options { get; set; }
}