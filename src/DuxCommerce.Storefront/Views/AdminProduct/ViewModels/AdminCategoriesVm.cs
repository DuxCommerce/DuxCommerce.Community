using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.Storefront.Views.AdminProduct.ViewModels;

public class AdminCategoriesVm
{
    public IEnumerable<CategoryRow> Parents { get; set; }
    public IDictionary<string, IEnumerable<CategoryRow>> ChildMap { get; set; }
}