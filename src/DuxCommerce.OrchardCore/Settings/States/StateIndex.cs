using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Settings.States;

public class StateIndex(string rowId, string countryCode, string name, string code)
    : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string CountryCode { get; set; } = countryCode;
    public string Name { get; set; } = name;
    public string Code { get; set; } = code;
}

public class StateIndexProvider : IndexProvider<StatePart>
{
    public override void Describe(DescribeContext<StatePart> context)
    {
        context.For<StateIndex>()
            .Map(x =>
            {
                var row = (StateRow)x.Row;

                return new StateIndex(row.Id, row.CountryCode, row.Name, row.Code);
            });
    }
}