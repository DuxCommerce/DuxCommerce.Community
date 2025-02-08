using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Settings.DomainTypes;
using DuxCommerce.StoreBuilder.Settings.Requests;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.Storefront.Views.TaxProfile.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.TaxProfile.VmBuilders;

public class TaxProfileVmBuilder(
    ITaxProfileStore profileStore,
    ICountryStore countryStore,
    StateUseCases stateUseCases)
{
    public async Task<TaxProfileVm> BuildEditModel()
    {
        var model = await CreateModel();

        await PopulateAddress(model);

        PopulateTaxCalculationTypes(model);

        return model;
    }

    public async Task<TaxProfileVm> BuildEditModel(TaxProfileVm model)
    {
        await PopulateAddress(model);

        PopulateTaxCalculationTypes(model);

        return model;
    }

    private async Task<TaxProfileVm> CreateModel()
    {
        var profile = await profileStore.GetProfile();

        return new TaxProfileVm { ProfileModel = ToProfileModel(profile) };
    }

    private async Task PopulateAddress(TaxProfileVm model)
    {
        var countries = (await countryStore.GetEnabledCountries()).ToList();

        var countryCode = model.ProfileModel?.DefaultTaxAddress?.CountryCode ?? countries.First().TwoLetterCode;
        var states = await stateUseCases.GetStates(countryCode);

        model.Countries = countries.Select(x => new SelectListItem(x.Name, x.TwoLetterCode));
        model.States = states.Select(x => new SelectListItem(x.Name, x.Id));
    }

    private void PopulateTaxCalculationTypes(TaxProfileVm model)
    {
        var calcTypes = new List<TaxCalculationVm>
        {
            new()
            {
                CalcType = nameof(TaxCalculationType.BaseOnShippingAddress),
                CalcName = "Based on shipping address"
            },
            new()
            {
                CalcType = nameof(TaxCalculationType.BasedOnBillingAddress),
                CalcName = "Based on billing address"
            },
            new()
            {
                CalcType = nameof(TaxCalculationType.BaseOnShippingOrigin),
                CalcName = "Based on shipping origin"
            }
        };

        model.TaxCalculationTypes = calcTypes.Select(x => new SelectListItem(x.CalcName, x.CalcType));
    }

    private TaxProfileModel ToProfileModel(TaxProfileRow profile)
    {
        var taxAddressModel = ToTaxAddressModel(profile.DefaultTaxAddress);

        return new TaxProfileModel
        {
            Id = profile.Id,
            TaxCalculationType = profile.TaxCalculationType,
            PricesIncludeTax = profile.PricesIncludeTax,
            BreakdownTaxOnFrontEnd = profile.BreakdownTaxOnFrontEnd,
            BreakdownTaxOnBackEnd = profile.BreakdownTaxOnBackEnd,
            DefaultTaxAddress = taxAddressModel
        };
    }

    private TaxAddressModel ToTaxAddressModel(TaxAddressRow taxAddress)
    {
        return new TaxAddressModel
        {
            CountryCode = taxAddress.CountryCode,
            StateId = taxAddress.StateId,
            PostalCode = taxAddress.PostalCode
        };
    }
}