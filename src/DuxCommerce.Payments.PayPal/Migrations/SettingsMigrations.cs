using System.Threading.Tasks;
using DuxCommerce.OrchardCore.Payments;
using DuxCommerce.Payments.PayPal.Models;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Environment.Shell.Scope;

namespace DuxCommerce.Payments.PayPal.Migrations;

public class SettingsMigrations : DataMigration
{
    private readonly IContentDefinitionManager _definitionManager;

    public SettingsMigrations(IContentDefinitionManager definitionManager) =>
        _definitionManager = definitionManager;

    public async Task<int> CreateAsync()
    {
        await _definitionManager
            .AlterPartDefinitionAsync(nameof(PayPalSettingsPart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into PayPal settings."));
        
        await _definitionManager
            .AlterTypeDefinitionAsync(PayPalConstants.ContentType, type => type
                .WithPart(nameof(PayPalSettingsPart)));
        
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