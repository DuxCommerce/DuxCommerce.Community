using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.Storefront.Views.SharedOption.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Shared.ViewModels;

public class SharedOptionVm
{
    public OptionLinks Links { get; set; }
    public OptionModel Option { get; set; }
    public IEnumerable<ChoiceRow> Choices { get; set; }
    public IEnumerable<SelectListItem> DisplayTypes { get; set; }
}