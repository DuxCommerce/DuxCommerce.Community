using DuxCommerce.OrchardCore.Settings.StoreProfile;
using DuxCommerce.StoreBuilder.Settings.Constants;
using DuxCommerce.StoreBuilder.Settings.DataTypes;
using YesSql.Indexes;

namespace DuxCommerce.OrchardCore.Settings.TaxProfile;

public class TaxProfileIndexProvider : IndexProvider<TaxProfilePart>
{
    public override void Describe(DescribeContext<TaxProfilePart> context)
    {
        context.For<StoreSettingsIndex>()
            .Map(x =>
            {
                var row = (TaxProfileRow)x.Row;
                return new StoreSettingsIndex(row.Id, SettingNames.TaxProfile);
            });
    }
}