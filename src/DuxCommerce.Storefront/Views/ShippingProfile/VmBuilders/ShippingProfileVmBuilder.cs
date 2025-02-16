using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Shipping.DataStores;
using DuxCommerce.StoreBuilder.Shipping.Requests;
using DuxCommerce.StoreBuilder.Shipping.UseCases;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.Shared.VmBuilders;
using DuxCommerce.Storefront.Views.ShippingProfile.ViewModels;
using DuxCommerce.Storefront.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.ShippingProfile.VmBuilders;

public class ShippingProfileVmBuilder(
    ShippingProfileUseCases profileUseCases,
    IShippingProfileStore profileStore,
    IShippingOriginStore originStore,
    ICountryStore countryStore,
    IStateStore stateStore,
    AddressVmBuilder addressVmBuilder)
{
    public async Task<ShippingProfileVm> BuildIndexModel()
    {
        var profile = await profileStore.GetDefault();

        var model = new ShippingProfileVm { Profile = profile };

        await PopulateShippingOrigins(model);

        await PopulateCountries(model);

        return model;
    }

    public async Task<ShippingZoneVm> BuildCreateZoneModel(string groupId)
    {
        var zoneModel = new ShippingZoneModel
        {
            GroupId = groupId,
            CountryStates = new List<string>()
        };

        var model = new ShippingZoneVm { ZoneModel = zoneModel };

        await PopulateCountries(model);

        return model;
    }

    public async Task<ShippingZoneVm> BuildCreateZoneModel(ShippingZoneVm model)
    {
        await PopulateCountries(model);

        return model;
    }

    public async Task<ShippingZoneVm> BuildEditZoneModel(string groupId, string zoneId)
    {
        var profile = await profileStore.GetDefault();

        var zone = profile.OriginGroups
            .SelectMany(g => g.Zones)
            .Single(z => z.Id == zoneId);

        var countryStates = zone.States
            .SelectMany(c => { return c.StateIds.Select(s => $"{c.CountryCode},{s}"); })
            .ToList();

        var zoneModel = new ShippingZoneModel
        {
            GroupId = groupId,
            ZoneId = zone.Id,
            Name = zone.Name,
            CountryStates = countryStates
        };

        var model = new ShippingZoneVm
        {
            ZoneModel = zoneModel,
            Links = new ShippingZoneLinks { ZoneId = zone.Id, GroupId = groupId, ZoneLink = true }
        };


        await PopulateCountries(model);

        return model;
    }

    public async Task<ShippingZoneVm> BuildEditZoneModel(ShippingZoneVm model)
    {
        await PopulateCountries(model);

        model.Links = new ShippingZoneLinks
        {
            ZoneId = model.ZoneModel.ZoneId,
            GroupId = model.ZoneModel.GroupId,
            ZoneLink = true
        };

        return model;
    }

    public async Task<ShippingMethodsVm> BuildMethodsModel(string groupId, string zoneId)
    {
        var profile = await profileStore.GetDefault();

        var zone = profile.OriginGroups
            .SelectMany(g => g.Zones)
            .Single(z => z.Id == zoneId);

        return new ShippingMethodsVm
        {
            GroupId = groupId,
            ZoneId = zoneId,
            Methods = zone.Methods,
            Links = new ShippingZoneLinks { ZoneId = zone.Id, GroupId = groupId, MethodsLink = true }
        };
    }

    public AddShippingMethodVm BuildAddMethodModel(string groupId, string zoneId)
    {
        var methods = MethodTypes.GetAll();

        return new AddShippingMethodVm
        {
            MethodModel = new ShippingMethodModel { GroupId = groupId, ZoneId = zoneId },
            MethodTypes = methods.Select(x => new SelectListItem(x.Name, x.Type)),
            Links = new ShippingZoneLinks { GroupId = groupId, ZoneId = zoneId, MethodsLink = true }
        };
    }

    public AddShippingMethodVm BuildAddMethodModel(AddShippingMethodVm model)
    {
        var types = MethodTypes.GetAll();
        model.MethodTypes = types.Select(x => new SelectListItem(x.Name, x.Type));
        model.Links = new ShippingZoneLinks { GroupId = model.MethodModel.GroupId, ZoneId = model.MethodModel.ZoneId, MethodsLink = true };

        return model;
    }

    public async Task<ShippingMethodVm> BuildEditMethodModel(string groupId, string zoneId, string methodId)
    {
        var profile = await profileStore.GetDefault();

        var method = profile.OriginGroups
            .SelectMany(g => g.Zones)
            .SelectMany(z => z.Methods)
            .Single(m => m.Id == methodId);

        return new ShippingMethodVm
        {
            GroupId = groupId,
            ZoneId = zoneId,
            Method = method,
            Links = new ShippingZoneLinks { GroupId = groupId, ZoneId = zoneId, MethodsLink = true }
        };
    }

    public ShippingRateModel BuildAddRateModel(string groupId, string zoneId, string methodId)
    {
        return new ShippingRateModel
        {
            GroupId = groupId,
            ZoneId = zoneId,
            MethodId = methodId
        };
    }

    public async Task<ShippingRateModel> BuildEditRateModel(string groupId, string zoneId, string methodId,
        string rateId)
    {
        var rate = await profileUseCases.GetRate(rateId);

        return new ShippingRateModel
        {
            GroupId = groupId,
            ZoneId = zoneId,
            MethodId = methodId,
            RateId = rateId,
            Min = rate.Min,
            Max = rate.Max,
            Fee = rate.Fee
        };
    }

    public async Task<OriginAddressVm> BuildEditAddressModel(string originId)
    {
        var origin = await originStore.Get(originId);
        var addressVm = new AddressVm { Address = origin.Address };

        var countries = await countryStore.GetEnabledCountries();
        await addressVmBuilder.PopulateCountries(addressVm, countries.ToList());

        return new OriginAddressVm { OriginId = originId, AddressVm = addressVm };
    }

    public async Task<OriginAddressVm> BuildEditAddressModel(string originId, OriginAddressVm model)
    {
        var countries = await countryStore.GetEnabledCountries();
        await addressVmBuilder.PopulateCountries(model.AddressVm, countries.ToList());

        model.OriginId = originId;

        return model;
    }

    private async Task PopulateCountries(ShippingProfileVm model)
    {
        // Retrieving all countries in case some shipping countries might be disabled after shipping zones were created
        var countries = await countryStore.GetAll();

        model.Countries = countries.ToDictionary(x => x.TwoLetterCode, x => x);
    }

    private async Task PopulateCountries(ShippingZoneVm model)
    {
        var countries = (await countryStore.GetShippingCountries()).ToList();
        model.Countries = countries;

        var countryCodes = countries.Select(x => x.TwoLetterCode);
        var allStates = await stateStore.GetStates(countryCodes);

        model.AllStates = allStates.GetStateMap();
    }

    private async Task PopulateShippingOrigins(ShippingProfileVm model)
    {
        var originIds = model.Profile.OriginGroups.Select(x => x.OriginId);
        var origins = await originStore.GetMany(originIds);

        model.Origins = origins.ToDictionary(x => x.Id, x => x);
    }
}