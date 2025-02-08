using DuxCommerce.OrchardCore.Payments;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Data.Migration;
using OrchardCore.Environment.Shell.Scope;

namespace DuxCommerce.Payments.Offline.Migrations;

public class SettingsMigrations : DataMigration
{
    public int Create()
    {
        ShellScope.AddDeferredTask(async scope =>
        {
            var repo = scope.ServiceProvider.GetRequiredService<IPaymentMethodSeeder>();
            var rows = PaymentMethodSeedData.GetMethods();
            await repo.CreateMany(rows);
        });

        return 2;
    }
}