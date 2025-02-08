using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.Storefront.Views.Product.ViewModels;

public class ProductOptionsVm
{
    public IEnumerable<OptionRow> Options { get; set; }
}