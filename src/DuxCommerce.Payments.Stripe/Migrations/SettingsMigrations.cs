using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Payments;
using DuxCommerce.Payments.Stripe.Models;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Environment.Shell.Scope;

namespace DuxCommerce.Payments.Stripe.Migrations;

public class SettingsMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(StripeSettingsPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into stripe settings."));
        
        await definitionManager
            .AlterTypeDefinitionAsync(StripeConstants.ContentType, type => type
                .WithPart(nameof(StripeSettingsPart)));
        
        return 1;
    }
    
    public int UpdateFrom1Async()
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