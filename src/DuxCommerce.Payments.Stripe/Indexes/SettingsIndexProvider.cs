using DuxCommerce.OrchardCore.Settings.StoreProfile;
using DuxCommerce.Payments.Stripe.Models;
using YesSql.Indexes;

namespace DuxCommerce.Payments.Stripe.Indexes;

public class SettingsIndexProvider : IndexProvider<StripeSettingsPart>
{
    public override void Describe(DescribeContext<StripeSettingsPart> context)
    {
        context.For<StoreSettingsIndex>()
            .Map(x =>
            {
                var row = (StripeSettingsRow)x.Row;
                return new StoreSettingsIndex(row.Id, StripeConstants.SettingsName);
            });
    }
}