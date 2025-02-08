using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Settings.StoreProfile;
using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.Payments.PayPal.Models;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.Payments.PayPal.DataStores;

public interface IPayPalSettingsStore
{
    Task<string> CreateOrUpdate(PayPalSettingsRow row);
    Task<PayPalSettingsRow> GetSettings();
}

public class PayPalSettingsStore(ISession session, IIdGenerator generator)
    : PartStore(session, generator), IPayPalSettingsStore
{
    public async Task<string> CreateOrUpdate(PayPalSettingsRow row)
    {
        if (string.IsNullOrEmpty(row.Id))
            return await Create<PayPalSettingsPart, PayPalSettingsRow>(row);

        await Update<PayPalSettingsPart, PayPalSettingsRow, StoreSettingsIndex>(row);

        return row.Id;
    }

    public async Task<PayPalSettingsRow> GetSettings()
    {
        var part = await Session
            .Query<PayPalSettingsPart, StoreSettingsIndex>(x => x.Name == PayPalConstants.SettingsName)
            .FirstOrDefaultAsync();

        if (part == null)
            return NewSettings();

        return part.Row;
    }

    private static PayPalSettingsRow NewSettings()
    {
        return new PayPalSettingsRow
        {
            Id = "",
            IsTestMode = true,
            ClientId = "",
            Secret = ""
        };
    }
}