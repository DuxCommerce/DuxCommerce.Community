using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Marketing.Promotions;

public class PromotionIndex(
    string rowId,
    string name,
    DateTime startTime,
    DateTime endTime,
    bool activated)
    : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string Name { get; set; } = name;
    public DateTime StartTime { get; set; } = startTime;
    public DateTime EndTime { get; set; } = endTime;
    public bool Activated { get; set; } = activated;
}

public class PromotionIndexProvider : IndexProvider<PromotionPart>
{
    public override void Describe(DescribeContext<PromotionPart> context)
    {
        context.For<PromotionIndex>()
            .Map(x =>
            {
                var row = (PromotionRow)x.Row;

                return new PromotionIndex(
                    row.Id,
                    row.Name,
                    row.Rule.Time.StartTime,
                    row.Rule.Time.EndTime,
                    row.Activated);
            });
    }
}