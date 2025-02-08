using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Settings.StoreProfile;
using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.Payments.Stripe.Models;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.Payments.Stripe.DataStores;

public interface IStripeSettingsStore
{
    Task<string> CreateOrUpdate(StripeSettingsRow row);
    Task<StripeSettingsRow> GetSettings();
}

public class StripeSettingsStore(ISession session, IIdGenerator generator)
    : PartStore(session, generator), IStripeSettingsStore
{
    public async Task<string> CreateOrUpdate(StripeSettingsRow row)
    {
        if (string.IsNullOrEmpty(row.Id))
        {
            return await Create<StripeSettingsPart, StripeSettingsRow>(row);
        }

        await Update<StripeSettingsPart, StripeSettingsRow, StoreSettingsIndex>(row);

        return row.Id;
    }

    public async Task<StripeSettingsRow> GetSettings()
    {
        var part = await Session
            .Query<StripeSettingsPart, StoreSettingsIndex>(x => x.Name == StripeConstants.SettingsName)
            .FirstOrDefaultAsync();

        if (part == null)
            return NewSettings();

        return (StripeSettingsRow)part.Row;
    }

    private static StripeSettingsRow NewSettings()
    {
        return new StripeSettingsRow
        {
            Id = "",
            IsTestMode = true,
            PublishableKey = "",
            SecretKey = "",
            WebhookSecret = ""
        };
    }
}