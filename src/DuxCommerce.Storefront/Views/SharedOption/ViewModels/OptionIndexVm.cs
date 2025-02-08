using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;

namespace DuxCommerce.Storefront.Views.SharedOption.ViewModels;

public class OptionIndexVm
{
    public IEnumerable<OptionRow> Options { get; set; }
}