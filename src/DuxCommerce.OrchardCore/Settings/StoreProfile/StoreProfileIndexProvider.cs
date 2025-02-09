using DuxCommerce.StoreBuilder.Settings.Constants;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Settings.StoreProfile;

public class StoreProfileIndexProvider : IndexProvider<StoreProfilePart>
{
    public override void Describe(DescribeContext<StoreProfilePart> context)
    {
        context.For<StoreSettingsIndex>()
            .Map(x =>
            {
                var row = (StoreProfileRow)x.Row;
                return new StoreSettingsIndex(row.Id, SettingNames.StoreProfile);
            });
    }
}