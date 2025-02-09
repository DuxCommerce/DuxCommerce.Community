using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Marketing.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Marketing.Coupons;

public class CouponIndex(
    string rowId,
    string name,
    string code,
    DateTime startTime,
    DateTime endTime,
    bool activated)
    : DuxIndex
{
    public sealed override string RowId { get; set; } = rowId;
    public string Name { get; set; } = name;
    public string Code { get; set; } = code;
    public DateTime StartTime { get; set; } = startTime;
    public DateTime EndTime { get; set; } = endTime;
    public bool Activated { get; set; } = activated;
}

public class CouponIndexProvider : IndexProvider<CouponPart>
{
    public override void Describe(DescribeContext<CouponPart> context)
    {
        context.For<CouponIndex>()
            .Map(x =>
            {
                var row = (CouponRow)x.Row;

                return new CouponIndex(
                    row.Id,
                    row.Name,
                    row.Code,
                    row.Rule.Time.StartTime,
                    row.Rule.Time.EndTime,
                    row.Activated);
            });
    }
}