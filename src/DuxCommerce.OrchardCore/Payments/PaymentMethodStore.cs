using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Payments.DataStores;
using DuxCommerce.StoreBuilder.Payments.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Payments;

public class PaymentMethodStore(ISession session, IIdGenerator generator)
    : PartStore(session, generator), IPaymentMethodStore
{
    public async Task<string> Create(PaymentMethodRow row)
    {
        return await base.Create<PaymentMethodPart, PaymentMethodRow>(row);
    }

    public async Task<PaymentMethodRow> Get(string id)
    {
        return await base.Get<PaymentMethodPart, PaymentMethodRow, PaymentMethodIndex>(id);
    }

    public async Task<PaymentMethodRow> GetMethod(string methodType)
    {
        var part = await Session
            .Query<PaymentMethodPart, PaymentMethodIndex>(x => x.MethodType == methodType)
            .FirstOrDefaultAsync();

        return part.Row;
    }

    public async Task<IEnumerable<PaymentMethodRow>> GetAll()
    {
        return await base.GetAll<PaymentMethodRow, PaymentMethodPart>();
    }

    public async Task<IEnumerable<PaymentMethodRow>> GetEnabled()
    {
        var parts = await Session
            .Query<PaymentMethodPart, PaymentMethodIndex>(index => index.Enabled)
            .ListAsync();

        return parts.Select(x => x.Row).OrderBy(x => x.DisplayOrder);
    }

    public async Task<bool> Update(PaymentMethodRow row)
    {
        return await base.Update<PaymentMethodPart, PaymentMethodRow, PaymentMethodIndex>(row);
    }
}