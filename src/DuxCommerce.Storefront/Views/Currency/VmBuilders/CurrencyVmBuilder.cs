using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using DuxCommerce.StoreBuilder.Settings.Requests;
using DuxCommerce.Storefront.Views.Currency.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Currency.VmBuilders;

public class CurrencyVmBuilder(ICurrencyStore currencyStore)
{
    public async Task<CurrencyIndexVm> BuildIndexModel()
    {
        var currencies = await currencyStore.GetAll();

        return new CurrencyIndexVm { Currencies = currencies.OrderBy(x => x.EnglishName) };
    }

    public CurrencyVm BuildCreateModel()
    {
        return new CurrencyVm
        {
            CurrencyModel = new CurrencyModel(),
            Locales = GetLocales()
        };
    }

    public CurrencyVm BuildCreateModel(CurrencyVm model)
    {
        model.Locales = GetLocales();

        return model;
    }

    public async Task<CurrencyVm> BuildEditModel(string currencyId)
    {
        var currencyRow = await currencyStore.Get(currencyId);

        var model = ToCurrencyModel(currencyRow);
        var locales = GetLocales();

        return new CurrencyVm { CurrencyModel = model, Locales = locales };
    }

    public CurrencyVm BuildEditModel(CurrencyVm model)
    {
        model.Locales = GetLocales();

        return model;
    }

    private CurrencyModel ToCurrencyModel(CurrencyRow currencyRow)
    {
        return new CurrencyModel
        {
            Id = currencyRow.Id,
            EnglishName = currencyRow.EnglishName,
            NativeName = currencyRow.NativeName,
            Symbol = currencyRow.Symbol,
            Code = currencyRow.Code,
            DisplayLocale = currencyRow.DisplayLocale,
            CustomFormatting = currencyRow.CustomFormatting
        };
    }

    private IEnumerable<SelectListItem> GetLocales()
    {
        var locales = new List<SelectListItem>();

        locales.Add(new SelectListItem("Select a locale", string.Empty));

        var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            .Where(x => x.EnglishName.Length > 0)
            .OrderBy(x => x.EnglishName);

        foreach (var culture in cultures)
        {
            var name = $"{culture.EnglishName} {culture.Name}";
            var locale = new SelectListItem(name, culture.Name);

            locales.Add(locale);
        }

        return locales;
    }
}