using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Shared.VmBuilders;

public class AddressVmBuilder(StateUseCases stateUseCases)
{
    public async Task PopulateCountries(AddressVm addressVm, List<CountryRow> countries)
    {
        var countryCode = addressVm.Address?.CountryCode ?? countries.First().TwoLetterCode;
        var states = (await stateUseCases.GetStates(countryCode)).ToList();

        addressVm.Countries = countries.Select(x => new SelectListItem(x.Name, x.TwoLetterCode));
        addressVm.States = states.Select(x => new SelectListItem(x.Name, x.Id));

        addressVm.Address ??= new AddressRow();
    }
}