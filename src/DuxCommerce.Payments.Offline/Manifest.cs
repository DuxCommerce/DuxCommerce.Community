using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "DuxCommerce.Payments.Offline",
    Author = "DuxCommerce Team",
    Website = "https://DuxCommerce.com",
    Version = "1.1.0",
    Description = "Offline payment methods for DuxCommerce",
    Category = "Commerce",
    Dependencies =
    [
        "OrchardCore.ContentTypes",
        "OrchardCore.Admin"
    ]
)]
