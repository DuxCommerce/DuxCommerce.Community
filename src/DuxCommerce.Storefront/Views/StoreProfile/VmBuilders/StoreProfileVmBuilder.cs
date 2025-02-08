using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.Shared.VmBuilders;
using DuxCommerce.Storefront.Views.StoreProfile.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.StoreProfile.VmBuilders;

public class StoreProfileVmBuilder(
    ICurrencyStore currencyStore,
    IStoreProfileStore profileStore,
    ICountryStore countryStore,
    AddressVmBuilder addressVmBuilder)
{
    public async Task<StoreProfileVm> BuildEditModel()
    {
        var model = await CreateModel();

        await PopulateAddress(model);

        PopulateUnitSystems(model);

        PopulateTimeZones(model);

        await PopulateCurrencies(model);

        return model;
    }

    public async Task<StoreProfileVm> BuildEditModel(StoreProfileVm model)
    {
        await PopulateAddress(model);

        PopulateUnitSystems(model);

        PopulateTimeZones(model);

        await PopulateCurrencies(model);

        return model;
    }

    private async Task PopulateCurrencies(StoreProfileVm model)
    {
        var currencies = (await currencyStore.GetAll()).OrderBy(x => x.EnglishName);
        model.Currencies = currencies.Select(x => new SelectListItem(x.EnglishName, x.Code));
    }

    private void PopulateTimeZones(StoreProfileVm model)
    {
        var timeZones = TimeZoneInfo.GetSystemTimeZones();
        model.TimeZones = timeZones.Select(x => new SelectListItem(x.DisplayName, x.Id));
    }

    private void PopulateUnitSystems(StoreProfileVm model)
    {
        var unitSystems = new List<UnitSystemVm> { new ImperialSystemVm(), new MetricSystemVm() };
        model.UnitSystems = unitSystems.Select(x => new SelectListItem(x.SystemName, x.SystemId));

        var systemId = model.Profile.UnitSystem;

        if (string.IsNullOrEmpty(systemId))
            systemId = unitSystems.First().SystemId;

        var system = unitSystems.Single(x => x.SystemId == systemId);
        model.WeightUnits = system.GetWeightUnits().Select(x => new SelectListItem(x.Name, x.Id));
        model.LengthUnits = system.GetLengthUnits().Select(x => new SelectListItem(x.Name, x.Id));
    }

    private async Task PopulateAddress(StoreProfileVm model)
    {
        var addressVm = new AddressVm { Address = model.Profile?.Address };
        var countries = (await countryStore.GetAll()).ToList();

        await addressVmBuilder.PopulateCountries(addressVm, countries);

        model.AddressVm = addressVm;
    }

    private async Task<StoreProfileVm> CreateModel()
    {
        var profile = await profileStore.GetProfile();

        return new StoreProfileVm { Profile = profile };
    }
}