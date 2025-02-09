using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Settings.Countries;

public class CountryIndex(
    string rowId,
    string name,
    string twoLetterCode,
    bool billingEnabled,
    bool shippingEnabled,
    int displayOrder)
    : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string Name { get; set; } = name;
    public string TwoLetterCode { get; } = twoLetterCode;
    public bool BillingEnabled { get; } = billingEnabled;
    public bool ShippingEnabled { get; } = shippingEnabled;
    public int DisplayOrder { get; } = displayOrder;
}

public class CountryIndexProvider : IndexProvider<CountryPart>
{
    public override void Describe(DescribeContext<CountryPart> context)
    {
        context.For<CountryIndex>()
            .Map(x =>
            {
                var row = (CountryRow)x.Row;

                return new CountryIndex(
                    row.Id, row.Name,
                    row.TwoLetterCode,
                    row.BillingEnabled,
                    row.ShippingEnabled,
                    row.DisplayOrder);
            });
    }
}