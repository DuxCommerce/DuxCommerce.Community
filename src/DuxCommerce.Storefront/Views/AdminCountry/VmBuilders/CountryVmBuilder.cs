using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Settings.Requests;
using DuxCommerce.Storefront.Views.AdminCountry.ViewModels;

namespace DuxCommerce.Storefront.Views.AdminCountry.VmBuilders;

public class CountryVmBuilder(
    ICountryStore countryStore,
    IStateStore stateStore)
{
    public async Task<CountryIndexVm> BuildIndexModel()
    {
        var countries = (await countryStore.GetAll())
            .OrderBy(x => x.DisplayOrder)
            .ThenBy(x => x.Name);

        return new CountryIndexVm { Countries = countries };
    }

    public async Task<CountryVm> BuildEditModel(string countryId)
    {
        var countryRow = await countryStore.Get(countryId);
        var states = await stateStore.GetStates(countryRow.TwoLetterCode);

        var model = ToCountryModel(countryRow);

        return new CountryVm { CountryModel = model, States = states };
    }

    public async Task<StateVm> BuildCreateStateModel(string countryId)
    {
        var country = await countryStore.Get(countryId);

        var model = new StateModel { CountryCode = country.TwoLetterCode };

        return new StateVm { CountryId = countryId, StateModel = model };
    }

    public async Task<StateVm> BuildEditStateModel(string countryId, string stateId)
    {
        var stateRow = await stateStore.Get(stateId);

        var model = ToStateModel(stateRow);

        return new StateVm { CountryId = countryId, StateModel = model };
    }

    private CountryModel ToCountryModel(CountryRow countryRow)
    {
        return new CountryModel
        {
            Id = countryRow.Id,
            Name = countryRow.Name,
            TwoLetterCode = countryRow.TwoLetterCode,
            ThreeLetterCode = countryRow.ThreeLetterCode,
            NumericCode = countryRow.NumericCode,
            BillingEnabled = countryRow.BillingEnabled,
            ShippingEnabled = countryRow.ShippingEnabled,
            DisplayOrder = countryRow.DisplayOrder
        };
    }

    private StateModel ToStateModel(StateRow stateRow)
    {
        return new StateModel
        {
            Id = stateRow.Id,
            CountryCode = stateRow.CountryCode,
            Name = stateRow.Name,
            Code = stateRow.Code
        };
    }
}