using DuxCommerce.OrchardCore.Settings.StoreProfile;
using DuxCommerce.Payments.PayPal.Models;
using YesSql.Indexes;

namespace DuxCommerce.Payments.PayPal.Indexes;

public class SettingsIndexProvider : IndexProvider<PayPalSettingsPart>
{
    public override void Describe(DescribeContext<PayPalSettingsPart> context)
    {
        context.For<StoreSettingsIndex>()
            .Map(x =>
            {
                var row = (PayPalSettingsRow)x.Row;
                return new StoreSettingsIndex(row.Id, PayPalConstants.SettingsName);
            });
    }
}