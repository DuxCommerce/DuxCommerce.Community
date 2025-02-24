using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "DuxCommerce.Storefront",
    Author = "DuxCommerce Team",
    Website = "https://DuxCommerce.com",
    Version = "1.1.0",
    Description = "DuxCommerce Storefront",
    Category = "Commerce",
    Dependencies =
    [
        "OrchardCore.Users",
        "OrchardCore.Contents",
        "OrchardCore.Email",
        "OrchardCore.ContentFields",
        "OrchardCore.Media",
        "OrchardCore.Autoroute"
    ]
)]