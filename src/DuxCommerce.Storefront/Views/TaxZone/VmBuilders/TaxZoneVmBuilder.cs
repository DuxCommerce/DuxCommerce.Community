using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Taxes.DataStores;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;
using DuxCommerce.StoreBuilder.Taxes.DomainTypes;
using DuxCommerce.StoreBuilder.Taxes.Requests;
using DuxCommerce.Storefront.Views.TaxZone.ViewModels;
using DuxCommerce.Storefront.Extensions;

namespace DuxCommerce.Storefront.Views.TaxZone.VmBuilders;

public class TaxZoneVmBuilder(
    ITaxZoneStore taxZoneStore,
    ICountryStore countryStore,
    IStateStore stateStore,
    ITaxCodeStore taxCodeStore)
{
    public async Task<TaxZoneIndexVm> BuildIndexModel()
    {
        var taxZones = await taxZoneStore.GetAll();

        return new TaxZoneIndexVm { Zones = taxZones };
    }

    public async Task<TaxZoneVm> BuildCreateZoneModel()
    {
        var model = new TaxZoneVm();

        PopulateZoneTypes(model);

        await PopulateCountries(model);

        return model;
    }

    public async Task<TaxZoneVm> BuildCreateZoneModel(TaxZoneVm model)
    {
        PopulateZoneTypes(model);

        await PopulateCountries(model);

        return model;
    }

    public async Task<TaxZoneVm> BuildEditZoneModel(string zoneId)
    {
        var zone = await taxZoneStore.Get(zoneId);

        var links = new TaxZoneLinks { ZoneId = zoneId, ZoneLink = true };
        var model = new TaxZoneVm { ZoneModel = ToTaxZoneModel(zone), Links = links };

        PopulateZoneTypes(model);

        await PopulateCountries(model);

        return model;
    }

    public async Task<TaxZoneVm> BuildEditZoneModel(TaxZoneVm model)
    {
        PopulateZoneTypes(model);

        await PopulateCountries(model);

        var links = new TaxZoneLinks { ZoneId = model.ZoneModel.Id, ZoneLink = true };
        model.Links = links;

        return model;
    }

    public async Task<TaxRatesVm> BuildTaxRatesModel(string zoneId)
    {
        var taxCodes = (await taxCodeStore.GetAll()).ToList();
        var taxZone = await taxZoneStore.Get(zoneId);

        return new TaxRatesVm
        {
            ZoneId = zoneId,
            TaxRates = taxZone.Rates?.ToList(),
            TaxCodes = taxCodes,
            Links = new TaxZoneLinks { ZoneId = zoneId, RatesLink = true }
        };
    }

    public async Task<TaxRateVm> BuildAddTaxRateModel(string zoneId)
    {
        var taxCodes = (await taxCodeStore.GetAll()).ToList();
        var taxRate = ToTaxRateModel(taxCodes);

        return new TaxRateVm
        {
            ZoneId = zoneId,
            RateModel = taxRate,
            TaxCodes = taxCodes,
            BreadCrumbs = new BreadCrumbs { ZoneId = zoneId }
        };
    }

    public async Task<TaxRateVm> BuildAddTaxRateModel(TaxRateVm model)
    {
        var taxCodes = (await taxCodeStore.GetAll()).ToList();
        model.TaxCodes = taxCodes;
        model.BreadCrumbs = new BreadCrumbs { ZoneId = model.ZoneId };

        return model;
    }

    public async Task<TaxRateVm> BuildEditTaxRateModel(string zoneId, string id)
    {
        var taxCodes = (await taxCodeStore.GetAll()).ToList();
        var taxRate = (await taxZoneStore.Get(zoneId)).Rates.Single(x => x.Id == id);

        var taxRateModel = ToTaxRateModel(taxRate, taxCodes);

        return new TaxRateVm
        {
            ZoneId = zoneId,
            RateModel = taxRateModel,
            TaxCodes = taxCodes,
            BreadCrumbs = new BreadCrumbs { ZoneId = zoneId }
        };
    }

    public async Task<TaxRateVm> BuildEditTaxRateModel(TaxRateVm model)
    {
        var taxCodes = (await taxCodeStore.GetAll()).ToList();
        model.TaxCodes = taxCodes;
        model.BreadCrumbs = new BreadCrumbs { ZoneId = model.ZoneId };

        return model;
    }

    private async Task PopulateCountries(TaxZoneVm model)
    {
        var countries = (await countryStore.GetEnabledCountries()).ToList();
        model.Countries = countries;

        var countryCodes = countries.Select(x => x.TwoLetterCode);
        var allStates = await stateStore.GetStates(countryCodes);

        model.States = allStates.GetStateMap();
    }

    private void PopulateZoneTypes(TaxZoneVm model)
    {
        var types = new List<TaxZoneTypeVm>
        {
            new() { Type = nameof(CountryZone), Name = "Tax zone based on countries" },
            new() { Type = nameof(StateZone), Name = "Tax zone based on states" },
            new() { Type = nameof(PostalCodeZone), Name = "Tax zone based on postal codes" }
        };

        model.ZoneTypes = types;
    }

    private static TaxZoneModel ToTaxZoneModel(TaxZoneRow zone)
    {
        return new TaxZoneModel
        {
            Id = zone.Id,
            Name = zone.Name,
            Type = zone.ZoneType,

            ZoneCountries = zone.ZoneCountries ?? [],

            ZoneStates = (zone.ZoneStates ?? [])
                .SelectMany(c => { return c.StateIds.Select(s => $"{c.CountryCode},{s}"); }),

            ZoneCountry = zone.ZonePostalCodes?.CountryCode,

            ZonePostalCodes = string.Join(',', zone.ZonePostalCodes?.PostalCodes ?? []),

            PricesDisplayOption = zone.PriceDisplayOption,
            ShowBothPricesOnListingPage = zone.ShowBothPricesOnListing,
            ShowBothPricesOnDetailPage = zone.ShowBothPricesOnDetails,

            Enabled = zone.Enabled
        };
    }

    private static TaxRateModel ToTaxRateModel(IEnumerable<TaxCodeRow> taxCodes)
    {
        var codeRates = taxCodes.Select(x => new TaxCodeRateRow { TaxCodeId = x.Id, Amount = 0m });

        return new TaxRateModel { Name = string.Empty, CodeRates = codeRates.ToArray() };
    }

    private static TaxRateModel ToTaxRateModel(TaxRateRow taxRate, List<TaxCodeRow> taxCodes)
    {
        var taxCodeRates = new List<TaxCodeRateRow>();

        foreach (var taxCode in taxCodes)
        {
            var codeRate = taxRate.CodeRates?.FirstOrDefault(x => x.TaxCodeId == taxCode.Id);

            taxCodeRates.Add(codeRate ?? new TaxCodeRateRow { TaxCodeId = taxCode.Id, Amount = 0m });
        }

        return new TaxRateModel
        {
            Id = taxRate.Id, Name = taxRate.Name,
            CodeRates = taxCodeRates.ToArray()
        };
    }
}