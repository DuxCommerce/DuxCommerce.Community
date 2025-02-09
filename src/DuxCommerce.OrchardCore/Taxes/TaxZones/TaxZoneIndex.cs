using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Taxes.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Taxes.TaxZones;

public class TaxZoneIndex(string rowId, string name) : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string Name { get; set; } = name;
}

public class TaxZoneIndexProvider : IndexProvider<TaxZonePart>
{
    public override void Describe(DescribeContext<TaxZonePart> context)
    {
        context.For<TaxZoneIndex>()
            .Map(x =>
            {
                var row = (TaxZoneRow)x.Row;

                return new TaxZoneIndex(row.Id, row.Name);
            });
    }
}