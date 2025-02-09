using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using ISO3166;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Environment.Shell.Scope;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Settings.Countries;

public class CountryMigrations : DataMigration
{
    private readonly IContentDefinitionManager _definitionManager;

    private readonly Dictionary<string, string> _enabledCountries = new()
    {
        { "AL", "" },
        { "AR", "" },
        { "AM", "" },
        { "AU", "" },
        { "AT", "" },
        { "AZ", "" },
        { "BD", "" },
        { "BY", "" },
        { "BE", "" },
        { "BR", "" },
        { "BG", "" },
        { "CA", "" },
        { "CL", "" },
        { "CN", "" },
        { "HR", "" },
        { "CZ", "" },
        { "DK", "" },
        { "EG", "" },
        { "FI", "" },
        { "FR", "" },
        { "DE", "" },
        { "GR", "" },
        { "HU", "" },
        { "IS", "" },
        { "IN", "" },
        { "ID", "" },
        { "IR", "" },
        { "IQ", "" },
        { "IE", "" },
        { "IL", "" },
        { "IT", "" },
        { "JP", "" },
        { "KR", "" },
        { "MY", "" },
        { "MX", "" },
        { "NL", "" },
        { "NO", "" },
        { "PK", "" },
        { "PE", "" },
        { "PH", "" },
        { "PL", "" },
        { "PT", "" },
        { "QA", "" },
        { "RO", "" },
        { "RU", "" },
        { "SA", "" },
        { "RS", "" },
        { "SG", "" },
        { "ZA", "" },
        { "ES", "" },
        { "LK", "" },
        { "SE", "" },
        { "CH", "" },
        { "TH", "" },
        { "TR", "" },
        { "UA", "" },
        { "AE", "" },
        { "GB", "" },
        { "US", "" },
        { "VN", "" },
        { "YE", "" }
    };

    public CountryMigrations(IContentDefinitionManager definitionManager)
    {
        _definitionManager = definitionManager;
    }

    public async Task<int> CreateAsync()
    {
        await _definitionManager
            .AlterPartDefinitionAsync(nameof(CountryPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a country."));
        
        await _definitionManager
            .AlterTypeDefinitionAsync(ContentType.Country, type => type
                .WithPart(nameof(CountryPart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<CountryIndex>(table => table
                .Column<string>(nameof(CountryIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(CountryIndex.Name), column => column.NotNull().WithLength(100))
                .Column<string>(nameof(CountryIndex.TwoLetterCode), column => column.NotNull().WithLength(2))
                .Column<bool>(nameof(CountryIndex.BillingEnabled), column => column.NotNull())
                .Column<bool>(nameof(CountryIndex.ShippingEnabled), column => column.NotNull())
                .Column<int>(nameof(CountryIndex.DisplayOrder), column => column.NotNull())
            );

        await SchemaBuilder
            .AlterIndexTableAsync<CountryIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(CountryIndex)}_{nameof(CountryIndex.RowId)}",
                    nameof(CountryIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }

    public int UpdateFrom2Async()
    {
        ShellScope.AddDeferredTask(async scope =>
        {
            var seeder = scope.ServiceProvider.GetRequiredService<ICountrySeeder>();
            var rows = Country.List.Select(x =>
            {
                var enabled = _enabledCountries.ContainsKey(x.TwoLetterCode);
                return new CountryRow
                {
                    Name = x.Name,
                    TwoLetterCode = x.TwoLetterCode,
                    ThreeLetterCode = x.ThreeLetterCode,
                    NumericCode = int.Parse(x.NumericCode),
                    BillingEnabled = enabled,
                    ShippingEnabled = enabled,
                    DisplayOrder = 1000
                };
            });
            await seeder.CreateMany(rows);
        });

        return 3;
    }
}