using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Payments.DataTypes;
using YesSql;
using IIdGenerator = OrchardCore.Entities.IIdGenerator;

namespace DuxCommerce.OrchardCore.Payments;

public interface IPaymentMethodSeeder
{
    Task CreateMany(IEnumerable<PaymentMethodRow> rows);
}

public class PaymentMethodSeeder(
    ISession session,
    IIdGenerator generator) : DataSeeder(session, generator), IPaymentMethodSeeder
{
    public async Task CreateMany(IEnumerable<PaymentMethodRow> rows)
    {
        await CreateMany<PaymentMethodPart, PaymentMethodRow>(rows);
    }
}