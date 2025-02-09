using System.Globalization;
using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Environment.Shell.Scope;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Settings.Currencies;

public class CurrencyMigrations : DataMigration
{
    private readonly IContentDefinitionManager _definitionManager;

    private readonly IDictionary<string, string> _displayLocale = new Dictionary<string, string>
    {
        { "ps-AF", "" },
        { "sq-AL", "" },
        { "ar-DZ", "" },
        { "pt-AO", "" },
        { "es-AR", "" },
        { "hy-AM", "" },
        { "nl-AW", "" },
        { "en-AU", "" },
        { "az-Cyrl-AZ", "" },
        { "en-BS", "" },
        { "ar-BH", "" },
        { "bn-BD", "" },
        { "en-BB", "" },
        { "be-BY", "" },
        { "en-BZ", "" },
        { "en-BM", "" },
        { "dz-BT", "" },
        { "es-BO", "" },
        { "bs-Latn-BA", "" },
        { "en-BW", "" },
        { "pt-BR", "" },
        { "en-GB", "" },
        { "ms-BN", "" },
        { "bg-BG", "" },
        { "rn-BI", "" },
        { "km-KH", "" },
        { "en-CA", "" },
        { "en-KY", "" },
        { "pt-CV", "" },
        { "fr-CF", "" },
        { "fr-PF", "" },
        { "es-CL", "" },
        { "zh-Hans-CN", "" },
        { "es-CO", "" },
        { "fr-KM", "" },
        { "fr-CD", "" },
        { "es-CR", "" },
        { "hr-HR", "" },
        { "es-CU", "" },
        { "cs-CZ", "" },
        { "da-DK", "" },
        { "ar-DJ", "" },
        { "es-DO", "" },
        { "en-VC", "" },
        { "ar-EG", "" },
        { "ar-ER", "" },
        { "ti-ER", "" },
        { "aa-ET", "" },
        { "de-DE", "" },
        { "en-FK", "" },
        { "en-FJ", "" },
        { "en-GM", "" },
        { "ka-GE", "" },
        { "en-GH", "" },
        { "es-GT", "" },
        { "ff-Latn-GN", "" },
        { "en-GY", "" },
        { "fr-HT", "" },
        { "es-HN", "" },
        { "zh-Hant-HK", "" },
        { "hu-HU", "" },
        { "is-IS", "" },
        { "hi-IN", "" },
        { "id-ID", "" },
        { "fa-IR", "" },
        { "ar-IQ", "" },
        { "he-IL", "" },
        { "en-JM", "" },
        { "ja-JP", "" },
        { "ar-JO", "" },
        { "kk-KZ", "" },
        { "sw-KE", "" },
        { "ar-KW", "" },
        { "ky-KG", "" },
        { "lo-LA", "" },
        { "ar-LB", "" },
        { "en-LR", "" },
        { "ar-LY", "" },
        { "zh-Hant-MO", "" },
        { "mk-MK", "" },
        { "mg-MG", "" },
        { "en-MW", "" },
        { "ms-MY", "" },
        { "dv-MV", "" },
        { "ar-MR", "" },
        { "mfe-MU", "" },
        { "es-MX", "" },
        { "ro-MD", "" },
        { "mn-MN", "" },
        { "ar-MA", "" },
        { "pt-MZ", "" },
        { "my-MM", "" },
        { "naq-NA", "" },
        { "ne-NP", "" },
        { "nl-CW", "" },
        { "zh-Hant-TW", "" },
        { "en-NZ", "" },
        { "es-NI", "" },
        { "en-NG", "" },
        { "ko-KP", "" },
        { "nb-NO", "" },
        { "ar-OM", "" },
        { "ur-PK", "" },
        { "es-PA", "" },
        { "en-PG", "" },
        { "es-PY", "" },
        { "es-PE", "" },
        { "en-PH", "" },
        { "pl-PL", "" },
        { "ar-QA", "" },
        { "ro-RO", "" },
        { "ru-RU", "" },
        { "rw-RW", "" },
        { "en-WS", "" },
        { "pt-ST", "" },
        { "ar-SA", "" },
        { "sr-Latn-RS", "" },
        { "fr-SC", "" },
        { "ff-Latn-SL", "" },
        { "zh-Hans-SG", "" },
        { "en-SB", "" },
        { "ar-SO", "" },
        { "en-ZA", "" },
        { "ko-KR", "" },
        { "en-SS", "" },
        { "si-LK", "" },
        { "en-SH", "" },
        { "ar-SD", "" },
        { "nl-SR", "" },
        { "ss-SZ", "" },
        { "sv-SE", "" },
        { "de-CH", "" },
        { "syr-SY", "" },
        { "tg-TJ", "" },
        { "sw-TZ", "" },
        { "th-TH", "" },
        { "to-TO", "" },
        { "en-TT", "" },
        { "ar-TN", "" },
        { "tr-TR", "" },
        { "tk-TM", "" },
        { "en-UG", "" },
        { "uk-UA", "" },
        { "ar-AE", "" },
        { "es-UY", "" },
        { "en-US", "" },
        { "uz-Cyrl-UZ", "" },
        { "en-VU", "" },
        { "es-VE", "" },
        { "vi-VN", "" },
        { "fr-NE", "" },
        { "ar-YE", "" },
        { "en-ZM", "" }
    };

