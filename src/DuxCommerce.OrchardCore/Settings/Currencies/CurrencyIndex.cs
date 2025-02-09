using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Settings.Currencies;

public class CurrencyIndex(
    string rowId,
    string englishName,
    string nativeName,
    string symbol,
    string code,
    string displayLocale,
    string customFormatting,
    decimal rate,
    bool enabled)
    : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string EnglishName { get; set; } = englishName;
    public string NativeName { get; set; } = nativeName;
    public string Symbol { get; set; } = symbol;
    public string Code { get; set; } = code;
    public string DisplayLocale { get; set; } = displayLocale;
    public string CustomFormatting { get; set; } = customFormatting;
    public decimal Rate { get; set; } = rate;
    public bool Enabled { get; set; } = enabled;
}

public class CurrencyIndexProvider : IndexProvider<CurrencyPart>
{
    public override void Describe(DescribeContext<CurrencyPart> context)
    {
        context.For<CurrencyIndex>()
            .Map(x =>
            {
                var row = (CurrencyRow)x.Row;

                return new CurrencyIndex(
                    row.Id,
                    row.EnglishName,
                    row.NativeName,
                    row.Symbol,
                    row.Code,
                    row.DisplayLocale,
                    row.CustomFormatting,
                    row.Rate,
                    row.Enabled);
            });
    }
}