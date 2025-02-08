using DuxCommerce.StoreBuilder.Plugins;
using DuxCommerce.Payments.Offline.Components;
using DuxCommerce.Payments.Offline.Migrations;
using DuxCommerce.Payments.Offline.Views.Settings.ViewModels;
using DuxCommerce.Payments.Offline.Views.Shared.Components.OfflinePayment;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace DuxCommerce.Payments.Offline
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDataMigration, SettingsMigrations>();

            services.AddScoped<IPaymentMethod, BankDepositPaymentMethod>();
            services.AddScoped<IPaymentMethod, MoneyOrderPaymentMethod>();
            services.AddScoped<IPaymentMethod, CheckPaymentMethod>();
            services.AddScoped<IPaymentMethod, CashOnDeliveryPaymentMethod>();
            services.AddScoped<IPaymentMethod, PayInStorePaymentMethod>();

            services.AddScoped<OfflineSettingsBuilder>();
            services.AddScoped<OfflinePaymentVmBuilder>();

            services.AddScoped<OfflinePaymentViewComponent>();            
        }
    }
}