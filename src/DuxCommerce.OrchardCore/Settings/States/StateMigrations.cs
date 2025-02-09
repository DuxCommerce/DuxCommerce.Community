using DuxCommerce.OrchardCore.Settings.StoreProfile;
using DuxCommerce.OrchardCore.Settings.TaxProfile;
using DuxCommerce.OrchardCore.Shared;
using DuxCommerce.StoreBuilder.Settings.DataStores;
using DuxCommerce.StoreBuilder.Settings.UseCases;
using DuxCommerce.StoreBuilder.Shipping.UseCases;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Environment.Shell.Scope;
using YesSql.Sql;

namespace DuxCommerce.OrchardCore.Settings.States;

public class StateMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(StatePart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into a state."));
        
        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.State, type => type
                .WithPart(nameof(StatePart)));

        return 1;
    }

    public async Task<int> UpdateFrom1Async()
    {
        await SchemaBuilder
            .CreateMapIndexTableAsync<StateIndex>(table => table
                .Column<string>(nameof(StateIndex.RowId), column => column.NotNull().WithLength(26))
                .Column<string>(nameof(StateIndex.CountryCode), column => column.NotNull().WithLength(2))
                .Column<string>(nameof(StateIndex.Name), column => column.NotNull().WithLength(50))
                .Column<string>(nameof(StateIndex.Code), column => column.Nullable().WithLength(10))
            );

        await SchemaBuilder
            .AlterIndexTableAsync<StateIndex>(table => table
                .CreateIndex(
                    $"IDX_{nameof(StateIndex)}_{nameof(StateIndex.RowId)}",
                    nameof(StateIndex.RowId),
                    nameof(DuxDocument.DocumentId))
            );

        return 2;
    }

    public int UpdateFrom2Async()
    {
        ShellScope.AddDeferredTask(async scope =>
        {
            var repo = scope.ServiceProvider.GetRequiredService<IStateSeeder>();
            var rows = StateSeedData.GetStates();
            await repo.CreateMany(rows);
        });

        return 3;
    }

    // Note: we create store profile here because we need to make sure states are created first
    public int UpdateFrom3Async()
    {
        ShellScope.AddDeferredTask(async scope =>
        {
            var stateStore = scope.ServiceProvider.GetRequiredService<IStateStore>();

            var states = await stateStore.GetStates("US");
            var state = states.Single(x => x.Code == "WA");

            var profileUseCases = scope.ServiceProvider.GetRequiredService<StoreProfileUseCases>();
            var profileRow = StoreProfileSeedData.CreateProfile(state);
            await profileUseCases.CreateProfile(profileRow);
        });

        return 4;
    }

    // Note: we create tax profiles here because we need to make sure states are created first
    public int UpdateFrom4Async()
    {
        ShellScope.AddDeferredTask(async scope =>
        {
            var stateStore = scope.ServiceProvider.GetRequiredService<IStateStore>();

            var states = await stateStore.GetStates("US");
            var state = states.Single(x => x.Code == "WA");

            var profileUseCases = scope.ServiceProvider.GetRequiredService<TaxProfileUseCases>();
            var profileRow = TaxProfileSeedData.CreateProfile(state);

            await profileUseCases.CreateProfile(profileRow);
        });

        return 5;
    }
}