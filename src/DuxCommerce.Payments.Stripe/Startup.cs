using DuxCommerce.StoreBuilder.Plugins;
using DuxCommerce.Payments.Stripe.Components;
using DuxCommerce.Payments.Stripe.DataStores;
using DuxCommerce.Payments.Stripe.Indexes;
using DuxCommerce.Payments.Stripe.Migrations;
using DuxCommerce.Payments.Stripe.Models;
using DuxCommerce.Payments.Stripe.Services;
using DuxCommerce.Payments.Stripe.Views.Settings.ViewModels;
using DuxCommerce.Payments.Stripe.Views.Shared.Components.StripePayment;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.ResourceManagement;
using Stripe;
using YesSql.Indexes;

namespace DuxCommerce.Payments.Stripe
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagement>();
            services.AddContentPart<StripeSettingsPart>();
            services.AddScoped<IDataMigration, SettingsMigrations>();
            services.AddSingleton<IIndexProvider, SettingsIndexProvider>();
            
            services.AddSingleton<PaymentIntentService>();

            services.AddScoped<IPaymentMethod, StripePaymentMethod>();
            services.AddScoped<IStripeSettingsStore, StripeSettingsStore>();
            services.AddScoped<StripePaymentAdapter>();
            
            services.AddScoped<StripePaymentUseCases>();
            services.AddScoped<StripeSettingsUseCases>();

            services.AddScoped<StripePaymentVmBuilder>();
            services.AddScoped<StripeSettingsBuilder>();

            services.AddScoped<StripePaymentViewComponent>();
        }
    }
}