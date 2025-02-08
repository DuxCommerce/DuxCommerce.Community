using DuxCommerce.StoreBuilder.Plugins;
using DuxCommerce.Payments.PayPal.Components;
using DuxCommerce.Payments.PayPal.DataStores;
using DuxCommerce.Payments.PayPal.Indexes;
using DuxCommerce.Payments.PayPal.Migrations;
using DuxCommerce.Payments.PayPal.Models;
using DuxCommerce.Payments.PayPal.Services;
using DuxCommerce.Payments.PayPal.Views.Settings.ViewModels;
using DuxCommerce.Payments.PayPal.Views.Shared.Components.PayPalPayment;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using PayPalCheckoutSdk.Core;
using YesSql.Indexes;

namespace DuxCommerce.Payments.PayPal
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<PayPalSettingsPart>();
            services.AddScoped<IDataMigration, SettingsMigrations>();
            services.AddSingleton<IIndexProvider, SettingsIndexProvider>();

            services.AddTransient<PayPalHttpClient>();

            services.AddScoped<IPaymentMethod, PayPalPaymentMethod>();
            services.AddScoped<IPayPalSettingsStore, PayPalSettingsStore>();
            services.AddScoped<PayPalPaymentAdapter>();
            
            services.AddScoped<PayPalPaymentUseCases>();
            services.AddScoped<PayPalSettingsUseCases>();

            services.AddScoped<PayPalPaymentVmBuilder>();
            services.AddScoped<PayPalSettingsBuilder>();

            services.AddScoped<PayPalPaymentViewComponent>();            
        }
    }
}