    public CurrencyMigrations(IContentDefinitionManager definitionManager)
    {
        _definitionManager = definitionManager;
    }

    public async Task<int> CreateAsync()
    {
        await _definitionManager
            .AlterPartDefinitionAsync(nameof(CurrencyPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a currency."));
        
        await _definitionManager
            .AlterTypeDefinitionAsync(ContentType.Currency, type => type
                .WithPart(nameof(CurrencyPart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<CurrencyIndex>(table => table
                .Column<string>(nameof(CurrencyIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(CurrencyIndex.EnglishName), column => column.NotNull().WithLength(100))
                .Column<string>(nameof(CurrencyIndex.NativeName), column => column.NotNull().WithLength(100))
                .Column<string>(nameof(CurrencyIndex.Symbol), column => column.NotNull().WithLength(10))
                .Column<string>(nameof(CurrencyIndex.Code), column => column.NotNull().WithLength(10))
                .Column<string>(nameof(CurrencyIndex.DisplayLocale), column => column.Nullable().WithLength(20))
                .Column<string>(nameof(CurrencyIndex.CustomFormatting), column => column.Nullable().WithLength(100))
                .Column<decimal>(nameof(CurrencyIndex.Rate), column => column.NotNull())
                .Column<bool>(nameof(CurrencyIndex.Enabled), column => column.NotNull())
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CurrencyIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CurrencyIndex)}_{nameof(CurrencyIndex.RowId)}",
                    nameof(CurrencyIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CurrencyIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CurrencyIndex)}_{nameof(CurrencyIndex.Code)}",
                    nameof(CurrencyIndex.Code),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }

    public int UpdateFrom2Async()
    {
        ShellScope.AddDeferredTask(async scope =>
        {
            var seeder = scope.ServiceProvider.GetRequiredService<ICurrencySeeder>();
            var rows = GetAllCurrencies();
            await seeder.CreateMany(rows);
        });

        return 3;
    }

    private IEnumerable<CurrencyRow> GetAllCurrencies()
    {
        var currencies = new List<CurrencyRow>();

        var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            .Where(x => x.EnglishName.Length > 0);

        foreach (var culture in cultures)
        {
            var region = new RegionInfo(culture.Name);
            if (_displayLocale.ContainsKey(culture.Name))
            {
                var currency = new CurrencyRow
                {
                    EnglishName = region.CurrencyEnglishName,
                    NativeName = region.CurrencyNativeName,
                    Symbol = region.CurrencySymbol,
                    Code = region.ISOCurrencySymbol,

                    // Note: use de-DE to add Euro, which needs custom formatting
                    DisplayLocale = culture.Name != "de-DE" ? culture.Name : null,
                    CustomFormatting = culture.Name != "de-DE" ? null : "€0.00",

                    Rate = 1m,
                    Enabled = true
                };

                currencies.Add(currency);
            }
        }

        return currencies;
    }
}