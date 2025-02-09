using DuxCommerce.OrchardCore.Shared;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace DuxCommerce.OrchardCore.Settings.TaxProfile;

public class TaxProfileMigrations(IContentDefinitionManager definitionManager) : DataMigration
{
    public async Task<int> CreateAsync()
    {
        await definitionManager
            .AlterPartDefinitionAsync(nameof(TaxProfilePart), builder => builder
                .Attachable()
                .WithDescription("Makes a content item into tax profile."));

        await definitionManager
            .AlterTypeDefinitionAsync(ContentType.TaxProfile, type => type
                .WithPart(nameof(TaxProfilePart)));

        return 1;
    }
}