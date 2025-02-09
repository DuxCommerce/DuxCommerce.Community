using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;
using static DuxCommerce.OrchardCore.ResourceNames;

namespace DuxCommerce.OrchardCore;

public static class ResourceNames
{
    public const string JQuery = "jQuery";

    public const string StoreStyles = nameof(StoreStyles);

    public const string Popup = nameof(Popup);
    public const string MultiSelect = nameof(MultiSelect);
    public const string FlatPicker = nameof(FlatPicker);
    public const string Trumbowyg = nameof(Trumbowyg);
}

public class ResourceManagement : IConfigureOptions<ResourceManagementOptions>
{
    private static readonly ResourceManifest Manifest = new();

    static ResourceManagement()
    {
        DefineStyles();
        DefineScripts();
    }

    public void Configure(ResourceManagementOptions options)
    {
        options.ResourceManifests.Add(Manifest);
    }

    private static void DefineStyles()
    {
        Manifest
            .DefineStyle(StoreStyles)
            .SetUrl("~/DuxCommerce.Storefront/css/store.css")
            .SetVersion("1.0.0");

        Manifest
            .DefineStyle(MultiSelect)
            .SetUrl("~/DuxCommerce.Storefront/css/multiselect.css")
            .SetVersion("1.0.0");

        Manifest
            .DefineStyle(FlatPicker)
            .SetCdn("https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css")
            .SetVersion("1.0.0");

        Manifest
            .DefineStyle(Trumbowyg)
            .SetCdn("https://cdn.jsdelivr.net/npm/trumbowyg@2.28.0/dist/trumbowyg.min.js")
            .SetVersion("1.0.0");
    }

    private static void DefineScripts()
    {
        Manifest
            .DefineScript(Popup)
            .SetUrl("~/DuxCommerce.Storefront/js/popup.js")
            .SetVersion("1.0.0");

        Manifest
            .DefineScript(MultiSelect)
            .SetDependencies(JQuery)
            .SetUrl("~/DuxCommerce.Storefront/js/multiselect.js")
            .SetVersion("1.0.0");

        Manifest
            .DefineScript(FlatPicker)
            .SetUrl("https://cdn.jsdelivr.net/npm/flatpickr")
            .SetVersion("1.0.0");

        Manifest
            .DefineScript(Trumbowyg)
            .SetDependencies(JQuery)
            .SetUrl("https://cdn.jsdelivr.net/npm/trumbowyg@2.28.0/dist/trumbowyg.min.js")
            .SetVersion("2.27.3");
    }
}