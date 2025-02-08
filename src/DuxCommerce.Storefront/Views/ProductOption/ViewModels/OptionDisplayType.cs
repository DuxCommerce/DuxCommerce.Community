using System.Collections.Generic;
using System.Dynamic;
using DuxCommerce.StoreBuilder.Catalog.SimpleTypes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.ProductOption.ViewModels;

public class OptionDisplayType
{
    public static IEnumerable<SelectListItem> GetAll()
    {
        dynamic dropDownList = new ExpandoObject();

        dropDownList.Name = "Drop Down List";
        dropDownList.Type = nameof(DisplayType.DropDownList);

        dynamic radioButtonGroup = new ExpandoObject();

        radioButtonGroup.Name = "Radio Button Group";
        radioButtonGroup.Type = nameof(DisplayType.RadioButtonGroup);

        return new List<SelectListItem>
        {
            new SelectListItem(dropDownList.Name, dropDownList.Type),
            new SelectListItem(radioButtonGroup.Name, radioButtonGroup.Type)
        };
    }
}