using System.Collections.Generic;
using System.Linq;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Extensions;

public static class AddressExtensions
{
    public static IEnumerable<SelectListItem> ToListItems(this IEnumerable<AddressRow> addresses,
        IEnumerable<CountryRow> countries, IEnumerable<StateRow> states)
    {
        var countryMap = countries.ToDictionary(x => x.TwoLetterCode);
        var stateMap = states.ToDictionary(x => x.Id);

        var listItems = addresses.Select(x =>
        {
            var address = x.FirstName + " " + x.LastName;

            address += ", " + x.AddressLine1;

            if (!string.IsNullOrEmpty(x.AddressLine2))
                address += ", " + x.AddressLine2;

            if (!string.IsNullOrEmpty(x.City))
                address += ", " + x.City;

            address += ", " + stateMap[x.StateId].Name;

            if (!string.IsNullOrEmpty(x.PostalCode))
                address += " " + x.PostalCode;

            address += ", " + countryMap[x.CountryCode].Name;

            return new SelectListItem(address, x.Id);
        }).ToList();

        listItems.Add(new SelectListItem("Add new address", string.Empty));

        return listItems;
    }
}